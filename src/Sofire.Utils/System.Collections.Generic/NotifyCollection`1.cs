using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace System.Collections.Generic
{
    /// <summary>
    /// 一个具有通知事件的集合。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NotifyList<T> : IList<T>
    {
        List<T> _items;

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 的新实例。
        /// </summary>
        public NotifyList()
        {
            this._items = new List<T>();
        }

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 的新实例，该实例为空并且具有指定的初始容量。
        /// </summary>
        /// <param name="capacity">新列表最初可以存储的元素数。</param>
        public NotifyList(int capacity)
        {
            this._items = new List<T>(capacity);
        }

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 的新实例，该实例包含从指定集合复制的元素并且具有足够的容量来容纳所复制的元素。
        /// </summary>
        /// <param name="collection">一个集合，其元素被复制到新列表中。</param>
        public NotifyList(IEnumerable<T> collection)
        {
            this._items = new List<T>(collection);
        }

        /// <summary>
        /// 集合的项发生变化后发生。
        /// </summary>
        public event ItemChangeEventHandler<T> ItemChanged;

        /// <summary>
        /// 集合的项发生变化时发生的方法。
        /// </summary>
        /// <param name="itemIndex">集合的索引。</param>
        /// <param name="item">集合的项。</param>
        /// <param name="action">操作类型。</param>
        protected virtual void OnItemChanged(int itemIndex, T item, ItemChangeAction action)
        {
            if(this.ItemChanged != null) this.ItemChanged(this, new ItemChangeEventArgs<T>(itemIndex, item, action));
        }

        /// <summary>
        /// 搜索指定的对象，并返回整个 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中第一个匹配项的从零开始的索引。
        /// </summary>
        /// <param name="item">要在 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中定位的对象。对于引用类型，该值可以为 null。</param>
        /// <returns>如果在整个 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中找到 item 的第一个匹配项，则为该项的从零开始的索引；否则为 -1。</returns>
        public int IndexOf(T item)
        {
            return this._items.IndexOf(item);
        }

        /// <summary>
        /// 将元素插入 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 的指定索引处。
        /// </summary>
        /// <param name="index">从零开始的索引，应在该位置插入 item。</param>
        /// <param name="item">要插入的对象。对于引用类型，该值可以为 null。</param>
        public void Insert(int index, T item)
        {
            this._items.Insert(index, item);
            this.OnItemChanged(index, item, ItemChangeAction.Add);
        }

        /// <summary>
        /// 移除 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 的指定索引处的元素。
        /// </summary>
        /// <param name="index">要移除的元素的从零开始的索引。</param>
        public void RemoveAt(int index)
        {
            this.Remove(index, this._items[index]);
        }

        /// <summary>
        /// 获取或设置指定索引处的元素。
        /// </summary>
        /// <param name="index">要获得或设置的元素从零开始的索引。</param>
        /// <returns>指定索引处的元素。</returns>
        public T this[int index]
        {
            get
            {
                if(index < 0 || index > this._items.Count) return default(T);
                return this._items[index];
            }
            set
            {
                if(index < 0 || index > this._items.Count) throw new ArgumentOutOfRangeException("value");
                this._items[index] = value;
                this.OnItemChanged(index, value, ItemChangeAction.Change);
            }
        }

        /// <summary>
        /// 将指定集合的元素添加到 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 的末尾。
        /// </summary>
        /// <param name="collection">一个集合，其元素应被添加到 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 的末尾。集合自身不能为 null，但它可以包含为 null 的元素（如果类型 T 为引用类型）。</param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach(var item in collection)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// 将对象添加到 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 的结尾处。
        /// </summary>
        /// <param name="item">要添加到 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 的末尾处的对象。对于引用类型，该值可以为 null。</param>
        public void Add(T item)
        {
            this._items.Add(item);
            this.OnItemChanged(this._items.Count - 1, item, ItemChangeAction.Add);
        }

        /// <summary>
        /// 从 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中移除所有元素。
        /// </summary>
        public void Clear()
        {
            this._items.Clear();
            this.OnItemChanged(-1, default(T), ItemChangeAction.Clear);
        }

        /// <summary>
        /// 确定某元素是否在 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中。
        /// </summary>
        /// <param name="item">要在 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中定位的对象。对于引用类型，该值可以为 null。</param>
        /// <returns>如果在 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中找到 <paramref name="item"/>，则为 true，否则为 false。</returns>
        public bool Contains(T item)
        {
            return this._items.Contains(item);
        }

        /// <summary>
        /// 将整个 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 复制到兼容的一维数组中，从目标数组的开头开始放置。
        /// </summary>
        /// <param name="array">作为从 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 复制的元素的目标位置的一维 <see cref="System.Array"/>。<see cref="System.Array"/> 必须具有从零开始的索引。</param>
        /// <param name="arrayIndex"><paramref name="array"/> 中从零开始的索引，从此处开始复制。</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            this._items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 获取 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中实际包含的元素数。
        /// </summary>
        public int Count
        {
            get { return this._items.Count; }
        }

        /// <summary>
        /// 从 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中移除特定对象的第一个匹配项。
        /// </summary>
        /// <param name="item">要从 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中移除的对象。对于引用类型，该值可以为 null。</param>
        /// <returns>如果成功移除 item，则为 true；否则为 false。如果在 <see cref="System.Collections.Generic.NotifyList&lt;T&gt;"/> 中没有找到 <paramref name="item"/>，该方法也会返回 false。</returns>
        public bool Remove(T item)
        {
            return this.Remove(this._items.IndexOf(item), item);
        }

        private bool Remove(int itemIndex, T item)
        {
            if(itemIndex < 0 || itemIndex > this._items.Count || item == null) return false;
            this._items.RemoveAt(itemIndex);
            this.OnItemChanged(itemIndex, item, ItemChangeAction.Remove);
            return true;
        }

        bool ICollection<T>.IsReadOnly { get { return false; } }


        #region IEnumerable<T>,IEnumerable 成员

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)this._items).GetEnumerator();
        }

        #endregion

    }

    /// <summary>
    /// 集合的项发生变化后发生的事件委托。
    /// </summary>
    /// <typeparam name="T">项的类型。</typeparam>
    /// <param name="sender">事件对象。</param>
    /// <param name="e">事件参数。</param>
    public delegate void ItemChangeEventHandler<T>(object sender, ItemChangeEventArgs<T> e);

    /// <summary>
    /// 集合的项发生变化后发生的事件参数。
    /// </summary>
    /// <typeparam name="T">项的类型。</typeparam>
    public class ItemChangeEventArgs<T> : EventArgs
    {
        private T _Item;
        /// <summary>
        /// 获取发生变化的项。
        /// </summary>
        public T Item { get { return this._Item; } }

        private ItemChangeAction _Action;
        /// <summary>
        /// 获取发生变化的原因。
        /// </summary>
        public ItemChangeAction Action { get { return this._Action; } }

        private int _ItemIndex;
        /// <summary>
        /// 获取发生变化的项索引。
        /// </summary>
        public int ItemIndex { get { return this._ItemIndex; } }

        /// <summary>
        /// 初始化 <see cref="System.Collections.Generic.ItemChangeEventArgs&lt;T&gt;"/> 的新实例。
        /// </summary>
        /// <param name="itemIndex">项索引。</param>
        /// <param name="tiem">项。</param>
        /// <param name="action">变化的原因。</param>
        public ItemChangeEventArgs(int itemIndex, T tiem, ItemChangeAction action)
        {
            this._ItemIndex = itemIndex;
            this._Item = Item;
            this._Action = action;
        }
    }

    /// <summary>
    /// 集合项的变化原因。
    /// </summary>
    public enum ItemChangeAction
    {
        /// <summary>
        /// 修改项。将指定 索引 或 键 的项修改为新的值。
        /// </summary>
        Change = 0,
        /// <summary>
        /// 添加项。
        /// </summary>
        Add = 1,
        /// <summary>
        /// 移除项。
        /// </summary>
        Remove = 2,
        /// <summary>
        /// 清空集合。
        /// </summary>
        Clear = 3,
    }
}

