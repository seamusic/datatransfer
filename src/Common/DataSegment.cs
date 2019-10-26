using System;

namespace Daan.DataTransfer.DataCommon
{

    /// <summary>
    /// 数据分段对象， 用于上传，下载分段处理
    /// </summary>
    [Serializable]
    public class DataSegment
    {
        public string DataId { get; set; }
        public string DataString { get; set; }
        public int Index { get; set; }
        public string Crccode { get; set; }
    }
}