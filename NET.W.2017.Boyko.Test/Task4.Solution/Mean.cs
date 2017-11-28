﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Solution
{
    public class Mean : IAveragingMethod
    {
        public double Calculate(IEnumerable<double> elements)
        {
            return elements.Sum() / elements.Count();
        }
    }
}
