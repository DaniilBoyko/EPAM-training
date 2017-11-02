using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Polinoms;

namespace Polinoms.Tests
{
    [TestFixture]
    public class PolynomTests
    {

        [TestCase(new double[] { -1, 1, 1 }, ExpectedResult = "-x^2 + x + 1")]
        [TestCase(new double[] { 0, 23.2, 123.2 }, ExpectedResult = "23,2x + 123,2")]
        [TestCase(new double[] { -1, -1, -1 }, ExpectedResult = "-x^2 - x - 1")]
        [TestCase(new double[] { 1.2, 23.2, 123.2}, ExpectedResult = "1,2x^2 + 23,2x + 123,2")]
        [TestCase(new double[] { 0, 0, 0 }, ExpectedResult = "0")]
        [TestCase(new double[] { 0}, ExpectedResult = "0")]
        [TestCase(new double[] { 1, 0, 1 }, ExpectedResult = "x^2 + 1")]
        [TestCase(new double[] { 1, 0, 0, 1 }, ExpectedResult = "x^3 + 1")]
        [TestCase(new double[] { -1, 0, 0, -1 }, ExpectedResult = "-x^3 - 1")]
        [TestCase(new double[] { 1, 0, 0, 0 }, ExpectedResult = "x^3")]
        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(new double[] { }, ExpectedException = typeof(ArgumentException))]
        public string ToStringMethod_ConvertPolinomialToString(double[] coefficients)
        {
            return new Polynom(coefficients).ToString();
        }

        [TestCase(new double[] { 0, 23.2, 123.2 }, new double[] { 0, 23.2, 123.2 }, ExpectedResult = true)]
        [TestCase(new double[] { -1, -1, -1 }, new double[] { -1, -1, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 1.2, 23.2, 123.2 }, new double[] { 1.2, 23.2, 123.2, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0 }, ExpectedResult = true)]
        public bool EqualsMethod_CheckIfObjecstIsEqual(double[] coefficients1, double[] coefficients2)
        {
            return new Polynom(coefficients1).Equals(new Polynom(coefficients2));
        }

        [TestCase(new double[] { 0, 23.2, 123.2 }, new double[] { 0, 23.2, 123.2 }, ExpectedResult = true)]
        [TestCase(new double[] { -1, -1, -1 }, new double[] { -1, -1, -1 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0 }, ExpectedResult = true)]
        public bool GetHashCodeMethod_CheckHashCodeOfTwoEqualPolinomial(double[] coefficients1, double[] coefficients2)
        {
            return new Polynom(coefficients1).GetHashCode() == new Polynom(coefficients2).GetHashCode();
        }

        [TestCase(new double[] { 0, 23.2, 123.2 }, 10, ExpectedResult = "232x + 1232")]
        [TestCase(new double[] { -1, -1, -1 }, 1, ExpectedResult = "-x^2 - x - 1")]
        [TestCase(new double[] { 1.2, 23.2, 123.2 }, -1, ExpectedResult = "-1,2x^2 - 23,2x - 123,2")]
        [TestCase(new double[] { 0, 0, 0 }, 100, ExpectedResult = "0")]
        [TestCase(new double[] { -1, 1, 1 }, 0, ExpectedResult = "0")]
        public string MultiplicationOperatorPolynomNumber_CheckMultiplicationOperatorBetweenPlinomAndDouble(double[] coefficients, double value)
        {
            return (new Polynom(coefficients) * value).ToString();
        }

        [TestCase(new double[] { 0, 23.2, 123.2 }, new double[] { 0, 23.2, 123.2 }, ExpectedResult = "46,4x + 246,4")]
        [TestCase(new double[] { -1, -1, -1 }, new double[] { -1, 1, 1 }, ExpectedResult = "-2x^2")]
        [TestCase(new double[] { 1.2, 23.2, 123.2 }, new double[] { 0, 0, 0 }, ExpectedResult = "1,2x^2 + 23,2x + 123,2")]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { -11, 0, 1 }, ExpectedResult = "-11x^2 + 1")]
        [TestCase(new double[] { -1, 1, 1 }, new double[] { -1, 1, 1 }, ExpectedResult = "-2x^2 + 2x + 2")]
        [TestCase(new double[] { -1, 1, 1 }, new double[] { -1 }, ExpectedResult = "-x^2 + x")]
        [TestCase(new double[] { -1 }, new double[] { -1, 1, 1 }, ExpectedResult = "-x^2 + x")]
        public string SumOperator_CheckSummationOfTwoPolinoms(double[] coefficients1, double[] coefficients2)
        {
            return (new Polynom(coefficients1) + new Polynom(coefficients2)).ToString();
        }

        [TestCase(new double[] { 0, 23.2, 123.2 }, 1, ExpectedResult = 146.4)]
        [TestCase(new double[] { -1, -1, -1 }, 1, ExpectedResult = -3)]
        [TestCase(new double[] { 1.2, 23.2, 123.2 }, 10, ExpectedResult = 475.2)]
        [TestCase(new double[] { 0, 0, 0 }, 100, ExpectedResult = 0)]
        [TestCase(new double[] { -1, 1, 1 }, 5, ExpectedResult = -19)]
        public double EvaluateMethod_CalculatePolynomWithSetValue(double[] coefficients, double value)
        {
            return new Polynom(coefficients).Evaluate(value);
        }

        [TestCase(new double[] { -1, -1, -1 }, new double[] { -1, 1, 1 }, ExpectedResult = "x^4 - x^2 - 2x - 1")]
        [TestCase(new double[] { 1.2, 23.2, 123.2 }, new double[] { 0, 0, 0 }, ExpectedResult = "0")]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { -11, 0, 1 }, ExpectedResult = "0")]
        [TestCase(new double[] { -1 }, new double[] { -1, 1, 1 }, ExpectedResult = "x^2 - x - 1")]
        [TestCase(new double[] { 1, -1 }, new double[] { 1, 1 }, ExpectedResult = "x^2 - 1")]
        public string MultiplicationOperatorPolynomPolynom_MultiplicationOperatorBetweenTwoPolynoms(
            double[] coefficients1, double[] coefficients2)
        {
            return (new Polynom(coefficients1) * new Polynom(coefficients2)).ToString();
        }
    }
}
