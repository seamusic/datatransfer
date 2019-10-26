namespace System
{
    /// <summary>
    /// 表示一个可复用池模型实体。
    /// </summary>
    public interface IPoolModel
    {
        /// <summary>
        /// 清除模型实例的数据。
        /// </summary>
        void Clear();
    }
}
