using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    /// <summary>
    /// Class for compare two double arrays.
    /// </summary>
    public class ComparisonAdapter : IComparer<double[]>
    {
        /// <summary>
        /// Delegate for compare.
        /// </summary>
        private readonly Comparison<double[]> _comparison;

        /// <summary>
        /// Constructor initialize a new instance of the <see cref="ComparisonAdapter"/> class.
        /// </summary>
        /// <param name="comparison"></param>
        public ComparisonAdapter(Comparison<double[]> comparison)
        {
            _comparison = comparison ?? throw new ArgumentNullException(nameof(comparison));
        }

        /// <summary>
        /// Compare two arrays.
        /// </summary>
        /// <param name="x">left array</param>
        /// <param name="y">right array</param>
        /// <returns>Integer representation of compare.</returns>
        public int Compare(double[] x, double[] y)
        {
            return _comparison(x, y);
        }
    }
}
