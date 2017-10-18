using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckQuickSort
{
    class Program
    {
        public static void ShowArray(int[] array)
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
            QuickSort.QuickSort.Sort(array);
            ShowArray(array);
            Console.WriteLine();

            int[] array2 = { 3, 7, 8, 5, 2, 1, 9, 5, 4 , -10};

            ShowArray(array2);
            QuickSort.QuickSort.Sort(array2);
            ShowArray(array2);
        }
    }
}
