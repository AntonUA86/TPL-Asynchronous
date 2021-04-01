using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_1._3
{
    class WrapperThreadGen<TResult>
    {
        Func<object, TResult> func;

        public bool IsCompleted { get; private set; } = false;
        public bool IsSuccess { get; private set; } = false;
        public bool IsFaulted { get; private set; } = false;
        public Exception Exception { get; private set; } = null;
        private    TResult Result;
        public TResult _result
        {
            get
            {
                while (IsCompleted == false)
                {
                    Thread.Sleep(150);
                }

                return IsSuccess == true && Exception == null ? Result : throw Exception;
            }
        }


        public WrapperThreadGen(Func<object,TResult> func)
        {
            this.func = func ?? throw new ArgumentNullException(nameof(func));
            Result = default;
        }

        public void  Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), state);
        }
        private void ThreadExecution(object state)
        {
            try
            {
                Result = func.Invoke(state);
                IsSuccess = true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                IsSuccess = false;
            }
            finally
            {
                IsCompleted = true;
            }
        }
    }
}
