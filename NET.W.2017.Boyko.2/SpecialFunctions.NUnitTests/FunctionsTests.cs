using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace SpecialFunctions.NUnitTests
{
    [TestFixture]
    public class FunctionsTests
    {

        public static IEnumerable<TestCaseData> InsertNumberMethodTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(16, 16, 0, 4).Returns(16);
                yield return new TestCaseData(1, 1, 31, 31).Returns(-2147483647);
                yield return new TestCaseData(1, 1, 30, 30).Returns(1073741825);
                yield return new TestCaseData(8, 15, 3, -8).Throws(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(8, 15, 3, 32).Throws(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(8, 15, 3, 32).Throws(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(8, 15, 8, 3).Throws(typeof(ArgumentException));
            }
        }

        public static IEnumerable<TestCaseData> FindNextBiggerNumberTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(12, 21);
                yield return new TestCaseData(4, -1);
                yield return new TestCaseData(513, 531);
                yield return new TestCaseData(2017, 2071);
                yield return new TestCaseData(414, 441);
                yield return new TestCaseData(144, 414);
                yield return new TestCaseData(1234321, 1241233);
                yield return new TestCaseData(1234126, 1234162);
                yield return new TestCaseData(3456432, 3462345);
                yield return new TestCaseData(10, -1);
                yield return new TestCaseData(20, -1);
                yield return new TestCaseData(44444, -1);
                yield return new TestCaseData(123987, 127389);
                yield return new TestCaseData(4569876, 4576689);
            }
        }

        public static IEnumerable<TestCaseData> FilterDigitTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(new[]{ 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}, 7).Returns(new[]{7, 70, 17});
                yield return new TestCaseData(new[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 1).Returns(new[] { 1, 15, 17 });
                yield return new TestCaseData(new int[3], 1).Returns(new int[0]);
                yield return new TestCaseData(null, 7).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new[] { 1, 2, 3, 68, 69, 70}, 10).Throws(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(new[] { 1, 2, 3, 68, 69, 70 }, -1).Throws(typeof(ArgumentOutOfRangeException));
            }
        }

        public static IEnumerable<TestCaseData> FindNthRootTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(1, 5, 0.0001, 1.0);
                yield return new TestCaseData(8, 3, 0.0001, 2.0);
                yield return new TestCaseData(0.001, 3, 0.0001, 0.1);
                yield return new TestCaseData(0.04100625, 4, 0.0001, 0.45);
                yield return new TestCaseData(0.0289936, 7, 0.0001, 0.603);
                yield return new TestCaseData(0.0081, 4, 0.01, 0.3);
                yield return new TestCaseData(-0.008, 3, 0.1, -0.2);
                yield return new TestCaseData(0.004241979, 9, 0.00000001, 0.545);
                yield return new TestCaseData(-8, 2, 0.0001, 1).Throws(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(8, 3, -0.0001, 1).Throws(typeof(ArgumentOutOfRangeException));
                yield return new TestCaseData(8, -3, -0.0001, 1).Throws(typeof(ArgumentOutOfRangeException));

            }
        }

        [Test, TestCaseSource(nameof(InsertNumberMethodTestCaseDatas))]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(8, 15, -3, 8, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public int InsertNumberMethod_InsertBytesFromOneNumberToAnother(int numberSource, int numberInsert, int fromPosition, int toPosition)
        {
            return Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);
        }

        [Test, TestCaseSource(nameof(FindNextBiggerNumberTestCaseDatas))]
        public void FindNextBiggerNumberMethod_FindNextBiggerNumberOrMines1(int number, int resultExpected)
        {
            Assert.AreEqual(resultExpected, Functions.FindNextBiggerNumber(number));
        }

        [Test, TestCaseSource(nameof(FilterDigitTestCaseDatas))]
        public int[] FilterDigitMethod_FilterListOfIntegersWhichDontHaveDigit(int[] array, int digit)
        {
            return Functions.FilterDigit(digit, array);
        }

        [Test, TestCaseSource(nameof(FindNthRootTestCaseDatas))]
        public void FindNthRootMethod_FindRootOfSetDegreeFromNumberWithSetPrecision(double number, int degree, double precision, double expectedResult)
        {
            double result = Functions.FindNthRoot(number, degree, precision);
            Assert.That(result, Is.EqualTo(expectedResult).Within(precision));
        }

    }
}
