using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 1, 3, 55, 12, 4 };
    
            Task<int[]> task = Task<int[]>.Run(() => SortArray(true, array));
            task.ContinueWith(GetResult);




            Console.ReadLine();
        }
        private static int[] SortArray(bool isAscending, params int[] array)
        {
            int[] result = new int[array.Length];
            if(isAscending == true)
            {
                result = array.OrderBy(i => i).ToArray();
            }
            else
            {
                result = array.OrderByDescending(i => i).ToArray();
            }
            
            return result;
        }

        public static void GetResult(Task<int[]> t)
        {
            var array = t.Result;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{ array[i]},");
            }
                       
        }
 
    }
}
