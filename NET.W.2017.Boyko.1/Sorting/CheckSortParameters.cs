using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class CheckSortParameters
    {
        public static void CheckParamArray<T>(IEnumerable<T> array)
        {
            if (array == null)
                throw new ArgumentNullException();
        }

        public static void CheckFullParam<T>(IEnumerable<T> array, int left, int right)
        {
            CheckParamArray(array);

            if (left < 0 || right >= array.Count())
                throw new ArgumentOutOfRangeException();

            if (right < left)
                throw new ArgumentException();
        }
    }
}
