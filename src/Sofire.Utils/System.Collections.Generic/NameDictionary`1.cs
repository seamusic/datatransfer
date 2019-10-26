namespace System.Collections.Generic
{
    using System.Collections.Generic;

    /// <summary>
    /// 字符串作为唯一键的字典集合（用于多线程）。
    /// </summary>
    /// <typeparam name="TValue">值的类型。</typeparam>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class NameDictionary<TValue> : SyncDictionary<string, TValue>
    {
        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.NameDictionary&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        public NameDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// 指定 <see cref="System.Collections.Generic.IEqualityComparer&lt;T&gt;"/>，初始化 <see cref="System.Collections.Generic.NameDictionary&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        /// <param name="comparer">比较键时要使用的 <see cref="System.Collections.Generic.IEqualityComparer&lt;T&gt;"/> 实现，或者为 null，以便为键类型使用默认的 <see cref="System.Collections.Generic.IEqualityComparer&lt;T&gt;"/>;。</param>
        public NameDictionary(IEqualityComparer<string> comparer)
            : base(comparer ?? StringComparer.OrdinalIgnoreCase)
        {
        }

        #endregion Constructors
    }
}