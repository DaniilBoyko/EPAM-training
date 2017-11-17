using System;

/*
 * Использовать BigInteger
 * Локальная функция 
 * Итератор
 * Выносить метод проверки аргументов в отдельный метод, т. е. сделать обертку для того, чтобы проверка аргументов была не ленивой
 * А лучше вынести во вложенную функцию.
 * 
 * */

namespace Fibonacci
{
    /// <summary>
    /// Contains methods for getting fibonacci numbers.
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Get one number of fibonacci sequence.
        /// </summary>
        /// <param name="index">number of element in sequence</param>
        /// <returns>Number of fibonacci sequence.</returns>
        public static long GetNumber(int index)
        {
            if (index <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(index)} should be more then 0");
            }

            if (index == 1 || index == 2)
            {
                return 1;
            }

            long[] prevNumbers = { 1, 1 };

            for (int i = 2; i < index; i++)
            {
                long temp = prevNumbers[1];
                prevNumbers[1] = prevNumbers[0] + prevNumbers[1];
                prevNumbers[0] = temp;
            }

            return prevNumbers[1];
        }

        /// <summary>
        /// Get sequence of fibonacci sequence.
        /// </summary>
        /// <param name="index">the greatest number of element in fibonacci sequence</param>
        /// <returns>Sequence of fibonacci sequence.</returns>
        public static long[] GetSequence(int index)
        {
            if (index <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(index)} should be more then 0");
            }

            if (index == 1)
            {
                return new long[] { 1 };
            }

            if (index == 2)
            {
                return new long[] { 1, 1 };
            }

            long[] numbers = new long[index];
            numbers[0] = 1;
            numbers[1] = 1;
            for (int i = 2; i < index; i++)
            {
                numbers[i] = numbers[i - 1] + numbers[i - 2];
            }

            return numbers;
        }
    }
}
