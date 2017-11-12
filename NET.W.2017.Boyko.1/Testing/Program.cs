using System;
using System.Collections.Generic;

namespace Testing
{
    /// <summary>
    /// Show functionality of sorting.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Delegate for sorting method.
        /// </summary>
        /// <typeparam name="T">type of elements in array</typeparam>
        /// <param name="array">sorting array</param>
        public delegate void SortingMethod<T>(T[] array);

        /// <summary>
        /// Method for show array.
        /// </summary>
        /// <typeparam name="T">type of elements in array</typeparam>
        /// <param name="array">showing array</param>
        public static void ShowArray<T>(IEnumerable<T> array)
        {
            foreach (var a in array)
            {
                Console.Write($"{a} ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Show tests of sorting array.
        /// </summary>
        /// <param name="sortingMethod">method of sorting</param>
        /// <param name="array">array to sort</param>
        /// <typeparam name="T">type of elements in array</typeparam>
        public static void ShowTest<T>(SortingMethod<T> sortingMethod, T[] array)
        {
            ShowArray(array);
            sortingMethod(array);
            ShowArray(array);
            Console.WriteLine();
        }

        /// <summary>
        /// Startup point of the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
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

            array3 = new[] { "A", "a", "B", "b", "c", "d", "q", "l" };
            array2 = new[] { 33.2, 7.0, -8.0, 5.3, 2.2, 1.1, 9.8, 5.2, 4.1, -10.1 };
            array = new[] { 3, 7, 8, 5, 2, 1, 9, 5, 4 };
            Console.WriteLine("Example of Merge Sort");
            ShowTest(Sorting.MergeSort<int>.Sort, array);
            ShowTest(Sorting.MergeSort<double>.Sort, array2);
            ShowTest(Sorting.MergeSort<string>.Sort, array3);
        }
    }
}
