using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sofire.Serialization.BinarySuite
{
    internal class BinaryHelperBase
    {
        protected Stream _Stream;
        protected Encoding _Encoding;

        public BinaryHelperBase(Stream stream, Encoding encoding)
        {
            if(stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            this._Stream = stream;
            this._Encoding = encoding ?? Encoding.UTF8;
        }
    }
}
