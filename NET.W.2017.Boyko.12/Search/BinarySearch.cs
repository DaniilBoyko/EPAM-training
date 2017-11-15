using System;

namespace Search
{
    /// <summary>
    /// Contains method for binary search
    /// </summary>
    /// <typeparam name="T">type of the elements in array</typeparam>
    public class BinarySearch<T> where T : IComparable
    {
        #region public Methods

        /// <summary>
        /// Find index of element in array.
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="element">element</param>
        /// <returns></returns>
        public static int Find(T[] array, T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array must contains one or more elements.", nameof(array));
            }

            CheckArray(array);

            int mid, first = 0, last = array.Length - 1;

            while (first <= last)
            {
                mid = (first + last) / 2;
                if (element.CompareTo(array[mid]) == 1)
                {
                    first = mid + 1;
                }

                if (element.CompareTo(array[mid]) == -1)
                {
                    last = mid - 1;
                }

                if (element.CompareTo(array[mid]) == 0)
                {
                    return mid;
                }
            }

            return -1;
        }

        #endregion // !public Methods

        #region private Methods

        /// <summary>
        /// Check array for ascending.
        /// </summary>
        /// <param name="array">array</param>
        private static void CheckArray(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) == -1)
                {
                    throw new ArgumentException("Array must be sorted.", nameof(array));
                }
            }
        }

        #endregion // !private Methods
    }
}
