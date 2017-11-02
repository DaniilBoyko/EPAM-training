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
        public static object[] CaseSourceTestDataIncreaseByMax =
        {
            new object[] 
            {
                new double[][]
                    {
                        new double[] {2.3, 12.31, -1.0},
                        new double[] {123.39, 12.0},
                        new double[] {1.0, 10.0, 10.0},
                    },
                new double[][]   {
                    new double[] {1.0, 10.0, 10.0},
                    new double[] {2.3, 12.31, -1.0},
                    new double[] {123.39, 12.0},
                    
                },
            },

            new object[]
            {
                new double[][]
                {
                    new double[] {-1},
                    new double[] {3.3456, 128},
                    new double[] {2, -40, 256},
                },
                new double[][]   {
                    new double[] {-1},
                    new double[] {3.3456, 128},
                    new double[] {2, -40, 256},
                },
            },
        };

        public static object[] CaseSourceTestDataDecreaseByMax =
        {
            new object[]
            {
                new double[][]
                {
                    new double[] {2.3, 12.31, -1.0},
                    new double[] {123.39, 12.0},
                    new double[] {1.0, 10.0, 10.0},
                },
                new double[][]   {
                    new double[] {123.39, 12.0},
                    new double[] {2.3, 12.31, -1.0},
                    new double[] {1.0, 10.0, 10.0},
                },
            },

            new object[]
            {
                new double[][]
                {
                    new double[] {-1},
                    new double[] {3.3456, 128},
                    new double[] {2, -40, 256},
                },
                new double[][]   {
                    new double[] {2, -40, 256},
                    new double[] {3.3456, 128},
                    new double[] {-1},
                },
            },
        };

        public static object[] CaseSourceTestDataDecreaseByMin =
        {
            new object[]
            {
                new double[][]
                {
                    new double[] {2.3, 12.31, -1.0},
                    new double[] {123.39, 12.0},
                    new double[] {1.0, 10.0, 10.0},
                },
                new double[][]   {
                    new double[] {123.39, 12.0},
                    new double[] {1.0, 10.0, 10.0},
                    new double[] {2.3, 12.31, -1.0},
                },
            },

            new object[]
            {
                new double[][]
                {
                    new double[] {-1},
                    new double[] {3.3456, 128},
                    new double[] {2, -40, 256},
                },
                new double[][]   {
                    new double[] {3.3456, 128},
                    new double[] {-1},
                    new double[] {2, -40, 256},
                },
            },
        };

        public static object[] CaseSourceTestDataIncreaseBySum =
        {
            new object[]
            {
                new double[][]
                {
                    new double[] {2.3, 12.31, -1.0},
                    new double[] {123.39, 12.0},
                    new double[] {1.0, 10.0, 10.0},
                },
                new double[][]   {
                    new double[] {2.3, 12.31, -1.0},
                    new double[] {1.0, 10.0, 10.0},
                    new double[] {123.39, 12.0},
                },
            },

            new object[]
            {
                new double[][]
                {
                    new double[] {-1},
                    new double[] {3.3456, 128},
                    new double[] {2, -40, 256},
                },
                new double[][]   {
                    new double[] {-1},
                    new double[] {3.3456, 128},
                    new double[] {2, -40, 256},
                },
            },
        };

        [Test, TestCaseSource(nameof(CaseSourceTestDataIncreaseByMax))]
        public void SortJaggedArrayMethod_SortByIncreaseMaxElements(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray(array, new BubbleSort.MaxNumber(), new BubbleSort.Increase());
            Assert.That(array, Is.EqualTo(resultArray));
        }

        [Test, TestCaseSource(nameof(CaseSourceTestDataDecreaseByMax))]
        public void SortJaggedArrayMethod_SortByDecreaseMaxElements(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray(array, new BubbleSort.MaxNumber(), new BubbleSort.Decrease());
            Assert.That(array, Is.EqualTo(resultArray));
        }

        [Test, TestCaseSource(nameof(CaseSourceTestDataDecreaseByMin))]
        public void SortJaggedArrayMethod_SortByDecreaseMinElements(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray(array, new BubbleSort.MinNumber(), new BubbleSort.Decrease());
            Assert.That(array, Is.EqualTo(resultArray));
        }

        [Test, TestCaseSource(nameof(CaseSourceTestDataIncreaseBySum))]
        public void SortJaggedArrayMethod_SortByIncreaseSumElements(double[][] array, double[][] resultArray)
        {
            BubbleSort.SortJaggedArray(array, new BubbleSort.Sum(), new BubbleSort.Increase());
            Assert.That(array, Is.EqualTo(resultArray));
        }
    }
}
