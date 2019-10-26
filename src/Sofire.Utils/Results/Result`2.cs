namespace System
{
    /// <summary>
    /// 表示包含两个返回值的结果。
    /// </summary>
    /// <typeparam name="TValue1">第一个返回值的类型。</typeparam>
    /// <typeparam name="TValue2">第二个返回值的类型。</typeparam>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Result<TValue1, TValue2> : Result, IResult<TValue1, TValue2>
    {
        #region Fields

        /// <summary>
        /// 获取结果的第一个返回值。若结果不处于成功的状态，将返回默认值。
        /// </summary>
        protected TValue1 _Value1;

        /// <summary>
        /// 获取结果的第二个返回值。若结果不处于成功的状态，将返回默认值。
        /// </summary>
        protected TValue2 _Value2;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.Result&lt;TValue1,TValue2&gt;"/> 的新实例。
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// 指定结果的返回值，初始化 <see cref="System.Result&lt;TValue1,TValue2&gt;"/> 的新实例。
        /// </summary>
        /// <param name="value1">结果的第一个返回值。</param>
        /// <param name="value2">结果的第二个返回值。</param>
        public Result(TValue1 value1, TValue2 value2)
        {
            this._Value1 = value1;
            this._Value2 = value2;
        }

        /// <summary>
        /// 指定结果的返回值和引发的异常，初始化 <see cref="System.Result&lt;TValue1,TValue2&gt;"/> 的新实例。
        /// </summary>
        /// <param name="value1">结果的第一个返回值。</param>
        /// <param name="value2">结果的第二个返回值。</param>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        public Result(TValue1 value1, TValue2 value2, Exception exception)
            : base(exception)
        {
            if(exception == null)
            {
                this._Value1 = value1;
                this._Value2 = value2;
            }
        }

        /// <summary>
        /// 指定引发的异常，初始化 <see cref="System.Result&lt;TValue1,TValue2&gt;"/> 的新实例。
        /// </summary>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        public Result(Exception exception)
            : base(exception)
        {
        }

        /// <summary>
        /// 指定描述异常的信息，初始化 <see cref="System.Result&lt;TValue1,TValue2&gt;"/> 的新实例。
        /// </summary>
        /// <param name="exceptionMessage">描述错误的信息。</param>
        public Result(string exceptionMessage)
            : base(exceptionMessage)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 设置或获取结果的第一个返回值。若结果不处于成功的状态，将返回默认值。
        /// </summary>
        public TValue1 Value1
        {
            get
            {
                return this._Value1;
            }
            set
            {
                this._Value1 = value;
            }
        }

        /// <summary>
        /// 设置或获取结果的第二个返回值。若结果不处于成功的状态，将返回默认值。
        /// </summary>
        public TValue2 Value2
        {
            get
            {
                return this._Value2;
            }
            set
            {
                this._Value2 = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// <see cref="System.Result&lt;TValue1,TValue2&gt;"/> 和 <see cref="System.Exception"/> 的隐式转换。
        /// </summary>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        /// <returns>表示一个异常的结果。</returns>
        public static implicit operator Result<TValue1, TValue2>(Exception exception)
        {
            return new Result<TValue1, TValue2>(exception);
        }

        /// <summary>
        /// <see cref="System.Result&lt;TValue1,TValue2&gt;"/> 和 <see cref="System.String"/> 的隐式转换。
        /// </summary>
        /// <param name="exceptionMessage">描述错误的信息。</param>
        /// <returns>表示一个异常的结果。</returns>
        public static implicit operator Result<TValue1, TValue2>(string exceptionMessage)
        {
            return new Result<TValue1, TValue2>(exceptionMessage);
        }

        /// <summary>
        /// 将当前结果切换到忽略状态。并清空两个值。
        /// </summary>
        public override void ToIgnored()
        {
            base.ToIgnored();
            this._Value1 = default(TValue1);
            this._Value2 = default(TValue2);
        }

        /// <summary>
        /// 返回以字符串形式描述的结果。
        /// </summary>
        /// <returns>如果这是一个成功的操作结果，将返回字符串形式的值，否则返回异常的描述信息。</returns>
        public override string ToString()
        {
            if(this.IsSucceed)
            {
                return string.Concat(this._Value1, this._Value2);
            }
            return base.ToString();
        }

        /// <summary>
        /// 将当前结果切换到成功的状态，并且清除结果的错误信息。
        /// </summary>
        /// <param name="value1">结果的第一个返回值。</param>
        /// <param name="value2">结果的第二个返回值。</param>
        public void ToSuccessed(TValue1 value1, TValue2 value2)
        {
            base.ToSuccessed();
            this._Value1 = value1;
            this._Value2 = value2;
        }

        /// <summary>
        /// 指示一个结果，与当前结果进行校验。如果 <paramref name="result"/> 是一个错误结果，那么当前的结果将会转换为错误状态。否则将会转换 <paramref name="result"/> 的状态。
        /// </summary>
        /// <param name="result">比较的结果。</param>
        /// <param name="value1">状态为成功时的第一个返回值。</param>
        /// <param name="value2">状态为成功时的第二个返回值。</param>
        /// <returns>返回一个值，表示结果是否为成功状态。</returns>
        public bool Checking(Result result, TValue1 value1, TValue2 value2)
        {
            var b = base.Checking(result);
            if(b)
            {
                this._Value1 = value1;
                this._Value2 = value2;
            }
            return b;
        }

        #endregion Methods
    }
}