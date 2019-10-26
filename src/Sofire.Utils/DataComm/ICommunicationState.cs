using System;
using System.Collections.Generic;
using System.Text;

namespace Sofire.DataComm
{
    /// <summary>
    /// 表示一个具有通讯状态的通讯接口。
    /// </summary>
    public interface ICommunicationState
    {
        /// <summary>
        /// 获取一个值，表示通讯的状态。
        /// </summary>
        CommunicationState State { get; }
        /// <summary>
        /// 通讯状态发生更改后发生。
        /// </summary>
        event CommunicationStateEventHandler StateChanged;
    }
}
