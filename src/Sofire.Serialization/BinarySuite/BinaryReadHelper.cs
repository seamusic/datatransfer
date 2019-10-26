using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Collections;

namespace Sofire.Serialization.BinarySuite
{
    internal class BinaryReadHelper : BinaryHelperBase
    {
        public BinaryReadHelper(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
            if(!stream.CanRead) throw new NotSupportedException("无法读取数据。");
        }

        private readonly List<object> ReferenceContainer = new List<object>(111);

        public object Read()
        {
            object value; int index;
            var tag = ((BinaryTag)this._Stream.ReadByte());
            switch(tag)
            {
                case BinaryTag.Reference:
                    index = this.ReadInt32();
                    return this.ReferenceContainer[index];
                case BinaryTag.Null:
                    return null;
                case BinaryTag.DBNull:
                    return DBNull.Value;
                case BinaryTag.Guid:
                    return this.ReadGuid();
                case BinaryTag.DateTime:
                    return this.ReadDateTime();
                case BinaryTag.Boolean:
                    return this.ReadBoolean();
                case BinaryTag.Byte:
                    return this.ReadByte();
                case BinaryTag.SByte:
                    return this.ReadSByte();
                case BinaryTag.Char:
                    return this.ReadChar();
                case BinaryTag.Int16:
                    return this.ReadInt16();
                case BinaryTag.Int32:
                    return this.ReadInt32();
                case BinaryTag.Int64:
                    return this.ReadInt64();
                case BinaryTag.UInt16:
                    return this.ReadUInt16();
                case BinaryTag.UInt32:
                    return this.ReadUInt32();
                case BinaryTag.UInt64:
                    return this.ReadUInt64();
                case BinaryTag.Single:
                    return this.ReadSingle();
                case BinaryTag.Double:
                    return this.ReadDouble();
                case BinaryTag.Decimal:
                    return this.ReadDecimal();
            }

            index = this.ReferenceContainer.Count;
            this.ReferenceContainer.Add(null);
            switch(tag)
            {
                case BinaryTag.GuidArray:
                    value = this.ReadGuidArray();
                    break;
                case BinaryTag.DateTimeArray:
                    value = this.ReadDateTimeArray();
                    break;
                case BinaryTag.BooleanArray:
                    value = this.ReadBooleanArray();
                    break;
                case BinaryTag.ByteArray:
                    value = this.ReadByteArray();
                    break;
                case BinaryTag.SByteArray:
                    value = this.ReadSByteArray();
                    break;
                case BinaryTag.CharArray:
                    value = this.ReadCharArray();
                    break;
                case BinaryTag.Int16Array:
                    value = this.ReadInt16Array();
                    break;
                case BinaryTag.Int32Array:
                    value = this.ReadInt32Array();
                    break;
                case BinaryTag.Int64Array:
                    value = this.ReadInt64Array();
                    break;
                case BinaryTag.UInt16Array:
                    value = this.ReadUInt16Array();
                    break;
                case BinaryTag.UInt32Array:
                    value = this.ReadUInt32Array();
                    break;
                case BinaryTag.UInt64Array:
                    value = this.ReadUInt64Array();
                    break;
                case BinaryTag.SingleArray:
                    value = this.ReadSingleArray();
                    break;
                case BinaryTag.DoubleArray:
                    value = this.ReadDoubleArray();
                    break;
                case BinaryTag.DecimalArray:
                    value = this.ReadDecimalArray();
                    break;

                case BinaryTag.String:
                    value = this.ReadString();
                    break;
                case BinaryTag.StringArray:
                    value = this.ReadStringArray();
                    break;
                case BinaryTag.StringBuilder:
                    value = this.ReadStringBuilder();
                    break;
                case BinaryTag.StringBuilderArray:
                    value = this.ReadStringBuilderArray();
                    break;
                case BinaryTag.Array:
                    return this.ReadArray(index);

                case BinaryTag.GList:
                    return this.ReadGList(index);

                case BinaryTag.GDictionary:
                    return this.ReadGDictionary(index);

                case BinaryTag.Object:
                    return this.ReadObject(index);

                default:
                    throw new ArgumentException();
            }
            this.ReferenceContainer[index] = value;
            return value;
        }

        #region InnerRead

        private string InnerReadString()
        {
            return this.Read() as string;
        }

