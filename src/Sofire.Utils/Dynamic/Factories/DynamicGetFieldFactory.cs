using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Sofire.Dynamic.Factories
{
    /// <summary>
    /// 表示动态获取成员的委托。
    /// <param name="instance">成员的实例。</param>
    /// </summary>
    /// <returns>返回动态获取的成员值。</returns>
    public delegate object DynamicGetMemberHandler(object instance);

    /// <summary>
    /// 表示动态获取字段的工厂。
    /// </summary>
    public sealed class DynamicGetFieldFactory : DynamicFactoryBase<FieldInfo, DynamicGetMemberHandler>
    {
        private static readonly DynamicGetFieldFactory _Instance = new DynamicGetFieldFactory();
        /// <summary>
        /// 获取动态获取字段的唯一工厂。
        /// </summary>
        public static DynamicGetFieldFactory Instance
        {
            get
            {
                return _Instance;
            }
        }

        /// <summary>
        /// 初始化 <see cref="Sofire.Dynamic.Factories.DynamicGetFieldFactory"/> 类的新实例。
        /// </summary>
        private DynamicGetFieldFactory() { }

        /// <summary>
        /// 创建指定 <paramref name="fieldInfo"/> 的动态字段获取器。
        /// </summary>
        /// <param name="fieldInfo">字段的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例字段获取器的委托。</returns>
        protected override DynamicGetMemberHandler CreateHandler(FieldInfo fieldInfo, Type declaringType)
        {
            // return CreateGetMemberHandler(declaringType, convertInstance => Expression.Field(fieldInfo.IsStatic ? null : convertInstance, fieldInfo));
            var instanceParameter = Expression.Parameter(Types.Object, "instance");
            var convertInstance = Expression.Convert(instanceParameter, declaringType);

            var body = Expression.Convert(Expression.Field(fieldInfo.IsStatic ? null : convertInstance, fieldInfo), Types.Object);

            return Expression.Lambda<DynamicGetMemberHandler>(body, instanceParameter).Compile();
        }

#if EMIT
        /// <summary>
        /// 创建指定 <paramref name="fieldInfo"/> 的动态字段获取器。
        /// </summary>
        /// <param name="fieldInfo">字段的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例字段获取器的委托。</returns>
        protected override DynamicGetMemberHandler CreateHandler(FieldInfo fieldInfo, Type declaringType)
        {
            EmitHelper emit = new EmitHelper(string.Empty,
                                             Types.Object,
                                             new Type[1] { Types.Object },
                                             declaringType,
                                             SkipVisibility,
                                             false);
            if(fieldInfo.IsStatic)
            {
                emit.LoadStaticField(fieldInfo);
            }
            else
            {
                emit.LoadThis(fieldInfo);
                emit.LoadField(fieldInfo);
            }

            emit.TryBox(fieldInfo.FieldType);
            emit.Return();

            /*
             * F = FieldType
             * public object <None>(T owner, object value)
             * {
             *      return owner.Field;     //如果 Field 为值类型，则 return (object)owner.Field; // 装箱
             * }
             */
            return emit.CreateDelegate<DynamicGetMemberHandler>();
        }
#endif
        /// <summary>
        /// 创建指定实例成员的动态委托。
        /// </summary>
        /// <param name="member">实例的成员。</param>
        /// <returns>返回一个绑定实例成员实现的委托。</returns>
        protected override string GetToken(FieldInfo member)
        {
            return GetMemberToken(member);
        }
    }
}