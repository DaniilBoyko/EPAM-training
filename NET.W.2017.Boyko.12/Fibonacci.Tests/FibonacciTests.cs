using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fibonacci.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(0, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 2)]
        [TestCase(4, ExpectedResult = 3)]
        [TestCase(5, ExpectedResult = 5)]
        [TestCase(6, ExpectedResult = 8)]
        public long GetNumberTests_GetFibonacciNumberAtIndex(int index)
        {
            return Fibonacci.GetNumber(index);
        }

        [TestCase(0, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, ExpectedResult = new long[] { 1 })]
        [TestCase(2, ExpectedResult = new long[] { 1, 1 })]
        [TestCase(3, ExpectedResult = new long[] { 1, 1, 2 })]
        [TestCase(4, ExpectedResult = new long[] { 1, 1, 2, 3 })]
        [TestCase(5, ExpectedResult = new long[] { 1, 1, 2, 3, 5 })]
        [TestCase(6, ExpectedResult = new long[] { 1, 1, 2, 3, 5, 8 })]
        public long[] GetNumberTests_GetFibonacciNumbersSequence(int index)
        {
            return Fibonacci.GetSequence(index);
        }
    }
}
