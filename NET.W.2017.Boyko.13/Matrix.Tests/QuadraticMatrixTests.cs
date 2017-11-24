using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Matrix.Tests
{
    [TestFixture]
    public class QuadraticMatrixTests
    {
        [TestCase(1, 1, ExpectedResult = 5)]
        [TestCase(0, 0, ExpectedResult = 1)]
        [TestCase(0, 2, ExpectedResult = 3)]
        [TestCase(2, 1, ExpectedResult = 8)]
        [TestCase(3, 1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, 3, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public int QuadraticMatrixMethod_CreateQuadraticMatrixAndGetElement(int row, int column)
        {
            int[][] array = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            };

            QuadraticMatrix<int> quadraticMatrix = new QuadraticMatrix<int>(array);
            return quadraticMatrix[row, column];
        }

        [TestCase(1, 1, 4, ExpectedResult = 1)]
        [TestCase(0, 0, 2, ExpectedResult = 2)]
        [TestCase(0, 2, 10, ExpectedResult = 1)]
        [TestCase(2, 1, 21, ExpectedResult = 1)]
        [TestCase(3, 1, 21, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, 3, 21, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public int SetElementIndexerMethod_CreateQuadraticMatrixSetElementAndGet(int row, int column, int value)
        {
            int[][] array = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            };

            QuadraticMatrix<int> quadraticMatrix = new QuadraticMatrix<int>(array);
            quadraticMatrix[row, column] = value;
            return quadraticMatrix[0, 0];
        }

        [TestCase(1, 1, ExpectedResult = 10)]
        [TestCase(0, 0, ExpectedResult = 2)]
        [TestCase(0, 2, ExpectedResult = 6)]
        [TestCase(2, 1, ExpectedResult = 0)]
        public int SummQuadraticMatrix_SetTwoQuadraticMatrixAndSummIt(int row, int column)
        {
            int[][] array1 = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            };

            int[][] array2 = new int[][]
            {
                new int[] { 1, 4, 3 },
                new int[] { 33, 5, -6 },
                new int[] { 7, -8, 99 },
            };

            QuadraticMatrix<int> quadraticMatrix1 = new QuadraticMatrix<int>(array1);
            QuadraticMatrix<int> quadraticMatrix2 = new QuadraticMatrix<int>(array2);
            return quadraticMatrix1.Add(quadraticMatrix2)[row, column];
        }

        [TestCase(1, 1, ExpectedResult = 9)]
        [TestCase(0, 0, ExpectedResult = 2)]
        [TestCase(0, 2, ExpectedResult = 3)]
        [TestCase(2, 1, ExpectedResult = 8)]
        public int SummQuadraticAndDiagonalMatrix_SetQuadraticAndDiagonalMatrixAndSummIt(int row, int column)
        {
            int[][] array1 = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            };

            int[] array2 = new int[] { 1, 4, 3 };

            QuadraticMatrix<int> quadraticMatrix1 = new QuadraticMatrix<int>(array1);
            DiagonalMatrix<int> quadraticMatrix2 = new DiagonalMatrix<int>(array2);
            return quadraticMatrix1.Add(quadraticMatrix2)[row, column];
        }
    }
}
