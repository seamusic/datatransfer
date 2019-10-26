namespace System.Collections.Generic
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// 表示一个具有唯一标识符（不区分大小写）的项集合。
    /// </summary>
    /// <typeparam name="IObject">对象类型。</typeparam>
    public partial class NameCollection<IObject>
    {
        #region Fields

        /// <summary>
        /// 名称的集合。
        /// </summary>
        protected List<string> _names;

        /// <summary>
        /// 值的集合。
        /// </summary>
        protected List<IObject> _values;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.NameCollection&lt;IObject&gt;"/> 的新实例。
        /// </summary>
        public NameCollection()
        {
            this._names = new List<string>();
            this._values = new List<IObject>();
        }

        /// <summary>
        /// 指定初始元素数，初始化 <see cref="System.Collections.Generic.NameCollection&lt;IObject&gt;"/> 的新实例。
        /// </summary>
        /// <param name="capacity">新集合最初可以存储的元素数。</param>
        public NameCollection(int capacity)
        {
            this._names = new List<string>(capacity);
            this._values = new List<IObject>(capacity);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 获取一个值，表示名称的集合。
        /// </summary>
        public IEnumerable<string> Names
        {
            get
            {
                return this._names;
            }
        }

        /// <summary>
        /// 获取一个值，值的集合。
        /// </summary>
        public IEnumerable<IObject> Values
        {
            get
            {
                return this._values;
            }
        }

        #endregion Properties

        #region Indexers

        /// <summary>
        /// 获取指定唯一标识符的对象。
        /// </summary>
        /// <param name="name">唯一的唯一标识符。</param>
        /// <returns>返回存在的项，或一个 null 值。</returns>
        public virtual IObject this[string name]
        {
            get
            {
                IObject item;
                this.TryGetValue(name, out item);
                return item;
            }
            set
            {
                var index = this._names.IndexOf(name, NameCollection<IObject>.OrdinalIgnoreCase);
                if(index == -1) return;
                this._values[index] = value;
            }
        }

        /// <summary>
        /// 获取指定索引处的对象。
        /// </summary>
        /// <param name="index">索引。</param>
        /// <returns>返回存在的项，或一个 null 值。</returns>
        public virtual IObject this[int index]
        {
            get
            {
                if(index < 0 || index >= this._values.Count) return default(IObject);
                return this._values[index];
            }
        }

        #endregion Indexers
    }

    public partial class NameCollection<IObject>
    {
        #region Fields

        private static readonly StringComparer OrdinalIgnoreCase = StringComparer.OrdinalIgnoreCase;

        #endregion Fields

        #region Properties

        /// <summary>
        /// 获取当前集合的项数。
        /// </summary>
        public int Count
        {
            get
            {
                return this._values.Count;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 给定唯一标识符和对象，添加到集合中。
        /// </summary>
        /// <param name="name">唯一标识符。</param>
        /// <param name="value">对象。</param>
        /// <returns>如果集合已存在该唯一标识符，将会返回 false，否则返回 true。</returns>
        public virtual bool Add(string name, IObject value)
        {
            if(this.ContainsName(name))
            {
                return false;
            }
            this._names.Add(name);
            this._values.Add(value);
            return true;
        }

        /// <summary>
        /// 更改唯一标识符。
        /// </summary>
        /// <param name="oldName">旧的唯一标识符。</param>
        /// <param name="newName">新的唯一标识符。</param>
        /// <returns>如果新的唯一标识符已存在或找不到旧的唯一标识符则返回 false，否则返回 true。</returns>
        public virtual bool ChangedName(string oldName, string newName)
        {
            if(this.ContainsName(newName))
            {
                return false;
            }
            int index = this._names.IndexOf(oldName, NameCollection<IObject>.OrdinalIgnoreCase);
            if(index == -1) return false;
            this._names[index] = newName;
            return true;
        }

        /// <summary>
        /// 清除所有项。
        /// </summary>
        public virtual void Clear()
        {
            this._names.Clear();
            this._values.Clear();
        }

        /// <summary>
        /// 确定当前集合是否包含指定的唯一标识符。
        /// </summary>
        /// <param name="name">唯一的唯一标识符。</param>
        /// <returns>如果包含指定的唯一标识符则返回 true，否则返回 false。</returns>
        public virtual bool ContainsName(string name)
        {
            return this._names.Contains(name, NameCollection<IObject>.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 搜索指定的唯一标识符，并返回整个集合中第一个匹配项的索引。
        /// </summary>
        /// <param name="name">唯一的唯一标识符。</param>
        /// <returns>如果在整个集合中找到唯一标识符的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1。</returns>
        public virtual int IndexOfName(string name)
        {
            return this._names.IndexOf(name, NameCollection<IObject>.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 移除指定唯一标识符的项。
        /// </summary>
        /// <param name="name">唯一标识符。</param>
        /// <returns>返回移除的状态。</returns>
        public virtual bool Remove(string name)
        {
            return this.RemoveAt(this._names.IndexOf(name, NameCollection<IObject>.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 移除指定索引处的项。
        /// </summary>
        /// <param name="index">索引。</param>
        /// <returns>返回移除的状态。</returns>
        public virtual bool RemoveAt(int index)
        {
            if(index < 0 || index >= this._names.Count) return false;
            this._names.RemoveAt(index);
            this._values.RemoveAt(index);
            return true;
        }

        /// <summary>
        /// 移除指定值的项。
        /// </summary>
        /// <param name="value">移除的值。</param>
        /// <returns>返回移除的状态。</returns>
        public virtual bool RemoveFirstValue(IObject value)
        {
            return this.RemoveAt(this._values.IndexOf(value));
        }

        /// <summary>
        /// 给定唯一标识符，尝试获取相应的对象。
        /// </summary>
        /// <param name="name">唯一标识符。</param>
        /// <param name="value">对象。</param>
        /// <returns>如果检索到对象返回 true，否则返回 false。</returns>
        public virtual bool TryGetValue(string name, out IObject value)
        {
            var index = this._names.IndexOf(name, NameCollection<IObject>.OrdinalIgnoreCase);

            if(index == -1)
            {
                value = default(IObject);
                return false;
            }
            value = this._values[index];
            return true;
        }

        #endregion Methods
    }
#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class NameCollection<IObject> : IEnumerable<IObject>
#if !SILVERLIGHT
        , IListSource
#endif
, IDisposable
    {
        #region Fields
#if !SILVERLIGHT
        [NonSerialized]
#endif
        private bool _isDisposed;

        #endregion Fields

        #region Properties

        /// <summary>
        /// 获取一个值，指示当前 <see cref="System.Collections.Generic.NameCollection&lt;IObject&gt;"/> 是否已释放。
        /// </summary>
        public bool IsDisposed
        {
            get { return this._isDisposed; }
        }
#if !SILVERLIGHT
        [Browsable(false)]
        bool IListSource.ContainsListCollection
        {
            get { return this._values != null; }
        }
#endif
        #endregion Properties

        #region Methods

        /// <summary>
        /// 释放由 <see cref="System.Collections.Generic.NameCollection&lt;IObject&gt;"/> 使用的所有资源。
        /// </summary>
        public void Dispose()
        {
            if(this._isDisposed) return;
            this._isDisposed = true;
            this.Dispoing();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this._values).GetEnumerator();
        }

        IEnumerator<IObject> IEnumerable<IObject>.GetEnumerator()
        {
            return this._values.GetEnumerator();
        }
#if !SILVERLIGHT
        IList IListSource.GetList()
        {
            return this._values;
        }
#endif
        /// <summary>
        /// 释放由 <see cref="System.Collections.Generic.NameCollection&lt;IObject&gt;"/> 使用的所有资源。
        /// </summary>
        protected virtual void Dispoing()
        {
            this.Clear();
            this._names = null;
            this._values = null;
        }

        #endregion Methods
    }
}