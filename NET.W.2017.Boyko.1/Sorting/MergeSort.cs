using System;

namespace Sorting
{
    /// <summary>
    /// Class for sorting array with merge sort method.
    /// </summary>
    /// <typeparam name="T">type elements in array</typeparam>
    public class MergeSort<T>
        where T : IComparable
    {
        #region public Methods

        /// <summary>
        /// Sort elements in array.
        /// </summary>
        /// <param name="array">passing array</param>
        public static void Sort(T[] array)
        {
            CheckSortParameters.CheckParamArray(array);
            T[] result = SortWithMerge(array);
            result.CopyTo(array, 0);
        }

        /// <summary>
        /// Sort elements in array.
        /// </summary>
        /// <param name="array">passing array</param>
        /// <param name="left">leftArray border of sorting</param>
        /// <param name="rihgt">rightArray border of sorting</param>
        public static void Sort(T[] array, int left, int rihgt)
        {
            CheckSortParameters.CheckFullParam(array, left, rihgt);
            T[] partArray = GetSubArray(array, left, rihgt);
            Sort(partArray);
            for (int i = left; i < rihgt; i++)
            {
                array[i] = partArray[i];
            }
        }

        #endregion // !public Methods

        #region private Methods

        /// <summary>
        /// The main algorithm for sorting.
        /// </summary>
        /// <param name="array">sorting array</param>
        /// <returns>New array after sorting.</returns>
        private static T[] SortWithMerge(T[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middle = array.Length / 2;

            T[] left = SortWithMerge(GetSubArray(array, 0, middle));
            T[] right = SortWithMerge(GetSubArray(array, middle, array.Length));
            T[] result = Merge(left, right);

            return result;
        }

        /// <summary>
        /// Merge two arrays.
        /// </summary>
        /// <param name="leftArray">leftArray array</param>
        /// <param name="rightArray">rightArray array</param>
        /// <returns>New array after merging.</returns>
        private static T[] Merge(T[] leftArray, T[] rightArray)
        {
            T[] result = new T[rightArray.Length + leftArray.Length];
            int i = 0, j = 0, k = 0;
            while (leftArray.Length > i && rightArray.Length > j)
            {
                if (leftArray[i].CompareTo(rightArray[j]) != 1)
                {
                    result[k++] = leftArray[i++];
                }
                else
                {
                    result[k++] = rightArray[j++];
                }
            }

            if (leftArray.Length > i)
            {
                GetSubArray(leftArray, i, leftArray.Length).CopyTo(result, k);
            }

            if (rightArray.Length > j)
            {
                GetSubArray(rightArray, j, rightArray.Length).CopyTo(result, k);
            }

            return result;
        }
        
        /// <summary>
        /// Get sub array.
        /// </summary>
        /// <param name="array">array from sub</param>
        /// <param name="left">left border</param>
        /// <param name="right">right border</param>
        /// <returns>New sub array</returns>
        private static T[] GetSubArray(T[] array, int left, int right)
        {
            T[] resutlArray = new T[Math.Min(right - left, array.Length - left)];
            for (int i = left, j = 0; i < right && i < array.Length; i++, j++)
            {
                resutlArray[j] = array[i];
            }

            return resutlArray;
        }

        #endregion // !private Methods
    }
}
