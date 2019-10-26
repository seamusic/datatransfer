namespace System
{
    using System.Collections.Generic;

    /// <summary>
    /// 实用的扩展方法集合。
    /// </summary>
    public static partial class UtilsExts
    {
        #region Methods

        /// <summary>
        /// 修改字典的键。
        /// </summary>
        /// <typeparam name="TKey">字典中的键的类型。</typeparam>
        /// <typeparam name="TValue">字典中的值的类型。</typeparam>
        /// <param name="dict">字典。</param>
        /// <param name="oldKey">旧的键。</param>
        /// <param name="newKey">新的键。</param>
        /// <returns>如果修改成功则返回 true，否则返回 false。</returns>
        public static bool ChangeKey<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey oldKey, TKey newKey)
        {
            if(dict == null || dict.ContainsKey(newKey)) return false;

            TValue value;
            if(!dict.TryGetValue(oldKey, out value)) return false;
            dict.Remove(oldKey);
            dict.Add(newKey, value);
            return true;
        }

        /// <summary>
        /// 将指定 <typeparamref name="T1"/> 转换为 <typeparamref name="T2"/> 的类型。
        /// </summary>
        /// <typeparam name="T1">源类型。</typeparam>
        /// <typeparam name="T2">转换后的类型。</typeparam>
        /// <param name="e">等待转换的集合。</param>
        /// <returns>返回一个新的集合。</returns>
        public static IEnumerable<T2> ConvertAllTo<T1, T2>(this IEnumerable<T1> e)
            where T1 : T2
        {
            foreach(var item in e) yield return item;
        }

        /// <summary>
        /// 合并两个集合，并返回一个新的集合。
        /// </summary>
        /// <typeparam name="T1">第一个集合的类型。</typeparam>
        /// <typeparam name="T2">第二个集合的类型。</typeparam>
        /// <param name="e1">连接的集合。</param>
        /// <param name="e2">另外一个连接的集合。</param>
        /// <returns>返回一个新的、包含两个集合数据的集合。</returns>
        public static IEnumerable<T2> ConcatTo<T1, T2>(this IEnumerable<T2> e1, IEnumerable<T1> e2)
            where T1 : T2
        {
            foreach(var item in e1) yield return item;
            foreach(var item in e2) yield return item;
        }


        /// <summary>
        /// 搜索指定的对象，并返回整个 System.Array 中第一个匹配项的索引。
        /// </summary>
        /// <typeparam name="T">数组元素的类型。</typeparam>
        /// <param name="array">要搜索的从零开始的一维 System.Array。</param>
        /// <param name="value">要在 array 中查找的对象。</param>
        /// <param name="comparer">一个对值进行比较的相等比较器。</param>
        /// <returns>如果在整个 array 中找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1。</returns>
        public static int IndexOf<T>(this T[] array
            , T value
            , IEqualityComparer<T> comparer)
        {
            if(array == null)
            {
                throw new ArgumentNullException("array");
            }
            return IndexOf<T>(array, value, 0, array.Length, comparer);
        }

        /// <summary>
        /// 搜索指定的对象，并返回 System.Array 中从指定索引到最后一个元素这部分元素中第一个匹配项的索引。
        /// </summary>
        /// <typeparam name="T">数组元素的类型。</typeparam>
        /// <param name="array">要搜索的从零开始的一维 System.Array。</param>
        /// <param name="value">要在 array 中查找的对象。</param>
        /// <param name="startIndex">从零开始的搜索的起始索引。</param>
        /// <param name="comparer">一个对值进行比较的相等比较器。</param>
        /// <returns>如果在 array 中从 startIndex 到最后一个元素这部分元素中找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1。</returns>
        public static int IndexOf<T>(this T[] array
            , T value
            , int startIndex
            , IEqualityComparer<T> comparer)
        {
            return IndexOf<T>(array, value, startIndex, array.Length, comparer);
        }

        ///// <summary>
        ///// 通过使用默认的相等比较器确定序列是否包含指定的元素。
        ///// </summary>
        ///// <typeparam name="TSource">source 中的元素的类型。</typeparam>
        ///// <param name="source">要在其中定位某个值的序列。</param>
        ///// <param name="value">要在序列中定位的值。</param>
        ///// <returns>如果源序列包含具有指定值的元素，则为 true；否则为 false。</returns>
        //public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
        //{
        //    ICollection<TSource> is2 = source as ICollection<TSource>;
        //    if(is2 != null) return is2.Contains(value);
        //    return source.Contains<TSource>(value, null);
        //}
        ///// <summary>
        ///// 通过使用指定的 System.Collections.Generic.IEqualityComparer&lt;TSource&gt; 确定序列是否包含指定的元素。
        ///// </summary>
        ///// <typeparam name="TSource">source 中的元素的类型。</typeparam>
        ///// <param name="source">要在其中定位某个值的序列。</param>
        ///// <param name="value">要在序列中定位的值。</param>
        ///// <param name="comparer">一个对值进行比较的相等比较器。</param>
        ///// <returns>如果源序列包含具有指定值的元素，则为 true；否则为 false。</returns>
        //public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        //{
        //    if(comparer == null) comparer = EqualityComparer<TSource>.Default;
        //    if(source == null) throw new ArgumentNullException("source");
        //    foreach(TSource local in source)
        //    {
        //        if(comparer.Equals(local, value)) return true;
        //    }
        //    return false;
        //}
        /// <summary>
        /// 搜索指定的对象，并返回 System.Array 中从指定索引开始包含指定个元素的这部分元素中第一个匹配项的索引。
        /// </summary>
        /// <typeparam name="T">数组元素的类型。</typeparam>
        /// <param name="array">要搜索的从零开始的一维 System.Array。</param>
        /// <param name="value">要在 array 中查找的对象。</param>
        /// <param name="startIndex">从零开始的搜索的起始索引。</param>
        /// <param name="count">要搜索的部分中的元素数。</param>
        /// <param name="comparer">一个对值进行比较的相等比较器。</param>
        /// <returns>如果在 array 中从 startIndex 开始、包含 count 所指定的元素个数的这部分元素中，找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1。</returns>
        public static int IndexOf<T>(this T[] array
            , T value
            , int startIndex
            , int count
            , IEqualityComparer<T> comparer)
        {
            if(array == null)
            {
                throw new ArgumentNullException("array");
            }

            if((startIndex < 0) || (startIndex > array.Length))
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            if((count < 0) || (count > (array.Length - startIndex)))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            int num = startIndex + count;

            for(int i = startIndex ; i < num ; i++)
            {
                if(comparer.Equals(array[i], value)) return i;
            }
            return -1;
        }

        /// <summary>
        /// 搜索指定的对象，并返回整个 System.Collections.Generic.IList&lt;T&gt; 中第一个匹配项的索引。
        /// </summary>
        /// <typeparam name="T">列表元素的类型。</typeparam>
        /// <param name="collection">要搜索的从零开始的 System.Collections.Generic.IList&lt;T&gt;。</param>
        /// <param name="value">要在 collection 中查找的对象。</param>
        /// <returns>如果在整个 collection 中找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1。</returns>
        public static int IndexOf<T>(this T[] collection
            , T value)
        {
            return Array.IndexOf(collection, value);
        }

        /// <summary>
        /// 搜索指定的对象，并返回整个 System.Collections.Generic.IList&lt;T&gt; 中第一个匹配项的索引。
        /// </summary>
        /// <typeparam name="T">列表元素的类型。</typeparam>
        /// <param name="collection">要搜索的从零开始的 System.Collections.Generic.IList&lt;T&gt;。</param>
        /// <param name="value">要在 collection 中查找的对象。</param>
        /// <param name="comparer">一个对值进行比较的相等比较器。</param>
        /// <returns>如果在整个 collection 中找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1。</returns>
        public static int IndexOf<T>(this IList<T> collection
            , T value
            , IEqualityComparer<T> comparer)
        {
            if(collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            return IndexOf<T>(collection, value, 0, collection.Count, comparer);
        }

        /// <summary>
        /// 搜索指定的对象，并返回 System.Collections.Generic.IList&lt;T&gt; 中从指定索引到最后一个元素这部分元素中第一个匹配项的索引。
        /// </summary>
        /// <typeparam name="T">列表元素的类型。</typeparam>
        /// <param name="collection">要搜索的从零开始的 System.Collections.Generic.IList&lt;T&gt;。</param>
        /// <param name="value">要在 collection 中查找的对象。</param>
        /// <param name="startIndex">从零开始的搜索的起始索引。</param>
        /// <param name="comparer">一个对值进行比较的相等比较器。</param>
        /// <returns>如果在 collection 中从 startIndex 到最后一个元素这部分元素中找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1。</returns>
        public static int IndexOf<T>(this IList<T> collection
            , T value
            , int startIndex
            , IEqualityComparer<T> comparer)
        {
            return IndexOf<T>(collection, value, startIndex, collection.Count, comparer);
        }

        /// <summary>
        /// 搜索指定的对象，并返回 System.Collections.Generic.IList&lt;T&gt; 中从指定索引开始包含指定个元素的这部分元素中第一个匹配项的索引。
        /// </summary>
        /// <typeparam name="T">列表元素的类型。</typeparam>
        /// <param name="collection">要搜索的从零开始的 System.Collections.Generic.IList&lt;T&gt;。</param>
        /// <param name="value">要在 collection 中查找的对象。</param>
        /// <param name="startIndex">从零开始的搜索的起始索引。</param>
        /// <param name="count">要搜索的部分中的元素数。</param>
        /// <param name="comparer">一个对值进行比较的相等比较器。</param>
        /// <returns>如果在 collection 中从 startIndex 开始、包含 count 所指定的元素个数的这部分元素中，找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1。</returns>
        public static int IndexOf<T>(this IList<T> collection
            , T value
            , int startIndex
            , int count
            , IEqualityComparer<T> comparer)
        {
            if(collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if((startIndex < 0) || (startIndex > collection.Count))
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            if((count < 0) || (count > (collection.Count - startIndex)))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            int num = startIndex + count;

            for(int i = startIndex ; i < num ; i++)
            {
                if(comparer.Equals(collection[i], value)) return i;
            }
            return -1;
        }

        #endregion Methods
    }
}