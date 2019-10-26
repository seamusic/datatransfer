namespace System
{
    /// <summary>
    /// 表示一个结果（接口）。
    /// </summary>
    public interface IResult
    {
        #region Properties

        /// <summary>
        /// 获取执行时发生的错误。
        /// </summary>
        Exception Exception
        {
            get;
        }

        /// <summary>
        /// 获取一个值，表示执行结果是否为失败。
        /// </summary>
        bool IsFailed
        {
            get;
        }

        /// <summary>
        /// 获取一个值，表示执行结果是否为忽略。
        /// </summary>
        bool IsIgnored
        {
            get;
        }

        /// <summary>
        /// 获取一个值，表示执行结果是否为成功。
        /// </summary>
        bool IsSucceed
        {
            get;
        }

        /// <summary>
        /// 获取执行的状态。
        /// </summary>
        ResultState State
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 指定错误信息，将当前结果切换到失败的状态。
        /// </summary>
        void ToFailded(Exception exception);

        /// <summary>
        /// 指定错误信息，将当前结果切换到失败的状态。
        /// </summary>
        void ToFailded(string exceptionMessage);

        /// <summary>
        /// 将当前结果切换到忽略的状态。
        /// </summary>
        void ToIgnored();

        /// <summary>
        /// 将当前结果切换到成功的状态，并且清除结果的错误信息。
        /// </summary>
        void ToSuccessed();

        /// <summary>
        /// 指示一个结果，与当前结果进行校验。如果 <paramref name="result"/> 是一个错误结果，那么当前的结果将会转换为错误状态。否则将会转换 <paramref name="result"/> 的状态。
        /// </summary>
        /// <param name="result">比较的结果。</param>
        /// <returns>返回一个值，表示结果是否为成功状态。</returns>
        bool Checking(Result result);

        #endregion Methods
    }

    /// <summary>
    /// 表示包含一个返回值的结果（接口）。
    /// </summary>
    /// <typeparam name="TValue">返回值的类型。</typeparam>
    public interface IResult<TValue> : IResult
    {
        #region Properties

        /// <summary>
        /// 设置或获取结果的返回值。若结果不处于成功的状态，将返回默认值。
        /// </summary>
        TValue Value
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 将当前结果切换到成功的状态，并且清除结果的错误信息。
        /// </summary>
        /// <param name="value">结果返回的值。</param>
        void ToSuccessed(TValue value);

        /// <summary>
        /// 指示一个结果，与当前结果进行校验。如果 <paramref name="result"/> 是一个错误结果，那么当前的结果将会转换为错误状态。否则将会转换 <paramref name="result"/> 的状态。
        /// </summary>
        /// <param name="result">比较的结果。</param>
        /// <param name="value">状态为成功时的返回值。</param>
        /// <returns>返回一个值，表示结果是否为成功状态。</returns>
        bool Checking(Result result, TValue value);

        #endregion Methods
    }

    /// <summary>
    /// 表示包含两个返回值的结果（接口）。
    /// </summary>
    /// <typeparam name="TValue1">第一个返回值的类型。</typeparam>
    /// <typeparam name="TValue2">第二个返回值的类型。</typeparam>
    public interface IResult<TValue1, TValue2> : IResult
    {
        #region Properties

        /// <summary>
        /// 设置或获取结果的第一个返回值。若结果不处于成功的状态，将返回默认值。
        /// </summary>
        TValue1 Value1
        {
            get; set;
        }

        /// <summary>
        /// 设置或获取结果的第二个返回值。若结果不处于成功的状态，将返回默认值。
        /// </summary>
        TValue2 Value2
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 将当前结果切换到成功的状态，并且清除结果的错误信息。
        /// </summary>
        /// <param name="value1">结果的第一个返回值。</param>
        /// <param name="value2">结果的第二个返回值。</param>
        void ToSuccessed(TValue1 value1, TValue2 value2);

        /// <summary>
        /// 指示一个结果，与当前结果进行校验。如果 <paramref name="result"/> 是一个错误结果，那么当前的结果将会转换为错误状态。否则将会转换 <paramref name="result"/> 的状态。
        /// </summary>
        /// <param name="result">比较的结果。</param>
        /// <param name="value1">状态为成功时的第一个返回值。</param>
        /// <param name="value2">状态为成功时的第二个返回值。</param>
        /// <returns>返回一个值，表示结果是否为成功状态。</returns>
        bool Checking(Result result, TValue1 value1, TValue2 value2);

        #endregion Methods
    }
}