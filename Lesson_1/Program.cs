using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_1
{

    class Program
    {
        public static Action<object> action = new Action<object>(WriteChar);
        static void Main(string[] args)
        {

           

            ThreadPool.QueueUserWorkItem(new WaitCallback(action),'#');
            ThreadPool.QueueUserWorkItem(new WaitCallback(action),'@');

            Console.Read();
        }

        static void WriteChar(object symbol)
        {
            char ch = (char)symbol;
            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(ch);
            }
        }
       
    }
}
