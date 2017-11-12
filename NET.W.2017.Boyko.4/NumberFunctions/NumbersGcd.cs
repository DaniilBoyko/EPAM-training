using System;
using System.Diagnostics;

namespace NumberFunctions
{
    /// <summary>
    /// Class for calculation greatest common divisor.
    /// </summary>
    public class NumbersGcd
    {
        #region public Methods

        /// <summary>
        /// Calculate greatest common divisor of two numbers by the Euclidean algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns>Greatest common divisor of two numbers</returns>
        public static int EuclideanGcd(int number1, int number2)
        {
            if (CheckNumbersForGcd(ref number1, ref number2, out int resultGcd))
            {
                return resultGcd;
            }
                
            while (number2 != 0)
            {
                int temp = number2;
                number2 = number1 % number2;
                number1 = temp;
            }

            return number1;
        }

        /// <summary>
        /// Calculate greatest common divisor of two numbers by the Euclidean algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="nubmer2"></param>
        /// <param name="executionTime">time of execution</param>
        /// <returns>Greatest common divisor of two numbers</returns>
        public static int EuclideanGcd(int number1, int nubmer2, out long executionTime)
        {
            return ExecutionTimeGcd(EuclideanGcd, number1, nubmer2, out executionTime);
        }

        /// <summary>
        /// Calculate greatest common divisor of three numbers by the Euclidean algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="number3"></param>
        /// <returns>Greatest common divisor of three numbers</returns>
        public static int EuclideanGcd(int number1, int number2, int number3)
        {
            return CalculateGcd(EuclideanGcd, number1, number2, number3);
        }

        /// <summary>
        /// Calculate greatest common divisor of three numbers by the Euclidean algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="nubmer2"></param>
        /// <param name="number3"></param>
        /// <param name="executionTime">time of execution</param>
        /// <returns>Greatest common divisor of three numbers</returns>
        public static int EuclideanGcd(int number1, int nubmer2, int number3, out long executionTime)
        {
            return ExecutionTimeGcd(EuclideanGcd, number1, nubmer2, number3, out executionTime);
        }

        /// <summary>
        /// Calculate greatest common divisor of more then one number by the Euclidean algorithm
        /// </summary>
        /// <param name="numbers">array of numbers</param>
        /// <returns>Greatest common divisor of all numbers</returns>
        public static int EuclideanGcd(params int[] numbers)
        {
            return CalculateGcd(EuclideanGcd, numbers);
        }

        /// <summary>
        /// Calculate greatest common divisor of more then one number by the Euclidean algorithm
        /// </summary>
        /// <param name="executionTime">time of execution</param>
        /// <param name="numbers"></param>
        /// <returns>Greatest common divisor all numbers</returns>
        public static int EuclideanGcd(out long executionTime, params int[] numbers)
        {
            return ExecutionTimeGcd(EuclideanGcd, numbers, out executionTime);
        }

        /// <summary>
        /// Calculate greatest common divisor of two numbers by the Stain algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns>Greatest common divisor of two numbers</returns>
        public static int StainGcd(int number1, int number2)
        {
            if (CheckNumbersForGcd(ref number1, ref number2, out int resultGcd))
            {
                return resultGcd;
            }

            int shift;
            for (shift = 0; ((number1 | number2) & 1) == 0; shift++)
            {
                number1 >>= 1;
                number2 >>= 1;
            }

            while ((number1 & 1) == 0)
            {
                number1 >>= 1;
            }

            do
            {
                while ((number2 & 1) == 0)
                {
                    number2 >>= 1;
                }

                if (number1 > number2)
                {
                    Swap(ref number1, ref number2);
                }

                number2 = number2 - number1;
            }
            while (number2 != 0);

            return number1 << shift;
        }

        /// <summary>
        /// Calculate greatest common divisor of two numbers by the Stain algorithm with calculation execution time
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="executionTime">execution time</param>
        /// <returns>Greatest common divisor of two numbers</returns>
        public static int StainGcd(int number1, int number2, out long executionTime)
        {
            return ExecutionTimeGcd(StainGcd, number1, number2, out executionTime);
        }

        /// <summary>
        /// Calculate greatest common divisor of three numbers by the Stain algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="number3"></param>
        /// <returns>Greatest common divisor of three numbers</returns>
        public static int StainGcd(int number1, int number2, int number3)
        {
            return CalculateGcd(StainGcd, number1, number2, number3);
        }

        /// <summary>
        /// Calculate greatest common divisor of three numbers by the Stain algorithm with calculation execution time
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="number3"></param>
        /// <param name="executionTime">execution time</param>
        /// <returns>Greatest common divisor of three numbers</returns>
        public static int StainGcd(int number1, int number2, int number3, out long executionTime)
        {
            return ExecutionTimeGcd(StainGcd, number1, number2, number3, out executionTime);
        }

        /// <summary>
        /// Calculate greatest common divisor of more then one number by the Stain algorithm
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Greatest common divisor all numbers</returns>
        public static int StainGcd(params int[] numbers)
        {
            return CalculateGcd(StainGcd, numbers);
        }

        /// <summary>
        /// Calculate greatest common divisor of more then one number by the Stain algorithm with calculation execution time
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="executionTime">execution time</param>
        /// <returns>Greatest common divisor all numbers</returns>
        public static int StainGcd(out long executionTime, params int[] numbers)
        {
            return ExecutionTimeGcd(StainGcd, numbers, out executionTime);
        }

        #endregion // !public Methods

        #region private Methods

        private static bool CheckNumbersForGcd(ref int number1, ref int number2, out int gcd)
        {
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);
            gcd = 0;

            if (number1 == 0 && number2 == 0)
            {
                throw new ArgumentException($"{nameof(number1)} and {nameof(number2)} can't be both zero");
            }

            if (number1 == 0)
            {
                gcd = number2;
            }

            if (number2 == 0)
            {
                gcd = number1;
            }

            if (number1 > 0 && number2 > 0)
            {
                return false;
            }

            return true;
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        ////Comon calculations methods
        private static int CalculateGcd(Func<int, int, int> calculateGcd, int number1, int number2, int number3)
        {
            return calculateGcd(calculateGcd(number1, number2), number3);
        }

        private static int CalculateGcd(Func<int, int, int> calculateGcd, params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException($"{nameof(numbers)} should contains two of more numbers", nameof(numbers));
            }

            int resultGcd = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                resultGcd = calculateGcd(resultGcd, numbers[i]);
            }

            return resultGcd;
        }

        ////Comon methods for calculations and get execution time
        private static int ExecutionTimeGcd(Func<int, int, int> calculateGcd, int number1, int nubmer2, out long executionTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int result = calculateGcd(number1, nubmer2);

            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;

            return result;
        }

        private static int ExecutionTimeGcd(Func<int, int, int> calculateGcd, int number1, int nubmer2, int number3, out long executionTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int result = CalculateGcd(calculateGcd, number1, nubmer2, number3);

            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;

            return result;
        }

        private static int ExecutionTimeGcd(Func<int, int, int> calculateGcd, int[] numbers, out long executionTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int result = CalculateGcd(calculateGcd, numbers);

            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;

            return result;
        }

        #endregion // !private Methods
    }
}
