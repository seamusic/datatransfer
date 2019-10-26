using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Daan.DataTransfer.DataCommon;
using Daan.DataTransfer.Utility;
using org.phprpc;

namespace Daan.DataTransfer.Client
{
    public class PhpRpcClient
    {
        private int dataLength = 1024 * 1024;

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataResult PullData(DataParameter parameter)
        {
            LogHelper.Debug(GetType(), "准备获取数据", LogInfo.ObjectToMessage(parameter));

            var success = true;
            var result = new DataResult();
            var crchash = new CrcHash();

            PHPRPC_Client client = new PHPRPC_Client("http://localhost:4631/PullData.aspx");
            IPullDataService pullDataService = (IPullDataService)client.UseService(typeof(IPullDataService));  
            //var pullDataService = AppCtx.Resolve<IPullDataService>("PullService");

            //初始化异常
            if (pullDataService == null)
            {
                LogHelper.Debug(GetType(), "获取接口失败");
                return null;
            }


            #region 开始请求
            var beginParameter = new DataParameter();
            beginParameter.Action = parameter.Action;
            LogHelper.Debug(GetType(), "发送请求", LogInfo.ObjectToMessage(beginParameter));
            var beginDataInfo = pullDataService.Begin(beginParameter);
            if (beginDataInfo == null)
            {
                success = false;
                result.ErrorId = (int)DataDictionary.ErrorType.DataPullBeginError;
                result.ErrorMessage = "";
                return result;
            }
            else
            {
                result.Action = parameter.Action;
                result.SplitCount = beginDataInfo.SpliteCount;
            }
            #endregion


            #region 请求数据
            //初始化容器以收集字符串
            var sb = new StringBuilder(beginDataInfo.SpliteCount * dataLength);

            LogHelper.Debug(GetType(), "开始请求具体数据");
            for (int i = 0; i < beginDataInfo.SpliteCount; i++)
            {
                //请求数据
                //todo:需优化，以重新请求超时未能请求到的数据
                //var tcs = new TaskCompletionSource<DataSegment>();
                //WaitCallback asyncWork = _ =>
                //{
                    var dataSegment = pullDataService.Pull(beginDataInfo.DataId, i);
                    if (dataSegment == null)
                    {
                        //tcs.SetResult(null);
                    }
                    else
                    {
                        LogHelper.Debug(GetType(), string.Format("获取索引为{0}的数据:", i),
                                        LogInfo.ObjectToMessage(dataSegment));

                        var stream = StreamHeandler.StringToStream(dataSegment.DataString);
                        dataSegment = !crchash.Hash(stream, dataSegment.Crccode)
                                          ? null
                                          : dataSegment;
                    }
                //        tcs.SetResult(dataSegment);
                //    }
                //};
                //ThreadPool.QueueUserWorkItem(asyncWork);
                //var task = tcs.Task;
                //var taskResult = task.Result;
                if (dataSegment != null)
                {
                    sb.Insert(i * dataLength, dataSegment.DataString);
                }
                else
                {
                    result.ErrorId = (int)DataDictionary.ErrorType.DataPullError;
                    result.ErrorMessage = "";
                    success = false;
                    break;
                }
            }
            #endregion

            #region 结束请求
            var endData = pullDataService.End(beginDataInfo.DataId, !success);
            LogHelper.Debug(GetType(), "结束请求数据", LogInfo.ObjectToMessage(endData));
            if (endData == null)
            {
                result.ErrorId = (int)DataDictionary.ErrorType.DataPullEndError;
                result.ErrorMessage = "";
                success = false;
            }
            #endregion

            if (success)
            {
                var stream = StreamHeandler.StringToStream(sb.ToString());
                var base64 = Base64Convert.FrmBase64(stream);
                LogHelper.Debug(GetType(), "解压请求到的数据");
                var unZipStream = ZipCompress.UnCompress(base64);
                result.CrcCode = crchash.GetHashCode(unZipStream);
                LogHelper.Debug(GetType(), "生成校验码", result.CrcCode);
                result.DataString = StreamHeandler.StreamToString(unZipStream);
                //返回
            }

            return result;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataResult PushData(DataParameter parameter)
        {
            LogHelper.Debug(GetType(), "准备发送数据", LogInfo.ObjectToMessage(parameter));


            PHPRPC_Client client = new PHPRPC_Client("http://localhost:4631/PullData.aspx");
            IPushDataService pushDataService = (IPushDataService)client.UseService(typeof(IPushDataService));  
            //var pushDataService = AppCtx.Resolve<IPushDataService>("PushService");

            //初始化异常
            if (pushDataService == null)
            {
                LogHelper.Warn(GetType(), "获取接口失败");
                return null;
            }

            var success = true;
            var result = new DataResult();
            var beginDataInfo = new DataInfo();
            var crchash = new CrcHash();

            result.DataId = Guid.NewGuid().ToString();
            result.Action = parameter.Action;
            result.CrcCode = parameter.CrcCode;
            result.DataString = parameter.DataString;

            var stream = StreamHeandler.StringToStream(parameter.DataString);
            var zipStream = ZipCompress.Compress(stream);
            var base64 = Base64Convert.ToBase64(zipStream);
            var sb = new StringBuilder(StreamHeandler.StreamToString(base64));
            var count = (int)Math.Ceiling(sb.Length / (double)dataLength);

            result.SplitCount = count;

            #region 准备发送数据
            beginDataInfo.ActionId = parameter.Action;
            beginDataInfo.DataId = result.DataId;
            beginDataInfo.SpliteCount = count;

            LogHelper.Debug(GetType(), "开始请求发送数据", LogInfo.ObjectToMessage(beginDataInfo));
            pushDataService.Begin(beginDataInfo);
            #endregion

            #region 发送数据
            LogHelper.Debug(GetType(), "开始发送数据");
            for (int i = 0; i < count; i++)
            {
                var tcs = new TaskCompletionSource<bool>();
                WaitCallback asyncWork = _ =>
                {
                    var beginPos = i * dataLength;
                    var legth = i == count - 1 ? sb.Length - beginPos : dataLength;
                    var data = sb.ToString(beginPos, legth);

                    var dataSegment = new DataSegment();
                    dataSegment.DataId = result.DataId;
                    dataSegment.Crccode = crchash.GetHashCode(StreamHeandler.StringToStream(data));
                    dataSegment.DataString = data;
                    dataSegment.Index = i;
                    LogHelper.Debug(GetType(), string.Format("发送数据，ID：{0}，索引：{1}", result.DataId, i), LogInfo.ObjectToMessage(dataSegment));
                    pushDataService.Push(dataSegment);

                    tcs.SetResult(true);
                };
                ThreadPool.QueueUserWorkItem(asyncWork);

                var task = tcs.Task;
                var taskResult = task.Result;
                if (!taskResult)
                {
                    success = false;
                    break;
                }
            }
            #endregion

            #region 发送完成
            var endResult = pushDataService.End(beginDataInfo.DataId, !success);
            LogHelper.Debug(GetType(), "发送数据完成");

            if (endResult == null)
            {
                success = false;
            }
            #endregion

            return result;
        }
    }
}
