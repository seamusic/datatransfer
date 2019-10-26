using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Daan.DataTransfer.DataCommon;

namespace Daan.DataTransfer.Client
{

    
    /// <summary>
    /// Web Service 封装类，将webservice 方法进行封装提供更友好易用的调用给调用者
    /// </summary>
    public class WebServiceClientHelper
    {
        /// <summary>
        /// 客户端从服务器拉取数据，采用同步方式 , 获取数据时需要版本号，处理逻辑编号actionid 
        /// </summary>
        /// <typeparam name="TResult">从服务器获取的返回结果类型</typeparam>
        /// <typeparam name="TParam">参数对象类型</typeparam>
        /// <param name="version">版本号</param>
        /// <param name="actionid">处理逻辑编码</param>
        /// <param name="parameter">从服务器获取数据传递给服务器的参数对象</param>
        
        /// <returns>调用服务器指定的逻辑并从服务器返回的结果</returns>
        public TResult Pull<TResult, TParam>(int version, int actionid, TParam parameter)
        {
            try
            {
                var pull = new PullDataClient {Version = version, ActionId = actionid};
                var result = pull.PullData<TResult, TParam>(parameter);
                return result; 
            }
            catch (Exception e)
            {
                LogHelper.Error(GetType(), LogInfo.TraceToMessage(new StackTrace(true)) ,e );
                throw;
            }

        }

        /// <summary>
        /// 异步方法，从服务器获取数据。获取数据时需要版本号，处理逻辑编号actionid 
        /// 此方法异步执行，采用非堵塞方式进行， 等待结果完成再处理其他逻辑使用 transferresult.continutewith 方法
        /// </summary>
        /// <typeparam name="TResult">调用返回结果对象类型</typeparam>
        /// <typeparam name="TParam">往服务器推送数据时的数据对象类型</typeparam>
        /// <param name="version">版本号</param>
        /// <param name="actionid">处理逻辑编码</param>
        /// <param name="parameter">服务器处理数据返回</param>
        /// <returns></returns>
        public TransferResult<TResult> AsyncPull<TResult,TParam> (int version , int actionid, TParam parameter)
        {
            var tcs = new TaskCompletionSource<TResult>();
            var result = new TransferResultHandler<TResult>(tcs);
            WaitCallback asyncWork = _ => tcs.SetResult(Pull<TResult, TParam>(version, actionid,parameter));
            ThreadPool.QueueUserWorkItem(asyncWork);
            return result ; 
        }


        /// <summary>
        /// 往服务器推送数据， 同步方法，需要版本号，处理逻辑编号actionid 来让服务器采用那些逻辑处理传递给服务器的数据
        /// </summary>
        /// <typeparam name="TResult">服务器操作完成后返回的结果</typeparam>
        /// <typeparam name="TParam">往服务器推送数据的对象类型</typeparam>
        /// <param name="version">版本号</param>
        /// <param name="actionid">处理逻辑编码</param>
        /// <param name="data">数据内容对象pono</param>
        /// <param name="serverasyncoption">异步标记，等于true 时服务器采用异步方法处理</param>
        /// <returns>当服务器处理完后返回给客户端的对象，当把异步处理的参数端地给服务器serverasyncoption =true 则返回的是状态</returns>
        public TResult Push<TResult,TParam> ( int version, int actionid , TParam data, bool serverasyncoption )
        {
            try
            {
                var pull = new PushDataClient() { Version = version, ActionId = actionid };
                var result = pull.PushData<TResult, TParam>(data);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(GetType(), LogInfo.TraceToMessage(new StackTrace(true)), e);
                throw;
            }
        }


        /// <summary>
        /// 往服务器推送数据， 异步方法
        /// 需要版本号，处理逻辑编号actionid 
        /// 此方法异步执行，采用非堵塞方式进行， 等待结果完成再处理其他逻辑使用 transferresult.continutewith 方法
        /// </summary>
        /// <typeparam name="TResult">服务器返回的对象类型</typeparam>
        /// <typeparam name="TParam">传递给服务数据的对象类型</typeparam>
        /// <param name="version">版本号</param>
        /// <param name="actionid">处理逻辑编码</param>
        /// <param name="data">数据对象</param>
        /// <param name="serverasyncoption">异步标记，等于true 时服务器采用异步方法处理</param>
        /// <returns></returns>
        public TransferResult<TResult> AsyncPush<TResult, TParam>(int version, int actionid, TParam data, bool serverasyncoption)
        {
            var tcs = new TaskCompletionSource<TResult>();
            var result = new TransferResultHandler<TResult>(tcs);
            WaitCallback asyncWork = _ => tcs.SetResult(Push<TResult, TParam>(version, actionid, data , serverasyncoption));
            ThreadPool.QueueUserWorkItem(asyncWork);
            return result; 
        } 


    }
}