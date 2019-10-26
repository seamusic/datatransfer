using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Daan.DataTransfer.DataCommon
{
    public abstract class DataProcessBase
    {
        public abstract byte[] Process(byte[] data);
        public abstract byte[] DeProcess(byte[] data);
        //public abstract void Add(DataProcessBase item);
        //public abstract void Remove(DataProcessBase item);
    }
}
