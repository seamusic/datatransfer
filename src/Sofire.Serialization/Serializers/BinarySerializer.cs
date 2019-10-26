#if !SILVERLIGHT
namespace Sofire.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    /// <summary>
    /// 表示二进制的序列化器。
    /// </summary>
    public class BinarySerializer : SerializerBase
    {
        #region Constructors

        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.BinarySerializer"/> 的新实例。
        /// </summary>
        public BinarySerializer()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.BinarySerializer"/> 的新实例。
        /// </summary>
        /// <param name="encoding">字符编码。</param>
        public BinarySerializer(Encoding encoding)
            : base(encoding)
        {
        }

        #endregion Constructors

        #region Events

        /// <summary> 
        /// 创建序列化器。
        /// </summary>
        public event Function<BinaryFormatter> CreateSerializer;

        #endregion Events

        #region Methods

        /// <summary>
        /// 获取序列化器。
        /// </summary>
        /// <returns>返回一个序列化器。</returns>
        protected virtual BinaryFormatter GetSerializer()
        {
            if(CreateSerializer == null)
            {
                var b = new BinaryFormatter();
                b.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;

                return b;
            }
            return this.CreateSerializer();
        }

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">序列化的流。</param>
        /// <returns>返回序列化对象。</returns>
        protected override object Reading<TData>(Stream stream)
        {
            return this.GetSerializer().Deserialize(stream);
        }

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">可序列化的流。</param>
        /// <param name="data">可序列化的对象。</param>
        protected override void Writing<TData>(Stream stream, TData data)
        {
            this.GetSerializer().Serialize(stream, data);
        }

        #endregion Methods
    }
}
#endif