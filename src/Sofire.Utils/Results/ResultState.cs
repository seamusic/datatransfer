namespace System
{
    #region Enumerations

    /// <summary>
    /// 表示 <see cref="System.Result" /> 的状态。
    /// </summary>
    public enum ResultState
    {
        /// <summary>
        /// 成功的结果。
        /// </summary>
        Failed = -1,
        /// <summary>
        /// 失败的结果。
        /// </summary>
        Succeed = 0,
        /// <summary>
        /// 忽略的结果。
        /// </summary>
        Ignored,
    }

    #endregion Enumerations
}