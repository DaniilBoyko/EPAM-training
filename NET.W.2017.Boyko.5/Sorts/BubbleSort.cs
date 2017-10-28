using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public class BubbleSort
    {
        #region Public Methods

        /// <summary>
        /// Calculates the sum of array elements.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Sum of array elements.</returns>
        public static double Sum(double[] array)
        {
            CheckArray(array);

            double sum = 0;
            foreach (var number in array)
                sum += number;
            return sum;
        }

        /// <summary>
        /// Calculates the maximum element in the array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>The maximum element in the array.</returns>
        public static double MaxNumber(double[] array)
        {
            CheckArray(array);

            double max = array[0];
            foreach (var number in array)
                if (max < number)
                    max = number;
            return max;
        }

        /// <summary>
        /// Calculates the minimum element in the arrya.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>The minimum element in the array.</returns>
        public static double MinNumber(double[] array)
        {
            CheckArray(array);

            double min = array[0];
            foreach (var number in array)
                if (min > number)
                    min = number;
            return min;
        }

        /// <summary>
        /// Compare two double numbers for decrease
        /// </summary>
        public class Decrease : IComparer<double>
        {
            public int Compare(double x, double y)
            {
                if (x > y) return 1;
                if (x < y) return -1;
                return 0;
            }
        }

        /// <summary>
        /// Compare two double numbers for increase
        /// </summary>
        public class Increase : IComparer<double>
        {
            public int Compare(double x, double y)
            {
                if (x < y) return 1;
                if (x > y) return -1;
                return 0;
            }
        }

        /// <summary>
        /// Sort array elements
        /// </summary>
        /// <param name="array"></param>
        /// <param name="calcRow">Sign for each line. It is function.</param>
        /// <param name="comparer">Comparer for values, which calcRow function return</param>
        public static void SortJaggedArray(double[][] array, Func<double[], double> calcRow, IComparer<double> comparer)
        {
            CheckArray(array);

            double[] rowsElements = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
                rowsElements[i] = calcRow(array[i]);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (comparer.Compare(rowsElements[j - 1], rowsElements[j]) == -1)
                    {
                        Swap(ref rowsElements[j - 1], ref rowsElements[j]);
                        Swap(ref array[j - 1], ref array[j]);
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private static bool CheckArray(Array array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                throw new ArgumentException($"{nameof(array)} should contains 1 or more elements", nameof(array));

            return true;
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        #endregion  
    }
}
