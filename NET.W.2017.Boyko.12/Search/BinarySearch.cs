using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class BinarySearch <T>
        where T:IComparable
    {
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

        public static int Fined(T[] array, T element)
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
                    first = mid + 1;
                if (element.CompareTo(array[mid]) == -1)
                    last = mid - 1;
                if (element.CompareTo(array[mid]) == 0)
                    return mid;
            }

            return -1;
        }
    }
}
