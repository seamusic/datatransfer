using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sofire.DataComm
{
    /// <summary>
    /// 一个通讯的实现。
    /// </summary>
    public abstract class CommunicationBase : ICommunication
    {
        private long _State = 0;
        private long _IsRunning = 0;

        /// <summary>
        /// 通讯状态发生更改后发生。
        /// </summary>
        public event CommunicationStateEventHandler StateChanged;

        /// <summary>
        /// 获取一个值，指示通讯是否正在运行中。
        /// </summary>
        public virtual bool IsRunning
        {
            get
            {
#if SILVERLIGHT
                return Interlocked.CompareExchange(ref this._IsRunning, 0, 0) == 1;
#else
                return Interlocked.Read(ref this._IsRunning) == 1;
#endif
            }
        }

        /// <summary>
        /// 获取一个值，表示通讯的状态。
        /// </summary>
        public CommunicationState State
        {
            get
            {
#if SILVERLIGHT
                return (CommunicationState)Interlocked.CompareExchange(ref this._State, 0, 0);
#else
                return (CommunicationState)Interlocked.Read(ref this._State);
#endif
            }
        }

        #region ICommunication

        /// <summary>
        /// 启动通讯。
        /// </summary>
        public void Open()
        {
            if(this.IsRunning) return;

            Interlocked.Exchange(ref this._IsRunning, 1);
            this.SwitchState(CommunicationState.Opening);
            try
            {
                this.OnOpen();
                this.SwitchState(CommunicationState.Opened);
            }
            catch(Exception ex)
            {
                this.SwitchState(ex);
            }
        }

        /// <summary>
        /// 打开通讯时发生。
        /// </summary>
        protected abstract void OnOpen();

        /// <summary>
        /// 关闭通讯。
        /// </summary>
        public void Close()
        {
            if(!this.IsRunning) return;

            Interlocked.Exchange(ref this._IsRunning, 0);

            this.SwitchState(CommunicationState.Closing);
            try
            {
                this.OnClose();
            }
            finally
            {
                this.SwitchState(CommunicationState.Closed);
            }
        }

        /// <summary>
        /// 关闭通讯时发生。
        /// </summary>
        protected abstract void OnClose();

        /// <summary>
        /// 切换通讯状态。
        /// </summary>
        /// <param name="state">通讯的状态。</param>
        protected void SwitchState(CommunicationState state)
        {
            this.OnSwitchState(state, null);
        }

        /// <summary>
        /// 切换到异常的通讯状态，通讯会先关闭连接，并触发异常状态事件。
        /// </summary>
        /// <param name="exception">通讯中抛出的异常。</param>
        protected void SwitchState(Exception exception)
        {
            this.OnSwitchState(CommunicationState.Failed, exception);
        }

        /// <summary>
        /// 切换通讯状态。
        /// </summary>
        /// <param name="state">通讯的状态。</param>
        /// <param name="exception">通讯中抛出的异常。</param>
        protected internal virtual void OnSwitchState(CommunicationState state, Exception exception)
        {
            Interlocked.Exchange(ref this._State, (long)state);
            if(this.StateChanged != null)
            {
                if(state == CommunicationState.Failed)
                {
                    this.Close();
                    this.StateChanged(this, new CommunicationFailedStateEventArgs(exception));
                }
                else this.StateChanged(this, new CommunicationStateEventArgs(state));
            }
        }

        #endregion

        void IDisposable.Dispose()
        {
            this.Close();
        }

        /// <summary>
        /// 析构函数。
        /// </summary>
        ~CommunicationBase()
        {
            this.Close();
        }
    }
}
