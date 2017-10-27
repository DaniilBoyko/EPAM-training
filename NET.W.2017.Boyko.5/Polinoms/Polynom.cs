using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Polynoms
{
    public class Polynom : ICloneable
    {
        #region Private Fields

        private double[] _coefficients;

        private char Letter { get; set; }
        private double[] Coefficients
        {
            get => _coefficients;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                if (value.Length == 0)
                    throw new ArgumentException($"{nameof(value)} should contains 1 and more values", nameof(value));

                int countZeros = 0;
                while (countZeros < value.Length && value[countZeros] == 0)
                    countZeros++;
                double[] coefs;

                if (countZeros == value.Length)
                {
                    _coefficients = new double[] { 0 };
                    return;
                }

                coefs = new double[value.Length - countZeros];
                for (int i = countZeros, j = 0; i < value.Length; i++, j++)
                    coefs[j] = value[i];

                _coefficients = coefs;
            }
        }

        #endregion

        #region Constructors

        private Polynom(char letter, params double[] coefficients)
        {
            Letter = letter;
            Coefficients = coefficients;
        }

        public Polynom(params double[] coefficients) : this('x', coefficients) { }

        #endregion

        #region Override Methods

        public override string ToString()
        {
            if (Coefficients.Length == 1) return Coefficients[0].ToString(CultureInfo.InvariantCulture);

            int n = Coefficients.Length - 1;
            var resultStr = new StringBuilder();

            for (int i = n, j = 0; i >= 0; i--, j++)
            {
                //Skip if zero
                if (Coefficients[j] == 0)
                    continue;

                //Print sign
                if (Coefficients[j] > 0 && i != n) resultStr.Append(" + ");
                if (Coefficients[j] < 0)
                {
                    resultStr.Append(i == n ? "-" : " - ");
                }

                //Print value
                if (Math.Abs(Coefficients[j]) != 1 || i == 0)
                    resultStr.Append(Math.Abs(Coefficients[j]));

                //Print letter
                if (i != 0)
                resultStr.Append(Letter);

                //Print power
                if (i > 1)
                    resultStr.Append("^" + i);
            }

            return resultStr.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Polynom polynomial = (Polynom)obj;

            if (Coefficients.Length != polynomial.Coefficients.Length)
                return false;

            for (int i = 0; i < Coefficients.Length; i++)
                if (Coefficients[i] != polynomial.Coefficients[i])
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = Coefficients[0].GetHashCode();
            for (int i = 1; i < Coefficients.Length; i++)
            {
                hashCode ^= Coefficients[i].GetHashCode();
            }
            return hashCode;
        }

        #endregion

        #region Public Methods

        public static bool Equals(Polynom polynom1, Polynom polynom2)
        {
            if (polynom1 == polynom2) return true;
            if (polynom1 == null || polynom2 == null)
                return false;
            return polynom1.Equals(polynom2);
        }

        public object Clone()
        {
            return new Polynom(Letter, Coefficients);
        }

        public double Evaluate(double xValue)
        {
            double summ = Coefficients[Coefficients.Length - 1];
            for (int i = Coefficients.Length - 2; i >= 0; i--)
            {
                summ += Coefficients[i] * xValue;
                xValue *= xValue;
            }
            return summ;
        }

        #endregion

        #region Operators

        public static Polynom operator -(Polynom polynom)
        {
            return polynom * (-1);
        }

        public static Polynom operator +(Polynom polynom)
        {
            return (Polynom)polynom.Clone();
        }

        public static Polynom operator +(Polynom polynom, double value)
        {
            return polynom + new Polynom(value);
        }

        public static Polynom operator +(double value, Polynom polynom)
        {
            return polynom + value;
        }

        public static Polynom operator -(Polynom polynom, double value)
        {
            return polynom + (-value);
        }

        public static Polynom operator -(double value, Polynom polynom)
        {
            return value + (-polynom);
        }

        public static Polynom operator *(Polynom polynom, double value)
        {
            double[] resultCoefs = (double[])polynom.Coefficients.Clone();

            for (int i = 0; i < resultCoefs.Length; i++)
                resultCoefs[i] *= value;

            return new Polynom(resultCoefs);
        }

        public static Polynom operator *(double value, Polynom polynom)
        {
            return polynom * value;
        }

        public static Polynom operator /(Polynom polynom, double value)
        {
            return polynom * (1 / value);
        }

        public static Polynom operator +(Polynom polynom1, Polynom polynom2)
        {
            double[] minCoefs, maxCoefs;
            SetMaxpolynomCoefficients(polynom1, polynom2, out maxCoefs, out minCoefs);

            double[] resultCefs = (double[])maxCoefs.Clone();
            for (int i = resultCefs.Length - 1, j = minCoefs.Length - 1; i >= 0 && j >= 0; i--, j--)
                resultCefs[i] += minCoefs[j];

            return new Polynom(resultCefs);
        }

        public static Polynom operator *(Polynom polynom1, Polynom polynom2)
        {
            double[] coefs1 = polynom1.Coefficients, coefs2 = polynom2.Coefficients;
            double[] resultCoefs = new double[coefs1.Length + coefs2.Length - 1];

            for (int i = 0; i < coefs1.Length; i++)
                for (int j = 0; j < coefs2.Length; j++)
                    resultCoefs[i + j] += coefs1[i] * coefs2[j];

            return new Polynom(resultCoefs);
        }

        public static Polynom operator -(Polynom polynom1, Polynom polynom2)
        {
            return polynom1 + (-polynom2);
        }

        public static bool operator ==(Polynom polynom1, Polynom polynom2)
        {
            return Equals(polynom1, polynom2);
        }

        public static bool operator !=(Polynom polynom1, Polynom polynom2)
        {
            return !(polynom1 == polynom2);
        }

        #endregion

        #region Private Methods

        private static void SetMaxpolynomCoefficients(Polynom polynom1, Polynom polynom2, out double[] maxCoefs,
            out double[] minCoefs)
        {
            if (polynom1.Coefficients.Length > polynom2.Coefficients.Length)
            {
                maxCoefs = polynom1.Coefficients;
                minCoefs = polynom2.Coefficients;
            }
            else
            {
                maxCoefs = polynom2.Coefficients;
                minCoefs = polynom1.Coefficients;
            }
        }

        #endregion
    }
}
