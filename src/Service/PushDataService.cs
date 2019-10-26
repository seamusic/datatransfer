using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.Services.Protocols;
using Daan.DataTransfer.DataCommon;
using Daan.DataTransfer.DataCommon.Caching;
using Daan.DataTransfer.Utility;

namespace Daan.DataTransfer.Services
{
    public class PushDataService : IPushDataService
    {
        private int dataLength = SystemParameter.DataLength;
        private ICache cache = new AspnetCache();
        private string actionID = string.Empty;

        private const string DataKey = "PushData";
        private const string ContentKey = "Content";

        /// <summary>
        /// 告诉服务器开始传递数据,把传递数据的 action id , 数据总分节数通知服务器
        /// 让服务器开辟内存等待处理
        /// </summary>
        /// <param name="info"></param>
        public void Begin(DataInfo info)
        {
            if (!AuthenticationHelper.AuthServiceHeader())
            {
                LogHelper.Debug(GetType(), "权限校验不通过");
                throw new SoapHeaderException();
            }

            LogHelper.Debug(GetType(), "开始推送数据", LogInfo.ObjectToMessage(info));
            if (cache == null)
            {
                cache = new AspnetCache(actionID);
            }

            actionID = info.DataId;
            cache.Add(DataKey, info);
        }

        public void Push(DataSegment segment)
        {
            if (!AuthenticationHelper.AuthServiceHeader())
            {
                LogHelper.Debug(GetType(), "权限校验不通过");
                throw new SoapHeaderException();
            }

            LogHelper.Debug(GetType(), "推送数据", LogInfo.ObjectToMessage(segment));
            if (cache == null)
            {
                cache = new AspnetCache(actionID);
            }

            var processFactory = new DataProcessFactory();
            if (processFactory.CheckDataSegment(segment))
            {
                cache.Add(string.Format("{0}.{1}", segment.DataId, segment.Index), segment.DataString);
            }
        }

        public DataResult End(string dataid, bool abandon)
        {
            if (!AuthenticationHelper.AuthServiceHeader())
            {
                LogHelper.Debug(GetType(), "权限校验不通过");
                return null;
            }

            LogHelper.Debug(GetType(), string.Format("推送数据结束，数据ID为：{0}，是否取消：{1}", dataid, abandon));
            if (abandon)
            {
                return null;
            }

            if (cache == null)
            {
                cache = new AspnetCache(actionID);
            }

            var processFactory = new DataProcessFactory();

            var dataInfo = cache.Get<DataInfo>(DataKey);
            var dataResult = new DataResult();
            var datalength = dataLength * dataInfo.SpliteCount;
            var sb = new StringBuilder(datalength);
            var success = true;

            for (int i = 0; i < dataInfo.SpliteCount; i++)
            {
                var data = cache.Get<string>(string.Format("{0}.{1}", dataid, i));
                if (string.IsNullOrEmpty(data))
                {
                    success = false;
                    break;
                }
                else
                {
                    sb.Append(data);
                }
            }

            if (success)
            {
                //解压
                var content = processFactory.ProcessToObject<string>(sb.ToString());

                var handler = AppCtx.Resolve<IDataHandler>(actionID);

                if (! handler.Validation(0, int.Parse(actionID)))
                {
                    //TODO: 无法通过校验，不进行处理    
                }

               // handler.ProcessData<object>()


                //todo:推送完成

                #region 把内容写下来
                var fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".log");
                FileStream fs = new FileStream(fileName, FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                streamWriter.Write(content);
                streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture));
                streamWriter.Flush();
                streamWriter.Close();
                FileInfo fileInfo = new FileInfo(fileName);
                LogHelper.Debug(GetType(), string.Format("保存成文件，路径为：{0}", fileInfo.FullName), LogInfo.ObjectToMessage(fileInfo));
                #endregion

                dataResult.DataId = dataInfo.DataId;
                dataResult.Action = dataInfo.ActionId;
                cache.Add(ContentKey, dataResult);

                cache.Clear();
                cache = null;
                return dataResult;
            }
            else
            {

                cache.Clear();
                cache = null;
                return null;
            }
        }
    }
}