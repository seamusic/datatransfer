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
    /// 表示动态工厂的基类。
    /// </summary>
    /// <typeparam name="M">表示实例成员的类型。</typeparam>
    /// <typeparam name="H">表示委托的类型。</typeparam>
    public abstract class DynamicFactoryBase<M, H> where M : MemberInfo
    {
        private const string ConcatCharacter = "::";
        private const string SetMemberTokenSuffix = "_Setter";
        private const string GetMemberTokenSuffix = "_Getter";
        internal readonly static Type[] DynamicSetMemberParams = new Type[2] { Types.RefObject, Types.Object };

        /// <summary>
        /// 指示是否要跳过动态方法的 MSIL 访问的类型和成员的 JIT 可见性检查，则为 true；否则为 false。
        /// </summary>
        public const bool SkipVisibility = true;

        internal static readonly Dictionary<string, HanderInfo> Cacher = new Dictionary<string, HanderInfo>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 表示动态函数的委托信息。
        /// </summary>
        public class HanderInfo
        {
            /// <summary>
            /// 唯一标识符。
            /// </summary>
            public readonly string Token;
            /// <summary>
            /// 声明该成员的类。
            /// </summary>
            public readonly Type DeclaringType;
            /// <summary>
            /// 实例的成员。
            /// </summary>
            public readonly MemberInfo Member;
            /// <summary>
            /// 动态委托。
            /// </summary>
            public readonly H Handler;

            internal HanderInfo(string token, Type declaringType, M member, H hander)
            {
                this.Token = token;
                this.DeclaringType = declaringType;
                this.Member = member;
                this.Handler = hander;
            }
        }

        internal DynamicFactoryBase() { }

        /// <summary>
        /// 创建指定实例成员的动态委托。
        /// </summary>
        /// <param name="member">实例的成员。</param>
        /// <returns>返回一个绑定到实例成员的委托。</returns>
        public H Create(M member)
        {
            return this.Create(member, member.DeclaringType);
        }

        /// <summary>
        /// 指定声明成员的类，创建指定实例成员的动态委托。
        /// </summary>
        /// <param name="member">实例的成员。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定到实例成员的委托。</returns>
        public H Create(M member, Type declaringType)
        {
            if(member == null) throw new ArgumentNullException("member");

            HanderInfo info;

            string token = this.GetToken(member);

            lock(member)
            {
                if(!Cacher.TryGetValue(token, out info))
                {
                    var handler = this.CreateHandler(member, declaringType);
                    info = new HanderInfo(token, declaringType, member, handler);
                    Cacher.Add(token, info);
                }
            }
            return info.Handler;
        }

        /// <summary>
        /// 创建指定实例成员的动态委托。
        /// </summary>
        /// <param name="member">实例的成员。</param>
        /// <param name="declaringType">声明该成员的类。</param>
        /// <returns>返回一个绑定实例成员实现的委托。</returns>
        protected abstract H CreateHandler(M member, Type declaringType);

        /// <summary>
        /// 获取当前实例成员的唯一标识。
        /// </summary>
        /// <param name="member">实例的成员。</param>
        /// <returns>返回一个表示当前实例成员的唯一标识。</returns>
        protected virtual string GetToken(M member)
        {
            return MemberToken(member);
        }

        internal static string MemberToken(MemberInfo member)
        {
            return string.Concat(member.DeclaringType.FullName, ConcatCharacter, member.Name);
        }

        internal static string SetMemberToken(MemberInfo member)
        {
            return string.Concat(member.DeclaringType.FullName, ConcatCharacter, member.Name, SetMemberTokenSuffix);
        }

        internal static string GetMemberToken(MemberInfo member)
        {
            return string.Concat(member.DeclaringType.FullName, ConcatCharacter, member.Name, GetMemberTokenSuffix);
        }

        internal static DynamicGetMemberHandler CreateGetMemberHandler(Type declaringType, Function<Expression, MemberExpression> memberCreater)
        {
            var instanceParameter = Expression.Parameter(Types.Object, "instance");
            var convertInstance = Expression.Convert(instanceParameter, declaringType);

            var body = Expression.Convert(memberCreater(convertInstance), Types.Object);

            return Expression.Lambda<DynamicGetMemberHandler>(body, instanceParameter).Compile();
        }
        /*
        internal static DynamicSetMemberHandler CreateSetMemberHandler(Type declaringType, Function<Expression, MemberExpression> memberCreater)
        {
            var instanceParameter = Expression.Parameter(Types.RefObject, "instance");
            var valueParameter = Expression.Parameter(Types.Object, "value");
            var convertInstance = Expression.Convert(instanceParameter, declaringType);
            var memberRef = memberCreater(convertInstance);
            var convertValue = Expression.Convert(valueParameter, memberRef.Type);
            // .net 4.0
            // return Expression.Lambda<DynamicSetMemberHandler>(Expression.Assign(fieldRef, convertValue), instanceParameter, valueParameter).Compile();

            return Expression.Lambda<DynamicSetMemberHandler>(ExpressionExs.Assign(memberRef, convertValue), instanceParameter, valueParameter).Compile();

        }
         */
    }
}