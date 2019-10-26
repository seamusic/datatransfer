using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// 创建并返回一个可复用的池模型实体。
    /// </summary>
    /// <typeparam name="TModel">可复用的池模型实体的数据类型。</typeparam>
    /// <returns>返回一个新的可复用的池模型实体。</returns>
    public delegate TModel PoolModelCreater<TModel>() where TModel : IPoolModel;

    /// <summary>
    /// 一个可复用的池模型实体的管理器。
    /// </summary>
    /// <typeparam name="TModel">可复用的池模型实体的数据类型。</typeparam>
    public class PoolModelManager<TModel>
            where TModel : IPoolModel
    {
        private readonly Stack<TModel> _Items;
        private readonly bool _autoIncrement;
        private readonly PoolModelCreater<TModel> _creater;

        /// <summary>
        /// 初始化 <see cref="System.PoolModelManager&lt;TModel&gt;"/> 的新实例。
        /// </summary>
        /// <param name="maxItemCount">最大元素数。</param>
        /// <param name="autoIncrement">指示在超出最大元素数时，是否自动创建新的池模型。</param>
        /// <param name="creater">池模型的创建器。</param>
        public PoolModelManager(int maxItemCount, bool autoIncrement
            , PoolModelCreater<TModel> creater)
        {
            if(creater == null) throw new ArgumentNullException("creater");

            this._Items = new Stack<TModel>(maxItemCount);

            for(int i = 0 ; i < maxItemCount ; i++)
            {
                this.Push(creater());
            }
            this._autoIncrement = autoIncrement;
            this._creater = creater;
        }

        /// <summary>
        /// 将指定池模型清空数据，并放入池管理器。
        /// </summary>
        /// <param name="model">池模型。</param>
        public void Push(TModel model)
        {
            if(model == null) throw new ArgumentNullException("model");
            lock(this._Items)
            {
                model.Clear();
                this._Items.Push(model);
            }
        }

        /// <summary>
        /// 从池里取出一个空的池模型。
        /// </summary>
        /// <returns>返回一个空的池模型。</returns>
        public TModel Pop()
        {
            lock(this._Items)
            {
                if(this._Items.Count == 0)
                {
                    if(this._autoIncrement) return this._creater();
                    else throw new ArgumentOutOfRangeException(this.GetType().FullName);
                }
                return this._Items.Pop();
            }
        }

        /// <summary>
        /// 析构函数。
        /// </summary>
        ~PoolModelManager()
        {
            lock(this._Items)
            {
                this._Items.Clear();
            }
        }
    }
}
