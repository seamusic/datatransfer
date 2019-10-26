using System.Threading;
namespace System
{
    public static partial class UtilsExts
    {

        #region Delegates

        internal delegate bool TryParseHandler<T>(string s, out T result);

        #endregion Delegates

        #region Methods

        private readonly static char[] WhitespaceChars = new char[] { ' ', '\t', '\n', '\r' };

        /// <summary>
        /// 判断当前字符处是否是一个空白字符。
        /// </summary>
        /// <param name="ch">判断的字符。</param>
        /// <returns>如果当前字符是是以下字符的其中一个（' ', '\t', '\n', '\r'）则返回 true，否则返回 false。</returns>
        public static bool IsWhitespaceChar(this char ch)
        {
            return Array.IndexOf(WhitespaceChars, ch) != -1;
        }

        /// <summary>
        /// 尝试将给定值转换为指定类型的可空类型。
        /// </summary>
        /// <typeparam name="T">可空的数据类型，这必须是一个值类型。</typeparam>
        /// <param name="value">请求类型转换的值。</param>
        /// <returns>返回一个可空数据类型的值。</returns>
        public static T? CastTo<T>(this object value)
            where T : struct
        {
            if(value == null || Convert.IsDBNull(value)) return null;
            var type = typeof(T);
            if(type.IsInstanceOfType(value)) return (T)value;
            object ret;

            if(type.IsNullable())
            {
                type = type.GetGenericArguments()[0];
            }
            if(type == Types.Boolean)
            {
                string v2 = value.ToString();
                if(Types.TrueStrings.IndexOf<string>(v2, StringComparer.OrdinalIgnoreCase) != -1)
                    ret = true;
                else
                    ret = false;
            }
            else if(Types.Enum.IsAssignableFrom(type))
            {
                string v2 = value.ToString();
                ret = System.Enum.Parse(type, v2, false);
            }
            else
            {
                try
                {
                    switch(System.Type.GetTypeCode(type))
                    {
                        case TypeCode.Byte:
                            ret = Convert.ToByte(value);
                            break;
                        case TypeCode.Char:
                            ret = Convert.ToChar(value);
                            break;
                        case TypeCode.DBNull:
                            ret = DBNull.Value;
                            break;
                        case TypeCode.DateTime:
                            ret = Convert.ToDateTime(value);
                            break;
                        case TypeCode.Decimal:
                            ret = Convert.ToDecimal(value);
                            break;
                        case TypeCode.Double:
                            ret = Convert.ToDouble(value);
                            break;
                        case TypeCode.Empty:
                            ret = null;
                            break;
                        case TypeCode.Int16:
                            ret = Convert.ToInt16(value);
                            break;
                        case TypeCode.Int32:
                            ret = Convert.ToInt32(value);
                            break;
                        case TypeCode.Int64:
                            ret = Convert.ToInt64(value);
                            break;
                        case TypeCode.Object:
                            ret = value;
                            break;
                        case TypeCode.SByte:
                            ret = Convert.ToSByte(value);
                            break;
                        case TypeCode.Single:
                            ret = Convert.ToSingle(value);
                            break;
                        case TypeCode.String:
                            ret = value.ToString();
                            break;
                        case TypeCode.UInt16:
                            ret = Convert.ToUInt16(value);
                            break;
                        case TypeCode.UInt32:
                            ret = Convert.ToUInt32(value);
                            break;
                        case TypeCode.UInt64:
                            ret = Convert.ToUInt64(value);
                            break;
                        default:
                            ret = Convert.ChangeType(value, type, null);
                            break;
                    }
                }
                catch(Exception)
                {
                    return null;
                }
            }
            return (T)ret;
        }

        /// <summary>
        /// 尝试将给定字符串转换为指定类型的可空类型。
        /// </summary>
        /// <typeparam name="T">可空的数据类型，这必须是一个值类型。</typeparam>
        /// <param name="value">请求类型转换的字符串。</param>
        /// <returns>返回一个可空数据类型的值。</returns>
        public static T? CastTo<T>(this string value)
            where T : struct
        {
            if(string.IsNullOrEmpty(value)) return null;
            TryParseHandler<T> handler = UtilsExts.TryParseInvoke<T>();
            if(handler != null)
            {
                T result;
                try
                {
                    if(handler(value, out result)) return result;
                }
                catch(Exception) { }
            }
            return (T?)CastTo(value, typeof(T));
        }

        /// <summary>
        /// 将字符串值转换为指定类型的实例。
        /// </summary>
        /// <param name="value">字符串值。</param>
        /// <param name="type">数据类型。</param>
        public static object CastTo(this string value, Type type)
        {
            if(string.IsNullOrEmpty(value) && !type.IsValueType)
            {
                return null;
            }
            if(type.IsNullable())
            {
                type = type.GetGenericArguments()[0];
            }
            if(type == Types.Boolean)
            {
                return Types.TrueStrings.IndexOf<string>(value.ToLower(), StringComparer.OrdinalIgnoreCase) != -1;

            }
            if(Types.Enum.IsAssignableFrom(type))
            {
                return System.Enum.Parse(type, value, false);
            }

