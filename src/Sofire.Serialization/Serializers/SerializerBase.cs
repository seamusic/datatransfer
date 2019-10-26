namespace Sofire.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// 表示一个序列化器基类。
    /// </summary>
    public abstract class SerializerBase : IObjectSerializer
    {
        #region Fields

        private Encoding _Encoding;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.SerializerBase"/> 的新实例。
        /// </summary>
        public SerializerBase()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.SerializerBase"/> 的新实例。
        /// </summary>
        /// <param name="encoding">字符编码。</param>
        public SerializerBase(Encoding encoding)
        {
            this._Encoding = encoding;
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// 表示读取后发生，其中 sender 参数是一个 System.Result 返回值。
        /// </summary>
        public event EventHandler ReadFinish;

        /// <summary>
        /// 表示写入后发生，其中 sender 参数是一个 System.Result 返回值。
        /// </summary>
        public event EventHandler WriteFinish;

        #endregion Events

        #region Properties

        /// <summary>
        /// 设置或获取一个值，表示字符编码。
        /// </summary>
        public Encoding Encoding
        {
            get
            {
                if(this._Encoding == null) return Encoding.UTF8;
                return this._Encoding;
            }
            set
            {
                this._Encoding = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="path">序列化的路径。</param>
        /// <returns>返回序列化对象的结果。</returns>
        public Result<TData> Read<TData>(string path)
        {
            if(string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");
            using(var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return this.Read<TData>(stream);
            }
        }

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">序列化的流。</param>
        /// <returns>返回序列化对象的结果。</returns>
        public Result<TData> Read<TData>(Stream stream)
        {
            Result<TData> result = new Result<TData>();
            try
            {
                result.Value = (TData)this.Reading<TData>(stream);
            }
            catch(Exception ex)
            {
                result.ToFailded(ex);
            }
            finally
            {
                this.OnReadFinish(result);
            }
            return result;
        }

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="content">可序列化为对象的内容文本。</param>
        /// <returns>返回序列化对象的结果。</returns>
        public Result<TData> ReadString<TData>(string content)
        {
            if(string.IsNullOrEmpty(content))
                return new ArgumentNullException("data");
            using(MemoryStream stream = new MemoryStream(this.Encoding.GetBytes(content)))
            {
                return this.Read<TData>(stream);
            }
        }

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="path">序列化的路径。</param>
        /// <param name="data">可序列化的对象。</param>
        /// <returns>返回一个结果，指示序列化是否成功。</returns>
        public Result Write<TData>(string path, TData data)
        {
            using(var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                return this.Write<TData>(stream, data);
            }
        }

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">可序列化的流。</param>
        /// <param name="data">可序列化的对象。</param>
        /// <returns>返回一个结果，指示序列化是否成功。</returns>
        public Result Write<TData>(Stream stream, TData data)
        {
            Result result = new Result();
            try
            {
                this.Writing<TData>(stream, data);
            }
            catch(Exception ex)
            {
                result.ToFailded(ex);
            }
            finally
            {
                this.OnWriteFinish(result);
            }
            return result;
        }

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="data">可序列化为字符串的对象。</param>
        /// <returns>返回一个结果，指示序列化是否成功。</returns>
        public StringResult WriteString<TData>(TData data)
        {
            StringResult result = new StringResult();

            using(MemoryStream stream = new MemoryStream())
            {
                var r = this.Write<TData>(stream, data);
                if(r.IsSucceed)
                {
                    stream.Position = 0;
                    var v = stream.ToArray();
                    result.Value = this.Encoding.GetString(v, 0, v.Length);
                }
                else
                {
                    result.ToFailded(r.Exception);
                }
            }
            return result;
        }

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="data">可序列化为字符串的对象。</param>
        /// <returns>返回一个结果，指示序列化是否成功。</returns>
        public Result<byte[]> WriteBytes<TData>(TData data)
        {
            using(MemoryStream stream = new MemoryStream())
            {
                var r = this.Write(stream, data);
                if(r.IsFailed) return r.Exception;
                return stream.ToArray();
            }
        }

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="bytes">可序列化为对象的二进制数组。</param>
        /// <returns>返回序列化对象的结果。</returns>
        public Result<TData> ReadBytes<TData>(byte[] bytes)
        {
            using(MemoryStream stream = new MemoryStream(bytes))
            {
                return this.Read<TData>(stream);
            }
        }

        /// <summary>
        /// 快速写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="data">可序列化为字符串的对象。</param>
        /// <returns>返回一个二进制数组。</returns>
        public byte[] FastWriteBytes<TData>(TData data)
        {
            var r = this.WriteBytes<TData>(data);
            if(r.IsFailed) throw r.Exception;
            return r.Value;
        }

        /// <summary>
        /// 快速读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="bytes">可序列化为对象的二进制数组。</param>
        /// <returns>返回序列化对象的对象。</returns>
        public TData FastReadBytes<TData>(byte[] bytes)
        {
            var r = this.ReadBytes<TData>(bytes);
            if(r.IsFailed) throw r.Exception;
            return r.Value;
        }

        /// <summary>
        /// 表示引发 <see cref="Sofire.Serialization.SerializerBase.ReadFinish"/> 事件。
        /// </summary>
        /// <param name="result">读取的返回值。</param>
        protected virtual void OnReadFinish(object result)
        {
            if(this.ReadFinish != null)
                this.ReadFinish(result, EventArgs.Empty);
        }

        /// <summary>
        /// 表示引发 <see cref="Sofire.Serialization.SerializerBase.WriteFinish"/> 事件。
        /// </summary>
        /// <param name="result">写入的返回值。</param>
        protected virtual void OnWriteFinish(object result)
        {
            if(this.WriteFinish != null)
                this.WriteFinish(result, EventArgs.Empty);
        }

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">序列化的流。</param>
        /// <returns>返回序列化对象。</returns>
        protected abstract object Reading<TData>(Stream stream);

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">可序列化的流。</param>
        /// <param name="data">可序列化的对象。</param>
        protected abstract void Writing<TData>(Stream stream, TData data);

        #endregion Methods
    }
}