        private byte[] InnerRead(int length)
        {
            byte[] buffer = new byte[length];
            this._Stream.Read(buffer, 0, length);
            return buffer;
        }

        #endregion

        #region Boolean DateTime Guid

        public Guid ReadGuid()
        {
            return new Guid(this.InnerRead(TypeByteLength.Guid));
        }

        public Guid[] ReadGuidArray()
        {
            var array = new Guid[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadGuid();
            }
            return array;
        }

        public DateTime ReadDateTime()
        {
            return DateTime.FromOADate(this.ReadDouble());
        }

        public DateTime[] ReadDateTimeArray()
        {
            var array = new DateTime[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = DateTime.FromOADate(this.ReadDouble());
            }
            return array;
        }

        public Boolean ReadBoolean()
        {
            return BitConverter.ToBoolean(this.InnerRead(TypeByteLength.Boolean), 0);
        }

        public Boolean[] ReadBooleanArray()
        {
            var array = new Boolean[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadBoolean();
            }
            return array;
        }

        #endregion

        #region Bytes

        public Byte ReadByte()
        {
            return (Byte)this._Stream.ReadByte();
        }

        public Byte[] ReadByteArray()
        {
            return this.InnerRead(this.ReadInt32());
        }

        public SByte ReadSByte()
        {
            return (SByte)this._Stream.ReadByte();
        }

        public SByte[] ReadSByteArray()
        {
            var length = this.ReadInt32();
            var bytes = this.InnerRead(length);
            SByte[] sbytes = new SByte[length];
            bytes.CopyTo(sbytes, 0);

            return sbytes;
        }

        #endregion

        #region Single Double Decimal

        public Single ReadSingle()
        {
            return BitConverter.ToSingle(this.InnerRead(TypeByteLength.Single), 0);
        }

        public Single[] ReadSingleArray()
        {
            var array = new Single[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadSingle();
            }
            return array;
        }

        public Double ReadDouble()
        {
            return BitConverter.ToDouble(this.InnerRead(TypeByteLength.Double), 0);
        }

        public Double[] ReadDoubleArray()
        {
            var array = new Double[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadDouble();
            }
            return array;
        }

        public Decimal ReadDecimal()
        {
            return new Decimal(new int[] { this.ReadInt32(), this.ReadInt32(), this.ReadInt32(), this.ReadInt32() });
        }

        public Decimal[] ReadDecimalArray()
        {
            var array = new Decimal[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadDecimal();
            }
            return array;
        }

        #endregion

        #region Int

        public Int16 ReadInt16()
        {
            return BitConverter.ToInt16(this.InnerRead(TypeByteLength.Int16), 0);
        }

        public Int16[] ReadInt16Array()
        {
            var array = new Int16[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadInt16();
            }
            return array;
        }

        public Int32 ReadInt32()
        {
            return BitConverter.ToInt32(this.InnerRead(TypeByteLength.Int32), 0);
        }

        public Int32[] ReadInt32Array()
        {
            var array = new Int32[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadInt32();
            }
            return array;
        }

        public Int64 ReadInt64()
        {
            return BitConverter.ToInt64(this.InnerRead(TypeByteLength.Int64), 0);
        }

        public Int64[] ReadInt64Array()
        {
            var array = new Int64[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadInt64();
            }
            return array;
        }

        public UInt16 ReadUInt16()
        {
            return BitConverter.ToUInt16(this.InnerRead(TypeByteLength.UInt16), 0);
        }

        public UInt16[] ReadUInt16Array()
        {
            var array = new UInt16[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadUInt16();
            }
            return array;
        }

        public UInt32 ReadUInt32()
        {
            return BitConverter.ToUInt32(this.InnerRead(TypeByteLength.UInt32), 0);
        }

        public UInt32[] ReadUInt32Array()
        {
            var array = new UInt32[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadUInt32();
            }
            return array;
        }

        public UInt64 ReadUInt64()
        {
            return BitConverter.ToUInt64(this.InnerRead(TypeByteLength.UInt64), 0);
        }

        public UInt64[] ReadUInt64Array()
        {
            var array = new UInt64[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadUInt64();
            }
            return array;
        }

        #endregion

        #region Char String StringBuilder

        public Char ReadChar()
        {
            return BitConverter.ToChar(this.InnerRead(TypeByteLength.Char), 0);
        }

