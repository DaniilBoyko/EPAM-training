using System;
using System.Configuration;
using System.Globalization;
using System.Text;

namespace Polinoms
{
    /// <summary>
    /// Represent the polynomial.
    /// </summary>
    public sealed class Polynom : ICloneable
    {
        #region private Fields
        
        /// <summary>
        /// Field stores coefficients of polynomial.
        /// </summary>
        private readonly double[] _coefficients;

        #endregion private Fields
        
        #region public Constructors

        /// <summary>
        /// Create new instance of Polynomial.
        /// </summary>
        /// <param name="coefficients">the coefficients of polynomial</param>
        public Polynom(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException($"{nameof(coefficients)} should contains 1 and more values", nameof(coefficients));
            }

            _coefficients = GetCoefficients(coefficients);
            Degree = _coefficients.Length - 1;
        }

        #endregion // !public Constructors

        #region public Properties

        /// <summary>
        /// Property stores degree of polynomial.
        /// </summary>
        public int Degree { get; }

        #endregion // !public Properties

        #region public Indexers

        /// <summary>
        /// Indexer of getting coefficients of polynomial.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Appropriate coefficient.</returns>
        public double this[int index]
        {
            get
            {
                if (index > Degree || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _coefficients[index];
            }
        }

        #endregion // !public Indexers

        #region public Operators

        /// <summary>
        /// Positive operator for polynomial.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>Polynomial with positive operator.</returns>
        public static Polynom operator +(Polynom polynom)
        {
            CheckPolynom(polynom);
            return (Polynom)polynom.Clone();
        }

        /// <summary>
        /// Add operator for polynomial and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">adding value</param>
        /// <returns>Polynomial after adding.</returns>
        public static Polynom operator +(Polynom polynom, double value)
        {
            CheckPolynom(polynom);
            return polynom + new Polynom(value);
        }

        /// <summary>
        /// Add operator for double value and polynomial.
        /// </summary>
        /// <param name="value">adding value</param>
        /// <param name="polynom"></param>
        /// <returns>Polynomial after adding</returns>
        public static Polynom operator +(double value, Polynom polynom)
        {
            CheckPolynom(polynom);
            return polynom + value;
        }

        /// <summary>
        /// Add operator for two polynomials.
        /// </summary>
        /// <param name="leftPolynom">left polynomial</param>
        /// <param name="rightPolynom">right polynomial</param>
        /// <returns>The result polynomial of adding two polynomials.</returns>
        public static Polynom operator +(Polynom leftPolynom, Polynom rightPolynom)
        {
            CheckPolynom(leftPolynom);
            CheckPolynom(rightPolynom);
            double[] resultCoefs = new double[Math.Max(leftPolynom.Degree, rightPolynom.Degree) + 1];

            for (int i = leftPolynom.Degree, k = resultCoefs.Length - 1; i >= 0; i--, k--)
            {
                resultCoefs[k] += leftPolynom[i];
            }

            for (int i = rightPolynom.Degree, k = resultCoefs.Length - 1; i >= 0; i--, k--)
            {
                resultCoefs[k] += rightPolynom[i];
            }

            return new Polynom(resultCoefs);
        }

        /// <summary>
        /// Negative operator for polynomial.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>Polynomial with mines.</returns>
        public static Polynom operator -(Polynom polynom)
        {
            CheckPolynom(polynom);
            return polynom * (-1);
        }

        /// <summary>
        /// Subtract operator for polynomial and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>Result polynomial after subtract.</returns>
        public static Polynom operator -(Polynom polynom, double value)
        {
            CheckPolynom(polynom);
            return polynom + (-value);
        }

        /// <summary>
        /// Subtract operator for double value and polynomial.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>Result polynomial after subtract.</returns>
        public static Polynom operator -(double value, Polynom polynom)
        {
            CheckPolynom(polynom);
            return value + (-polynom);
        }

        /// <summary>
        /// Subtract operator for two polynomials.
        /// </summary>
        /// <param name="leftPolynom">left polynomial</param>
        /// <param name="rightPolynom">right polynomial</param>
        /// <returns>Result polynomial of subtract.</returns>
        public static Polynom operator -(Polynom leftPolynom, Polynom rightPolynom)
        {
            CheckPolynom(leftPolynom);
            CheckPolynom(rightPolynom);
            return leftPolynom + (-rightPolynom);
        }

        /// <summary>
        /// Multiply operator for polynomial and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>Result polynomial after multiplying.</returns>
        public static Polynom operator *(Polynom polynom, double value)
        {
            CheckPolynom(polynom);

            double[] resultCoefs = new double[polynom.Degree + 1];
            for (int i = 0; i < resultCoefs.Length; i++)
            {
                resultCoefs[i] = polynom[i] * value;
            }

            return new Polynom(resultCoefs);
        }

        /// <summary>
        /// Multiply operator for double value and polynomial.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>Result polynomial after multiplying.</returns>
        public static Polynom operator *(double value, Polynom polynom)
        {
            CheckPolynom(polynom);
            return polynom * value;
        }

        /// <summary>
        /// Multiply operator for two polynomials.
        /// </summary>
        /// <param name="leftPolynom">left polynomial</param>
        /// <param name="rightPolynom">right polynomial</param>
        /// <returns>Result polynomial after multiplying two polynomials.</returns>
        public static Polynom operator *(Polynom leftPolynom, Polynom rightPolynom)
        {
            CheckPolynom(leftPolynom);
            CheckPolynom(rightPolynom);
            double[] resultCoefs = new double[leftPolynom.Degree + rightPolynom.Degree + 1];

            for (int i = 0; i <= leftPolynom.Degree; i++)
            {
                for (int j = 0; j <= rightPolynom.Degree; j++)
                    {
                        resultCoefs[i + j] += leftPolynom[i] * rightPolynom[j];
                    }
            }

            return new Polynom(resultCoefs);
        }

        /// <summary>
        /// Divide operator for polynomial and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>Result after dividing polynomial on double value.</returns>
        public static Polynom operator /(Polynom polynom, double value)
        {
            CheckPolynom(polynom);
            return polynom * (1 / value);
        }

        /// <summary>
        /// Equal operator for two polynomials.
        /// </summary>
        /// <param name="leftPolynom">left polynomial</param>
        /// <param name="rightPolynom">right polynomial</param>
        /// <returns>The boolean result of the comparison.</returns>
        public static bool operator ==(Polynom leftPolynom, Polynom rightPolynom)
        {
            return Equals(leftPolynom, rightPolynom);
        }

        /// <summary>
        /// Not equal operator for two polynomials.
        /// </summary>
        /// <param name="leftPolynom">left polynomial</param>
        /// <param name="rightPolynom">right polynomial</param>
        /// <returns>The boolean result of the comparison.</returns>
        public static bool operator !=(Polynom leftPolynom, Polynom rightPolynom)
        {
            return !Equals(leftPolynom, rightPolynom);
        }

        #endregion // !public Operators

        #region public Functions By Operators

        /// <summary>
        /// The function representation of negative operator for polynomial.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>Polynomial with negative operator.</returns>
        public static Polynom Negate(Polynom polynom)
        {
            return -polynom;
        }

        /// <summary>
        /// The function representation of positive operator for polynomial.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>Polynomial with positive operator.</returns>
        public static Polynom Posite(Polynom polynom)
        {
            return +polynom;
        }

        /// <summary>
        /// The function representation of add operator for two polynomials.
        /// </summary>
        /// <param name="leftPolynom">left polynomial</param>
        /// <param name="rightPolynom">right polynomial</param>
        /// <returns>The result polynomial after adding.</returns>
        public static Polynom Add(Polynom leftPolynom, Polynom rightPolynom)
        {
            return leftPolynom + rightPolynom;
        }

        /// <summary>
        /// The function representation of add operator for polynomial and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>The result polynomial after adding double value to polynomial.</returns>
        public static Polynom Add(Polynom polynom, double value)
        {
            return polynom + value;
        }

        /// <summary>
        /// The function representation of add operator for double value and polynomial.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>The result after adding double value to polynomial.</returns>
        public static Polynom Add(double value, Polynom polynom)
        {
            return value + polynom;
        }

        /// <summary>
        /// The function representation of subtract operator for two polynomials.
        /// </summary>
        /// <param name="leftPolynom">left polynomial</param>
        /// <param name="rightPolynom">right polynomial</param>
        /// <returns>The result polynomial of subtract operation between two polynomials.</returns>
        public static Polynom Subtract(Polynom leftPolynom, Polynom rightPolynom)
        {
            return leftPolynom - rightPolynom;
        }

        /// <summary>
        /// The function representation of subtract operator for polynomial and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>The result polynomial of subtraction double value from polynomial.</returns>
        public static Polynom Subtract(Polynom polynom, double value)
        {
            return polynom - value;
        }

        /// <summary>
        /// The function representation of subtract operator for double value and polynomial.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>The result polynomial of subtraction polynomial from double value.</returns>
        public static Polynom Subtract(double value, Polynom polynom)
        {
            return value - polynom;
        }

        /// <summary>
        /// The function representation of multiply operator for two polynomials.
        /// </summary>
        /// <param name="leftPolynom">left polynomial</param>
        /// <param name="rightPolynom">right polynomial</param>
        /// <returns>The result polynomial of multiplying two polynomials.</returns>
        public static Polynom Multiply(Polynom leftPolynom, Polynom rightPolynom)
        {
            return leftPolynom * rightPolynom;
        }

        /// <summary>
        /// The function representation of multiply operator for polynomial and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>The result polynomial of multiplying polynomial and double value.</returns>
        public static Polynom Multiply(Polynom polynom, double value)
        {
            return polynom * value;
        }

        /// <summary>
        /// The function representation of multiply operator for double value and polynomial.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>The result polynomial of multiplying double value and polynomial.</returns>
        public static Polynom Multiply(double value, Polynom polynom)
        {
            return value * polynom;
        }

        /// <summary>
        /// The function representation of divide operator for polynomial and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>The result of divide polynomial and double value.</returns>
        public static Polynom Divide(Polynom polynom, double value)
        {
            return polynom / value;
        }

        #endregion // !public Functions By Operators

        #region public Methods

        /// <summary>
        /// Compare two polynomials.
        /// </summary>
        /// <param name="leftPolynom"></param>
        /// <param name="rightPolynom"></param>
        /// <returns>If polynomials equal - true, otherwise - false.</returns>
        public static bool Equals(Polynom leftPolynom, Polynom rightPolynom)
        {
            if (ReferenceEquals(leftPolynom, rightPolynom))
            {
                return true;
            }

            if (ReferenceEquals(leftPolynom, null) || ReferenceEquals(rightPolynom, null))
            {
                return false;
            }

            return leftPolynom.Equals(rightPolynom);
        }

        /// <summary>
        /// Compare polynomial with polynomial.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>If equals - true, otherwise - false.</returns>
        public bool Equals(Polynom polynom)
        {
            if (ReferenceEquals(null, polynom))
            {
                return false;
            }

            if (ReferenceEquals(this, polynom))
            {
                return true;
            }

            if (GetType() != polynom.GetType())
            {
                return false;
            }

            if (Degree != polynom.Degree)
            {
                return false;
            }

            double epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
            for (int i = 0; i <= Degree; i++)
            {
                if (Math.Abs(this[i] - polynom[i]) > epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Create clone of polynomial.
        /// </summary>
        /// <returns>Clone of polynomial.</returns>
        public object Clone()
        {
            return new Polynom(_coefficients);
        }

        /// <summary>
        /// Calculate polynomial.
        /// </summary>
        /// <param name="xValue">the value of unknown</param>
        /// <returns>Calculated result.</returns>
        public double Evaluate(double xValue)
        {
            double summ = this[Degree];
            for (int i = Degree - 1; i >= 0; i--)
            {
                summ += this[i] * xValue;
                xValue *= xValue;
            }

            return summ;
        }

        #endregion // !public Methods

        #region public Override Methods

        /// <summary>
        /// Build string representation of polynomial.
        /// </summary>
        /// <returns>String representation of polynomial.</returns>
        public override string ToString()
        {
            if (Degree == 0)
            {
                return this[0].ToString(CultureInfo.InvariantCulture);
            }

            int n = Degree;
            double epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
            var resultStr = new StringBuilder();

            for (int i = n, j = 0; i >= 0; i--, j++)
            {
                ////Skip if zero
                if (Math.Abs(this[j]) < epsilon)
                {
                    continue;
                }

                ////Print sign
                if (this[j] > 0 && i != n)
                {
                    resultStr.Append(" + ");
                }

                if (this[j] < 0)
                {
                    resultStr.Append(i == n ? "-" : " - ");
                }

                ////Print value
                if (Math.Abs(this[j]) - 1 > epsilon || i == 0)
                {
                    resultStr.Append(Math.Abs(this[j]));
                }

                ////Print letter
                if (i != 0)
                {
                    resultStr.Append("x");
                }

                ////Print power
                if (i > 1)
                {
                    resultStr.Append("^" + i);
                }
            }

            return resultStr.ToString();
        }

        /// <summary>
        /// Compare polynomial with other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>If equals - true, otherwise - false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            Polynom polynom = (Polynom)obj;

            if (Degree != polynom.Degree)
            {
                return false;
            }

            return Equals(polynom);
        }

        /// <summary>
        /// Calculate hash code of polynomial.
        /// </summary>
        /// <returns>Hash code of polynomial.</returns>
        public override int GetHashCode()
        {
            int hashCode = this[0].GetHashCode();
            for (int i = 1; i <= Degree; i++)
            {
                hashCode ^= this[i].GetHashCode();
            }

            return hashCode;
        }

        #endregion // !public Override Methods

        #region private Methods

        /// <summary>
        /// Check polynomial of null reference.
        /// </summary>
        /// <param name="polynom"></param>
        private static void CheckPolynom(Polynom polynom)
        {
            if (polynom == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Removes unused zeros.
        /// </summary>
        /// <param name="coefficients"></param>
        /// <returns>Array of refactor coefficients.</returns>
        private double[] GetCoefficients(double[] coefficients)
        {
            double epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
            int countZeros = 0;
            while (countZeros < coefficients.Length && Math.Abs(coefficients[countZeros]) < epsilon)
            {
                countZeros++;
            }

            if (countZeros == coefficients.Length)
            {
                return new double[] { 0 };
            }

            var coefs = new double[coefficients.Length - countZeros];
            for (int i = countZeros, j = 0; i < coefficients.Length; i++, j++)
            {
                coefs[j] = coefficients[i];
            }

            return coefs;
        }

        #endregion // !private Methods
    }
}
