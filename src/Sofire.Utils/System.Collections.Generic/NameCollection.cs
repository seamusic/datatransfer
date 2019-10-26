namespace System.Collections.Generic
{
    /// <summary>
    /// 表示一个具有唯一标识符（不区分大小写）的项集合。
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class NameCollection : NameCollection<object>
    {
        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.NameCollection"/> 的新实例。
        /// </summary>
        public NameCollection()
            : base()
        {
        }

        /// <summary>
        /// 指定初始元素数，初始化 <see cref="System.Collections.Generic.NameCollection"/> 的新实例。
        /// </summary>
        /// <param name="capacity">新集合最初可以存储的元素数。</param>
        public NameCollection(int capacity)
            : base(capacity)
        {
        }

        #endregion Constructors
    }
}