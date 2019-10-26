

namespace Daan.DataTransfer.DataCommon
{
    public interface IPullDataService
    {
        DataInfo Begin(DataParameter parameter);
        DataSegment Pull(string dataid, int index);
        DataResult End(string dataid, bool abandon);
    }
}