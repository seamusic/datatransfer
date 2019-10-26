using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// 表示键和值的只读集合。
    /// </summary>
    /// <typeparam name="TKey">字典中的键的类型。</typeparam>
    /// <typeparam name="TValue">字典中的值的类型。</typeparam>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue> _dict;
        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 类的新实例。
        /// </summary>
        /// <param name="dict">内部字典集合。</param>
        public ReadOnlyDictionary(Dictionary<TKey, TValue> dict)
        {
            if(dict == null) throw new ArgumentNullException("dict");
            this._dict = dict;
        }

        /// <summary>
        /// 获取包含 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 中的键的集合。
        /// </summary>
        public Dictionary<TKey, TValue>.KeyCollection Keys
        {
            get { return this._dict.Keys; }
        }

        /// <summary>
        /// 获取包含 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 中的值的集合。
        /// </summary>
        public Dictionary<TKey, TValue>.ValueCollection Values
        {
            get { return this._dict.Values; }
        }

        /// <summary>
        /// 确定 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 是否包含指定的键。
        /// </summary>
        /// <param name="key">要在 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 中定位的键。</param>
        /// <returns>如果 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 包含具有指定键的元素，则为 true；否则为 false。</returns>
        public bool ContainsKey(TKey key)
        {
            return this._dict.ContainsKey(key);
        }
        
        /// <summary>
        /// 确定 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 是否包含特定值。
        /// </summary>
        /// <param name="value">要在 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 中定位的值。对于引用类型，该值可以为 null。</param>
        /// <returns>如果 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 包含具有指定值的元素，则为 true；否则为 false。</returns>
        public bool ContainsValue(TValue value)
        {
            return this._dict.ContainsValue(value);
        }

        /// <summary>
        /// 获取与指定的键相关联的值。
        /// </summary>
        /// <param name="key">要获取的值的键。</param>
        /// <param name="value">当此方法返回值时，如果找到该键，便会返回与指定的键相关联的值；否则，则会返回 <paramref name="value"/> 参数的类型默认值。该参数未经初始化即被传递。</param>
        /// <returns>如果 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 包含具有指定键的元素，则为 true；否则为 false。</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return this._dict.TryGetValue(key, out value);
        }

        /// <summary>
        /// 获与指定的键相关联的值。
        /// </summary>
        /// <param name="key">要获取值的键。</param>
        /// <returns>与指定的键相关联的值。如果找不到指定的键，get 操作便会引发 <see cref="System.Collections.Generic.KeyNotFoundException"/> </returns>
        public TValue this[TKey key]
        {
            get
            {
                return this._dict[key];
            }
        }

        /// <summary>
        /// 获取包含在 <see cref="System.Collections.Generic.ReadOnlyDictionary&lt;TKey,TValue&gt;"/> 中的键/值对的数目。
        /// </summary>
        public int Count
        {
            get { return this._dict.Count; }
        }


        #region IDictionary<TKey,TValue> 成员

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get
            {
                return this._dict[key];
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get { throw new NotImplementedException(); }
        }

        bool IDictionary<TKey, TValue>.Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> 成员

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)this._dict).Contains(item);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)this._dict).CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return true; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> 成员

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return this._dict.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
        {
            return this._dict.GetEnumerator();
        }

        #endregion
    }
}
