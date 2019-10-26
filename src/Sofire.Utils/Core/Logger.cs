namespace System
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// 表示一条日志的描述。
    /// </summary>
    public class LogEntry
    {
        #region Fields

        private DateTime _DataTime = DateTime.Now;
        private string _Group;
        private string _Message;
        private string _Source;
        private string _Title;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 初始化 System.LogEntry 的新实例。
        /// </summary>
        /// <param name="message">日志的消息。</param>
        public LogEntry(string message)
            : this(null, null, null, message)
        {
        }

        /// <summary>
        /// 初始化 System.LogEntry 的新实例。
        /// </summary>
        /// <param name="title">日志的标题。</param>
        /// <param name="message">日志的消息。</param>
        public LogEntry(string title, string message)
            : this(null, null, title, message)
        {
        }

        /// <summary>
        /// 初始化 System.LogEntry 的新实例。
        /// </summary>
        /// <param name="source">日志的源。</param>
        /// <param name="title">日志的标题。</param>
        /// <param name="message">日志的消息。</param>
        public LogEntry(string source, string title, string message)
            : this(null, source, title, message)
        {
        }

        /// <summary>
        /// 初始化 System.LogEntry 的新实例。
        /// </summary>
        /// <param name="group">日志的所在组，可以是一个 null 值。</param>
        /// <param name="source">日志的源。</param>
        /// <param name="title">日志的标题。</param>
        /// <param name="message">日志的消息。</param>
        public LogEntry(string group, string source, string title, string message)
        {
            this._Group = group;
            this._Source = source;
            this._Title = title;
            this._Message = message;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 获取一个值，表示日志的日期时间。
        /// </summary>
        public DateTime DataTime
        {
            get
            {
                return this._DataTime;
            }
        }

        /// <summary>
        /// 获取一个值，表示日志的所在组，这可能是一个 null 值。
        /// </summary>
        public string Group
        {
            get
            {
                return this._Group;
            }
        }

        /// <summary>
        /// 获取一个值，表示日志的消息。
        /// </summary>
        public string Message
        {
            get
            {
                return this._Message;
            }
        }

        /// <summary>
        /// 获取一个值，表示日志的源，这可能是一个 null 值。
        /// </summary>
        public string Source
        {
            get
            {
                return this._Source;
            }
        }

        /// <summary>
        /// 获取一个值，表示日志的标题，这可能是一个 null 值。。
        /// </summary>
        public string Title
        {
            get
            {
                return this._Title;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 返回描述当前日志信息的字符串。
        /// </summary>
        public override string ToString()
        {
            return string.Format(
            @"[Group]
            {0}
            [Source]
            {1}
            [Title]
            {2}
            [DataTime]
            {3}
            [Message]
            {4}", this._Group ?? "Ungroup", this._Source ?? "Unknow", this._Title ?? "Unknow", this._DataTime, this._Message);
        }

        #endregion Methods
    }

    /// <summary>
    /// 日志记录器。
    /// </summary>
    public class Logger
    {
        #region Fields

        private static Logger _Current;

        private bool _Enabled;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.Logger"/> 的新实例。
        /// </summary>
        protected Logger()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 设置或获取一个值，表示当前的日志记录器。
        /// </summary>
        public static Logger Current
        {
            get
            {
                if(_Current == null) _Current = new Logger();
                return _Current;
            }
            set
            {
                _Current = value;
            }
        }

        /// <summary>
        /// 设置或获取一个值，表示是否启用日志记录器。
        /// </summary>
        public bool Enabled
        {
            get
            {
                return this._Enabled;
            }
            set
            {
                this._Enabled = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 写入日志。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="args">包含零个或多个要格式化的对象的 <see cref="System.Object"/> 数组。</param>
        [Conditional("DEBUG")]
        public static void DebugWriteLine(string format, params object[] args)
        {
            Console.WriteLine(string.Format(format, args));
        }

        /// <summary>
        /// 写入异常信息后抛出异常。
        /// </summary>
        /// <param name="source">错误的源。</param>
        /// <param name="message">描述错误的消息。</param>
        public static void ThrowException(string source, string message)
        {
            Logger.ThrowException(source, new Exception(message));
        }

        /// <summary>
        /// 写入异常信息。
        /// </summary>
        /// <param name="source">错误的源。</param>
        /// <param name="exception">异常。</param>
        public static void ThrowException(string source, Exception exception)
        {
            Logger.ExceptionHandler(source, exception, true);
        }

        /// <summary>
        /// 写入异常信息。
        /// </summary>
        /// <param name="source">错误的源。</param>
        /// <param name="message">描述错误的消息。</param>
        public static void WriteException(string source, string message)
        {
            Logger.WriteException(source, new Exception(message));
        }

        /// <summary>
        /// 写入异常信息。
        /// </summary>
        /// <param name="source">错误的源。</param>
        /// <param name="exception">异常。</param>
        public static void WriteException(string source, Exception exception)
        {
            Logger.ExceptionHandler(source, exception, false);
        }

        /// <summary>
        /// 写入日志。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="args">包含零个或多个要格式化的对象的 <see cref="System.Object"/> 数组。</param>
        public static void WriteLine(string format, params object[] args)
        {
            Logger.Current.OnWriteLine(new LogEntry(string.Format(format, args)));
        }

        /// <summary>
        /// 写入日志。
        /// </summary>
        /// <param name="entry">日志的描述。</param>
        public static void WriteLine(LogEntry entry)
        {
            Logger.Current.OnWriteLine(entry);
        }

        /// <summary>
        /// 当写入异常信息时发生。
        /// </summary>
        /// <param name="source">错误的源。</param>
        /// <param name="exception">异常。</param>
        /// <param name="throwIt">指示是否抛出异常。</param>
        protected virtual void OnException(string source, Exception exception, bool throwIt)
        {
            if(throwIt) throw exception;
        }

        /// <summary>
        /// 当写入日志时发生。
        /// </summary>
        /// <param name="entry">日志的描述。</param>
        protected virtual void OnWriteLine(LogEntry entry)
        {
        }

        private static void ExceptionHandler(string source, Exception exception, bool throwIt)
        {
            Logger.DebugWriteLine("{0} 引发的异常：{1}", source, exception);
            Logger.Current.OnException(source, exception, throwIt);
        }

        #endregion Methods
    }
}