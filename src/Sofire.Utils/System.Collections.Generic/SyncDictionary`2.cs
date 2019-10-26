namespace System.Collections.Generic
{
    /// <summary>
    /// 一个由派生类可重写的泛型字典集合（用于多线程）。
    /// </summary>
    /// <typeparam name="TKey">键的类型。</typeparam>
    /// <typeparam name="TValue">值的类型。</typeparam>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class SyncDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        #region Fields

        /// <summary>
        /// 表示内部的字段集合。
        /// </summary>
        protected readonly Dictionary<TKey, TValue> _innerDictionary;

        /// <summary>
        /// 表示同步 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 的实例。
        /// </summary>
#if !SILVERLIGHT
    [NonSerialized]
#endif
        protected readonly object _SyncRoot = new Object();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 的新实例。
        /// </summary>
        public SyncDictionary()
            : this(null)
        {
        }

        /// <summary>
        /// 指定 <see cref="System.Collections.Generic.IEqualityComparer&lt;TKey&gt;"/>，初始化 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 的新实例。
        /// </summary>
        /// <param name="comparer">比较键时要使用的 <see cref="System.Collections.Generic.IEqualityComparer&lt;TKey&gt;"/> 实现，或者为 null，以便为键类型使用默认的<see cref="System.Collections.Generic.IEqualityComparer&lt;TKey&gt;"/>。</param>
        public SyncDictionary(IEqualityComparer<TKey> comparer)
        {
            _innerDictionary = new Dictionary<TKey, TValue>(comparer);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 获取包含在 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中的键/值对的数目。
        /// </summary>
        public int Count
        {
            get
            {
                lock(_SyncRoot)
                {
                    return _innerDictionary.Count;
                }
            }
        }

        /// <summary>
        /// 获取一个值，表示包含 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中的键的集合。
        /// </summary>
        public virtual Dictionary<TKey, TValue>.KeyCollection Keys
        {
            get
            {
                lock(_SyncRoot)
                {
                    return this._innerDictionary.Keys;
                }
            }
        }

        /// <summary>
        /// 获取一个值，表示同步 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 的实例。
        /// </summary>
        public object SyncRoot
        {
            get
            {
                return _SyncRoot;
            }
        }

        /// <summary>
        /// 获取包含 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中的值的集合。
        /// </summary>
        public virtual Dictionary<TKey, TValue>.ValueCollection Values
        {
            get
            {
                lock(_SyncRoot)
                {
                    return this._innerDictionary.Values;
                }
            }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return false; }
        }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get
            {
                lock(_SyncRoot)
                {
                    return _innerDictionary.Keys;
                }
            }
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get
            {
                lock(_SyncRoot)
                {
                    return _innerDictionary.Values;
                }
            }
        }

        #endregion Properties

        #region Indexers

        /// <summary>
        /// 获取或设置与指定的键相关联的值。
        /// </summary>
        /// <param name="key">要获取或设置的值的键。</param>
        /// <returns>与指定的键相关联的值。如果找不到指定的键，get 操作便会引发 System.Collections.Generic.KeyNotFoundException，而 set 操作会创建一个具有指定键的新元素。</returns>
        public virtual TValue this[TKey key]
        {
            get
            {
                lock(_SyncRoot)
                {
                    return _innerDictionary[key];
                }
            }
            set
            {
                lock(_SyncRoot)
                {
                    _innerDictionary[key] = value;
                }
            }
        }

        #endregion Indexers

        #region Methods

        /// <summary>
        /// 将指定的键和值添加到 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中。
        /// </summary>
        /// <param name="key">要添加的缓存的键。</param>
        /// <param name="value">要添加的缓存的值。对于引用类型，该值可以为 null 值。</param>
        public virtual void Add(TKey key, TValue value)
        {
            lock(_SyncRoot)
            {
                _innerDictionary.Add(key, value);
            }
        }

        /// <summary>
        /// 从 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中移除所有的键和值。
        /// </summary>
        public void Clear()
        {
            lock(_SyncRoot)
            {
                _innerDictionary.Clear();
            }
        }

        /// <summary>
        /// 确定 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中是否包含指定的键。
        /// </summary>
        /// <param name="key">要在 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中定位的键。</param>
        /// <returns>如果 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 包含具有指定键的元素，则为 true；否则为 false。</returns>
        public virtual bool ContainsKey(TKey key)
        {
            lock(_SyncRoot)
            {
                return _innerDictionary.ContainsKey(key);
            }
        }

        /// <summary>
        /// 确定 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 是否包含特定值。
        /// </summary>
        /// <param name="value">要在 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中定位的值。对于引用类型，该值可以为 null 值。</param>
        /// <returns>如果 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 包含具有指定值的元素，则为 true；否则为 false。</returns>
        public virtual bool ContainsValue(TValue value)
        {
            lock(_SyncRoot)
            {
                return _innerDictionary.ContainsValue(value);
            }
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            lock(_SyncRoot)
            {
                (_innerDictionary as ICollection<KeyValuePair<TKey, TValue>>).Add(item);
            }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            lock(_SyncRoot)
            {
                return (_innerDictionary as ICollection<KeyValuePair<TKey, TValue>>).Contains(item);
            }
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            lock(_SyncRoot)
            {
                (_innerDictionary as ICollection<KeyValuePair<TKey, TValue>>).CopyTo(array, arrayIndex);
            }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            lock(_SyncRoot)
            {
                return (_innerDictionary as ICollection<KeyValuePair<TKey, TValue>>).Remove(item);
            }
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            lock(_SyncRoot)
            {
                return _innerDictionary.GetEnumerator();
            }
        }

        /// <summary>
        /// 从 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中移除所指定的键的值。
        /// </summary>
        /// <param name="key">要移除的元素的键。</param>
        /// <returns>如果成功找到并移除该元素，则为 true；否则为 false。如果在 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 中没有找到 key，此方法则返回 false。</returns>
        public virtual bool Remove(TKey key)
        {
            lock(_SyncRoot)
            {
                return _innerDictionary.Remove(key);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            lock(_SyncRoot)
            {
                return _innerDictionary.GetEnumerator();
            }
        }

        /// <summary>
        /// 获取与指定的键相关联的值。
        /// </summary>
        /// <param name="key">要获取的值的键。</param>
        /// <param name="value">当此方法返回值时，如果找到该键，便会返回与指定的键相关联的值；否则，则会返回 value 参数的类型默认值。该参数未经初始化即被传递。</param>
        /// <returns>如果 <see cref="System.Collections.Generic.SyncDictionary&lt;TKey,TValue&gt;"/> 包含具有指定键的元素，则为 true；否则为 false。</returns>
        public virtual bool TryGetValue(TKey key, out TValue value)
        {
            lock(_SyncRoot)
            {
                return _innerDictionary.TryGetValue(key, out value);
            }
        }

        #endregion Methods
    }
}