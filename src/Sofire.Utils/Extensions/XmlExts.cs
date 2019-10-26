
#if !SILVERLIGHT
namespace System.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using Sofire.Dynamic;

    /// <summary>
    /// xml 的扩展方法集合。
    /// </summary>
    public static class XmlExts
    {
#region Methods

        /// <summary>
        /// 指定一个 <see cref="System.Xml.XmlNode"/> 节点动态生成一个对象。
        /// </summary>
        /// <typeparam name="TEntity">实体的类型。</typeparam>
        /// <param name="node">System.Xml.XmlNode 节点。</param>
        /// <returns>返回一个填充数据后的新实体。</returns>
        public static Result<TEntity> BuildEntity<TEntity>(XmlNode node)
            where TEntity : new()
        {
            TEntity entity = new TEntity();
            DynamicPropertyHelper<TEntity> helper = new DynamicPropertyHelper<TEntity>(entity);

            var flags = MemberFlags.InstanceSetPropertyFlags | BindingFlags.IgnoreCase;
            PropertyInfo p;
            object value;
            try
            {
                foreach(XmlAttribute attribute in node.Attributes)
                {
                    p = helper.GetProperty(attribute.Name, flags);
                    if(p.PropertyType == Types.String)
                    {
                        value = attribute.Value;
                    }
                    else
                    {
                        value = attribute.Value.CastTo(p.PropertyType);
                    }
                    helper[p] = attribute.Value;
                }
            }
            catch(Exception ex)
            {
                return ex;
            }
            return new Result<TEntity>(entity);
        }

        /// <summary>
        /// 尝试返回具有指定不区分大小写名称的属性的值。
        /// </summary>
        /// <param name="node">xml 元素。</param>
        /// <param name="name">xml 元素的名称。</param>
        /// <returns>指定属性的值。如果未找到匹配属性，或者如果此属性没有指定值或默认值，则返回空字符串。</returns>
        public static string TryGetAttribute(this XmlNode node, string name)
        {
            return TryGetAttribute(node, name, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 尝试返回具有指定名称的属性的值。
        /// </summary>
        /// <param name="node">xml 元素。</param>
        /// <param name="name">不区分大小写的 xml 元素的名称。</param>
        /// <param name="comparisonType"><see cref="System.StringComparison"/> 值之一。</param>
        /// <returns>指定属性的值。如果未找到匹配属性，或者如果此属性没有指定值或默认值，则返回空字符串。</returns>
        public static string TryGetAttribute(this XmlNode node, string name, StringComparison comparisonType)
        {
            foreach(XmlAttribute attrbute in node.Attributes)
            {
                if(name.Equals(attrbute.Name, comparisonType))
                {
                    return attrbute.Value;
                }
            }
            return string.Empty;
        }

    #endregion Methods
    }
}
#endif