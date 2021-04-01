using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var task = Task.Run(() =>  WriteChar('3'));
           
        
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(2000);
                Console.Write("$");
            }
            if(task.IsCompleted == true)
            {
                Console.WriteLine("Метод Main закончил свою работу");
            }
            Console.ReadLine();
            
        }

        private static void WriteChar(object symbol)
        {
            char ch = (char)symbol;
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(100);
                Console.Write(ch);
            }
        }
    }
}
