using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public class Calculator
    {
        public double CalculateAverage(IEnumerable<double> values, IAveragingMethod averagingMethod)
        {
            Check(values, averagingMethod);
            return averagingMethod.Calculate(values);
        }

        public double CalculateAverage(IEnumerable<double> values, Func<IEnumerable<double>, double> calculateFunc)
        {
            Check(values, calculateFunc);
            return calculateFunc(values);
        }

        private void Check(IEnumerable<double> values, IAveragingMethod averagingMethod)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (averagingMethod == null)
                throw new ArgumentNullException(nameof(averagingMethod));
        }

        private void Check(IEnumerable<double> values, Func<IEnumerable<double>, double> calculateFunc)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (calculateFunc == null)
                throw new ArgumentNullException(nameof(calculateFunc));
        }
    }
}
