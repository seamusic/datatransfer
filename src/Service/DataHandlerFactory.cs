using System;
using System.Diagnostics;
using Daan.DataTransfer.DataCommon;
using Daan.DataTransfer.Utility;

namespace Daan.DataTransfer.Services
{
    internal class DataHandlerFactory
    {
       
        public IDataHandler CreateHandler(int version, int actionid )
        {
            try
            {
                var result = AppCtx.Resolve<IDataHandler>(actionid.ToString());
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(GetType(), LogInfo.TraceToMessage(new StackTrace(true)) ,e );
            }
            return null;
        }

    }
}