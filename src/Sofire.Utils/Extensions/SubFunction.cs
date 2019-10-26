namespace System
{
    #region Delegates

    /// <summary>
    /// 表示包含一个返回值的的委托。
    /// </summary>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<TResult>();

    /// <summary>
    /// 表示包含一个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T">参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg">参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T, TResult>(T arg);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, TResult>(T1 arg1, T2 arg2);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <typeparam name="T13">第 13 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    /// <param name="arg13">第 13 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <typeparam name="T13">第 13 个参数的类型。</typeparam>
    /// <typeparam name="T14">第 14 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    /// <param name="arg13">第 13 个参数的值。</param>
    /// <param name="arg14">第 14 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <typeparam name="T13">第 13 个参数的类型。</typeparam>
    /// <typeparam name="T14">第 14 个参数的类型。</typeparam>
    /// <typeparam name="T15">第 15 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    /// <param name="arg13">第 13 个参数的值。</param>
    /// <param name="arg14">第 14 个参数的值。</param>
    /// <param name="arg15">第 15 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);

    /// <summary>
    /// 表示包含一个或多个参数，以及一个返回值的的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <typeparam name="T13">第 13 个参数的类型。</typeparam>
    /// <typeparam name="T14">第 14 个参数的类型。</typeparam>
    /// <typeparam name="T15">第 15 个参数的类型。</typeparam>
    /// <typeparam name="T16">第 16 个参数的类型。</typeparam>
    /// <typeparam name="TResult">返回值的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    /// <param name="arg13">第 13 个参数的值。</param>
    /// <param name="arg14">第 14 个参数的值。</param>
    /// <param name="arg15">第 15 个参数的值。</param>
    /// <param name="arg16">第 16 个参数的值。</param>
    /// <returns>函数的返回值。</returns>
    public delegate TResult Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

    /// <summary>
    /// 表示无参数无返回值的委托。
    /// </summary>
    public delegate void Sub();

    /// <summary>
    /// 表示包含一个参数的委托。
    /// </summary>
    /// <typeparam name="T">参数的类型。</typeparam>
    /// <param name="arg">参数的值。</param>
    public delegate void Sub<T>(T arg);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    public delegate void Sub<T1, T2>(T1 arg1, T2 arg2);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    public delegate void Sub<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7, T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <typeparam name="T13">第 13 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    /// <param name="arg13">第 13 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <typeparam name="T13">第 13 个参数的类型。</typeparam>
    /// <typeparam name="T14">第 14 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    /// <param name="arg13">第 13 个参数的值。</param>
    /// <param name="arg14">第 14 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <typeparam name="T13">第 13 个参数的类型。</typeparam>
    /// <typeparam name="T14">第 14 个参数的类型。</typeparam>
    /// <typeparam name="T15">第 15 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    /// <param name="arg13">第 13 个参数的值。</param>
    /// <param name="arg14">第 14 个参数的值。</param>
    /// <param name="arg15">第 15 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);

    /// <summary>
    /// 表示包含一个或多个参数的委托。
    /// </summary>
    /// <typeparam name="T1">第 1 个参数的类型。</typeparam>
    /// <typeparam name="T2">第 2 个参数的类型。</typeparam>
    /// <typeparam name="T3">第 3 个参数的类型。</typeparam>
    /// <typeparam name="T4">第 4 个参数的类型。</typeparam>
    /// <typeparam name="T5">第 5 个参数的类型。</typeparam>
    /// <typeparam name="T6">第 6 个参数的类型。</typeparam>
    /// <typeparam name="T7">第 7 个参数的类型。</typeparam>
    /// <typeparam name="T8">第 8 个参数的类型。</typeparam>
    /// <typeparam name="T9">第 9 个参数的类型。</typeparam>
    /// <typeparam name="T10">第 10 个参数的类型。</typeparam>
    /// <typeparam name="T11">第 11 个参数的类型。</typeparam>
    /// <typeparam name="T12">第 12 个参数的类型。</typeparam>
    /// <typeparam name="T13">第 13 个参数的类型。</typeparam>
    /// <typeparam name="T14">第 14 个参数的类型。</typeparam>
    /// <typeparam name="T15">第 15 个参数的类型。</typeparam>
    /// <typeparam name="T16">第 16 个参数的类型。</typeparam>
    /// <param name="arg1">第 1 个参数的值。</param>
    /// <param name="arg2">第 2 个参数的值。</param>
    /// <param name="arg3">第 3 个参数的值。</param>
    /// <param name="arg4">第 4 个参数的值。</param>
    /// <param name="arg5">第 5 个参数的值。</param>
    /// <param name="arg6">第 6 个参数的值。</param>
    /// <param name="arg7">第 7 个参数的值。</param>
    /// <param name="arg8">第 8 个参数的值。</param>
    /// <param name="arg9">第 9 个参数的值。</param>
    /// <param name="arg10">第 10 个参数的值。</param>
    /// <param name="arg11">第 11 个参数的值。</param>
    /// <param name="arg12">第 12 个参数的值。</param>
    /// <param name="arg13">第 13 个参数的值。</param>
    /// <param name="arg14">第 14 个参数的值。</param>
    /// <param name="arg15">第 15 个参数的值。</param>
    /// <param name="arg16">第 16 个参数的值。</param>
    public delegate void Sub<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

    #endregion Delegates
}