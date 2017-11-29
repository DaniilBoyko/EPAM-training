using System;
using System.Collections.Generic;

namespace Test6.Solution
{
    /// <summary>
    /// Generate sequenced of elements.
    /// </summary>
    /// <typeparam name="T">type of elements</typeparam>
    public class Generator<T>
    {
        /// <summary>
        /// Generate sequence.
        /// </summary>
        /// <param name="x0">first element</param>
        /// <param name="x1">second element</param>
        /// <param name="calculateNext">function for calculate next</param>
        /// <param name="count">count of generating elements</param>
        /// <returns>generating elemens</returns>
        public static IEnumerable<T> Generate(T x0, T x1, Func<T, T, T> calculateNext, int count)
        {
            T prevPrev = x0;
            T prev = x1;

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException($"argument {count} should be more then -1");
            }
  
            yield return x0;
            if (count == 1)
            {
                yield break;
            }

            yield return x1;
            if (count == 2)
            {
                yield break;
            }

            for (int i = 2; i < count; i++)
            {
                T current = calculateNext(prevPrev, prev);
                prevPrev = prev;
                prev = current;
                yield return current;
            }
        }
    }
}
