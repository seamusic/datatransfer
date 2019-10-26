using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sofire
{
    /// <summary>
    /// 日志输出时发生的委托。
    /// </summary>
    /// <param name="value">输出的字符串。</param>
    public delegate void LogWriterHandler(string value);

    /// <summary>
    /// 表示一个日志输出器。
    /// </summary>
    public class LogWriter : TextWriter
    {
        Stream _stream;
        /// <summary>
        /// 当日志输出时发生。
        /// </summary>
        public event LogWriterHandler Writing;

        private Encoding _Encoding;
        /// <summary>
        /// 返回用来写输出的 <see cref="System.Text.Encoding"/>。
        /// </summary>
        public override Encoding Encoding
        {
            get { return this._Encoding; }
        }

        /// <summary>
        /// 指定日志输出路径，初始化 <see cref="Sofire.LogWriter"/> 的新实例。
        /// </summary>
        /// <param name="logPath">日志输出的路径。</param>
        public LogWriter(string logPath) : this(logPath, null) { }

        /// <summary>
        /// 指定日志输出路径和编码格式，初始化 <see cref="Sofire.LogWriter"/> 的新实例。
        /// </summary>
        /// <param name="logPath">日志输出的路径。</param>
        /// <param name="encoding">输出的编码格式。</param>
        public LogWriter(string logPath, Encoding encoding)
            : this(new FileStream(logPath, FileMode.OpenOrCreate, FileAccess.Write), encoding) { }

        /// <summary>
        /// 指定日志输出流，初始化 <see cref="Sofire.LogWriter"/> 的新实例。
        /// </summary>
        /// <param name="stream">日志输出的流。可以为 null 值。</param>
        public LogWriter(Stream stream) : this(stream, null) { }

        /// <summary>
        /// 指定日志输出流，初始化 <see cref="Sofire.LogWriter"/> 的新实例。
        /// </summary>
        /// <param name="stream">日志输出的流。可以为 null 值。</param>
        /// <param name="encoding">输出的编码格式。</param>
        public LogWriter(Stream stream, Encoding encoding)
        {
            this._stream = stream;
            this._Encoding = encoding ??System.Text.Encoding.UTF8;

        }

        /// <summary>
        /// [该属性已失效]获取控制格式设置的对象。
        /// </summary>
        public override IFormatProvider FormatProvider
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private void WriteFile(byte[] bytes)
        {
            if(this._stream != null)
            {
                this._stream.Write(bytes, 0, bytes.Length);
            }
        }

        private void WriteString(string value)
        {
            if(this._IsDisposed) throw new ObjectDisposedException(this.GetType().FullName);
            if(this.Writing != null)
            {
                this.Writing(value + Environment.NewLine);
            }

            this.WriteFile(this._Encoding.GetBytes(value));

        }

        /// <summary>
        /// 将字符写入文本流。
        /// </summary>
        /// <param name="value">要写入文本流中的字符。</param>
        public override void Write(char value)
        {
            if(this._IsDisposed) throw new ObjectDisposedException(this.GetType().FullName);
            if(this.Writing != null)
            {
                this.Writing(value.ToString());
            }

            this.WriteFile(this._Encoding.GetBytes(new char[1] { value }));
        }

        /// <summary>
        /// 将字符串写入文本流。
        /// </summary>
        /// <param name="value">要写入的字符串。</param>
        public override void Write(string value)
        {
            if(!string.IsNullOrEmpty(value)) this.WriteString(value);
        }

        /// <summary>
        /// 将后跟行结束符的字符串写入文本流。
        /// </summary>
        /// <param name="value">要写入的字符串。如果 value 为 null，则仅写入行结束字符。</param>
        public override void WriteLine(string value)
        {
            this.WriteString(value + this.NewLine);
        }

        /// <summary>
        /// 将字符的子数组写入文本流。
        /// </summary>
        /// <param name="buffer">要从中写出数据的字符数组。</param>
        /// <param name="index">在缓冲区中开始索引。</param>
        /// <param name="count">要写入的字符数。</param>
        public override void Write(char[] buffer, int index, int count)
        {
            base.Write(buffer, index, count);
            if(this._IsDisposed) throw new ObjectDisposedException(this.GetType().FullName);
            else if(buffer == null) throw new ArgumentNullException("buffer");
            else if(index < 0) throw new ArgumentOutOfRangeException("index");
            else if(count < 0) throw new ArgumentOutOfRangeException("count");
            else if((buffer.Length - index) < count) throw new ArgumentException("索引超出长度。");
            else
            {
                if(this.Writing != null)
                {
                    this.Writing(new string(buffer, index, count));
                }

                this.WriteFile(this._Encoding.GetBytes(buffer, index, count));
            }
        }

        /// <summary>
        /// 清理当前编写器的所有缓冲区，使所有缓冲数据写入基础设备。
        /// </summary>
        public override void Flush()
        {
            if(this._stream != null) this._stream.Flush();
        }

        private bool _IsDisposed;
        /// <summary>
        /// 指示 <see cref="Sofire.LogWriter"/> 是否已被释放。
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                return this._IsDisposed;
            }
        }

        /// <summary>
        /// 释放由 <see cref="Sofire.LogWriter"/> 占用的非托管资源，还可以另外再释放托管资源。
        /// </summary>
        /// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
        protected override void Dispose(bool disposing)
        {
            // Close 也会调用此函数
            if(this._IsDisposed) return;
            this._IsDisposed = true;
            if(this._stream != null)
            {
                this._stream.Dispose();
                this._stream = null;
            }
            base.Dispose(disposing);
        }
    }
}
