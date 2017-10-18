using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public class MergeSort
    {
        public static void Sort(int[] array)
        {
            int[] result = SortWithMerge(array.ToList()).ToArray();
            for (int i = 0; i < result.Length; i++)
                array[i] = result[i];
        }

        private static List<int> SortWithMerge(List<int> list)
        {
            if (list.Count <= 1)
                return list;

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> result = new List<int>();
            int middle = list.Count / 2;

            left = list.GetRange(0, middle);
            if (list.Count % 2 == 0)
                right = list.GetRange(middle, middle);
            else
                right = list.GetRange(middle, middle + 1);

            left = SortWithMerge(left);
            right = SortWithMerge(right);

            result = Merge(left, right);
            return result;
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            if (left.Count > 0)
                result.AddRange(left);
            if (right.Count > 0)
                result.AddRange(right);

            return result;
        }
    }
}
