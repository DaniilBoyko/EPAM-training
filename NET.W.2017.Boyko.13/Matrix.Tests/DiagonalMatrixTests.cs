using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Matrix.Tests
{
    [TestFixture]
    public class DiagonalMatrixTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 1, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 0, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 0, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 3, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 4, ExpectedResult = 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 3, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 66, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public int DiagonalMatrixMethod_ChreateDiagonalMatrixAndGetElement(int[] array, int row, int column)
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(array);
            return matrix[row, column];
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 1, 1, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 0, 2, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 4, 2, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 0, 1, ExpectedException = typeof(InvalidOperationException))]
        public int IndexerMethod_SetElementIntoDiagonalMetrix(int[] array, int row, int column, int value)
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(array);
            matrix[row, column] = value;
            return matrix[0, 0];
        }
    }
}
