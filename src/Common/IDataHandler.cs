namespace Daan.DataTransfer.DataCommon
{
    public interface IDataHandler
    {
        bool Validation(int version, int actionid);
        TResult ProcessData<TResult,TParam>( TParam parameter);

    }
}