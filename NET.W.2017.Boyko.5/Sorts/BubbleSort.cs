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

        #region Public

        #region public Inner Classes

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
        /// Contains method for calculation sum of array elements.
        /// </summary>
        public class Sum : Interfaces.ICalculateArray
        {
            public double CalculateArray(double[] array)
            {
                CheckArray(array);

                double sum = 0;
                foreach (var number in array)
                    sum += number;
                return sum;
            }
        }

        /// <summary>
        /// Contains method for calculation max number of array elements.
        /// </summary>
        public class MaxNumber : Interfaces.ICalculateArray
        {
            public double CalculateArray(double[] array)
            {
                CheckArray(array);

                double max = array[0];
                foreach (var number in array)
                    if (max < number)
                        max = number;
                return max;
            }
        }

        /// <summary>
        /// Contains method for calculation min number of array elements.
        /// </summary>
        public class MinNumber : Interfaces.ICalculateArray
        {
            public double CalculateArray(double[] array)
            {
                CheckArray(array);

                double min = array[0];
                foreach (var number in array)
                    if (min > number)
                        min = number;
                return min;
            }
        }

        #endregion public Inner Classes

        #region public Methods

        /// <summary>
        /// Sort array elements
        /// </summary>
        /// <param name="array"></param>
        /// <param name="calcArray">Sign for each line. It is function.</param>
        /// <param name="comparer">Comparer for values, which calcRow function return</param>
        public static void SortJaggedArray(double[][] array, Interfaces.ICalculateArray calcArray, IComparer<double> comparer)
        {
            CheckArray(array);

            double[] rowsElements = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
                rowsElements[i] = calcArray.CalculateArray(array[i]);

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

        #endregion public Methods

        #endregion Public


        #region Private

        #region private Methods

        /// <summary>
        /// Check arrya for null and empty.
        /// </summary>
        /// <param name="array"></param>
        private static void CheckArray(Array array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                throw new ArgumentException($"{nameof(array)} should contains 1 or more elements", nameof(array));

            return;
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

        #endregion  private Methods

        #endregion Private

    }
}
