using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Linq;

namespace System.Net
{
    /// <summary>
    /// System.Net 的扩展方法集合。
    /// </summary>
    public static class NetExts
    {
#if !SILVERLIGHT
        /// <summary>
        ///  获取本机已被使用的网络端点。
        /// </summary>
        /// <returns>返回本机所有网络地址端口。</returns>
        public static IEnumerable<IPEndPoint> GetUsedIPEndPoint()
        {
            //获取一个对象，该对象提供有关本地计算机的网络连接和通信统计数据的信息。
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();

            foreach(var item in ipGlobalProperties.GetActiveTcpListeners()) yield return item;
            foreach(var item in ipGlobalProperties.GetActiveUdpListeners()) yield return item;
            foreach(var item in ipGlobalProperties.GetActiveTcpConnections()) yield return item.LocalEndPoint;
        }
        /// <summary>
        /// 判断指定的网络端点（只判断端口）是否被使用。
        /// </summary>
        /// <returns>如果端口已被占用，则返回 true，否则返回 false。</returns>
        public static bool IsUsedIPEndPoint(int port)
        {
            foreach(IPEndPoint iep in GetUsedIPEndPoint())
            {
                if(iep.Port == port)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断指定的网络端点（判断IP和端口）是否被使用
        /// </summary>
        /// <returns>如果地址和端口已被占用，则返回 true，否则返回 false。</returns>
        public static bool IsUsedIPEndPoint(string ip, int port)
        {
            foreach(IPEndPoint iep in GetUsedIPEndPoint())
            {
                if(iep.Address.ToString() == ip && iep.Port == port)
                {
                    return true;
                }
            }
            return false;
        }
        
#endif
        /// <summary>
        /// 将指定 IP 地址转换为 <see cref="System.Net.IPAddress"/> 的新实例。
        /// </summary>
        /// <param name="ip">包含 IP 地址（IPv4 使用以点分隔的四部分表示法，IPv6 使用冒号十六进制表示法）的字符串。可以是 null 值、“localhost”和“127.0.0.1”，这三个值代表相同的地址。</param>
        /// <returns>返回一个新的 <see cref="System.Net.IPAddress"/> 实例。</returns>
        public static IPAddress ParseAddress(string ip)
        {
            if(string.IsNullOrEmpty(ip)
                || string.Equals(ip, "127.0.0.1")
                || string.Equals(ip, "localhost", StringComparison.OrdinalIgnoreCase)) return IPAddress.Loopback;

            return IPAddress.Parse(ip);
        }
    }
}
