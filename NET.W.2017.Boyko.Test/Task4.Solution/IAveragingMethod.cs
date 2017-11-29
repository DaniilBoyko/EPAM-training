using System.Collections.Generic;

namespace Task4.Solution
{
    /// <summary>
    /// Interface wich constains calculate methods.
    /// </summary>
    public interface IAveragingMethod
    {
        /// <summary>
        /// Calculate averate elements.
        /// </summary>
        /// <param name="elements">elements</param>
        /// <returns>result of caclulation</returns>
        double Calculate(IEnumerable<double> elements);
    }
}