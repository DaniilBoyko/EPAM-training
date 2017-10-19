using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMergeSort
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
            Sorting.MergeSort<int>.Sort(array);
            ShowArray(array);
            Console.WriteLine();

            int[] array2 = { 3, 7, 8, 5, 2, 1, 9, 5, 4, -10, -11, -12 };

            ShowArray(array2);
            Sorting.MergeSort<int>.Sort(array2);
            ShowArray(array2);
        }
    }
}
