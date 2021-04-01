using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для запуска нажмите любую клавишу");
            Console.ReadKey();

            WrapperThreadGen<int> threadPoolWorker = new WrapperThreadGen<int>(SumNumber);
            threadPoolWorker.Start(1000);

            while (threadPoolWorker.IsCompleted == false)
            {
                Console.Write("*");
                Thread.Sleep(35);
            }

            Console.WriteLine();
            Console.WriteLine($"Результат асинхронной операции = {threadPoolWorker._result:N}");
            Console.ReadLine();
        }
        private static int SumNumber(object arg)
        {
            int number = (int)arg;
            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                sum += i;
                Thread.Sleep(1);
            }

            return sum;
        }
    }
}
