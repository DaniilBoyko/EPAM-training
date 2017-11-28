using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class Generator<T>
    {
        T x0;
        T x1;
        private Func<T, T, T> calculateNext;

        public Generator(T x0, T x1, Func<T, T, T> calculateNext)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.calculateNext = calculateNext;
        }

        public IEnumerable<T> Generate(int count)
        {
            T prev_prev = x0;
            T prev = x1;
            if (count <= 0)
                throw new ArgumentOutOfRangeException($"argument {count} should be more then -1");
            if (count == 0)
            {
                yield return default(T);
                yield break;
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
                T current = calculateNext(prev_prev, prev);
                prev_prev = prev;
                prev = current;
                yield return current;
            }
        }
    }
}
