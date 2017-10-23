using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace SpecialFunctions
{
    public class Functions
    {
        #region Constants
        private const int COUNT_BITS = 31;
        #endregion

        #region Public Methods (API)
        /// <summary>
        /// This function get first (toPosition - fromPositon) bytes from nuberInset
        /// and insert them into numberSource in position (fromPosition, toPosition).
        /// </summary>
        /// <param name="numberSource">the number which is inserted</param>
        /// <param name="numberInsert">the number from which insert</param>
        /// <param name="fromPosition">start inserting position</param>
        /// <param name="toPosition">end inserting position</param>
        /// <returns>Number after inserting.</returns>
        public static int InsertNumber(int numberSource, int numberInsert, int fromPosition, int toPosition)
        {
            if (fromPosition < 0 || toPosition < 0 || toPosition > COUNT_BITS)
                throw new ArgumentOutOfRangeException();

            if (fromPosition > toPosition)
                throw new ArgumentException();

            int length = toPosition - fromPosition + 1;

            int maskWithOnes = 1;
            for (int i = 1; i < length; i++)
            {
                maskWithOnes <<= 1;
                maskWithOnes += 1;
            }

            int insertingValue = numberInsert & maskWithOnes;

            maskWithOnes <<= fromPosition;
            insertingValue <<= fromPosition;

            numberSource = numberSource & ~maskWithOnes ^ insertingValue;

            return numberSource;
        }

        /// <summary>
        /// Find next bigger number, if exists, or -1
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Finding bigger number or -1</returns>
        public static Tuple<int, long> FindNextBiggerNumber(int number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            StringBuilder strNumber = new StringBuilder(number.ToString());
            bool flagExistsBigger = false;
            int index = -1;

            for (int i = 0; i < strNumber.Length - 1; i++)
            {
                if (strNumber[i + 1] > strNumber[i])
                {
                    index = i;
                    flagExistsBigger = true;
                }
            }
            if (!flagExistsBigger)
            {
                stopwatch.Stop();
                return new Tuple<int, long>(-1, stopwatch.ElapsedMilliseconds);
            }

            int replaceIndex = -1;
            int minDifference = 10;
            for (int i = index + 1; i < strNumber.Length; i++)
            {
                int difference = strNumber[i] - strNumber[index];
                if (difference > 0 && difference < minDifference)
                {
                    minDifference = difference;
                    replaceIndex = i;
                }
            }

            char temp = strNumber[index];
            strNumber[index] = strNumber[replaceIndex];
            strNumber[replaceIndex] = temp;

            char[] endOfNumberString = strNumber.ToString().Substring(index + 1).ToCharArray();
            Array.Sort(endOfNumberString);
            strNumber.Remove(index + 1, endOfNumberString.Length);
            strNumber.Append(endOfNumberString);

            stopwatch.Stop();

            return new Tuple<int, long>(int.Parse(strNumber.ToString()), stopwatch.ElapsedMilliseconds);
        }


        /// <summary>
        /// This function filter numbers, which don't contain set digit.
        /// </summary>
        /// <param name="list">list of numbers</param>
        /// <param name="digit">digit to filter</param>
        /// <returns>List of numbers, which contains set digit.</returns>
        public static List<int> FilterDigit (List<int> list, int digit)
        {
            if (list == null)
                throw new ArgumentNullException();

            if (digit > 9 || digit < 0)
                throw new ArgumentOutOfRangeException();

            List<int> resultList = new List<int>();

            foreach(int number in list)
            {
                if (number.ToString().Contains(digit.ToString()))
                    resultList.Add(number);
            }

            return resultList;
        }


        /// <summary>
        /// Find root of set degree from number with set precision
        /// </summary>
        /// <param name="number"></param>
        /// <param name="degree">degree of root</param>
        /// <param name="precision">precision of calculation</param>
        /// <returns>Finding root</returns>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (precision < 0)
                throw new ArgumentOutOfRangeException();

            if (number < 0 && degree % 2 == 0)
                throw new ArgumentOutOfRangeException();

            double prevResult = number / degree;
            double curResult = prevResult;

            do
            {
                prevResult = curResult;
                curResult = 1.0 / degree * ((degree - 1) * curResult + number * 1.0 / Math.Pow(curResult, degree - 1));
            } while (Math.Abs(prevResult - curResult) > precision);

            return curResult;
        }

        #endregion
    }
}
