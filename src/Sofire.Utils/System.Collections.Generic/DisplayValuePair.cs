namespace System.Collections.Generic
{
    /// <summary>
    /// 表示一个值显对。
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class DisplayValuePair : DisplayValuePair<object>
    {
        #region Constructors

        /// <summary>
        /// 指定值显内容，初始化 <see cref="System.Collections.Generic.DisplayValuePair"/> 的新实例。
        /// </summary>
        /// <param name="display">显示内容。</param>
        /// <param name="value">值内容。</param>
        public DisplayValuePair(string display, object value)
            : base(display, value)
        {
        }

        /// <summary>
        /// 指定值内容，初始化 <see cref="System.Collections.Generic.DisplayValuePair"/> 的新实例。
        /// </summary>
        /// <param name="value">值内容。</param>
        public DisplayValuePair(object value)
            : base(value)
        {
        }

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.DisplayValuePair"/> 的新实例。
        /// </summary>
        public DisplayValuePair()
        {
        }

        #endregion Constructors
    }
}