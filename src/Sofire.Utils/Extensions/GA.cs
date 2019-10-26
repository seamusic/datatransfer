using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace System
{
    /// <summary>
    /// 通用全局函数。
    /// </summary>
    public static class GA
    {
#if !SILVERLIGHT
        /// <summary>
        /// 获取包含该应用程序的目录的名称。该字符串结尾包含“/”。
        /// </summary>
        public static readonly string AppDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;


        /// <summary>
        /// 获取指定路径的完整路径。
        /// </summary>
        /// <param name="path">绝对路径或相对路径。</param>
        /// <returns>若 <paramref name="path"/> 是绝对路径，则返回本身，否则返回基于当前应用程序目录的绝对路径。</returns>
        public static string FullPath(string path)
        {
            if(Path.IsPathRooted(path)) return path;
            return Path.Combine(AppDirectory, path);
        }
#endif
        /// <summary>
        /// 指定一个实例和一个类型，进行类型转换。
        /// </summary>
        /// <param name="value">实例。</param>
        /// <param name="type">类型。</param>
        /// <returns>返回类型转换的实例。</returns>
        public static object ChangeType(object value, Type type)
        {
            if(value == null || Convert.IsDBNull(value)) return null;
            if(type.IsNullable())
            {
                type = type.GetGenericArguments()[0];
            }
            if(type.IsInstanceOfType(value)) return value;
            object ret;

            if(type == Types.Boolean)
            {
                return Types.TrueStrings.IndexOf<string>(value.ToString(), StringComparer.OrdinalIgnoreCase) != -1;
            }
            if(Types.Enum.IsAssignableFrom(type))
            {
                return System.Enum.Parse(type, value.ToString(), false);
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
            return ret;
        }

        /// <summary>
        /// 获取应用程序当前的操作系统主版本是否少于 6（XP/2003 含以下的操作系统）。
        /// </summary>
        public static readonly bool IsOldOS = Environment.OSVersion.Version.Major < 6;

        /// <summary>
        /// 忽略被比较字符串的大小写，确定两个指定的 <see cref="System.String"/> 对象是否具有同一值。
        /// </summary>
        /// <param name="a"><see cref="System.String"/> 对象或 null。</param>
        /// <param name="b"><see cref="System.String"/> 对象或 null。</param>
        /// <returns>如果 a 参数的值等于 b 参数的值，则为 true；否则为 false。</returns>
        public static bool Equals(string a, string b)
        {
            return string.Equals(a, b, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 指示字符串形式的绝对地址，创建一个 <see cref="System.Uri"/> 对象。
        /// </summary>
        /// <param name="url">字符串形式的绝对地址。</param>
        /// <returns>返回一个 <see cref="System.Uri"/> 对象，或一个 null 值。</returns>
        public static Uri CreateUri(string url)
        {
            return CreateUri(url, UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// 指示字符串形式的绝对地址，创建一个 <see cref="System.Uri"/> 对象。
        /// </summary>
        /// <param name="url">字符串形式的绝对地址。</param>
        /// <param name="kind">URI 的类型。</param>
        /// <returns>返回一个 <see cref="System.Uri"/> 对象，或一个 null 值。</returns>
        public static Uri CreateUri(string url, UriKind kind)
        {
            Uri url2;
            Uri.TryCreate(url, kind, out url2);
            return url2;
        }
    }

}
