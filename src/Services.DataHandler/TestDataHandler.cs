using Daan.DataTransfer.DataCommon;

namespace Daan.DataTransfer.Services.DataHandler
{
    public class TestDataHandler: IDataHandler 
    {
        #region Implementation of IDataHandler

        public bool Validation(int version, int actionid)
        {
            throw new System.NotImplementedException();
        }

        public TResult ProcessData<TResult, TParam>(TParam parameter)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
