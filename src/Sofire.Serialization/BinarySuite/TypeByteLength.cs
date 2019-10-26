using System;
using System.Collections.Generic;
using System.Text;

namespace Sofire.Serialization.BinarySuite
{
    internal static class TypeByteLength
    {
        public const int Guid = 16;
        public const int Boolean = 1;

        public const int Single = 4;
        public const int Double = 8;

        public const int Int16 = 2;
        public const int Int32 = 4;
        public const int Int64 = 8;
        public const int UInt16 = 2;
        public const int UInt32 = 4;
        public const int UInt64 = 8;

        public const int Char = 2;

    }
}
