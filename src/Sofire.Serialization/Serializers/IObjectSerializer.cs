namespace Sofire.Serialization
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// 表示一个对象序列化器的接口。
    /// </summary>
    public interface IObjectSerializer
    {
        #region Properties

        /// <summary>
        /// 设置或获取一个值，表示字符编码。默认为 UTF8。
        /// </summary>
        Encoding Encoding
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="path">序列化的路径。</param>
        /// <returns>返回序列化对象的结果。</returns>
        Result<TData> Read<TData>(string path);

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">序列化的流。</param>
        /// <returns>返回序列化对象的结果。</returns>
        Result<TData> Read<TData>(Stream stream);

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="data">可序列化为对象的内容文本。</param>
        /// <returns>返回序列化对象的结果。</returns>
        Result<TData> ReadString<TData>(string data);

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="path">序列化的路径。</param>
        /// <param name="data">可序列化的对象。</param>
        /// <returns>返回一个结果，指示序列化是否成功。</returns>
        Result Write<TData>(string path, TData data);

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">可序列化的流。</param>
        /// <param name="data">可序列化的对象。</param>
        /// <returns>返回一个结果，指示序列化是否成功。</returns>
        Result Write<TData>(Stream stream, TData data);

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="data">可序列化为字符串的对象。</param>
        /// <returns>返回一个结果，指示序列化是否成功。</returns>
        StringResult WriteString<TData>(TData data);

        #endregion Methods
    }
}