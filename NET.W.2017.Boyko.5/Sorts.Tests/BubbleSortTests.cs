using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sorts.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        private static object[] _caseSourceTestDataIncreaseByMax =
        {
            new object[] 
            {
                new double[][]
                    {
                        new double[] { 2.3, 12.31, -1.0 },
                        new double[] { 123.39, 12.0 },
                        new double[] { 1.0, 10.0, 10.0 },
                    },
                new double[][]   
                {
                    new double[] { 1.0, 10.0, 10.0 },
                    new double[] { 2.3, 12.31, -1.0 },
                    new double[] { 123.39, 12.0 },
                },
            },

            new object[]
            {
                new double[][]
                {
                    new double[] { -1 },
                    new double[] { 3.3456, 128 },
                    new double[] { 2, -40, 256 },
                },
                new double[][]   
                {
                    new double[] { -1 },
                    new double[] { 3.3456, 128 },
                    new double[] { 2, -40, 256 },
                },
            },
        };

        private static object[] _caseSourceTestDataDecreaseByMax =
        {
            new object[]
            {
                new double[][]
                {
                    new double[] { 2.3, 12.31, -1.0 },
                    new double[] { 123.39, 12.0 },
                    new double[] { 1.0, 10.0, 10.0 },
                },
                new double[][]   
                {
                    new double[] { 123.39, 12.0 },
                    new double[] { 2.3, 12.31, -1.0 },
                    new double[] { 1.0, 10.0, 10.0 },
                },
            },

            new object[]
            {
                new double[][]
                {
                    new double[] { -1 },
                    new double[] { 3.3456, 128 },
                    new double[] { 2, -40, 256 },
                },
                new double[][]   
                {
                    new double[] { 2, -40, 256 },
                    new double[] { 3.3456, 128 },
                    new double[] { -1 },
                },
            },
        };

        private static object[] _caseSourceTestDataDecreaseByMin =
        {
            new object[]
            {
                new double[][]
                {
                    new double[] { 2.3, 12.31, -1.0 },
                    new double[] { 123.39, 12.0 },
                    new double[] { 1.0, 10.0, 10.0 },
                },
                new double[][]   
                {
                    new double[] { 123.39, 12.0 },
                    new double[] { 1.0, 10.0, 10.0 },
                    new double[] { 2.3, 12.31, -1.0 },
                },
            },

            new object[]
            {
                new double[][]
                {
                    new double[] { -1 },
                    new double[] { 3.3456, 128 },
                    new double[] { 2, -40, 256 },
                },
                new double[][]   
                {
                    new double[] { 3.3456, 128 },
                    new double[] { -1 },
                    new double[] { 2, -40, 256 },
                },
            },
        };

        private static object[] _caseSourceTestDataIncreaseBySum =
        {
            new object[]
            {
                new double[][]
                {
                    new double[] { 2.3, 12.31, -1.0 },
                    new double[] { 123.39, 12.0 },
                    new double[] { 1.0, 10.0, 10.0 },
                },
                new double[][]   
                {
                    new double[] { 2.3, 12.31, -1.0 },
                    new double[] { 1.0, 10.0, 10.0 },
                    new double[] { 123.39, 12.0 },
                },
            },

            new object[]
            {
                new double[][]
                {
                    new double[] { -1 },
                    new double[] { 3.3456, 128 },
                    new double[] { 2, -40, 256 },
                },
                new double[][]   
                {
                    new double[] { -1 },
                    new double[] { 3.3456, 128 },
                    new double[] { 2, -40, 256 },
                },
            },
        };

        [Test, TestCaseSource(nameof(_caseSourceTestDataIncreaseByMax))]
        public void SortJaggedArrayMethod_SortByIncreaseMaxElementsWithComparator(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray1(array, new IncreaseByMax());
            Assert.That(array, Is.EqualTo(resultArray));
        }

        [Test, TestCaseSource(nameof(_caseSourceTestDataIncreaseByMax))]
        public void SortJaggedArrayMethod_SortByIncreaseMaxElementsWithDelegate(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray1(array, new IncreaseByMax().Compare);
            Assert.That(array, Is.EqualTo(resultArray));
        }

        [Test, TestCaseSource(nameof(_caseSourceTestDataIncreaseByMax))]
        public void SortJaggedArrayMethod_SortByIncreaseMaxElements(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray(array, new BubbleSort.MaxNumber(), new BubbleSort.Increase());
            Assert.That(array, Is.EqualTo(resultArray));
        }

        [Test, TestCaseSource(nameof(_caseSourceTestDataDecreaseByMax))]
        public void SortJaggedArrayMethod_SortByDecreaseMaxElements(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray(array, new BubbleSort.MaxNumber(), new BubbleSort.Decrease());
            Assert.That(array, Is.EqualTo(resultArray));
        }

        [Test, TestCaseSource(nameof(_caseSourceTestDataDecreaseByMin))]
        public void SortJaggedArrayMethod_SortByDecreaseMinElements(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray(array, new BubbleSort.MinNumber(), new BubbleSort.Decrease());
            Assert.That(array, Is.EqualTo(resultArray));
        }

        [Test, TestCaseSource(nameof(_caseSourceTestDataIncreaseBySum))]
        public void SortJaggedArrayMethod_SortByIncreaseSumElements(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray(array, new BubbleSort.Sum(), new BubbleSort.Increase());
            Assert.That(array, Is.EqualTo(resultArray));
        }
    }
}
