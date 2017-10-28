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

        public static double Sum(double[] array)
        {
            CheckArray(array);

            double sum = 0;
            foreach (var number in array)
                sum += number;
            return sum;
        }

        public static double MaxNumber(double[] array)
        {
            CheckArray(array);

            double max = array[0];
            foreach (var number in array)
                if (max < number)
                    max = number;
            return max;
        }

        public static double MinNumber(double[] array)
        {
            CheckArray(array);

            double min = array[0];
            foreach (var number in array)
                if (min > number)
                    min = number;
            return min;
        }

        public class Decrease : IComparer<double>
        {
            public int Compare(double x, double y)
            {
                if (x > y) return 1;
                if (x < y) return -1;
                return 0;
            }
        }

        public class Increase : IComparer<double>
        {
            public int Compare(double x, double y)
            {
                if (x < y) return 1;
                if (x > y) return -1;
                return 0;
            }
        }

        public static void SortJaggedArray(double[][] array, Func<double[], double> calcRow, IComparer<double> comparable)
        {
            CheckArray(array);

            double[] rowsElements = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
                rowsElements[i] = calcRow(array[i]);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (comparable.Compare(rowsElements[j - 1], rowsElements[j]) == -1)
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
