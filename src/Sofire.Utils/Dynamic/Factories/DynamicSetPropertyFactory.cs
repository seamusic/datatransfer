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
    /// 表示动态设置属性的工厂。
    /// </summary>
    public sealed class DynamicSetPropertyFactory : DynamicFactoryBase<PropertyInfo, DynamicSetMemberHandler>
    {
        private static readonly DynamicSetPropertyFactory _Instance = new DynamicSetPropertyFactory();
        /// <summary>
        /// 获取动态设置属性的唯一工厂。
        /// </summary>
        public static DynamicSetPropertyFactory Instance
        {
            get
            {
                return _Instance;
            }
        }

        private DynamicSetPropertyFactory() { }

        /// <summary>
        /// 创建指定 <paramref name="propertyInfo"/> 的动态属性设置器。
        /// </summary>
        /// <param name="propertyInfo">属性的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例属性设置器的委托。</returns>
        protected override DynamicSetMemberHandler CreateHandler(PropertyInfo propertyInfo, Type declaringType)
        {
            var setMethod = propertyInfo.GetSetMethod(true);

            //return CreateSetMemberHandler(declaringType, (convertInstance) => Expression.Property(setMethod.IsStatic ? null : convertInstance, propertyInfo));

            var instanceParameter = Expression.Parameter(Types.RefObject, "instance");
            var valueParameter = Expression.Parameter(Types.Object, "value");
            var convertInstance = Expression.Convert(instanceParameter, declaringType);
            var convertValue = Expression.Convert(valueParameter, propertyInfo.PropertyType);

            return Expression.Lambda<DynamicSetMemberHandler>(setMethod.IsStatic
                ? Expression.Call(setMethod, convertValue)
                : Expression.Call(convertInstance, setMethod, convertValue)
                , instanceParameter, valueParameter).Compile();

        }

#if EMIT
        /// <summary>
        /// 创建指定 <paramref name="propertyInfo"/> 的动态属性设置器。
        /// </summary>
        /// <param name="propertyInfo">属性的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例属性设置器的委托。</returns>
        protected override DynamicSetMemberHandler CreateHandler(PropertyInfo propertyInfo, Type declaringType)
        {
            var methodInfo = propertyInfo.GetSetMethod(true);

            var memberType = propertyInfo.PropertyType;

            var declareingTypeIsValueType = declaringType.IsValueType;
            var memberTypeIsStatic = methodInfo.IsStatic;


            DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, null, DynamicSetMemberParams, declaringType, SkipVisibility);

            ILGenerator generator = dynamicMethod.GetILGenerator();

            if(!memberTypeIsStatic)
            {
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldind_Ref);
                if(declareingTypeIsValueType)
                {
                    generator.Emit(OpCodes.Unbox, declaringType);
                }
            }
            generator.Emit(OpCodes.Ldarg_1);
            if(memberType.IsValueType)
            {
                generator.Emit(OpCodes.Unbox_Any, memberType);
            }

            generator.Emit(OpCodes.Callvirt, methodInfo);
            generator.Emit(OpCodes.Ret);

            return dynamicMethod.CreateDelegate(typeof(DynamicSetMemberHandler)) as DynamicSetMemberHandler;
        }
#endif
        /// <summary>
        /// 创建指定实例成员的动态委托。
        /// </summary>
        /// <param name="member">实例的成员。</param>
        /// <returns>返回一个绑定实例成员实现的委托。</returns>
        protected override string GetToken(PropertyInfo member)
        {
            return SetMemberToken(member);
        }
    }
}