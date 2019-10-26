namespace System.Collections.Generic
{
    /// <summary>
    /// 表示一个自定义值类型的值显对。
    /// </summary>
    /// <typeparam name="TValue">值类型。</typeparam>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class DisplayValuePair<TValue>
    {
        #region Fields

        private string _Display;
        private TValue _Value;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 指定值显内容，初始化 <see cref="System.Collections.Generic.DisplayValuePair&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        /// <param name="display">显示内容。</param>
        /// <param name="value">值内容。</param>
        public DisplayValuePair(string display, TValue value)
            : this(value)
        {
            this._Display = display;
        }

        /// <summary>
        /// 指定值内容，初始化 <see cref="System.Collections.Generic.DisplayValuePair&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        /// <param name="value">值内容。</param>
        public DisplayValuePair(TValue value)
        {
            this._Value = value;
        }

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.DisplayValuePair&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        public DisplayValuePair()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 设置或获取一个值，表示显示内容。
        /// </summary>
        public string Display
        {
            get
            {
                if(string.IsNullOrEmpty(this._Display))
                {
                    return this._Value.ToStringOrEmpty();
                }
                return this._Display;
            }
            set { this._Display = value; }
        }

        /// <summary>
        /// 设置或获取一个值，表示值内容。
        /// </summary>
        public TValue Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 返回表示显示内容的字符串形式。
        /// </summary>
        /// <returns>如果显示内容不存在，则返回值类型。</returns>
        public override string ToString()
        {
            return this.Display;
        }

        #endregion Methods
    }
}