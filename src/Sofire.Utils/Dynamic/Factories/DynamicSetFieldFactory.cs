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
    /// 表示动态设置成员的委托。
    /// </summary>
    /// <param name="instance">成员的实例。</param>
    /// <param name="value">成员的值。</param>
    public delegate void DynamicSetMemberHandler(ref object instance, object value);

    /// <summary>
    /// 表示动态设置字段的工厂。
    /// </summary>
    public sealed class DynamicSetFieldFactory : DynamicFactoryBase<FieldInfo, DynamicSetMemberHandler>
    {
        private static readonly DynamicSetFieldFactory _Instance = new DynamicSetFieldFactory();
        /// <summary>
        /// 获取动态设置字段的唯一工厂。
        /// </summary>
        public static DynamicSetFieldFactory Instance
        {
            get
            {
                return _Instance;
            }
        }

        private DynamicSetFieldFactory() { }

        #region Methods

        /// <summary>
        /// 创建指定 <paramref name="fieldInfo"/> 的动态字段设置器。
        /// </summary>
        /// <param name="fieldInfo">字段的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例字段设置器的委托。</returns>
        protected override DynamicSetMemberHandler CreateHandler(FieldInfo fieldInfo, Type declaringType)
        {
            //return CreateSetMemberHandler(declaringType, (convertInstance) => Expression.Field(fieldInfo.IsStatic ? null : convertInstance, fieldInfo));
            var instanceParameter = Expression.Parameter(Types.RefObject, "instance");
            var valueParameter = Expression.Parameter(Types.Object, "value");
            var convertInstance = Expression.Convert(instanceParameter, declaringType);
            var convertValue = Expression.Convert(valueParameter, fieldInfo.FieldType);
            var fieldRef = Expression.Field(fieldInfo.IsStatic
                ? null
                : convertInstance, fieldInfo);

            return Expression.Lambda<DynamicSetMemberHandler>(ExpressionExs.Assign(fieldRef, convertValue), instanceParameter, valueParameter).Compile();
        }

#if EMIT
        /// <summary>
        /// 创建指定 <paramref name="fieldInfo"/> 的动态字段设置器。
        /// </summary>
        /// <param name="fieldInfo">字段的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例字段设置器的委托。</returns>
        protected override DynamicSetMemberHandler CreateHandler(FieldInfo fieldInfo, Type declaringType)
        {
            var memberType = fieldInfo.FieldType;

            var declareingTypeIsValueType = declaringType.IsValueType;
            var memberTypeIsStatic = fieldInfo.IsStatic;

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

            generator.Emit(memberTypeIsStatic ? OpCodes.Stsfld : OpCodes.Stfld, fieldInfo);

            generator.Emit(OpCodes.Ret);

            return dynamicMethod.CreateDelegate(typeof(DynamicSetMemberHandler)) as DynamicSetMemberHandler;
        }

#endif
        /// <summary>
        /// 创建指定实例成员的动态委托。
        /// </summary>
        /// <param name="member">实例的成员。</param>
        /// <returns>返回一个绑定实例成员实现的委托。</returns>
        protected override string GetToken(FieldInfo member)
        {
            return SetMemberToken(member);
        }

        #endregion Methods
    }
}