



using System;
using System.Text;
using Daan.DataTransfer.DataCommon;
using Daan.DataTransfer.DataCommon.Caching;

namespace Daan.DataTransfer.Services
{
    public class PullDataService : IPullDataService
    {
        private int dataLength = SystemParameter.DataLength;
        private ICache cache = new AspnetCache();
        private string actionID = string.Empty;
        private const string DataKey = "PullData";
        private const string DataCountKey = "DataCount";

        #region Implementation of IPullDataService

        /// <summary>
        /// 开始拉数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataInfo Begin(DataParameter parameter)
        {
            if (!AuthenticationHelper.AuthServiceHeader())
            {
                LogHelper.Debug(GetType(), "权限校验不通过");
                return null;
            }

            LogHelper.Debug(GetType(), "开始准备数据" + LogInfo.ObjectToMessage(parameter));
            var dataInfo = new DataInfo();
            actionID = Guid.NewGuid().ToString();

            dataInfo.ActionId = parameter.Action;
            dataInfo.DataId = actionID;

            cache = new AspnetCache(actionID);

            //todo:根据action取得字符串
            var test = @"Testtest";

            var processFactory = new DataProcessFactory();
            var data = processFactory.ProcessToString(test);
            var dataCount = (int)Math.Ceiling(data.Length / (double)dataLength);

            //存于缓存中
            cache.Add(DataKey, data);
            cache.Add(DataCountKey, dataCount);
            dataInfo.SpliteCount = dataCount;

            return dataInfo;
        }

        /// <summary>
        /// 拉数据
        /// </summary>
        /// <param name="dataid"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataSegment Pull(string dataid, int index)
        {
            if (!AuthenticationHelper.AuthServiceHeader())
            {
                LogHelper.Debug(GetType(), "权限校验不通过");
                return null;
            }

            LogHelper.Debug(GetType(), string.Format("数据ID：{0}，索引：{1}", dataid, index), "拉数据");
            if (cache == null)
            {
                cache = new AspnetCache(actionID);
            }

            var dataCount = cache.Get<int>(DataCountKey);
            var content = cache.Get<string>(DataKey);
            var processFactory = new DataProcessFactory();
            var dataSegment = processFactory.BuildDataSegment(index, dataid, dataLength, dataCount, content);

            return dataSegment;
        }

        /// <summary>
        /// 终止
        /// </summary>
        /// <param name="dataid"></param>
        /// <param name="abandon"></param>
        /// <returns></returns>
        public DataResult End(string dataid, bool abandon)
        {
            if (!AuthenticationHelper.AuthServiceHeader())
            {
                LogHelper.Debug(GetType(), "权限校验不通过");
                return null;
            }

            LogHelper.Debug(GetType(), string.Format("拉数据结束，数据ID：{0}，是否取消：{1}", dataid, abandon), "拉数据结束");
            if (abandon)
            {
                return null;
            }

            if (cache == null)
            {
                cache = new AspnetCache(actionID);
            }

            var dataCount = cache.Get<int>(DataCountKey);
            var dataResult = new DataResult();
            dataResult.DataId = dataid;
            dataResult.SplitCount = dataCount;

            //清理缓存中的东西
            cache.Clear();
            cache = null;

            return dataResult;
        }

        #endregion
    }
}