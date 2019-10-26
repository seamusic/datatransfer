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
    /// 表示动态创建实例的委托。
    /// </summary>
    /// <param name="parameters">构造函数的参数值集合。</param>
    /// <returns>返回一个动态创建的实例。</returns>
    public delegate object DynamicConstructorHandler(params object[] parameters);

    /// <summary>
    /// 表示动态创建实例的工厂。
    /// </summary>
    public sealed class DynamicConstructorFactory : DynamicFactoryBase<ConstructorInfo, DynamicConstructorHandler>
    {
        private static readonly DynamicConstructorFactory _Instance = new DynamicConstructorFactory();
        /// <summary>
        /// 获取动态创建实例的唯一工厂。
        /// </summary>
        public static DynamicConstructorFactory Instance
        {
            get
            {
                return _Instance;
            }
        }

        private DynamicConstructorFactory() { }

        /// <summary>
        /// 创建指定 <paramref name="constructorInfo"/> 的动态构造函数。
        /// </summary>
        /// <param name="constructorInfo">构造函数的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例构造函数的委托。</returns>
        protected override DynamicConstructorHandler CreateHandler(ConstructorInfo constructorInfo, Type declaringType)
        {
            var paramsInfo = constructorInfo.GetParameters();

            //- 创建函数的参数
            var param = Expression.Parameter(typeof(object[]), "parameters");
            var argsExp = new Expression[paramsInfo.Length];


            for(int i = 0 ; i < paramsInfo.Length ; i++)
            {
                var index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;
                var paramAccessorExp = Expression.ArrayIndex(param, index);
                var paramCastExp = Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }
        
            var newExp =     Expression.Convert(Expression.New(constructorInfo, argsExp),Types.Object);

            return Expression.Lambda<DynamicConstructorHandler>(newExp, param).Compile();
        }

#if EMIT
        /// <summary>
        /// 创建指定 <paramref name="constructorInfo"/> 的动态构造函数。
        /// </summary>
        /// <param name="constructorInfo">构造函数的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例构造函数的委托。</returns>
        protected override DynamicConstructorHandler CreateHandler(ConstructorInfo constructorInfo, Type declaringType)
        {
            if(declaringType.IsValueType)
            {
                return (parameters) =>
                {
                    return Activator.CreateInstance(declaringType, parameters);
                };
            }
            ParameterInfo[] parameterInfos = constructorInfo.GetParameters();
            int paramterLength = parameterInfos.Length;


            EmitHelper emit = new EmitHelper(string.Empty,
                                             Types.Object,
                                             new Type[1] { Types.ObjectArray },
                                             declaringType,
                                             SkipVisibility, true);

            Type[] paramTypes = new Type[paramterLength];
            LocalBuilder[] locals = new LocalBuilder[paramterLength];

            if(paramterLength > 0)
            {
                for(int i = 0 ; i < paramterLength ; i++)
                {
                    if(parameterInfos[i].ParameterType.IsByRef)
                    {
                        paramTypes[i] = parameterInfos[i].ParameterType.GetElementType();
                    }
                    else
                    {
                        paramTypes[i] = parameterInfos[i].ParameterType;
                    }

                    locals[i] = emit.DeclareLocal(paramTypes[i]);
                    emit.LoadArgument(0);       //- 取出参数0 也就是 object[]
                    emit.LoadConstant(i);       //- 指定索引号 —— 0
                    emit.LoadRefElement();      //- 取出索引元素 object[0]
                    emit.CastTo(paramTypes[i]); //- 类型转换，从 object 到指定参数类型。
                    emit.StoreLocal(locals[i]);
                }

                for(int i = 0 ; i < paramterLength ; i++)
                {   //- 取出所有 method 函数的参数
                    if(parameterInfos[i].ParameterType.IsByRef)
                        emit.LoadLocalBySpecific(locals[i]);
                    else
                        emit.LoadLocal(locals[i]);
                }
            }
            emit.NewObject(constructorInfo);

            emit.Return();
            return emit.CreateDelegate<DynamicConstructorHandler>();
        }

#endif
    }
}