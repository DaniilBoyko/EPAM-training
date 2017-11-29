using System;
using System.Collections.Generic;

namespace Task4.Solution
{
    /// <summary>
    /// Model of calculator.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Calculate average value of values.
        /// </summary>
        /// <param name="values">values</param>
        /// <param name="averagingMethod">methods for calculate avarage methods</param>
        /// <returns>average value</returns>
        public double CalculateAverage(IEnumerable<double> values, IAveragingMethod averagingMethod)
        {
            Check(values, averagingMethod);
            return averagingMethod.Calculate(values);
        }

        /// <summary>
        /// Calculate average value of values.
        /// </summary>
        /// <param name="values">values</param>
        /// <param name="calculateFunc">calculating function</param>
        /// <returns>average value</returns>
        public double CalculateAverage(IEnumerable<double> values, Func<IEnumerable<double>, double> calculateFunc)
        {
            Check(values, calculateFunc);
            return calculateFunc(values);
        }

        /// <summary>
        /// Method for check arguments.
        /// </summary>
        /// <param name="values">values</param>
        /// <param name="averagingMethod">interface wich has calculation method</param>
        private void Check(IEnumerable<double> values, IAveragingMethod averagingMethod)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (averagingMethod == null)
                throw new ArgumentNullException(nameof(averagingMethod));
        }

        /// <summary>
        /// Method for check argumentds.
        /// </summary>
        /// <param name="values">values</param>
        /// <param name="calculateFunc">calculation function</param>
        private void Check(IEnumerable<double> values, Func<IEnumerable<double>, double> calculateFunc)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (calculateFunc == null)
                throw new ArgumentNullException(nameof(calculateFunc));
        }
    }
}
