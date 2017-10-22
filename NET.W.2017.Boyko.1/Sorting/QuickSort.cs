using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSort<T> 
        where T : IComparable
    {
        #region API
        public static void Sort(T[] array)
        {
            CheckSortParameters.CheckParamArray<T>(array);
            SortPart(array, 0, array.Length - 1);
        }

        public static void Sort(T[] array, int left, int right)
        {
            CheckSortParameters.CheckFullParam(array, left, right);
            SortPart(array, left, right);
        }
        #endregion

        #region Private methods
        private static void SortPart(T[] array, int left, int right)
        {
            if (left < right)
            {
                int position = PartitionSort(array, left, right);
                SortPart(array, left, position - 1);
                SortPart(array, position, right);
            }
        }

        private static int PartitionSort(T[] array, int left, int right)
        {
            T baseElement = GetBaseElement(array, left, right);

            while (left <= right)
            {
                while (array[left].CompareTo(baseElement) < 0)
                    left++;
                while (array[right].CompareTo(baseElement) > 0)
                    right--;

                if (left <= right)
                {
                    Swap(ref array[left], ref array[right]);
                    left++;
                    right--;
                }
            }

            return left;
        }

        private static T GetBaseElement(T[] array, int left, int right) 
        {
            return array[right - 1];
        }

        private static void Swap(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }
        #endregion

    }
}
