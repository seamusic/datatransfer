using System;
using System.Collections.Generic;
using System.Text;

namespace Sofire.Serialization.BinarySuite
{
    internal enum BinaryTag : byte
    {
        Reference,
        Null,
        DBNull,

        Guid,
        GuidArray,
        DateTime,
        DateTimeArray,

        Boolean,
        BooleanArray,

        Byte,
        ByteArray,
        SByte,
        SByteArray,

        Char,
        CharArray,
        String,
        StringArray,

        Int16,
        Int16Array,
        Int32,
        Int32Array,
        Int64,
        Int64Array,

        UInt16,
        UInt16Array,
        UInt32,
        UInt32Array,
        UInt64,
        UInt64Array,

        Single,
        SingleArray,
        Double,
        DoubleArray,
        Decimal,
        DecimalArray,

        Array,
        StringBuilder,
        StringBuilderArray,

        GList,
        GDictionary,

        Object,
    }
}
