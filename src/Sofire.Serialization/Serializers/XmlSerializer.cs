#if !SILVERLIGHT
namespace Sofire.Serialization
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// 表示 XML 的序列化器。
    /// </summary>
    public class XmlSerializer : SerializerBase
    {
        #region Constructors

        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.XmlSerializer"/> 的新实例。
        /// </summary>
        public XmlSerializer()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.XmlSerializer"/> 的新实例。
        /// </summary>
        /// <param name="encoding">字符编码。</param>
        public XmlSerializer(Encoding encoding)
            : base(encoding)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// 获取序列化器。
        /// </summary>
        /// <returns>返回一个序列化器。</returns>
        protected virtual System.Xml.Serialization.XmlSerializer GetSerializer(Type type)
        {
            return new System.Xml.Serialization.XmlSerializer(type);
        }

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">序列化的流。</param>
        /// <returns>返回序列化对象。</returns>
        protected override object Reading<TData>(Stream stream)
        {
            return this.GetSerializer(typeof(TData)).Deserialize(stream);
        }

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">可序列化的流。</param>
        /// <param name="data">可序列化的对象。</param>
        protected override void Writing<TData>(Stream stream, TData data)
        {
            this.GetSerializer(typeof(TData)).Serialize(stream, data);
        }

        #endregion Methods
    }
}
#endif