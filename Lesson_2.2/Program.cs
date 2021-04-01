using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<double> task = Task<double>.Run(() => FindLastFibonacciNumber(33)) ;
            task.ContinueWith((t) => GetResult(t), TaskContinuationOptions.LongRunning);
            Console.Read();
        }


        private static double FindLastFibonacciNumber(int number)
        {
            Func<int, double> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            return fib.Invoke(number);
        }

        public static void GetResult(Task<double> task)
        {
            double Result = task.Result;
            Console.WriteLine(Result);

        }
    }
}
