using System;
using System.Collections.Generic;
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
    public class PullDataClient : AbstractClientBase
    {
        protected IPullDataService DataService = null;
        private Dictionary<int, bool> _tasksStatus = null;

        /// <summary>
        /// 重试的次数
        /// </summary>
        public int RetryTimes { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public PullDataClient()
        {
            DataService = AppCtx.Resolve<IPullDataService>("PullService");
            if (DataService == null)
            {
                LogHelper.Debug(GetType(), "获取接口失败");
                throw new InvalidCastException("获取接口IPullDataService失败");
            }
            ProcessFactory = new DataProcessFactory();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public TREsult PullData<TREsult, TParam>(TParam parameter)
        {
            LogHelper.Debug(GetType(), "准备获取数据");

            OperatorResult = new DataResult();

            if (Begin(parameter))
            {
                #region 开始获取数据
                //初始化容器以收集字符串
                DataHolder = new StringBuilder(SpliteCount * DataLength);

                LogHelper.Debug(GetType(), "开始请求具体数据");

                var semaphore = new SemaphoreSlim(SystemParameter.MaxTaskNumber);
                CancellationToken token = TokenSource.Token;
                var tasks = new Task[SpliteCount];
                _tasksStatus = new Dictionary<int, bool>();

                for (int i = 0; i < SpliteCount; i++)
                {
                    int index = i;
                    int retryTimes = RetryTimes;
                    _tasksStatus.Add(index, false);
                    var task = new Task(() =>
                    {
                        try
                        {
                            semaphore.Wait(token);

                            if (!token.IsCancellationRequested)
                            {
                                //循环执行
                                while (retryTimes > 0)
                                {
                                    if (Pull(index))
                                    {
                                        _tasksStatus[index] = true;
                                        break;
                                    }
                                    retryTimes--;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            OperatorResult.ErrorId = (int)DataDictionary.ErrorType.DataPullError;
                            OperatorResult.ErrorMessage = "获取数据结束出现错误";

                            LogHelper.Error(GetType(), "获取数据出现错误", ex);
                        }
                    });
                    task.ContinueWith(t =>
                                          {
                                              //任务完成，释放一个资源
                                              semaphore.Release();
                                          });

                    tasks[i] = task;
                    task.Start();
                }
                #endregion


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
            }

            return DataProcess<TREsult>();
        }

        /// <summary>
        /// 结束数据接入
        /// </summary>
        /// <returns></returns>
        private void End(bool abndon)
        {
            var endData = DataService.End(DataId, abndon);
            LogHelper.Debug(GetType(), "结束请求数据", LogInfo.ObjectToMessage(endData));

            if (endData == null)
            {
                OperatorResult.ErrorId = (int)DataDictionary.ErrorType.DataPullEndError;
                OperatorResult.ErrorMessage = "获取数据结束出现错误";
            }
        }

        /// <summary>
        /// 组合输出数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T DataProcess<T>()
        {
            if (_tasksStatus.Any(o => o.Value == false))
            {
                return default(T);
            }

            return ProcessFactory.ProcessToObject<T>(DataHolder.ToString());
        }

        private bool Pull(int index)
        {
            //获取数据
            var dataSegment = DataService.Pull(DataId, index);
            LogHelper.Debug(GetType(), string.Format("获取索引为{0}的数据:", index),
                            LogInfo.ObjectToMessage(dataSegment));

            //如果校验通过，则加入
            var result = ProcessFactory.CheckDataSegment(dataSegment);
            if (result)
            {
                DataHolder.Insert(index * DataLength, dataSegment.DataString);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Begin<TParam>(TParam parameter)
        {
            var beginParameter = ProcessFactory.BuildDataParameter(ActionId, parameter);

            LogHelper.Debug(GetType(), "发送请求", LogInfo.ObjectToMessage(beginParameter));

            var beginDataInfo = DataService.Begin(beginParameter);

            if (beginDataInfo == null)
            {
                OperatorResult.ErrorId = (int)DataDictionary.ErrorType.DataPullBeginError;
                OperatorResult.ErrorMessage = "获取头出现错误";
                DataTransferStatus = false;
                LogHelper.Debug(GetType(), "发送请求失败");
                return false;
            }
            else
            {
                SpliteCount = beginDataInfo.SpliteCount;
                DataId = beginDataInfo.DataId;

                LogHelper.Debug(GetType(), "发送请求成功");
                return true;
            }
        }
    }
}
