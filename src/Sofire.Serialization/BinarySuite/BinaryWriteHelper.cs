using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace Sofire.Serialization.BinarySuite
{
    internal class BinaryWriteHelper : BinaryHelperBase
    {
        public BinaryWriteHelper(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
            if(!stream.CanWrite) throw new NotSupportedException("无法写入数据。");
        }

        public void Write(object value)
        {
            if(value == null) this.WriteNull();
            else if(value is DBNull) this.WriteDBNull();

            else if(value is Guid) this.WriteGuid((Guid)value);
            else if(value is DateTime) this.WriteDateTime((DateTime)value);
            else if(value is Boolean) this.WriteBoolean((Boolean)value);
            else if(value is Byte) this.WriteByte((Byte)value);
            else if(value is SByte) this.WriteSByte((SByte)value);
            else if(value is Char) this.WriteChar((Char)value);
            else if(value is Single) this.WriteSingle((Single)value);
            else if(value is Double) this.WriteDouble((Double)value);
            else if(value is Decimal) this.WriteDecimal((Decimal)value);
            else if(value is Int16) this.WriteInt16((Int16)value);
            else if(value is Int32) this.WriteInt32((Int32)value);
            else if(value is Int64) this.WriteInt64((Int64)value);
            else if(value is UInt16) this.WriteUInt16((UInt16)value);
            else if(value is UInt32) this.WriteUInt32((UInt32)value);
            else if(value is UInt64) this.WriteUInt64((UInt64)value);

            else if(this.TryWriteReference(value)) return;

            else if(value is String) this.WriteString((String)value);
            else if(value is String[]) this.WriteString((String[])value);
            else if(value is Guid[]) this.WriteGuid((Guid[])value);
            else if(value is DateTime[]) this.WriteDateTime((DateTime[])value);
            else if(value is Boolean[]) this.WriteBoolean((Boolean[])value);
            else if(value is Byte[]) this.WriteByte((Byte[])value);
            else if(value is SByte[]) this.WriteSByte((SByte[])value);
            else if(value is Char[]) this.WriteChar((Char[])value);
            else if(value is Single[]) this.WriteSingle((Single[])value);
            else if(value is Double[]) this.WriteDouble((Double[])value);
            else if(value is Decimal[]) this.WriteDecimal((Decimal[])value);
            else if(value is Int16[]) this.WriteInt16((Int16[])value);
            else if(value is Int32[]) this.WriteInt32((Int32[])value);
            else if(value is Int64[]) this.WriteInt64((Int64[])value);
            else if(value is UInt16[]) this.WriteUInt16((UInt16[])value);
            else if(value is UInt32[]) this.WriteUInt32((UInt32[])value);
            else if(value is UInt64[]) this.WriteUInt64((UInt64[])value);
            else if(value is StringBuilder) this.WriteStringBuilder((StringBuilder)value);
            else if(value is Enum) this.Write(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), null));
            else if(value is Array) this.WriteArray(value as Array);

            else
            {
                // 无需判断可空类型 is 将识别可空类型
                var valueType = value.GetType();

                if(valueType.IsGenericType)
                {
                    var defineType = valueType.GetGenericTypeDefinition();
                    if(Types.GList == defineType)
                    {
                        this.WriteGList(value, valueType);
                    }
                    else if(Types.GDictionary == defineType)
                    {
                        this.WriteGDictionary(value, valueType);
                    }
                    else this.WriteObject(value);
                }
                else
                {
                    this.WriteObject(value);
                }
            }
        }

        #region InnerWrite

        private void InnerWrite(byte value)
        {
            this._Stream.WriteByte(value);
        }

        private void InnerWrite(byte[] buffer)
        {
            this._Stream.Write(buffer, 0, buffer.Length);
        }

        private void InnerWrite(BinaryTag tag)
        {
            this._Stream.WriteByte((byte)tag);
        }

        private void InnerWrite(BinaryTag tag, byte[] buffer)
        {
            this.InnerWrite(tag);
            this.InnerWrite(buffer);
        }

        private void InnerWrite(Decimal value)
        {
            var bits = Decimal.GetBits(value);
            this.InnerWrite(BitConverter.GetBytes(bits[0]));
            this.InnerWrite(BitConverter.GetBytes(bits[1]));
            this.InnerWrite(BitConverter.GetBytes(bits[2]));
            this.InnerWrite(BitConverter.GetBytes(bits[3]));
        }

        private void InnerWrite(Array array, Type elementType)
        {
            int rank = array.Rank;
            int i, j;
            int[,] des = new int[rank, 2];
            int[] loc = new int[rank];

            //- 写入维数
            this.InnerWrite(BitConverter.GetBytes(rank));
            //- 写入维数长度
            for(i = 0 ; i < rank ; i++)
            {
                this.InnerWrite(BitConverter.GetBytes(array.GetLength(i)));
            }

            //- 写入元素
            //- 设置每一个 数组维 的上下标。
            for(i = 0 ; i < rank ; i++)
            {
                j = array.GetLowerBound(i);//- 上标
                des[i, 0] = j;
                des[i, 1] = array.GetUpperBound(i);  //- 下标
                loc[i] = j;
            }
            i = rank - 1;
            while(loc[0] <= des[0, 1])
            {
                this.Write(array.GetValue(loc));
                loc[i]++;
                for(j = rank - 1 ; j > 0 ; j--)
                {
                    if(loc[j] > des[j, 1])
                    {
                        loc[j] = des[j, 0];
                        loc[j - 1]++;
                    }
                }
            }
        }

        private void InnerWrite(ICollection collection, Type arrayType)
        {
            object[] keyArray = new object[collection.Count];
            collection.CopyTo(keyArray, 0);
            this.InnerWrite(keyArray, arrayType);
        }

        #endregion

        #region Reference Write

        //private readonly Dictionary<object, int> ReferenceContainer = new Dictionary<object, int>(1024);
        private readonly List<object> reference = new List<object>(111);

        private bool TryWriteReference(object value)
        {
            var refObjectID = reference.IndexOf(value);
            if(refObjectID < 0)
            {
                reference.Add(value);
                return false;
            }

            this.InnerWrite(BinaryTag.Reference);
            this.InnerWrite(BitConverter.GetBytes(refObjectID));
            return true;

            //int refObjectID;
            //if(this.ReferenceContainer.TryGetValue(value, out refObjectID))
            //{
            //    this.InnerWrite(BinaryTag.Reference);
            //    this.InnerWrite(BitConverter.GetBytes(refObjectID));
            //    return true;
            //}
            //this.ReferenceContainer.Add(value, ReferenceContainer.Count);
            //return false;
        }

        private void WriteReferenceString(string value)
        {
            if(this.TryWriteReference(value)) return;
            this.WriteString(value);
        }

        #endregion

        #region Boolean DateTime Guid Null DBNull

        public void WriteNull()
        {
            this._Stream.WriteByte((byte)BinaryTag.Null);
        }

        public void WriteDBNull()
        {
            this._Stream.WriteByte((byte)BinaryTag.DBNull);
        }

        public void WriteGuid(Guid value)
        {
            this.InnerWrite(BinaryTag.Guid, value.ToByteArray());
        }

        public void WriteGuid(Guid[] value)
        {
            this.InnerWrite(BinaryTag.GuidArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(v.ToByteArray());
            }
        }

        public void WriteDateTime(DateTime value)
        {
            this.InnerWrite(BinaryTag.DateTime, BitConverter.GetBytes(value.ToOADate()));
        }

        public void WriteDateTime(DateTime[] value)
        {
            this.InnerWrite(BinaryTag.DateTimeArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v.ToOADate()));
            }
        }

        public void WriteBoolean(Boolean value)
        {
            this.InnerWrite(BinaryTag.Boolean, BitConverter.GetBytes(value));
        }

        public void WriteBoolean(Boolean[] value)
        {
            this.InnerWrite(BinaryTag.BooleanArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v));
            }
        }

        #endregion

        #region Bytes

        public void WriteByte(Byte value)
        {
            this.InnerWrite(BinaryTag.Byte);
            this.InnerWrite(value);
        }

        public void WriteByte(Byte[] value)
        {
            this.InnerWrite(BinaryTag.ByteArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            this.InnerWrite(value);
        }

        public void WriteSByte(SByte value)
        {
            this.InnerWrite(BinaryTag.SByte);
            this.InnerWrite((byte)value);
        }

        public void WriteSByte(SByte[] value)
        {
            this.InnerWrite(BinaryTag.SByteArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this._Stream.WriteByte((byte)v);
            }
        }

        #endregion

        #region Single Double Decimal

        public void WriteSingle(Single value)
        {
            this.InnerWrite(BinaryTag.Single, BitConverter.GetBytes(value));
        }

        public void WriteSingle(Single[] value)
        {
            this.InnerWrite(BinaryTag.SingleArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v));
            }
        }

        public void WriteDouble(Double value)
        {
            this.InnerWrite(BinaryTag.Double, BitConverter.GetBytes(value));
        }

        public void WriteDouble(Double[] value)
        {
            this.InnerWrite(BinaryTag.DoubleArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v));
            }
        }

        public void WriteDecimal(Decimal value)
        {
            this.InnerWrite(BinaryTag.Decimal);
            this.InnerWrite(value);
        }

        public void WriteDecimal(Decimal[] value)
        {
            this.InnerWrite(BinaryTag.DecimalArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(v);
            }
        }

        #endregion

        #region Int

        public void WriteInt16(Int16 value)
        {
            this.InnerWrite(BinaryTag.Int16, BitConverter.GetBytes(value));
        }

        public void WriteInt16(Int16[] value)
        {
            this.InnerWrite(BinaryTag.Int16Array);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v));
            }
        }

        public void WriteInt32(Int32 value)
        {
            this.InnerWrite(BinaryTag.Int32, BitConverter.GetBytes(value));
        }

        public void WriteInt32(Int32[] value)
        {
            this.InnerWrite(BinaryTag.Int32Array);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v));
            }
        }

        public void WriteInt64(Int64 value)
        {
            this.InnerWrite(BinaryTag.Int64, BitConverter.GetBytes(value));
        }

        public void WriteInt64(Int64[] value)
        {
            this.InnerWrite(BinaryTag.Int64Array);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v));
            }
        }

        public void WriteUInt16(UInt16 value)
        {
            this.InnerWrite(BinaryTag.UInt16, BitConverter.GetBytes(value));
        }

        public void WriteUInt16(UInt16[] value)
        {
            this.InnerWrite(BinaryTag.UInt16Array);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v));
            }
        }

        public void WriteUInt32(UInt32 value)
        {
            this.InnerWrite(BinaryTag.UInt32, BitConverter.GetBytes(value));
        }

        public void WriteUInt32(UInt32[] value)
        {
            this.InnerWrite(BinaryTag.UInt32Array);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v));
            }
        }

        public void WriteUInt64(UInt64 value)
        {
            this.InnerWrite(BinaryTag.UInt64, BitConverter.GetBytes(value));
        }

        public void WriteUInt64(UInt64[] value)
        {
            this.InnerWrite(BinaryTag.UInt64Array);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.InnerWrite(BitConverter.GetBytes(v));
            }
        }

        #endregion

        #region Char String StringBuilder

        public void WriteChar(Char value)
        {
            this.InnerWrite(BinaryTag.Char, BitConverter.GetBytes(value));
        }

        public void WriteChar(Char[] value)
        {
            this.InnerWrite(BinaryTag.CharArray);
            var bytes = this._Encoding.GetBytes(value);
            this.InnerWrite(BitConverter.GetBytes(bytes.Length));
            this.InnerWrite(bytes);
        }

        public void WriteString(String value)
        {
            this.InnerWrite(BinaryTag.String);
            if(value == null) this.InnerWrite(BitConverter.GetBytes(-1));
            else if(value.Length == 0) this.InnerWrite(BitConverter.GetBytes(0));
            else
            {
                var bytes = this._Encoding.GetBytes(value);
                this.InnerWrite(BitConverter.GetBytes(bytes.Length));
                this.InnerWrite(bytes);
            }
        }

        public void WriteString(String[] value)
        {
            this.InnerWrite(BinaryTag.StringArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.WriteReferenceString(v);
            }
        }

        public void WriteStringBuilder(StringBuilder value)
        {
            this.InnerWrite(BinaryTag.StringBuilder);
            this.WriteReferenceString(value.ToString());
        }

        public void WriteStringBuilder(StringBuilder[] value)
        {
            this.InnerWrite(BinaryTag.StringBuilderArray);
            this.InnerWrite(BitConverter.GetBytes(value.Length));
            foreach(var v in value)
            {
                this.WriteReferenceString(v == null ? null : v.ToString());
            }
        }

        #endregion

        #region GList GDictionary Array Object

        public void WriteGList(object value, Type valueType)
        {
            this.InnerWrite(BinaryTag.GList);
            var elemenType = valueType.GetGenericArguments()[0];
            this.WriteReferenceString(SerializationHelper.SimplifyQualifiedName(elemenType));
            this.InnerWrite(value as ICollection, elemenType);
        }

        public void WriteGDictionary(object value, Type type)
        {
            this.InnerWrite(BinaryTag.GDictionary);

            IDictionary dict = value as IDictionary;
            var genericArguments = type.GetGenericArguments();
            var keyType = genericArguments[0];
            var valueType = genericArguments[1];

            //- 写入类型
            this.WriteReferenceString(SerializationHelper.SimplifyQualifiedName(keyType));
            this.WriteReferenceString(SerializationHelper.SimplifyQualifiedName(valueType));

            this.InnerWrite(dict.Keys, keyType);
            this.InnerWrite(dict.Values, valueType);
        }

        public void WriteArray(Array value)
        {
            this.InnerWrite(BinaryTag.Array);
            var elementType = value.GetType().GetElementType();
            //- 写入类型
            this.WriteReferenceString(SerializationHelper.SimplifyQualifiedName(elementType));
            this.InnerWrite(value, elementType);
        }

        public void WriteObject(object value)
        {
            this.InnerWrite(BinaryTag.Object);

            var type = value.GetType();

            this.WriteReferenceString(SerializationHelper.SimplifyQualifiedName(type));

            SerializableFieldInfo[] fields = SerializationHelper.GetSerializableMembers(type);
            var fieldCount = fields.Length;
            this.InnerWrite(BitConverter.GetBytes(fieldCount));

            SerializableFieldInfo fieldInfo;
            for(var i = 0 ; i < fieldCount ; i++)
            {
                fieldInfo = fields[i];
                this.InnerWrite(BitConverter.GetBytes(fieldInfo.NameHashCode));
                //this.WriteReferenceString(fieldInfo.Name);
                var fieldValue = fieldInfo.GetValue(value);
                this.Write(fieldValue);
            }
        }

        #endregion
    }
}
