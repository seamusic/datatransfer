using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sofire.Serialization.BinarySuite;

namespace Sofire.Serialization
{
    /// <summary>
    /// 表示一个快速的二进制序列化器。
    /// </summary>
    public class FastBinarySerializer : SerializerBase
    {
        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.FastBinarySerializer"/> 的新实例。
        /// </summary>
        public FastBinarySerializer() : this(Encoding.UTF8) { }

        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.FastBinarySerializer"/> 的新实例。
        /// </summary>
        /// <param name="encoding">字符编码。</param>
        public FastBinarySerializer(Encoding encoding) : base(encoding) { }

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">序列化的流。</param>
        /// <returns>返回序列化对象。</returns>
        protected override object Reading<TData>(Stream stream)
        {
            return new BinaryReadHelper(stream, this.Encoding).Read();
        }

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">可序列化的流。</param>
        /// <param name="data">可序列化的对象。</param>
        protected override void Writing<TData>(Stream stream, TData data)
        {
            new BinaryWriteHelper(stream, this.Encoding).Write(data);
        }
    }
}
