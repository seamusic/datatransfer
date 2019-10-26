using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Sofire.Dynamic.Factories;

namespace Sofire.Dynamic
{
    /// <summary>
    /// 表示一个成员的委托信息。
    /// </summary>
    /// <typeparam name="H">委托的数据类型。</typeparam>
    public class HandlerInfo<H>
    {
        /// <summary>
        /// 获取成员的元数据。
        /// </summary>
        public readonly MemberInfo Member;
        /// <summary>
        /// 获取成员的委托。
        /// </summary>
        public readonly H Handler;

        /// <summary>
        /// 初始化 <see cref="Sofire.Dynamic.HandlerInfo&lt;H&gt;"/> 的新实例。
        /// </summary>
        /// <param name="member">成员的元数据。</param>
        /// <param name="handler">成员的委托。</param>
        public HandlerInfo(MemberInfo member,H handler)
        {
            this.Member = member;
            this.Handler = handler;
        }
    }
}
