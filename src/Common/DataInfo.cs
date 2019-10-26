using System;

namespace Daan.DataTransfer.DataCommon
{
    /// <summary>
    /// 传送下载数据头信息
    /// </summary>
    [Serializable]
    public class DataInfo
    {
        public string DataId { get; set; }
        public int SpliteCount { get; set; }
        public int ActionId { get; set; }
    }
}