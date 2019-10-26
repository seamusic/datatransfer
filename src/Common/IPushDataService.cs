

namespace Daan.DataTransfer.DataCommon
{
    public interface IPushDataService
    {
        /// <summary>
        /// ���߷�������ʼ��������,�Ѵ������ݵ� action id , �����ֽܷ���֪ͨ������
        /// �÷����������ڴ�ȴ�����
        /// </summary>
        /// <param name="info"></param>
        void Begin(DataInfo info);

        void Push(DataSegment segment);
        DataResult End(string dataid, bool abandon);
    }
}