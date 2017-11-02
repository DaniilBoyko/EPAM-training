using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Interfaces
{
    /// <summary>
    /// Contains function for conversion double arrya to double value.
    /// </summary>
    public interface ICalculateArray
    {
        /// <summary>
        /// Convert double array to double value.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Double value.</returns>
        double CalculateArray(double[] array);
    }
}
