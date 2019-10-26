namespace System
{
    /// <summary>
    /// 表示包含一个返回值的结果。
    /// </summary>
    /// <typeparam name="TValue">返回值的类型。</typeparam>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Result<TValue> : Result, IResult<TValue>
    {
        #region Fields

        /// <summary>
        /// 表示一个操作结果返回值的类型。
        /// </summary>
        public static readonly Type ValueType = typeof(TValue);

        /// <summary>
        /// 设置或获取结果的返回值。若结果不处于成功的状态，将返回默认值。
        /// </summary>
        protected TValue _Value;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.Result&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// 指定结果的返回值，初始化 <see cref="System.Result&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        /// <param name="value">结果的返回值。</param>
        public Result(TValue value)
        {
            this._Value = value;
        }

        /// <summary>
        /// 指定结果的返回值和引发的异常，初始化 <see cref="System.Result&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        /// <param name="value">结果的返回值。只有当 <paramref name="exception"/> 为 null 时，此参数才会有效。</param>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        public Result(TValue value, Exception exception)
            : base(exception)
        {
            if(exception == null)
            {
                this._Value = value;
            }
        }

        /// <summary>
        /// 指定引发的异常，初始化 <see cref="System.Result&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        public Result(Exception exception)
            : base(exception)
        {
        }

        /// <summary>
        /// 指定描述错误的信息，初始化 <see cref="System.Result&lt;TValue&gt;"/> 的新实例。
        /// </summary>
        /// <param name="exceptionMessage">描述错误的信息。</param>
        public Result(string exceptionMessage)
            : base(exceptionMessage)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 设置或获取结果的返回值。若结果不处于成功的状态，将返回默认值。
        /// </summary>
        public virtual TValue Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// <see cref="System.Result&lt;TValue&gt;"/> 和 <see cref="System.Exception"/> 的隐式转换。
        /// </summary>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        /// <returns>表示一个异常的结果。</returns>
        public static implicit operator Result<TValue>(Exception exception)
        {
            return new Result<TValue>(exception);
        }

        /// <summary>
        /// <see cref="System.Result&lt;TValue&gt;"/> 和 <see cref="System.String"/> 的隐式转换。
        /// </summary>
        /// <param name="exceptionMessage">描述错误的信息。</param>
        /// <returns>表示一个异常的结果。</returns>
        public static implicit operator Result<TValue>(string exceptionMessage)
        {
            return new Result<TValue>(exceptionMessage);
        }

        /// <summary>
        /// <see cref="System.Result&lt;TValue&gt;"/> 和 <typeparamref name="TValue"/> 的隐式转换。
        /// </summary>
        /// <param name="value">结果的返回值。</param>
        /// <returns>表示包含返回值的结果。</returns>
        public static implicit operator Result<TValue>(TValue value)
        {
            if(value == null) return null;
            return new Result<TValue>(value);
        }

        /// <summary>
        /// 将当前结果切换到忽略状态。并清空值。
        /// </summary>
        public override void ToIgnored()
        {
            base.ToIgnored();
            this._Value = default(TValue);
        }

        /// <summary>
        /// 返回以字符串形式描述的结果。
        /// </summary>
        /// <returns>如果这是一个成功的操作结果，将返回字符串形式的值，否则返回异常的描述信息。</returns>
        public override string ToString()
        {
            if(this.IsSucceed)
            {
                if(this._Value == null) return string.Empty;
                return this._Value.ToString();
            }
            return base.ToString();
        }

        /// <summary>
        /// 将当前结果切换到成功的状态，并且清除结果的错误信息。
        /// </summary>
        /// <param name="value">结果返回的值。</param>
        public void ToSuccessed(TValue value)
        {
            base.ToSuccessed();
            this._Value = value;
        }

        /// <summary>
        /// 指示一个结果，与当前结果进行校验。如果 <paramref name="result"/> 是一个错误结果，那么当前的结果将会转换为错误状态。否则将会转换 <paramref name="result"/> 的状态。
        /// </summary>
        /// <param name="result">比较的结果。</param>
        /// <param name="value">状态为成功时的返回值。</param>
        /// <returns>返回一个值，表示结果是否为成功状态。</returns>
        public bool Checking(Result result, TValue value)
        {
            var b = base.Checking(result);
            if(b)
            {
                this._Value = value;
            }
            return b;
        }

        #endregion Methods
    }
}