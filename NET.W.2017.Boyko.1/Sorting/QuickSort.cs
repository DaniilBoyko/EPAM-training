using System;

namespace Sorting
{
    /// <summary>
    /// Sort array with quick sort method.
    /// </summary>
    /// <typeparam name="T">Type of elements in array</typeparam>
    public class QuickSort<T> 
        where T : IComparable
    {
        #region public Methods

        /// <summary>
        /// Sort array
        /// </summary>
        /// <param name="array">passing array</param>
        public static void Sort(T[] array)
        {
            CheckSortParameters.CheckParamArray<T>(array);
            SortPart(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sort array from left to right border.
        /// </summary>
        /// <param name="array">passing array</param>
        /// <param name="left">left border</param>
        /// <param name="right">right border</param>
        public static void Sort(T[] array, int left, int right)
        {
            CheckSortParameters.CheckFullParam(array, left, right);
            SortPart(array, left, right);
        }

        #endregion // !public Methods

        #region private methods

        /// <summary>
        /// Sort part of array.
        /// </summary>
        /// <param name="array">passing array</param>
        /// <param name="left">left border</param>
        /// <param name="right">right border</param>
        private static void SortPart(T[] array, int left, int right)
        {
            if (left < right)
            {
                int position = PartitionSort(array, left, right);
                SortPart(array, left, position - 1);
                SortPart(array, position, right);
            }
        }

        /// <summary>
        /// Partition sort of array.
        /// </summary>
        /// <param name="array">passing array</param>
        /// <param name="left">left border</param>
        /// <param name="right">right border</param>
        /// <returns>Index of base element.</returns>
        private static int PartitionSort(T[] array, int left, int right)
        {
            T baseElement = GetBaseElement(array, left, right);

            while (left <= right)
            {
                while (array[left].CompareTo(baseElement) < 0)
                {
                    left++;
                }

                while (array[right].CompareTo(baseElement) > 0)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(ref array[left], ref array[right]);
                    left++;
                    right--;
                }
            }

            return left;
        }

        /// <summary>
        /// Get base element
        /// </summary>
        /// <param name="array">passing array</param>
        /// <param name="left">left border</param>
        /// <param name="right">right border</param>
        /// <returns>Base element.</returns>
        private static T GetBaseElement(T[] array, int left, int right) 
        {
            return array[right - 1];
        }

        /// <summary>
        /// Swap two elements.
        /// </summary>
        /// <param name="a">first element</param>
        /// <param name="b">second element</param>
        private static void Swap(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        #endregion // !private Methods
    }
}
