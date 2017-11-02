using System;
using System.Configuration;
using System.Globalization;
using System.Text;


namespace Polinoms
{
    public sealed class Polynom : ICloneable
    {
        #region private Fields
        
        /// <summary>
        /// Field stores coefficients of polynom.
        /// </summary>
        private readonly double[] _coefficients;

        #endregion private Fields


        #region Public 
        
        #region public Properties

        /// <summary>
        /// Properti stores degree of polynom.
        /// </summary>
        public int Degree { get; private set; }

        #endregion


        #region public Methods

        /// <summary>
        /// Create new instance of Polynom.
        /// </summary>
        /// <param name="coefficients">the coefficients of polynom</param>
        public Polynom(params double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException(nameof(coefficients));

            if (coefficients.Length == 0)
                throw new ArgumentException($"{nameof(coefficients)} should contains 1 and more values", nameof(coefficients));

            _coefficients = GetCoefficients(coefficients);
            Degree = _coefficients.Length - 1;
        }

        /// <summary>
        /// Compare plynom with polynom.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>If equals - true, otherwise - false.</returns>
        public bool Equals(Polynom polynom)
        {
            if (ReferenceEquals(null, polynom)) return false;
            if (ReferenceEquals(this, polynom)) return true;
            if (GetType() != polynom.GetType()) return false;

            if (Degree != polynom.Degree)
                return false;

            double epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
            for (int i = 0; i <= Degree; i++)
            {
                if (Math.Abs(this[i] - polynom[i]) > epsilon)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Create clone of polynom.
        /// </summary>
        /// <returns>Clone of polynom.</returns>
        public object Clone()
        {
            return new Polynom(_coefficients);
        }

        /// <summary>
        /// Calculate polynom.
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

        /// <summary>
        /// Compary two polynoms.
        /// </summary>
        /// <param name="leftPolynom"></param>
        /// <param name="rightPolynom"></param>
        /// <returns>If polynoms equl - true, otherwise - false.</returns>
        public static bool Equals(Polynom leftPolynom, Polynom rightPolynom)
        {
            if (ReferenceEquals(leftPolynom, rightPolynom)) return true;
            if (ReferenceEquals(leftPolynom, null) || ReferenceEquals(rightPolynom, null))
                return false;
            return leftPolynom.Equals(rightPolynom);
        }

        #endregion public Methods


        #region public Indexers

        /// <summary>
        /// Indexer of getting coefficients of polynom.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Appropriate coefficient.</returns>
        public double this[int index]
        {
            get
            {
                if (index > Degree || index < 0)
                    throw new ArgumentOutOfRangeException();
                return _coefficients[index];
            }
        }

        #endregion


        #region public Override Methods

        /// <summary>
        /// Build string representation of polynom.
        /// </summary>
        /// <returns>String representation of polynom.</returns>
        public override string ToString()
        {
            if (Degree == 0) return this[0].ToString();

            int n = Degree;
            double epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
            var resultStr = new StringBuilder();

            for (int i = n, j = 0; i >= 0; i--, j++)
            {
                //Skip if zero
                if (Math.Abs(this[j]) < epsilon)
                    continue;

                //Print sign
                if (this[j] > 0 && i != n) resultStr.Append(" + ");
                if (this[j] < 0)
                {
                    resultStr.Append(i == n ? "-" : " - ");
                }

                //Print value
                if (Math.Abs(this[j]) - 1 > epsilon || i == 0)
                    resultStr.Append(Math.Abs(this[j]));

                //Print letter
                if (i != 0)
                    resultStr.Append("x");

                //Print power
                if (i > 1)
                    resultStr.Append("^" + i);
            }

            return resultStr.ToString();
        }

        /// <summary>
        /// Compare polynom with other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>If equals - true, otherwise - false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            Polynom polynom = (Polynom)obj;

            if (Degree != polynom.Degree)
                return false;

            return Equals(polynom);
        }

        /// <summary>
        /// Calculate hash code of polynom.
        /// </summary>
        /// <returns>Hash code of polynom.</returns>
        public override int GetHashCode()
        {
            int hashCode = this[0].GetHashCode();
            for (int i = 1; i <= Degree; i++)
            {
                hashCode ^= this[i].GetHashCode();
            }
            return hashCode;
        }

        #endregion public Override Methods


        #region public Operators

        /// <summary>
        /// Positive operator for polynom.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>Polynom with positive operator.</returns>
        public static Polynom operator +(Polynom polynom)
        {
            CheckPolynom(polynom);
            return (Polynom)polynom.Clone();
        }

        /// <summary>
        /// Add operator for polynom and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">adding value</param>
        /// <returns>Polynom after adding.</returns>
        public static Polynom operator +(Polynom polynom, double value)
        {
            CheckPolynom(polynom);
            return polynom + new Polynom(value);
        }

        /// <summary>
        /// Add operator for double value and polynom.
        /// </summary>
        /// <param name="value">adding value</param>
        /// <param name="polynom"></param>
        /// <returns>Polynom after adding</returns>
        public static Polynom operator +(double value, Polynom polynom)
        {
            CheckPolynom(polynom);
            return polynom + value;
        }

        /// <summary>
        /// Add operator for two polynoms.
        /// </summary>
        /// <param name="leftPolynom">left polynom</param>
        /// <param name="rightPolynom">right polynom</param>
        /// <returns>The result polynom of adding two polynoms.</returns>
        public static Polynom operator +(Polynom leftPolynom, Polynom rightPolynom)
        {
            CheckPolynom(leftPolynom);
            CheckPolynom(rightPolynom);
            double[] resultCoefs = new double[Math.Max(leftPolynom.Degree, rightPolynom.Degree) + 1];

            for (int i = leftPolynom.Degree, k = resultCoefs.Length - 1; i >= 0; i--, k--)
                resultCoefs[k] += leftPolynom[i];
            for (int i = rightPolynom.Degree, k = resultCoefs.Length - 1; i >= 0; i--, k--)
                resultCoefs[k] += rightPolynom[i];

            return new Polynom(resultCoefs);
        }

        /// <summary>
        /// Negative operator for polyno.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>Polynom with mines.</returns>
        public static Polynom operator -(Polynom polynom)
        {
            CheckPolynom(polynom);
            return polynom * (-1);
        }

        /// <summary>
        /// Subtract operator for plynom and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>Result polynom after subtract.</returns>
        public static Polynom operator -(Polynom polynom, double value)
        {
            CheckPolynom(polynom);
            return polynom + (-value);
        }

        /// <summary>
        /// Subtract operator for double value and polynom.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>Result polynom after subtract.</returns>
        public static Polynom operator -(double value, Polynom polynom)
        {
            CheckPolynom(polynom);
            return value + (-polynom);
        }
        
        /// <summary>
        /// Subtract operator for two polynoms.
        /// </summary>
        /// <param name="leftPolynom">left polynom</param>
        /// <param name="rightPolynom">right polynom</param>
        /// <returns>Result polynom of subtract.</returns>
        public static Polynom operator -(Polynom leftPolynom, Polynom rightPolynom)
        {
            CheckPolynom(leftPolynom);
            CheckPolynom(rightPolynom);
            return leftPolynom + (-rightPolynom);
        }

        /// <summary>
        /// Multiply operator for polynom and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>Result polynom after multiplying.</returns>
        public static Polynom operator *(Polynom polynom, double value)
        {
            CheckPolynom(polynom);

            double[] resultCoefs = new double[polynom.Degree + 1];
            for (int i = 0; i < resultCoefs.Length; i++)
                resultCoefs[i] = polynom[i] * value;

            return new Polynom(resultCoefs);
        }

        /// <summary>
        /// Multiply operator for double value and polynom.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>Result polynom after multiplying.</returns>
        public static Polynom operator *(double value, Polynom polynom)
        {
            CheckPolynom(polynom);
            return polynom * value;
        }

        /// <summary>
        /// Multiply operator for two polynoms.
        /// </summary>
        /// <param name="leftPolynom">left polynom</param>
        /// <param name="rightPolynom">right polynom</param>
        /// <returns>Result polynom after multiplying two polynoms.</returns>
        public static Polynom operator *(Polynom leftPolynom, Polynom rightPolynom)
        {
            CheckPolynom(leftPolynom);
            CheckPolynom(rightPolynom);
            double[] resultCoefs = new double[leftPolynom.Degree + rightPolynom.Degree + 1];

            for (int i = 0; i <= leftPolynom.Degree; i++)
            for (int j = 0; j <= rightPolynom.Degree; j++)
                resultCoefs[i + j] += leftPolynom[i] * rightPolynom[j];

            return new Polynom(resultCoefs);
        }

        /// <summary>
        /// Divide operator for polynom and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>Result after dividing polynom on double value.</returns>
        public static Polynom operator /(Polynom polynom, double value)
        {
            CheckPolynom(polynom);
            return polynom * (1 / value);
        }

        /// <summary>
        /// Equal operator for two polynoms.
        /// </summary>
        /// <param name="leftPolynom">left polynom</param>
        /// <param name="rightPolynom">right polynom</param>
        /// <returns>The bool result of the comparison.</returns>
        public static bool operator ==(Polynom leftPolynom, Polynom rightPolynom)
        {
            return Equals(leftPolynom, rightPolynom);
        }

        /// <summary>
        /// Not equal operator for two polynoms.
        /// </summary>
        /// <param name="leftPolynom">left polynom</param>
        /// <param name="rightPolynom">right polynom</param>
        /// <returns>The bool result of the comparison.</returns>
        public static bool operator !=(Polynom leftPolynom, Polynom rightPolynom)
        {
            return !Equals(leftPolynom, rightPolynom);
        }

        #endregion


        #region public Functions By Operators

        /// <summary>
        /// The function representation of negative operator for polynom.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>Polynom with negative operator.</returns>
        public static Polynom Negate(Polynom polynom)
        {
            return (-polynom);
        }

        /// <summary>
        /// The function representation of positive operator for polynom.
        /// </summary>
        /// <param name="polynom"></param>
        /// <returns>Polynom with positive operator.</returns>
        public static Polynom Posite(Polynom polynom)
        {
            return (+polynom);
        }

        /// <summary>
        /// The function representation of add operator for two polynoms.
        /// </summary>
        /// <param name="leftPolynom">left polynom</param>
        /// <param name="rightPolynom">right polynom</param>
        /// <returns>The result polynom after adding.</returns>
        public static Polynom Add(Polynom leftPolynom, Polynom rightPolynom)
        {
            return (leftPolynom + rightPolynom);
        }

        /// <summary>
        /// The function representation of add operator for polynom and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>Thre result polynom after adding double value to polynom.</returns>
        public static Polynom Add(Polynom polynom, double value)
        {
            return (polynom + value);
        }

        /// <summary>
        /// The function representation of add operator for double value and polynom.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>The result after adding double value to polynom.</returns>
        public static Polynom Add(double value, Polynom polynom)
        {
            return (value + polynom);
        }

        /// <summary>
        /// The function representation of subtract operator for two polynoms.
        /// </summary>
        /// <param name="leftPolynom">left polynom</param>
        /// <param name="rightPolynom">right polynom</param>
        /// <returns>The result polynom of subtract operation between two polynoms.</returns>
        public static Polynom Subtract(Polynom leftPolynom, Polynom rightPolynom)
        {
            return (leftPolynom - rightPolynom);
        }

        /// <summary>
        /// The function representation of subtract operator for polynom and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>The result polynom of subtractin double value from polynom.</returns>
        public static Polynom Subtract(Polynom polynom, double value)
        {
            return (polynom - value);
        }

        /// <summary>
        /// The function representation of subtract operator for double value and polynom.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>The result polynom of subtractin polynom from double value.</returns>
        public static Polynom Subtract(double value, Polynom polynom)
        {
            return (value - polynom);
        }

        /// <summary>
        /// The function representation of multiply operator for two polynoms.
        /// </summary>
        /// <param name="leftPolynom">left polynom</param>
        /// <param name="rightPolynom">right polynom</param>
        /// <returns>The result polynom of multiplying two polynoms.</returns>
        public static Polynom Multiply(Polynom leftPolynom, Polynom rightPolynom)
        {
            return (leftPolynom * rightPolynom);
        }

        /// <summary>
        /// The function representation of multiply operator for polynom and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>The result polynom of multiplying polynom and double value.</returns>
        public static Polynom Multiply(Polynom polynom, double value)
        {
            return (polynom * value);
        }

        /// <summary>
        /// The function representation of multiply operator for double value and polynom.
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="polynom"></param>
        /// <returns>The result polynom of multiplying double value and polynom.</returns>
        public static Polynom Multiply(double value, Polynom polynom)
        {
            return (value * polynom);
        }

        /// <summary>
        /// The function representation of divide operator for polynom and double value.
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="value">double value</param>
        /// <returns>The result of divide polynom and double value.</returns>
        public static Polynom Divide(Polynom polynom, double value)
        {
            return (polynom / value);
        }

        #endregion public Functions By Operators

        #endregion Public


        #region Private

        #region private Methods

        /// <summary>
        /// Removes unused zeros.
        /// </summary>
        /// <param name="coefficients"></param>
        /// <returns>Arrya of refactor coefficients.</returns>
        private double[] GetCoefficients(double[] coefficients)
        {
            double epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
            int countZeros = 0;
            while (countZeros < coefficients.Length && Math.Abs(coefficients[countZeros]) < epsilon)
                countZeros++;

            if (countZeros == coefficients.Length)
                return new double[] { 0 };

            var coefs = new double[coefficients.Length - countZeros];
            for (int i = countZeros, j = 0; i < coefficients.Length; i++, j++)
                coefs[j] = coefficients[i];

            return coefs;
        }

        /// <summary>
        /// Check polynom of null reference.
        /// </summary>
        /// <param name="polynom"></param>
        private static void CheckPolynom(Polynom polynom)
        {
            if (polynom == null) throw new ArgumentNullException();
        }

        #endregion private Methods

        #endregion
    }
}
