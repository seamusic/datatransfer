namespace System
{
    #region Delegates

    /// <summary>
    /// 表示异常信息的事件方法。
    /// </summary>
    /// <param name="sender">对象。</param>
    /// <param name="e">参数。</param>
    public delegate void ExceptionEventHandler(object sender, ExceptionEventArgs e);

    #endregion Delegates

    /// <summary>
    /// 表示异常信息的事件参数。
    /// </summary>
    public class ExceptionEventArgs : EventArgs
    {
        #region Fields

        /// <summary>
        /// 表示抛出的异常。
        /// </summary>
        protected Exception _exception;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.ExceptionEventArgs "/> 的新实例。
        /// </summary>
        public ExceptionEventArgs()
        {
        }

        /// <summary>
        /// 初始化 <see cref="System.ExceptionEventArgs "/> 的新实例。
        /// </summary>
        /// <param name="exception">异常。</param>
        public ExceptionEventArgs(Exception exception)
        {
            this._exception = exception;
        }

        /// <summary>
        /// 初始化 <see cref="System.ExceptionEventArgs "/> 的新实例。
        /// </summary>
        /// <param name="message">异常信息。</param>
        public ExceptionEventArgs(string message)
            : this(new Exception(message))
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 获取一个值，表示抛出的异常。
        /// </summary>
        public virtual Exception Exception
        {
            get { return this._exception; }
            set { this._exception = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 设置当前异常信息。
        /// </summary>
        /// <param name="message">异常信息。</param>
        public void SetException(string message)
        {
            this._exception = new Exception(message);
        }

        #endregion Methods
    }
}