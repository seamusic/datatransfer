using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daan.DataTransfer.Utility;

namespace Daan.DataTransfer.DataCommon
{
    public static class DataDictionary
    {
        /// <summary>
        /// 错误信息
        /// 1-98 系统问题
        /// 99 其它未知错误
        /// 100-199 网络问题
        /// 200-299 数据问题
        /// </summary>
        public enum ErrorType
        {
            [EnumDescription("正常")]
            Success = 0,

            [EnumDescription("未知错误")]
            Error = 99,

            [EnumDescription("网络超时")]
            NetworkTimeout = 101,

            [EnumDescription("数据CRC校验失败")]
            DataCrcEror = 201,
            [EnumDescription("开始获取数据失败")]
            DataPullBeginError = 210,
            [EnumDescription("获取数据失败")]
            DataPullError = 211,
            [EnumDescription("结束获取数据失败")]
            DataPullEndError = 212,

            [EnumDescription("开始推送数据失败")]
            DataPushBeginError = 220,
            [EnumDescription("推送数据失败")]
            DataPushError = 221,
            [EnumDescription("开始推送数据失败")]
            DataPushEndError = 222,
        }
    }

    public static class SystemParameter
    {
        public const int DataLength = 1024 * 1024;
        public const int MaxTaskNumber = 10;
    }
}
