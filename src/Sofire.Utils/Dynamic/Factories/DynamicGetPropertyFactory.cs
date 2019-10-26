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
    /// 表示动态获取属性的工厂。
    /// </summary>
    public sealed class DynamicGetPropertyFactory : DynamicFactoryBase<PropertyInfo, DynamicGetMemberHandler>
    {
        private static readonly DynamicGetPropertyFactory _Instance = new DynamicGetPropertyFactory();
        /// <summary>
        /// 获取动态获取属性的唯一工厂。
        /// </summary>
        public static DynamicGetPropertyFactory Instance
        {
            get
            {
                return _Instance;
            }
        }

        private DynamicGetPropertyFactory() { }

        /// <summary>
        /// 创建指定 <paramref name="propertyInfo"/> 的动态属性获取器。
        /// </summary>
        /// <param name="propertyInfo">属性的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例属性获取器的委托。</returns>
        protected override DynamicGetMemberHandler CreateHandler(PropertyInfo propertyInfo, Type declaringType)
        {
            var getMethod = propertyInfo.GetGetMethod(true);
            // return CreateGetMemberHandler(declaringType, convertInstance => Expression.Property(propertyInfo.GetGetMethod(true).IsStatic ? null : convertInstance, propertyInfo));

            var instanceParameter = Expression.Parameter(Types.Object, "instance");
            var convertInstance = Expression.Convert(instanceParameter, declaringType);

            return Expression.Lambda<DynamicGetMemberHandler>(Expression.Convert(getMethod.IsStatic
                ? Expression.Call(getMethod)
                : Expression.Call(convertInstance, getMethod), Types.Object)
                , instanceParameter).Compile();

        }

#if EMIT
        /// <summary>
        /// 创建指定 <paramref name="propertyInfo"/> 的动态属性获取器。
        /// </summary>
        /// <param name="propertyInfo">属性的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例属性获取器的委托。</returns>
        protected override DynamicGetMemberHandler CreateHandler(PropertyInfo propertyInfo, Type declaringType)
        {
            var methodInfo = propertyInfo.GetGetMethod(true);

            EmitHelper emit = new EmitHelper(string.Empty,
                                 Types.Object,
                                 new Type[1] { Types.Object },
                                 declaringType,
                                 SkipVisibility,
                                 false);//- 为什么这里不使用 OwnerType 而使用 member.DeclaringType，主要是考虑到泛型：<object>
            if(!methodInfo.IsStatic)
            {
                emit.LoadThis(methodInfo);  //- 非静态，取出实例
            }
            emit.Call(methodInfo);
            emit.TryBox(methodInfo.ReturnType);
            emit.Return();
            return emit.CreateDelegate<DynamicGetMemberHandler>();
        }
#endif
        /// <summary>
        /// 创建指定实例成员的动态委托。
        /// </summary>
        /// <param name="member">实例的成员。</param>
        /// <returns>返回一个绑定实例成员实现的委托。</returns>
        protected override string GetToken(PropertyInfo member)
        {
            return GetMemberToken(member);
        }
    }
}