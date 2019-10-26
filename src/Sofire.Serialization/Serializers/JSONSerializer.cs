#if !SILVERLIGHT
using System.IO;
using System.Text;

namespace Sofire.Serialization
{
    /// <summary>
    /// 基于 FastJSON 的序列化器。
    /// </summary>
    public class JSONSerializer : SerializerBase
    {
        /// <summary>
        /// 设置或获取一个值，是否优化数据集结构。默认为 true。
        /// </summary>
        public static bool UseOptimizedDatasetSchema
        {
            get
            {
                return fastJSON.JSON.Instance.UseOptimizedDatasetSchema;
            }
            set
            {
                fastJSON.JSON.Instance.UseOptimizedDatasetSchema = value;
            }
        }
        /// <summary>
        /// 设置或获取一个值，是否快速 序列化/反序列化 <see cref="System.Guid"/>。默认为 true。
        /// </summary>
        public static bool UseFastGuid
        {
            get
            {
                return fastJSON.JSON.Instance.UseFastGuid;
            }
            set
            {
                fastJSON.JSON.Instance.UseFastGuid = value;
            }
        }
        /// <summary>
        /// 设置或获取一个值，是否在序列化时，是否序列化类型的名称（$types），以及编号（$type）。默认为 false。
        /// </summary>
        public static bool UseSerializerExtension
        {
            get
            {
                return fastJSON.JSON.Instance.UseSerializerExtension;
            }
            set
            {
                fastJSON.JSON.Instance.UseSerializerExtension = value;
            }
        }
        /// <summary>
        /// 设置或获取一个值，是否缩排输出。默认为 false。
        /// </summary>
        public static bool IndentOutput
        {
            get
            {
                return fastJSON.JSON.Instance.IndentOutput;
            }
            set
            {
                fastJSON.JSON.Instance.IndentOutput = value;
            }
        }
        /// <summary>
        /// 设置或获取一个值，是否序列化空值。默认为 true。
        /// </summary>
        public static bool SerializeNullValues
        {
            get
            {
                return fastJSON.JSON.Instance.SerializeNullValues;
            }
            set
            {
                fastJSON.JSON.Instance.SerializeNullValues = value;
            }
        }
        ///// <summary>
        ///// 设置或获取一个值，是否序列化公共字段。默认为 true。
        ///// </summary>
        //public static bool SerializeFields
        //{
        //    get
        //    {
        //        return fastJSON.JSON.Instance.SerializeFields;
        //    }
        //    set
        //    {
        //        fastJSON.JSON.Instance.SerializeFields = value;
        //    }
        //}
        /// <summary>
        /// 设置或获取一个值，是否使用 UTC 时间。默认为 false。
        /// </summary>
        public static bool UseUTCDateTime
        {
            get
            {
                return fastJSON.JSON.Instance.UseUTCDateTime;
            }
            set
            {
                fastJSON.JSON.Instance.UseUTCDateTime = value;
            }
        }
        /// <summary>
        /// 设置或获取一个值，是否显示只读属性。默认为 false。
        /// </summary>
        public static bool ShowReadOnlyProperties
        {
            get
            {
                return fastJSON.JSON.Instance.ShowReadOnlyProperties;
            }
            set
            {
                fastJSON.JSON.Instance.ShowReadOnlyProperties = value;
            }
        }
        /// <summary>
        /// 设置或获取一个值，是否引用全局类型。默认为 true。
        /// </summary>
        public static bool UsingGlobalTypes
        {
            get
            {
                return fastJSON.JSON.Instance.UsingGlobalTypes;
            }
            set
            {
                fastJSON.JSON.Instance.UsingGlobalTypes = value;
            }
        }

        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.JSONSerializer"/> 的新实例。
        /// </summary>
        public JSONSerializer() { }

        /// <summary>
        /// 初始化 <see cref="Sofire.Serialization.JSONSerializer"/> 的新实例。
        /// </summary>
        /// <param name="encoding">字符编码。</param>
        public JSONSerializer(Encoding encoding)
            : base(encoding) { }

        /// <summary>
        /// 快速反序列化 JSON 字符串。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="json">JSON 字符串。</param>
        /// <returns>返回一个对象。</returns>
        public TData FastRead<TData>(string json)
        {
            return fastJSON.JSON.Instance.ToObject<TData>(json);
        }

        /// <summary>
        /// 快速序列化 JSON 对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="data">可序列化的对象。</param>
        /// <returns>返回 JSON 字符串。</returns>
        public string FastWrite<TData>(TData data)
        {
            return fastJSON.JSON.Instance.ToJSON(data);
        }

        /// <summary>
        /// 读取对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">序列化的流。</param>
        /// <returns>返回序列化对象。</returns>
        protected override object Reading<TData>(Stream stream)
        {
            var json = new StreamReader(stream, this.Encoding).ReadToEnd();
            return fastJSON.JSON.Instance.ToObject<TData>(json);
        }

        /// <summary>
        /// 写入可序列化的对象。
        /// </summary>
        /// <typeparam name="TData">可序列化对象的类型。</typeparam>
        /// <param name="stream">可序列化的流。</param>
        /// <param name="data">可序列化的对象。</param>
        protected override void Writing<TData>(Stream stream, TData data)
        {
            var bytes = this.Encoding.GetBytes(fastJSON.JSON.Instance.ToJSON(data));
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
#endif