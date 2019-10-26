using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Daan.DataTransfer.DataCommon;
using Daan.DataTransfer.Utility;

namespace Daan.DataTransfer.Client
{
    public abstract class AbstractClientBase
    {
        /// <summary>
        /// 验证的KEY
        /// </summary>
        public string AuthKey = AppSettingsHelper.GetString("AuthKey");
        /// <summary>
        /// 验证的值
        /// </summary>
        public string AuthValue = AppSettingsHelper.GetString("AuthValue");
        /// <summary>
        /// 每节发送的长度
        /// </summary>
        protected int DataLength
        {
            get { return SystemParameter.DataLength; }
        }

        /// <summary>
        /// 数据容器
        /// </summary>
        protected StringBuilder DataHolder { get; set; }
        /// <summary>
        /// 划分数量
        /// </summary>
        protected int SpliteCount = 0;
        /// <summary>
        /// 数据传输状态
        /// </summary>
        protected bool DataTransferStatus = true;
        /// <summary>
        /// 版本号
        /// </summary>
        public virtual int Version { protected get; set; }
        /// <summary>
        /// 动作ID
        /// </summary>
        public virtual int ActionId { protected get; set; }

        /// <summary>
        /// 数据ID
        /// </summary>
        public virtual string DataId { protected get; set; }

        /// <summary>
        /// 是否取消
        /// </summary>
        public virtual bool CancelTransfer { protected get; set; }

        /// <summary>
        /// 是否同步传输
        /// </summary>
        public bool Synchronous { get; set; }

        /// <summary>
        /// 操作结果
        /// </summary>
        public DataResult OperatorResult { get; protected set; }

        protected CancellationTokenSource TokenSource = new CancellationTokenSource();

        public void Cancel()
        {
            CancelTransfer = true;
            TokenSource.Cancel();
        }

        protected DataProcessFactory ProcessFactory { get; set; }
    }
}
