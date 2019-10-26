using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Daan.DataTransfer.DataCommon;
using Daan.DataTransfer.Services;
using Daan.DataTransfer.Utility;
using Sofire.Serialization;

namespace Daan.DataTransfer.Client
{
    public class PushDataClient : AbstractClientBase
    {
        protected IPushDataService DataService = null;
        public PushDataClient()
        {
            DataService = AppCtx.Resolve<IPushDataService>("PushService");
            if (DataService == null)
            {
                LogHelper.Debug(GetType(), "获取接口失败");
                throw new InvalidCastException("获取接口IPushDataService失败");
            }
            ProcessFactory = new DataProcessFactory();
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public TResult PushData<TResult, TParam>(TParam data)
        {
            LogHelper.Debug(GetType(), "准备发送数据");

            Begin(data);

            #region 发送数据

            LogHelper.Debug(GetType(), "开始发送数据");

            var semaphore = new SemaphoreSlim(SystemParameter.MaxTaskNumber);
            CancellationToken token = TokenSource.Token;

            var tasks = new Task[SpliteCount];
            for (int i = 0; i < SpliteCount; i++)
            {
                int index = i;
                var task = Task.Factory.StartNew(() =>
                                      {
                                          try
                                          {
                                              semaphore.Wait(token);
                                              if (!token.IsCancellationRequested)
                                              {
                                                  Push(index);
                                              }
                                          }
                                          catch (Exception ex)
                                          {
                                              LogHelper.Error(GetType(), "发送数据出现错误", ex);
                                          }
                                      });
                task.ContinueWith(t =>
                                      {
                                          semaphore.Release();
                                      });

                tasks[i] = task;
            }
            #endregion

            #region 发送完成

            if (Synchronous)
            {
                Task.WaitAll(tasks);

                var abandon = CancelTransfer;

                if (!CancelTransfer)
                {
                    //检查所有任务是否正确完成
                    if (tasks.Any(task => task.IsFaulted || task.IsCanceled))
                    {
                        abandon = true;
                    }
                }
                //最后操作
                End(abandon);
            }
            else
            {
                End(CancelTransfer);
            }
            #endregion

            return default(TResult);
        }

        /// <summary>
        /// 结束操作
        /// </summary>
        private void End(bool cancel)
        {
            var abandon = CancelTransfer || cancel;
            var endResult = DataService.End(DataId, abandon);
            LogHelper.Debug(GetType(), "发送数据完成");

            if (endResult == null)
            {
                DataTransferStatus = false;
            }
        }

        /// <summary>
        /// 推送数据
        /// </summary>
        /// <param name="index"></param>
        protected virtual void Push(int index)
        {
            var dataSegment = ProcessFactory.BuildDataSegment(index, DataId, DataLength, SpliteCount, DataHolder.ToString());

            DataService.Push(dataSegment);

            LogHelper.Debug(GetType(), string.Format("发送数据，ID：{0}，索引：{1}", DataId, index),
                            LogInfo.ObjectToMessage(dataSegment));
        }

        /// <summary>
        /// 准备数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        private void Begin<T>(T parameter)
        {
            OperatorResult = new DataResult();
            DataId = Guid.NewGuid().ToString();
            OperatorResult.DataId = DataId;
            OperatorResult.Action = ActionId;

            var result = ProcessFactory.ProcessToString(parameter);
            DataHolder = new StringBuilder(result);
            SpliteCount = (int)Math.Ceiling(DataHolder.Length / (double)DataLength);

            var beginDataInfo = new DataInfo { ActionId = ActionId, DataId = DataId, SpliteCount = SpliteCount };

            LogHelper.Debug(GetType(), "开始请求发送数据", LogInfo.ObjectToMessage(beginDataInfo));
            DataService.Begin(beginDataInfo);
        }

    }
}
