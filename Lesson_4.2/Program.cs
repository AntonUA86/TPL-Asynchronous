using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_4._2
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await Task.Run(() =>
            {
                for (int i = 0; i < 120; i++)
                {
                    Thread.Sleep(200);
                    Console.WriteLine($"Main {i}");
                }
            });

          await  Task.Run(async () =>
            {
                await CalculateFactorialAsync(3);
            });


            Console.ReadLine();
        }

        static int CalculateFactorial(int number)
        {

            int result = Enumerable.Range(1, number).Aggregate(1, (p, item) => p * item);
            return result;

        }

        static async Task CalculateFactorialAsync(int result)
        {
            int res = await Task.Run(() => CalculateFactorial(result));
            Console.WriteLine($"Async {res}");
        }
    }
}
