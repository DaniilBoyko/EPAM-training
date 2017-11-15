using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public static class Fibonacci
    {
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

            long[] prevNumbers = new long[] {1, 1};

            for (int i = 2; i < index; i++)
            {
                long temp = prevNumbers[1];
                prevNumbers[1] = prevNumbers[0] + prevNumbers[1];
                prevNumbers[0] = temp;
            }

            return prevNumbers[1];
        }

        public static long[] GetSequence(int index)
        {
            if (index <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(index)} should be more then 0");
            }

            if (index == 1)
            {
                return new long[] {1};
            }

            if (index == 2)
            {
                return new long[] {1, 1};
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
