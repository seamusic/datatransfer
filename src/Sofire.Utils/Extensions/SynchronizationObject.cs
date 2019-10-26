using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace System
{
    /// <summary>
    /// 提供在各种同步模型中传播同步上下文的基本功能。
    /// </summary>
    public class SynchronizationObject
    {
        private readonly static SynchronizationContext _DefaultContext = SynchronizationContext.Current;

        private SynchronizationContext _Context;
        /// <summary>
        /// 设置或获取当前同步的上下文。
        /// </summary>
        public SynchronizationContext Context
        {
            get
            {
                if(_Context == null)
                {
                    return _DefaultContext;
                }
                return _Context;
            }
            set
            {
                _Context = value;
            }
        }

        /// <summary>
        /// 将一个同步消息调度到一个同步上下文。
        /// </summary>
        /// <param name="callback">要调用的 <see cref="System.Threading.SendOrPostCallback"/> 委托。</param>
        public void Invoke(SendOrPostCallback callback)
        {
            Invoke(callback, null);
        }

        /// <summary>
        /// 将一个同步消息调度到一个同步上下文。
        /// </summary>
        /// <param name="callback">要调用的 <see cref="System.Threading.SendOrPostCallback"/> 委托。</param>
        /// <param name="state">传递给委托的对象。</param>
        public void Invoke(SendOrPostCallback callback, object state)
        {
            if(Context == null) callback(state);
            else Context.Send(callback, state);
        }

        /// <summary>
        /// 将异步消息调度到一个同步上下文。
        /// </summary>
        /// <param name="callback">要调用的 <see cref="System.Threading.SendOrPostCallback"/> 委托。</param>
        public void BeginInvoke(SendOrPostCallback callback)
        {
            BeginInvoke(callback, null);
        }

        /// <summary>
        /// 将异步消息调度到一个同步上下文。
        /// </summary>
        /// <param name="callback">要调用的 <see cref="System.Threading.SendOrPostCallback"/> 委托。</param>
        /// <param name="state">传递给委托的对象。</param>
        public void BeginInvoke(SendOrPostCallback callback, object state)
        {
            if(Context == null) callback(state);
            else Context.Post(callback, state);
        }

        

        /// <summary>
        /// 初始化 <see cref="System.SynchronizationObject"/> 的新实例。
        /// </summary>
        public SynchronizationObject() { }

        /// <summary>
        /// 初始化 <see cref="System.SynchronizationObject"/> 的新实例。
        /// </summary>
        /// <param name="context">同步的上下文。</param>
        public SynchronizationObject(SynchronizationContext context)
        {
            this._Context = context;
        }
    }
}
