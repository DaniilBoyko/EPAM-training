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
    public class DelegateComparer : IComparer<double[]>
    {
        /// <summary>
        /// Delegate for compare.
        /// </summary>
        private readonly Func<double[], double[], int> _comparer;

        /// <summary>
        /// Constructor initialize a new instance of the <see cref="DelegateComparer"/> class.
        /// </summary>
        /// <param name="comparer"></param>
        public DelegateComparer(Func<double[], double[], int> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        /// <summary>
        /// Compare two arrays.
        /// </summary>
        /// <param name="x">left array</param>
        /// <param name="y">right array</param>
        /// <returns>Integer representation of compare.</returns>
        public int Compare(double[] x, double[] y)
        {
            return _comparer(x, y);
        }
    }
}
