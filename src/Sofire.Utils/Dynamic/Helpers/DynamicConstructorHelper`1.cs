#if DynamicConstructorHelper
using System;
using System.Collections.Generic;
using System.Text;
using Sofire.Dynamic.Factories;
using System.Reflection;

namespace Sofire.Dynamic
{
    /// <summary>
    /// 表示构造函数的动态实现。
    /// </summary>
    /// <typeparam name="I">实例的类型。</typeparam>
    public class DynamicConstructorHelper<I> : DynamicHelperBase<I>
    {
#region ctor

        /// <summary>
        /// 初始化 <see cref="Sofire.Dynamic.DynamicConstructorHelper&lt;I&gt;"/> 类的新实例。
        /// </summary>
        public DynamicConstructorHelper() { }

        /// <summary>
        /// 指定绑定动态实现的实例类型，初始化 <see cref="Sofire.Dynamic.DynamicConstructorHelper&lt;I&gt;"/> 类的新实例。
        /// </summary>
        /// <param name="instanceType">实例类型。</param>
        public DynamicConstructorHelper(Type instanceType) : base(instanceType) { }

        #endregion

#region This Methods

        /// <summary>
        /// 获取指定参数类型的动态构造函数委托。
        /// </summary>
        /// <param name="types">构造函数参数的类型集合。</param>
        /// <returns>返回一个动态绑定的构造函数委托。</returns>
        public DynamicMethodInvoke this[params Type[] types]
        {
            get
            {
                return this[this.GetConstructor(types)];
            }
        }

        /// <summary>
        /// 获取指定参数类型和构造函数绑定标识的动态构造函数委托。
        /// </summary>
        /// <param name="bindingAttr">构造函数绑定标识。</param>
        /// <param name="types">构造函数参数的类型集合。</param>
        /// <returns>返回一个动态绑定的构造函数委托。</returns>
        public DynamicMethodInvoke this[BindingFlags bindingAttr, params Type[] types]
        {
            get
            {
                return this[this.GetConstructor(bindingAttr, types)];
            }
        }

        /// <summary>
        /// 获取指定构造函数元数据的动态构造函数委托。
        /// </summary>
        /// <param name="constructorInfo">构造函数元数据。</param>
        /// <returns>返回一个动态绑定的构造函数委托。</returns>
        public DynamicMethodInvoke this[ConstructorInfo constructorInfo]
        {
            get
            {
                var handler = this.CreateHandler(constructorInfo);
                return ((parameters) =>
                {
                    return handler(parameters);
                });
            }
        }

        #endregion

#region Create Instance

        /// <summary>
        /// 动态创建一个默认构造函数的实例。
        /// </summary>
        /// <returns>返回动态创建的实例。</returns>
        public I CreateInstance()
        {
            return this.CreateInstance(this.GetConstructor());
        }

        /// <summary>
        /// 动态创建一个指定构造函数绑定标识的实例。
        /// </summary>
        /// <param name="bindingAttr">构造函数绑定标识。</param>
        /// <returns>返回动态创建的实例。</returns>
        public I CreateInstance(BindingFlags bindingAttr)
        {
            return this.CreateInstance(this.GetConstructor(bindingAttr));
        }

        /// <summary>
        /// 动态创建一个指定构造函数参数类型的实例。
        /// </summary>
        /// <param name="types">构造函数参数的类型集合。</param>
        /// <param name="parameters">参数对应的值。</param>
        /// <returns>返回动态创建的实例。</returns>
        public I CreateInstance(Type[] types, params object[] parameters)
        {
            return this.CreateInstance(this.GetConstructor(types), parameters);
        }

        /// <summary>
        /// 动态创建一个指定构造函数绑定标识和参数类型的实例。
        /// </summary>
        /// <param name="bindingAttr">构造函数绑定标识。</param>
        /// <param name="types">构造函数参数的类型集合。</param>
        /// <param name="parameters">参数对应的值。</param>
        /// <returns>返回动态创建的实例。</returns>
        public I CreateInstance(BindingFlags bindingAttr, Type[] types, params object[] parameters)
        {
            return this.CreateInstance(this.GetConstructor(bindingAttr, types), parameters);
        }

        /// <summary>
        /// 动态创建一个指定构造函数元数据的实例。
        /// </summary>
        /// <param name="constructorInfo">构造函数元数据。</param>
        /// <param name="parameters">参数对应的值。</param>
        /// <returns>返回动态创建的实例。</returns>
        public I CreateInstance(ConstructorInfo constructorInfo, params object[] parameters)
        {
            return (I)this.CreateHandler(constructorInfo)(parameters);
        }

        #endregion

#region Create Handler

        /// <summary>
        /// 创建一个默认构造函数的工厂委托。
        /// </summary>
        /// <returns>返回一个动态创建实例的工厂委托。</returns>
        public DynamicConstructorHandler CreateHandler()
        {
            return this.CreateHandler(this.GetConstructor());
        }

        /// <summary>
        /// 创建一个指定构造函数绑定标识的工厂委托。
        /// </summary>
        /// <param name="bindingAttr">构造函数绑定标识。</param>
        /// <returns>返回一个动态创建实例的工厂委托。</returns>
        public DynamicConstructorHandler CreateHandler(BindingFlags bindingAttr)
        {
            return this.CreateHandler(this.GetConstructor(bindingAttr));
        }

        /// <summary>
        /// 创建一个指定构造函数参数类型的工厂委托。
        /// </summary>
        /// <param name="types">构造函数参数的类型集合。</param>
        /// <returns>返回一个动态创建实例的工厂委托。</returns>
        public DynamicConstructorHandler CreateHandler(params Type[] types)
        {
            return this.CreateHandler(this.GetConstructor(types));
        }

        /// <summary>
        /// 创建一个指定构造函数绑定标识和参数类型的工厂委托。
        /// </summary>
        /// <param name="bindingAttr">构造函数绑定标识。</param>
        /// <param name="types">构造函数参数的类型集合。</param>
        /// <returns>返回一个动态创建实例的工厂委托。</returns>
        public DynamicConstructorHandler CreateHandler(BindingFlags bindingAttr, params Type[] types)
        {
            return this.CreateHandler(this.GetConstructor(bindingAttr, types));
        }

        /// <summary>
        /// 创建一个指定构造函数元数据的工厂委托。
        /// </summary>
        /// <param name="constructorInfo">构造函数元数据。</param>
        /// <returns>返回一个动态创建实例的工厂委托。</returns>
        public DynamicConstructorHandler CreateHandler(ConstructorInfo constructorInfo)
        {
            return DynamicConstructorFactory.Instance.Create(constructorInfo);
        }

        #endregion

#region Get Constructor/s

        /// <summary>
        /// 获取默认的构造函数元数据。
        /// </summary>
        /// <returns>返回一个构造函数的元数据。</returns>
        public ConstructorInfo GetConstructor()
        {
            return this.GetConstructor(Type.EmptyTypes);
        }

        /// <summary>
        /// 获取指定构造函数绑定标识的构造函数元数据。
        /// </summary>
        /// <param name="bindingAttr">构造函数绑定标识。</param>
        /// <returns>返回一个构造函数的元数据。</returns>
        public ConstructorInfo GetConstructor(BindingFlags bindingAttr)
        {
            return this.GetConstructor(bindingAttr, Type.EmptyTypes);
        }

        /// <summary>
        /// 获取指定构造函数参数类型的构造函数元数据。
        /// </summary>
        /// <param name="types">构造函数参数的类型集合。</param>
        /// <returns>返回一个构造函数的元数据。</returns>
        public ConstructorInfo GetConstructor(params Type[] types)
        {
            return this.GetConstructor(MemberFlags.InstanceFlags, types);
        }

        /// <summary>
        /// 获取指定构造函数绑定标识和参数类型的构造函数元数据。
        /// </summary>
        /// <param name="bindingAttr">构造函数绑定标识。</param>
        /// <param name="types">构造函数参数的类型集合。</param>
        /// <returns>返回一个构造函数的元数据。</returns>
        public ConstructorInfo GetConstructor(BindingFlags bindingAttr, params Type[] types)
        {
            return this._InstanceType.GetConstructor(bindingAttr, null, types, null);
        }

        /// <summary>
        /// 获取所有公共的构造函数。
        /// </summary>
        /// <returns>返回多个构造函数的元数据。</returns>
        public ConstructorInfo[] GetConstructors()
        {
            return this._InstanceType.GetConstructors();
        }

        /// <summary>
        /// 获取指定构造函数绑定标识的多个构造函数。
        /// </summary>
        /// <param name="bindingAttr">构造函数绑定标识。</param>
        /// <returns>返回多个构造函数的元数据。</returns>
        public ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
        {
            return this._InstanceType.GetConstructors(bindingAttr);
        }

        #endregion

    }
}
#endif