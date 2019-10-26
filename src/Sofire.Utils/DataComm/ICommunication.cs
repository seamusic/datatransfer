using System;
using System.Collections.Generic;
using System.Text;

namespace Sofire.DataComm
{
    /// <summary>
    /// 表示通讯基类。
    /// </summary>
    public interface ICommunication : ICommunicationState, IDisposable
    {
        ///// <summary>
        ///// 获取一个值，指示通讯是否正在运行中。
        ///// </summary>
        //bool IsRunning { get; }
        /// <summary>
        /// 启动通讯。
        /// </summary>
        void Open();
        /// <summary>
        /// 关闭通讯。
        /// </summary>
        void Close();
    }
}
