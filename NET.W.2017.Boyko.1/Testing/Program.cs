using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        public static void ShowArray<T>(IEnumerable<T> array)
        {
            foreach (var a in array)
                Console.Write($"{a} ");

            Console.WriteLine();

        }

        public delegate void SortingMethod<T>(T[] array);

        public static void ShowTest<T>(SortingMethod<T> sortingMethod, T[] array)
        {
            ShowArray(array);
            sortingMethod(array);
            ShowArray(array);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string[] array3 = { "A", "a", "B", "b", "c", "d", "q", "l" };
            double[] array2 = { 33.2, 7.0, -8.0, 5.3, 2.2, 1.1, 9.8, 5.2, 4.1, -10.1 };
            int[] array = { 3, 7, 8, 5, 2, 1, 9, 5, 4 };

            Console.WriteLine("Example of Quick Sort");
            ShowTest(Sorting.QuickSort<int>.Sort, array);
            ShowTest(Sorting.QuickSort<double>.Sort, array2);
            ShowTest(Sorting.QuickSort<string>.Sort, array3);

            Console.WriteLine();
            Console.WriteLine();

            array3 = new string[]{ "A", "a", "B", "b", "c", "d", "q", "l" };
            array2 = new double[]{ 33.2, 7.0, -8.0, 5.3, 2.2, 1.1, 9.8, 5.2, 4.1, -10.1 };
            array = new int[]{ 3, 7, 8, 5, 2, 1, 9, 5, 4 };
            Console.WriteLine("Example of Merge Sort");
            ShowTest(Sorting.MergeSort<int>.Sort, array);
            ShowTest(Sorting.MergeSort<double>.Sort, array2);
            ShowTest(Sorting.MergeSort<string>.Sort, array3);


        }
    }
}
