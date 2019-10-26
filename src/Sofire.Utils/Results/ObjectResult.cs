namespace System
{
    /// <summary>
    /// 表示包含一个 <see cref="System.Object"/> 类型返回值的结果。
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class ObjectResult : Result<object>
    {
        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.ObjectResult"/> 的新实例。
        /// </summary>
        public ObjectResult()
        {
        }

        /// <summary>
        /// 指定结果的返回值，初始化 <see cref="System.ObjectResult"/> 的新实例。
        /// </summary>
        /// <param name="value">结果的返回值。</param>
        public ObjectResult(object value)
        {
            this._Value = value;
        }

        /// <summary>
        /// 指定结果的返回值和引发的异常，初始化 <see cref="System.ObjectResult"/> 的新实例。
        /// </summary>
        /// <param name="value">结果的返回值。只有当 <paramref name="exception"/> 为 null 时，此参数才会有效。</param>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        public ObjectResult(object value, Exception exception)
            : base(exception)
        {
            if(exception == null)
                this._Value = value;
        }

        /// <summary>
        /// 指定引发的异常，初始化 <see cref="System.ObjectResult"/> 的新实例。
        /// </summary>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        public ObjectResult(Exception exception)
            : base(exception)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// <see cref="System.ObjectResult"/> 和 <see cref="System.Exception"/> 的隐式转换。
        /// </summary>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        /// <returns>表示一个异常的结果。</returns>
        public static implicit operator ObjectResult(Exception exception)
        {
            return new ObjectResult(exception);
        }

        #endregion Methods
    }
}