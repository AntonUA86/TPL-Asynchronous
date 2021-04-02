using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_3._1
{
    class Program
    {
        static void Main(string[] args)
        {

            TaskScheduler scheduler = new LimitedConcurrencyTaskScheduler(3);
            Task[] tasks = new Task[30];

            for (int i = 0; i < 30; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(3000);
                    Console.WriteLine($"Выполнена задача #{Task.CurrentId} в потоке {Thread.CurrentThread.ManagedThreadId}");
                });
                tasks[i].Start(scheduler);
            }

            Task.WaitAll(tasks);

            Console.ReadLine();
        }
    }
}
