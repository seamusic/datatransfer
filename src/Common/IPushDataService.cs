

namespace Daan.DataTransfer.DataCommon
{
    public interface IPushDataService
    {
        /// <summary>
        /// 告诉服务器开始传递数据,把传递数据的 action id , 数据总分节数通知服务器
        /// 让服务器开辟内存等待处理
        /// </summary>
        /// <param name="info"></param>
        void Begin(DataInfo info);

        void Push(DataSegment segment);
        DataResult End(string dataid, bool abandon);
    }
}