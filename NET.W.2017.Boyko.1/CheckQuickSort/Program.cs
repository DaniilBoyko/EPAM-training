using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting;

namespace CheckQuickSort
{
    class Program
    {
        public static void ShowArray<T>(IEnumerable<T> array)
        {
            foreach (var a in array)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine();

        }

        static void Main(string[] args)
        {
            int[] array = { 3, 7, 8, 5, 2, 1, 9, 5, 4 };

            ShowArray(array);
            QuickSort<int>.Sort(array);
            ShowArray(array);
            Console.WriteLine();

            double[] array2 = { 33.2, 7.0, -8.0, 5.3, 2.2, 1.1, 9.8, 5.2, 4.1, -10.1};

            ShowArray(array2);
            QuickSort<double>.Sort(array2);
            ShowArray(array2);
            Console.WriteLine();

            string[] array3 = { "A", "a", "B", "b", "c" , "d" ,"q", "l"};

            ShowArray(array3);
            QuickSort<string>.Sort(array3);
            ShowArray(array3);
        }
    }
}
