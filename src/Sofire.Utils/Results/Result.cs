namespace System
{
    /// <summary>
    /// 表示一个结果。
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Result : IResult
    {
        #region Fields

        /// <summary>
        /// 表示成功状态的操作结果的字符串形式。
        /// </summary>
        private const string IgnoredString = "结果已被忽略！";

        /// <summary>
        /// 表示成功状态的操作结果的字符串形式。
        /// </summary>
        private const string SuccessedString = "执行成功！";
#if !SILVERLIGHT
        [NonSerialized]
#endif
        private Exception _Exception;
        private string _exceptionMessage;
        private ResultState _State = ResultState.Succeed;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.Result"/> 的新实例。
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// 指定引发的异常，初始化 <see cref="System.Result"/> 的新实例。
        /// </summary>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        public Result(Exception exception)
        {
            this.ToFailded(exception);
        }

        /// <summary>
        /// 指定描述错误的信息，初始化 <see cref="System.Result"/> 的新实例。
        /// </summary>
        /// <param name="exceptionMessage">描述错误的信息。</param>
        public Result(string exceptionMessage)
        {
            this.ToFailded(exceptionMessage);
        }

        #endregion Constructors

        #region Properties


        private class SuccessfullyResult : Result
        {
            static readonly Exception ReadOnlyException = new Exception("System.Result.Successfully 成功结果不允许修改其状态。");

            public override Exception Exception
            {
                get
                {
                    return null;
                }
            }
            public override bool IsFailed
            {
                get
                {
                    return false;
                }
            }
            public override bool IsIgnored
            {
                get
                {
                    return false;
                }
            }
            public override bool IsSucceed
            {
                get
                {
                    return true;
                }
            }
            public override ResultState State
            {
                get
                {
                    return ResultState.Succeed;
                }
            }

            public override void ToFailded(Exception exception)
            {
                throw ReadOnlyException;
            }
            public override void ToIgnored()
            {
                throw ReadOnlyException;
            }
            public override void ToFailded(string exceptionMessage)
            {
                throw ReadOnlyException;
            }
        }

        /// <summary>
        /// 表示成功、且无法修改的结果。
        /// </summary>
        public static Result Successfully = new SuccessfullyResult();


        /// <summary>
        /// 获取执行时发生的错误。结果状态非 <see cref="System.ResultState.Failed"/> 时，该值为 null 值。
        /// </summary>
        public virtual Exception Exception
        {
            get
            {
                if(this._State != ResultState.Succeed && this._Exception == null)
                {
                    if(this._exceptionMessage == null) this._Exception = new Exception("被忽略的结果。");
                    else this._Exception = new Exception(this._exceptionMessage);
                }
                return this._Exception;
            }
        }

        /// <summary>
        /// 获取一个值，表示执行结果是否为失败。
        /// </summary>
        public virtual bool IsFailed
        {
            get { return this._State == ResultState.Failed; }
        }

        /// <summary>
        /// 获取一个值，表示执行结果是否为忽略。
        /// </summary>
        public virtual bool IsIgnored
        {
            get { return this._State == ResultState.Ignored; }
        }

        /// <summary>
        /// 获取一个值，表示执行结果是否为成功。
        /// </summary>
        public virtual bool IsSucceed
        {
            get { return this._State == ResultState.Succeed; }
        }

        /// <summary>
        /// 获取执行的状态。
        /// </summary>
        public virtual ResultState State
        {
            get { return this._State; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// <see cref="System.Result"/> 和 <see cref="System.Exception"/> 的隐式转换。
        /// </summary>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。</param>
        /// <returns>表示一个异常的结果。</returns>
        public static implicit operator Result(Exception exception)
        {
            if(exception == null) return Result.Successfully;
            return new Result(exception);
        }

        /// <summary>
        /// <see cref="System.Result"/> 和 <see cref="System.String"/> 的隐式转换。
        /// </summary>
        /// <param name="exceptionMessage">描述异常结果的信息。</param>
        /// <returns>表示一个异常的结果。</returns>
        public static implicit operator Result(string exceptionMessage)
        {
            if(exceptionMessage == null) return Result.Successfully;
            return new Result(exceptionMessage);
        }

        /// <summary>
        /// <see cref="System.String"/> 和 <see cref="System.Result"/> 的隐式转换。
        /// </summary>
        /// <param name="result">返回结果。</param>
        /// <returns>返回字符串形式的结果。如果该结果为 null 值，则返回 null 值。</returns>
        public static implicit operator string(Result result)
        {
            if(result == null) return null;
            return result.ToString();
        }

        /// <summary>
        /// 指定错误信息，将当前结果切换到失败状态。
        /// </summary>
        /// <param name="exception">引发异常的 <see cref="System.Exception"/>。如果为 null 值，将不会更改返回结果的状态。</param>
        public virtual void ToFailded(Exception exception)
        {
            if(exception == null)
                return;
            this._Exception = exception;
            this._exceptionMessage = exception == null
                ? null
#if DEBUG
 : exception.ToString();
#else
             : exception.Message;
#endif
            this._State = ResultState.Failed;
        }

        /// <summary>
        /// 指定错误信息，将当前结果切换到失败状态。
        /// </summary>
        /// <param name="exceptionMessage">描述错误的信息。</param>
        public virtual void ToFailded(string exceptionMessage)
        {
            this._exceptionMessage = exceptionMessage;
            this._Exception = exceptionMessage == null ? null : new Exception(exceptionMessage);
            this._State = ResultState.Failed;
        }

        /// <summary>
        /// 将当前结果切换到忽略状态。
        /// </summary>
        public virtual void ToIgnored()
        {
            this._State = ResultState.Ignored;
        }

        /// <summary>
        /// 返回以字符串形式描述的结果。
        /// </summary>
        /// <returns>如果这是一个成功的操作结果，将返回“执行成功！”，否则返回异常的描述信息。</returns>
        public override string ToString()
        {
            switch(this._State)
            {
                case ResultState.Failed:
                    return this._exceptionMessage;

                case ResultState.Ignored:
                    return Result.IgnoredString + this._exceptionMessage;
                case ResultState.Succeed:
                default:
                    return Result.SuccessedString;
            }
        }

        /// <summary>
        /// 将当前结果切换到成功状态，并且清除结果的错误信息。
        /// </summary>
        public void ToSuccessed()
        {
            this._State = ResultState.Succeed;
            this._exceptionMessage = null;
            this._Exception = null;
        }

        /// <summary>
        /// 指示一个结果，与当前结果进行校验。如果 <paramref name="result"/> 是一个错误结果，那么当前的结果将会转换为错误状态。否则将会转换 <paramref name="result"/> 的状态。
        /// </summary>
        /// <param name="result">比较的结果。</param>
        /// <returns>返回一个值，表示结果是否为成功状态。</returns>
        public bool Checking(Result result)
        {
            this._Exception = result._Exception;
            this._exceptionMessage = result._exceptionMessage;
            this._State = result._State;
            return this._State == ResultState.Succeed;
        }

        #endregion Methods
    }
}