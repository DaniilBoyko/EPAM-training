using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MergeSort<T>
        where T : IComparable
    {
        #region API
        public static void Sort(T[] array)
        {
            CheckSortParameters.CheckParamArray(array);
            T[] result = SortWithMerge(array);
            result.CopyTo(array, 0);
        }

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
        #endregion


        #region Private methods
        private static T[] SortWithMerge(T[] array)
        {
            if (array.Length <= 1)
                return array;

            int middle = array.Length / 2;

            T[] left = SortWithMerge(GetSubArray(array, 0, middle));
            T[] right = SortWithMerge(GetSubArray(array, middle, array.Length));
            T[]result = Merge(left, right);

            return result;
        }

        private static T[] Merge(T[] left, T[] right)
        {
            T[] result = new T[right.Length + left.Length];
            int i = 0, j = 0, k = 0;
            while (left.Length > i && right.Length > j)
            {
                if (!(left[i].CompareTo(right[j]) == 1))
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }

            if (left.Length > i)
                GetSubArray(left, i, left.Length).CopyTo(result, k);
            if (right.Length > j)
                GetSubArray(right, j, right.Length).CopyTo(result, k);

            return result;
        }
        
        private static T[] GetSubArray(T[] array, int left, int right)
        {
            T[] resutlArray = new T[Math.Min(right - left, array.Length - left)];
            for (int i = left, j = 0; i < right && i < array.Length; i++, j++)
            {
                resutlArray[j] = array[i];
            }
            return resutlArray;
        }
        #endregion 
    }
}
