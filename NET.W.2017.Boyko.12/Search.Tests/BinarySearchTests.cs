using System;
using NUnit.Framework;

namespace Search.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, ExpectedResult = 1)] 
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, ExpectedResult = 2)]
        [TestCase(new int[] { -2, -1, 3, 4, 5 }, 5, ExpectedResult = 4)]
        [TestCase(new int[] { -2, -1, 3, 4, 5 }, -2, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, ExpectedResult = 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 4, ExpectedResult = 3)]
        [TestCase(new int[] { 1 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, -2, 3, 4, 5, 6 }, 4, ExpectedException = typeof(ArgumentException))]
        [TestCase(new int[] { }, 4, ExpectedException = typeof(ArgumentException))]
        [TestCase(null, 4, ExpectedException = typeof(ArgumentNullException))]
        public int BinarySearchTests_GetIndexOfElementInArrayOrMinesOne(int[] array, int element)
        {
            return BinarySearch<int>.Find(array, element);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, 2, ExpectedResult = 1)]
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, 5, ExpectedResult = 4)]
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, 3, ExpectedResult = 2)]
        [TestCase(new double[] { -2, -1, 3, 4, 5 }, 5, ExpectedResult = 4)]
        [TestCase(new double[] { -2, -1, 3, 4, 5 }, -2, ExpectedResult = 0)]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, 6, ExpectedResult = 5)]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, 1, ExpectedResult = 0)]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, 4, ExpectedResult = 3)]
        [TestCase(new double[] { 1 }, 1, ExpectedResult = 0)]
        [TestCase(new double[] { 1, -2, 3, 4, 5, 6 }, 4, ExpectedException = typeof(ArgumentException))]
        [TestCase(new double[] { }, 4, ExpectedException = typeof(ArgumentException))]
        [TestCase(null, 4, ExpectedException = typeof(ArgumentNullException))]
        public int BinarySearchTests_GetIndexOfElementInArrayOrMinesOne(double[] array, double element)
        {
            return BinarySearch<double>.Find(array, element);
        }
    }
}
