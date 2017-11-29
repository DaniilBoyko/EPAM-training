using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    /// <summary>
    /// Calculate mean value.
    /// </summary>
    public class Mean : IAveragingMethod
    {
        /// <inheritdoc></inheritdoc>
        public double Calculate(IEnumerable<double> elements)
        {
            return elements.Sum() / elements.Count();
        }
    }
}
