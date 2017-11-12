using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    /// <summary>
    /// Class for check parameters in sorting.
    /// </summary>
    internal class CheckSortParameters
    {
        #region public Methods

        /// <summary>
        /// Check array for null.
        /// </summary>
        /// <typeparam name="T">type of elements in array</typeparam>
        /// <param name="array">passing array</param>
        public static void CheckParamArray<T>(IEnumerable<T> array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Check full parameters of sorting.
        /// </summary>
        /// <typeparam name="T">type of elements in array</typeparam>
        /// <param name="array">passing array</param>
        /// <param name="left">left border of sorting</param>
        /// <param name="right">right border of sorting</param>
        public static void CheckFullParam<T>(IEnumerable<T> array, int left, int right)
        {
            CheckParamArray(array);

            if (left < 0 || right >= array.Count())
            {
                throw new ArgumentOutOfRangeException();
            }

            if (right < left)
            {
                throw new ArgumentException();
            }
        }

        #endregion // !public Methods
    }
}
