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
    /// 表示动态调用方法的委托。
    /// </summary>
    /// <param name="instance">方法的实例。</param>
    /// <param name="parameters">方法的参数值集合。</param>
    /// <returns>返回实例方法调用的返回值。</returns>
    public delegate object DynamicMethodHandler(object instance, params object[] parameters);

    /// <summary>
    /// 表示动态调用方法的工厂。
    /// </summary>
    public sealed class DynamicMethodFactory : DynamicFactoryBase<MethodInfo, DynamicMethodHandler>
    {
        private delegate void DynamicMethodVoidHandler(object instance, params object[] parameters);

        private static readonly DynamicMethodFactory _Instance = new DynamicMethodFactory();
        /// <summary>
        /// 获取动态调用方法的唯一工厂。
        /// </summary>
        public static DynamicMethodFactory Instance
        {
            get
            {
                return _Instance;
            }
        }

        private DynamicMethodFactory() { }

        /// <summary>
        /// 创建指定 <paramref name="methodInfo"/> 的动态方法。
        /// </summary>
        /// <param name="methodInfo">方法的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例方法的委托。</returns>
        protected override DynamicMethodHandler CreateHandler(MethodInfo methodInfo, Type declaringType)
        {
            ParameterInfo[] paramsInfo = methodInfo.GetParameters();

            var instanceParameter = Expression.Parameter(Types.Object, "instance");
            Expression convertInstance = null;
            if(!methodInfo.IsStatic) convertInstance = Expression.Convert(instanceParameter, declaringType);

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
            MethodCallExpression callExp;
            if(methodInfo.IsStatic) callExp = Expression.Call(methodInfo, argsExp);
            else callExp = Expression.Call(convertInstance, methodInfo, argsExp);
            if(methodInfo.ReturnType == Types.Void)
            {
                var voidInvoke = Expression.Lambda<DynamicMethodVoidHandler>(callExp, instanceParameter, param).Compile();
                return (instance, parameters) =>
                {
                    voidInvoke(instance, parameters);
                    return null;
                };
            }
            else
            {
                return Expression.Lambda<DynamicMethodHandler>(Expression.Convert(callExp, Types.Object), instanceParameter, param).Compile();
            }
        }

#if EMIT
        /// <summary>
        /// 创建指定 <paramref name="methodInfo"/> 的动态方法。
        /// </summary>
        /// <param name="methodInfo">方法的元数据。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例方法的委托。</returns>
        protected override DynamicMethodHandler CreateHandler(MethodInfo methodInfo, Type declaringType)
        {
            Type returnType = methodInfo.ReturnType;                      //- 方法的返回类型
            ParameterInfo[] parameterInfos = methodInfo.GetParameters();                 //- 方法的参数集合
            int paramterLength = parameterInfos.Length;

            EmitHelper emit = new EmitHelper(string.Empty,
                                             Types.Object,
                                             new Type[2] { Types.Object, Types.ObjectArray },
                                             declaringType,
                                             SkipVisibility,
                                             false);//- 为什么这里不使用 OwnerType 而使用 member.DeclaringType，主要是考虑到泛型：<object>

            Type[] paramTypes = new Type[paramterLength];

            LocalBuilder[] locals = new LocalBuilder[paramterLength];

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
                emit.LoadArgument(1);       //- 取出参数1 也就是 object[]
                emit.LoadConstant(i);       //- 指定索引号 —— 0
                emit.LoadRefElement();      //- 取出索引元素 object[0]
                emit.CastTo(paramTypes[i]); //- 类型转换，从 object 到指定参数类型。
                emit.StoreLocal(locals[i]);
            }

            if(!methodInfo.IsStatic)
            {
                emit.LoadThis(methodInfo);  //- 非静态，取出实例
                //emit.CastTo(member.DeclaringType);
            }

            for(int i = 0 ; i < paramterLength ; i++)
            {   //- 取出所有 method 函数的参数
                if(parameterInfos[i].ParameterType.IsByRef)
                    emit.LoadLocalBySpecific(locals[i]);
                else
                    emit.LoadLocal(locals[i]);
            }

            emit.Call(methodInfo);

            if(returnType == typeof(void))
            {
                emit.LoadNull();
            }
            else
            {
                emit.TryBox(returnType);
            }

            for(int i = 0 ; i < paramterLength ; i++)
            {
                if(parameterInfos[i].ParameterType.IsByRef)
                {
                    emit.LoadArgument(1);               //- 取出参数1 也就是 object[]
                    emit.LoadConstant(i);               //- 指定索引号 —— 0
                    emit.LoadLocal(locals[i]);          //- 加载指定索引的数组元素
                    emit.TryBox(locals[i].LocalType);   //- 尝试装箱  paramTypes[i]
                    emit.StoreLocalByRef();             //- 赋值给 ref 或  out
                }
            }
            emit.Return();
            return emit.CreateDelegate<DynamicMethodHandler>();
        }
#endif
    }
}