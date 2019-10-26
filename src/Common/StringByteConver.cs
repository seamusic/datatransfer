using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daan.DataTransfer.DataCommon
{
    public class StringByteConver
    {
        public static byte[] ToByte(string data)
        {
            return System.Text.Encoding.UTF8.GetBytes(data);
        }

        public static string ToString(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }
    }
}