            try
            {
                switch(System.Type.GetTypeCode(type))
                {
                    case TypeCode.Byte:
                        return System.Convert.ToByte(value);

                    case TypeCode.Char:
                        return System.Convert.ToChar(value);

                    case TypeCode.DBNull:
                        return System.DBNull.Value;

                    case TypeCode.DateTime:
                        return System.Convert.ToDateTime(value);

                    case TypeCode.Decimal:
                        return System.Convert.ToDecimal(value);

                    case TypeCode.Double:
                        return System.Convert.ToDouble(value);

                    case TypeCode.Empty:
                        return null;

                    case TypeCode.Int16:
                        return System.Convert.ToInt16(value);

                    case TypeCode.Int32:
                        return System.Convert.ToInt32(value);

                    case TypeCode.Int64:
                        return System.Convert.ToInt64(value);

                    case TypeCode.Object:
                        return value;

                    case TypeCode.SByte:
                        return System.Convert.ToSByte(value);

                    case TypeCode.Single:
                        return System.Convert.ToSingle(value);

                    case TypeCode.String:
                        return value;

                    case TypeCode.UInt16:
                        return System.Convert.ToUInt16(value);

                    case TypeCode.UInt32:
                        return System.Convert.ToUInt32(value);

                    case TypeCode.UInt64:
                        return System.Convert.ToUInt64(value);

                    default:
                        return System.Convert.ChangeType(value, type, null);
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或 <see cref="System.String.Empty"/>，或者如果 value 仅由空白字符组成，则为 true。</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if(value == null)
            {
                return true;
            }
            for(int i = 0 ; i < value.Length ; i++)
            {
                if(!char.IsWhiteSpace(value[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 指示指定的字符串是 null 还是 <see cref="System.String.Empty"/> 字符串。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value.Length == 0;
        }

        /// <summary>
        ///  确定当前实例中是否设置了一个或多个位域。
        /// </summary>
        /// <typeparam name="T">枚举类型。</typeparam>
        /// <param name="flag1">一个枚举值。</param>
        /// <param name="flag2">另一个枚举值。</param>
        /// <returns>如果在 <paramref name="flag2"/> 中设置的位域也在 <paramref name="flag1"/> 中进行了设置，则为 true；否则为 false。</returns>
        public static bool HasFlag<T>(this T flag1, T flag2) where T : struct,IComparable, IFormattable, IConvertible
        {
            if(flag1 is Enum)
            {
                var val1 = Convert.ToUInt64(flag1);
                var val2 = Convert.ToUInt64(flag2);
                return (val1 & val2) == val2;
            }
            return false;
        }

        /// <summary>
        /// 创造调用指定 System.Reflection.MethodInfo 的委托。
        /// </summary>
        /// <param name="method">方法元数据。</param>
        /// <returns>返回调用 method 的委托。</returns>
        public static Delegate CreateDelegate(this System.Reflection.MethodInfo method)
        {
            return Delegate.CreateDelegate(MakeNewDelegate(method), method);
        }

        /// <summary>
        /// 创造指定 System.Reflection.MethodInfo 的委托。
        /// </summary>
        /// <param name="method">方法元数据。</param>
        /// <returns>返回 method 的委托的类型。</returns>
        public static Type MakeNewDelegate(this System.Reflection.MethodInfo method)
        {
            Type[] types;
            var ps = method.GetParameters();
            if(ps.Length > 17)
            {
                throw new ArgumentOutOfRangeException("types", method.Name + "声明了过多的参数！无法转换成委托！");
            }
            int i;
            if(method.ReturnType == Types.Void)
            {
                types = new Type[ps.Length];
                System.Reflection.ParameterInfo p;
                for(i = 0 ; i < ps.Length ; i++)
                {
                    p = ps[i];
                    if(p.ParameterType.IsByRef) throw new ArgumentException(method.Name + "含有 out 或 ref 参数。无法转换成 Delegate。", "method");
                    types[i] = p.ParameterType;
                }
                return GetActionType(types);
            }
            else
            {
                types = new Type[ps.Length + 1];
                System.Reflection.ParameterInfo p;
                for(i = 0 ; i < ps.Length ; i++)
                {
                    p = ps[i];
                    if(p.ParameterType.IsByRef) throw new ArgumentException(method.Name + "含有 out 或 ref 参数。无法转换成 Delegate。", "method");
                    types[i] = p.ParameterType;
                }
                types[i] = method.ReturnType;
                return GetFuncType(types);
            }
        }

        /// <summary>
        /// 删除当前字符串的最后一个字符串。
        /// </summary>
        /// <param name="val">目标字符串。</param>
        /// <returns>返回删除后的字符串。</returns>
        public static string RemoveEnd(this string val)
        {
            return RemoveEnd(val, 1);
        }

        /// <summary>
        /// 删除当前字符串的最后的字符串。
        /// </summary>
        /// <param name="val">目标字符串。</param>
        /// <param name="count">要删除的字长度。</param>
        /// <returns>返回删除后的字符串。</returns>
        public static string RemoveEnd(this string val, int count)
        {
            if(string.IsNullOrEmpty(val) || val.Length < count) return val;
            return val.Remove(val.Length - count);
        }

        /// <summary>
        /// 返回表示当前对象的 System.String，如果这是一个 null 值，将返回 String.Empty。
        /// </summary>
        /// <param name="value">对象。</param>
        /// <returns>当前对象的 System.String 形式或一个 String.Empty。</returns>
        public static string ToStringOrEmpty(this object value)
        {
            if(value == null) return string.Empty;
            return value.ToString();
        }

        /// <summary>
        /// 尝试释放当前对象使用的所有资源
        /// </summary>
        /// <param name="obj">释放的对象。</param>
        public static void TryDispose(this IDisposable obj)
        {
            if(obj != null) obj.Dispose();
        }

        internal static Type GetActionType(Type[] types)
        {
            switch(types.Length)
            {
                case 0:
                    {
                        return typeof(Sub);
                    }
                case 1:
                    {
                        return typeof(Sub<>).MakeGenericType(types);
                    }
                case 2:
                    {
                        return typeof(Sub<,>).MakeGenericType(types);
                    }
                case 3:
                    {
                        return typeof(Sub<,,>).MakeGenericType(types);
                    }
                case 4:
                    {
                        return typeof(Sub<,,,>).MakeGenericType(types);
                    }
                case 5:
                    {
                        return typeof(Sub<,,,,>).MakeGenericType(types);
                    }
                case 6:
                    {
                        return typeof(Sub<,,,,,>).MakeGenericType(types);
                    }
                case 7:
                    {
                        return typeof(Sub<,,,,,,>).MakeGenericType(types);
                    }
                case 8:
                    {
                        return typeof(Sub<,,,,,,,>).MakeGenericType(types);
                    }
                case 9:
                    {
                        return typeof(Sub<,,,,,,,,>).MakeGenericType(types);
                    }
                case 10:
                    {
                        return typeof(Sub<,,,,,,,,,>).MakeGenericType(types);
                    }
                case 11:
                    {
                        return typeof(Sub<,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 12:
                    {
                        return typeof(Sub<,,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 13:
                    {
                        return typeof(Sub<,,,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 14:
                    {
                        return typeof(Sub<,,,,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 15:
                    {
                        return typeof(Sub<,,,,,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 16:
                    {
                        return typeof(Sub<,,,,,,,,,,,,,,,>).MakeGenericType(types);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        internal static Type GetFuncType(Type[] types)
        {
            switch(types.Length)
            {
                case 1:
                    {
                        return typeof(Function<>).MakeGenericType(types);
                    }
                case 2:
                    {
                        return typeof(Function<,>).MakeGenericType(types);
                    }
                case 3:
                    {
                        return typeof(Function<,,>).MakeGenericType(types);
                    }
                case 4:
                    {
                        return typeof(Function<,,,>).MakeGenericType(types);
                    }
                case 5:
                    {
                        return typeof(Function<,,,,>).MakeGenericType(types);
                    }
                case 6:
                    {
                        return typeof(Function<,,,,,>).MakeGenericType(types);
                    }
                case 7:
                    {
                        return typeof(Function<,,,,,,>).MakeGenericType(types);
                    }
                case 8:
                    {
                        return typeof(Function<,,,,,,,>).MakeGenericType(types);
                    }
                case 9:
                    {
                        return typeof(Function<,,,,,,,,>).MakeGenericType(types);
                    }
                case 10:
                    {
                        return typeof(Function<,,,,,,,,,>).MakeGenericType(types);
                    }
                case 11:
                    {
                        return typeof(Function<,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 12:
                    {
                        return typeof(Function<,,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 13:
                    {
                        return typeof(Function<,,,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 14:
                    {
                        return typeof(Function<,,,,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 15:
                    {
                        return typeof(Function<,,,,,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 16:
                    {
                        return typeof(Function<,,,,,,,,,,,,,,,>).MakeGenericType(types);
                    }
                case 17:
                    {
                        return typeof(Function<,,,,,,,,,,,,,,,,>).MakeGenericType(types);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        internal static TryParseHandler<T> TryParseInvoke<T>()
            where T : struct
        {
            return Delegate.CreateDelegate(typeof(TryParseHandler<T>), typeof(T), "TryParse", false) as TryParseHandler<T>;
        }

        #endregion Methods
    }
}