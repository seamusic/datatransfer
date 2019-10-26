namespace System
{
    using System;
    using System.Reflection;

    /// <summary>
    /// 表示内部错误。
    /// </summary>
    public static class InternalResource
    {
        #region Fields

        readonly static Function<string, string> SRGetStringHandler;
        readonly static Function<string, string> EnvironmentGetStringHandler;
        readonly static Function<string, object[], string> EnvironmentGetStringHandler2;

        #endregion Fields

        #region Constructors

        static InternalResource()
        {
            var type = typeof(Function<string, string>);

            const BindingFlags InvokeMethod = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod;

            SRGetStringHandler = Delegate.CreateDelegate(type, typeof(Uri).Assembly.GetType("System.SR").GetMethod("GetString", InvokeMethod), true) as Function<string, string>;
            var envirType = typeof(Environment);
            EnvironmentGetStringHandler = Delegate.CreateDelegate(type,
                envirType.GetMethod("GetResourceString", InvokeMethod, null, new Type[1] { Types.String }, null), true) as Function<string, string>;
            EnvironmentGetStringHandler2 = Delegate.CreateDelegate(type,
                envirType.GetMethod("GetResourceString", InvokeMethod, null, new Type[2] { Types.String, Types.ObjectArray }, null), true) as Function<string, object[], string>;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// 获取 System.SR.GetString 的资源字符串。
        /// </summary>
        /// <param name="name">资源的名称。</param>
        /// <returns>资源字符串。</returns>
        public static string GetString(string name)
        {
            return SRGetStringHandler(name);
        }

        /// <summary>
        /// 获取 System.Environment.GetResourceString 的资源字符串。
        /// </summary>
        /// <param name="name">资源的名称。</param>
        /// <returns>资源字符串。</returns>
        public static string GetResourceString(string name)
        {
            return EnvironmentGetStringHandler(name);
        }

        /// <summary>
        /// 获取 System.Environment.GetResourceString 的资源字符串。
        /// </summary>
        /// <param name="name">资源的名称。</param>
        /// <param name="parameters">参数集合。</param>
        /// <returns>资源字符串。</returns>
        public static string GetResourceString(string name, params object[] parameters)
        {
            return EnvironmentGetStringHandler2(name, parameters);
        }




        #endregion Methods
    }
}