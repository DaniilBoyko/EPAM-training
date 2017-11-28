using System.Collections.Generic;

namespace Task4.Solution
{
    public interface IAveragingMethod
    {
        double Calculate(IEnumerable<double> elements);
    }
}