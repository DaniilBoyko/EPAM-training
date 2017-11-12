using System;
using System.Collections.Generic;

namespace Sorts
{
    /// <summary>
    /// Sort jagged array.
    /// </summary>
    public class BubbleSort
    { 
        #region public Methods

        /// <summary>
        /// Sort array elements.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="calcArray">Sign for each line. It is function.</param>
        /// <param name="comparer">Comparer for values, which calculate row function return</param>
        public static void SortJaggedArray(double[][] array, Interfaces.ICalculateArray calcArray, IComparer<double> comparer)
        {
            CheckArray(array);

            double[] rowsElements = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                rowsElements[i] = calcArray.CalculateArray(array[i]);
            }

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

        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="array">sorting array</param>
        /// <param name="comparer">comparer</param>
        public static void SortJaggedArray1(double[][] array, IComparer<double[]> comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (comparer.Compare(array[j - 1], array[j]) == -1)
                    {
                        Swap(ref array[j - 1], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="array">sorting array</param>
        /// <param name="delegateComparer">delegate for compare</param>
        public static void SortJaggedArray1(double[][] array, Func<double[], double[], int> delegateComparer)
        {
            SortJaggedArray1(array, new DelegateComparer(delegateComparer));
        }

        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="array">sorting array</param>
        /// <param name="comparer">comparer</param>
        public static void SortJaggedArray2(double[][] array, IComparer<double[]> comparer)
        {
            SortJaggedArray2(array, comparer.Compare);
        }

        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="array">sorting array</param>
        /// <param name="delegateComparer">delegate for compare</param>
        public static void SortJaggedArray2(double[][] array, Func<double[], double[], int> delegateComparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (delegateComparer(array[j - 1], array[j]) < 0)
                    {
                        Swap(ref array[j - 1], ref array[j]);
                    }
                }
            }
        }

        #endregion // !public Methods

        #region private Methods

        /// <summary>
        /// Check array for null and empty.
        /// </summary>
        /// <param name="array"></param>
        private static void CheckArray(Array array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} should contains 1 or more elements", nameof(array));
            }
        }

        /// <summary>
        /// Swap two values.
        /// </summary>
        /// <typeparam name="T">template of type</typeparam>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        private static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        #endregion  // !private Methods

        #region public Inner Classes

        /// <summary>
        /// Compare two double numbers for decrease
        /// </summary>
        public class Decrease : IComparer<double>
        {
            /// <summary>
            /// Compare two double numbers for decrease.
            /// </summary>
            /// <param name="x">left number</param>
            /// <param name="y">right number</param>
            /// <returns>Integer representation of comparison.</returns>
            public int Compare(double x, double y)
            {
                if (x > y)
                {
                    return 1;
                }

                if (x < y)
                {
                    return -1;
                }

                return 0;
            }
        }

        /// <summary>
        /// Compare two double numbers for increase
        /// </summary>
        public class Increase : IComparer<double>
        {
            /// <summary>
            /// Compare two double numbers for increase.
            /// </summary>
            /// <param name="x">left number</param>
            /// <param name="y">right number</param>
            /// <returns>Integer representation of comparison.</returns>
            public int Compare(double x, double y)
            {
                if (x < y)
                {
                    return 1;
                }

                if (x > y)
                {
                    return -1;
                }

                return 0;
            }
        }

        /// <summary>
        /// Contains method for calculation sum of array elements.
        /// </summary>
        public class Sum : Interfaces.ICalculateArray
        {
            /// <summary>
            /// Calculate sum in array.
            /// </summary>
            /// <param name="array">passing array</param>
            /// <returns>Sum of array.</returns>
            public double CalculateArray(double[] array)
            {
                BubbleSort.CheckArray(array);

                double sum = 0;
                foreach (var number in array)
                {
                    sum += number;
                }

                return sum;
            }
        }

        /// <summary>
        /// Contains method for calculation max number of array elements.
        /// </summary>
        public class MaxNumber : Interfaces.ICalculateArray
        {
            /// <summary>
            /// Calculate max number in array.
            /// </summary>
            /// <param name="array">passing array</param>
            /// <returns>Max number in array.</returns>
            public double CalculateArray(double[] array)
            {
                BubbleSort.CheckArray(array);

                double max = array[0];
                foreach (var number in array)
                {
                    if (max < number)
                    {
                        max = number;
                    }
                }

                return max;
            }
        }

        /// <summary>
        /// Contains method for calculation min number of array elements.
        /// </summary>
        public class MinNumber : Interfaces.ICalculateArray
        {
            /// <summary>
            /// Calculate min number in array.
            /// </summary>
            /// <param name="array">passing array.</param>
            /// <returns>Min number in array.</returns>
            public double CalculateArray(double[] array)
            {
                BubbleSort.CheckArray(array);

                double min = array[0];
                foreach (var number in array)
                {
                    if (min > number)
                    {
                        min = number;
                    }
                }

                return min;
            }
        }

        #endregion // !public Inner Classes
    }
}