        public Char[] ReadCharArray()
        {
            var array = new Char[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadChar();
            }
            return array;
        }

        public String ReadString()
        {
            var byteLength = this.ReadInt32();
            if(byteLength == -1) return null;
            else if(byteLength == 0) return string.Empty;
            var bytes = this.InnerRead(byteLength);
            return this._Encoding.GetString(bytes, 0, bytes.Length);
        }

        public String[] ReadStringArray()
        {
            var array = new String[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.InnerReadString();
            }
            return array;
        }

        public StringBuilder ReadStringBuilder()
        {
            var s = this.InnerReadString();
            if(s == null) return null;
            return new StringBuilder(s);
        }

        public StringBuilder[] ReadStringBuilderArray()
        {
            var array = new StringBuilder[this.ReadInt32()];
            for(int i = 0 ; i < array.Length ; i++)
            {
                array[i] = this.ReadStringBuilder();
            }
            return array;
        }

        #endregion

        #region GList GDictionary Array Object

        public object ReadGList(int index)
        {

            Type elemType = this.ReadType();
            IList list = Activator.CreateInstance(Types.GList.MakeGenericType(elemType)) as IList;

            this.ReferenceContainer[index] = list;

            var array = this.ReadArray(elemType);
            foreach(var item in array) list.Add(item);
            return list;
        }

        public object ReadGDictionary(int index)
        {
            Type keyType = this.ReadType(), valueType = this.ReadType();
            IDictionary dict = Activator.CreateInstance(Types.GDictionary.MakeGenericType(keyType, valueType)) as IDictionary;

            this.ReferenceContainer[index] = dict;

            var keyArray = this.ReadArray(keyType);
            var valueArray = this.ReadArray(valueType);
            for(int i = 0 ; i < keyArray.Length ; i++) dict.Add(keyArray.GetValue(i), valueArray.GetValue(i));

            return dict;
        }

        private Type ReadType()
        {
            return this.GetType(this.InnerReadString());
        }

        public Array ReadArray(int index)
        {
            return this.ReadArray(this.ReadType(), index);
        }

        private Array ReadArray(Type elementType)
        {
            return this.ReadArray(elementType, -1);
        }

        private Array ReadArray(Type elementType, int refKey)
        {
            var rank = this.ReadInt32();
            int i, j;
            var des = new int[rank, 2];
            var loc = new int[rank];

            int[] rankLengths = new int[rank];
            for(i = 0 ; i < rank ; i++)
            {
                rankLengths[i] = this.ReadInt32();
            }

            Array array = Array.CreateInstance(elementType, rankLengths);

            if(refKey > 0) this.ReferenceContainer[refKey] = array;

            // 设置每一个 数组维 的上下标。
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
                array.SetValue(this.Read(), loc);
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
            return array;
        }

        public object ReadObject(int index)
        {
            var type = this.ReadType();
            var fieldCount = this.ReadInt32();

            Object result = Sofire.Dynamic.Factories.DynamicConstructorFactory.Instance.Create(type.FindConstructor())();

            this.ReferenceContainer[index] = result;

            var fields = SerializationHelper.GetSerializableMembers(type);

            for(Int32 i = 0 ; i < fieldCount ; i++)
            {
                var fieldNameCode = this.ReadInt32();
              //  string fieldName = this.InnerReadString();
                SerializableFieldInfo sfieldInfo = null;
                foreach(var f in fields)
                {
                    if(f.NameHashCode == fieldNameCode)
                    {
                        sfieldInfo = f;
                        break;
                    }
                    //if(f.Name == fieldName)
                    //{
                    //    sfieldInfo = f;
                    //    break;
                    //}
                }

                if(sfieldInfo == null) continue;

                sfieldInfo.SetValue(ref result, this.Read());

            }
            return result;
        }

        #endregion

        private readonly static Dictionary<string, Type> TypeCacher = new Dictionary<string, Type>();

        private Type GetType(string simplifyQualifiedName)
        {
            Type type;
            lock(TypeCacher)
            {
                if(!TypeCacher.TryGetValue(simplifyQualifiedName, out type))
                {
                    type = SerializationHelper.RecoveryQualifiedName(simplifyQualifiedName);
                    TypeCacher.Add(simplifyQualifiedName, type);
                }
            }
            return type;

        }
    }
}
