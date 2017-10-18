using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QuickSort
    {
        public static void Sort(int[] array)
        {
            SortPart(array, 0, array.Length - 1);
        }

        private static void SortPart(int[] array, int left, int right)
        {
            if (left < right)
            {
                int position = PartitionSort(array, left, right);
                SortPart(array, left, position - 1);
                SortPart(array, position, right);
            }
        }

        private static int PartitionSort(int[] array, int left, int right)
        {
            int baseElement = GetBaseElement(array, left, right);
            int l = left;
            int r = right;
            while (l <= r)
            {
                while (array[l] < baseElement)
                    l++;
                while (array[r] > baseElement)
                    r--;
                if (l <= r)
                {
                    Swap(ref array[l], ref array[r]);
                    l++;
                    r--;
                }
            }

            return l;
        }

        private static int GetBaseElement(int[] array, int left, int right) 
        {
            return array[right];
        }

        private static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

    }
}
