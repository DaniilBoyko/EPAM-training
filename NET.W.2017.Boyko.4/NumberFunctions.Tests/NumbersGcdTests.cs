using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NumberFunctions.Tests
{
    [TestFixture]
    public class NumbersGcdTests
    {

        public static IEnumerable<TestCaseData> FindGcdOfTwoNumbersTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(4, 4).Returns(4);
                yield return new TestCaseData(4, 8).Returns(4);
                yield return new TestCaseData(8, 4).Returns(4);
                yield return new TestCaseData(-4, 9).Returns(1);
                yield return new TestCaseData(4, 9).Returns(1);
                yield return new TestCaseData(8, 4).Returns(4);
                yield return new TestCaseData(-4, -10).Returns(2);
                yield return new TestCaseData(0, -10).Returns(10);
                yield return new TestCaseData(-4, 0).Returns(4);
                yield return new TestCaseData(4, 0).Returns(4);
                yield return new TestCaseData(0, 4).Returns(4);
                yield return new TestCaseData(3, 7).Returns(1);
                yield return new TestCaseData(55, 65).Returns(5);
                yield return new TestCaseData(0, 0).Throws(typeof(ArgumentException));
            }
        }

        public static IEnumerable<TestCaseData> FindGcdOfThreeNumbersTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(1, 2, 3).Returns(1);
                yield return new TestCaseData(1, -2, 3).Returns(1);
                yield return new TestCaseData(12, 3, 9).Returns(3);
                yield return new TestCaseData(0, 0, 0).Throws(typeof(ArgumentException));
                yield return new TestCaseData(0, 5, 5).Returns(5);
            }
        }

        public static IEnumerable<TestCaseData> FindGcdOfMoreThenThreeNumbersTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(new[] {1, 2, 3, 4, 5, 6}).Returns(1);
                yield return new TestCaseData(new[] {3, 6, 15, 3, 27, 9}).Returns(3);
                yield return new TestCaseData(new[] {-9, 27, 81, -900}).Returns(9);
            }
            
        }

        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string GetBinaryStringMethod_GetBinaryStringOfDobule(double number)
        {
            return number.GetBinaryString();
        }

        #region EuclideanGcd

        [Test, TestCaseSource(nameof(FindGcdOfTwoNumbersTestCaseDatas))]
        public int EuclideanGcdMethod_CalculateEuclideanGreatestCommonDivisor(int number1, int number2)
        {
            return NumbersGcd.EuclideanGcd(number1, number2);
        }

        [Test, TestCaseSource(nameof(FindGcdOfThreeNumbersTestCaseDatas))]
        public int EuclideanGcdMethod_CalculateEuclideanGreatestCommonDivisor(int number1, int number2, int number3)
        {
            return NumbersGcd.EuclideanGcd(number1, number2, number3);
        }

        [Test, TestCaseSource(nameof(FindGcdOfMoreThenThreeNumbersTestCaseDatas))]
        public int EuclideanGcdMethod_CalculateEuclideanGreatestCommonDivisor(int[] numbers)
        {
            return NumbersGcd.EuclideanGcd(numbers);
        }

        #endregion


        #region StainGcd

        [Test, TestCaseSource(nameof(FindGcdOfTwoNumbersTestCaseDatas))]
        public int StainGcdMethod_CalculateStainGreatestCommonDivisor(int number1, int number2)
        {
            return NumbersGcd.StainGcd(number1, number2);
        }

        [Test, TestCaseSource(nameof(FindGcdOfThreeNumbersTestCaseDatas))]
        public int StainGcdMethod_CalculateStainGreatestCommonDivisor(int number1, int number2, int number3)
        {
            return NumbersGcd.StainGcd(number1, number2, number3);
        }

        [Test, TestCaseSource(nameof(FindGcdOfMoreThenThreeNumbersTestCaseDatas))]
        public int StainGcdMethod_CalculateStainGreatestCommonDivisor(int[] numbers)
        {
            return NumbersGcd.StainGcd(numbers);
        }

        #endregion
      
    }
}
