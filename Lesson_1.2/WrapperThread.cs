using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_1._2
{
    public class WrapperThread
    {
       private readonly Action<object> action;
        
        public bool IsCompleted { get; private set; } = false;
        public bool IsSuccess { get; private set; } = false;
        public bool IsFaulted { get; private set; } = false;
        public Exception Exception { get; private set; } = null;


        public WrapperThread(Action<object> action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }
       public void Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), state);
        }

        private void ThreadExecution(object state)
        {
            try
            {
                action.Invoke(state);
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

        public void Wait()
        {
            if(IsCompleted == false)
            {
                Thread.Sleep(222);
            }
            if (Exception != null)
            {
                throw Exception;
            }
        }

      }
}
