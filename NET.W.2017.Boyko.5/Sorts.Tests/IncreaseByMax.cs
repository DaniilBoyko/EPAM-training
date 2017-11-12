using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorts.Tests
{
    /// <summary>
    /// Compare two jagged arrays.
    /// </summary>
    public class IncreaseByMax : IComparer<double[]>
    {
        /// <summary>
        /// Compare two jagged arrays.
        /// </summary>
        /// <param name="leftArray">left jagged array</param>
        /// <param name="rightArray">right jagged array</param>
        /// <returns>Integer representation of comparison.</returns>
        public int Compare(double[] leftArray, double[] rightArray)
        {
            if (leftArray == null)
            {
                throw new ArgumentNullException(nameof(leftArray));
            }

            if (rightArray == null)
            {
                throw new ArgumentNullException(nameof(rightArray));
            }

            double leftMax = leftArray.Max();
            double rightMax = rightArray.Max();

            if (leftMax > rightMax)
            {
                return -1;
            }

            if (leftMax < rightMax)
            {
                return 1;
            }

            return 0;
        }
    }
}
