using System;
using System.Threading.Tasks;

namespace Daan.DataTransfer.Client
{
    public class TransferResult<TResult>
    {
        protected TaskCompletionSource<TResult> Tcs;
        protected Task<TResult> Task;

        public bool IsCanceled
        {
            get { return Tcs.Task.IsCanceled; }
        }

        public bool IsCompleted
        {
            get { return Tcs.Task.IsCompleted; }
        }

        public bool IsFaulted
        {
            get { return Tcs.Task.IsFaulted; }
        }

        public int Status
        {
            get { return (int) Task.Status; }
        }

        public int ErrorNo { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public string StatusDescription { get; protected set; }

        public TResult Result { get; protected set; }

        public void Abort()
        {
            if (!Tcs.Task.IsCanceled && !Tcs.Task.IsCompleted)
                Tcs.SetCanceled();
        }

        public void ContinuteWith(Action<TResult> continuation)
        {
            Tcs.Task.ContinueWith((t) => continuation(t.Result));
        }
    }

    internal class TransferResultHandler<TResult> : TransferResult<TResult>
    {
        public TransferResultHandler(TaskCompletionSource<TResult> tcs)
        {
            Tcs = tcs;
            Task = tcs.Task;
        }

        public void SetErrorNo(int exceptionno)
        {
            ErrorNo = exceptionno;
        }

        public void SetErrorDescription(string exceptionmessage)
        {
            ErrorMessage = exceptionmessage;
        }
    }
}