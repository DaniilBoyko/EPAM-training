using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using collect = Collections;

namespace Collections.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [TestCase(new int[] { 1, 2, 4, -1, 7 }, 1, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 4, -1, 7 }, 2, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 4, -1, 7 }, 3, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 4, -1, 7 }, 6, ExpectedException = typeof(InvalidOperationException))]
        [TestCase(new int[] { 1, 2 }, 1, ExpectedResult = 1)]
        [TestCase(new int[] { }, 1, ExpectedException = typeof(InvalidOperationException))]
        public int DequeueMethod_EnqueueElementFromQueue(int[] array, int count)
        {
            Queue.Queue<int> queue = new Queue.Queue<int>(array);
            while (count-- > 1)
            {
                queue.Dequeue();
            }

            return queue.Dequeue();
        }

        [TestCase(new int[] { 1, 2, 4, -1, 7 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 1)]
        [TestCase(new int[] { }, ExpectedException = typeof(InvalidOperationException))]
        public int PeekMethod_PeekElementFromHeadQueue(int[] array)
        {
            Queue.Queue<int> queue = new Queue.Queue<int>(array);
            return queue.Peek();
        }

        [TestCase(new int[] { 1, 2, 4, -1, 7, 5, 5, 3, 1, 3, 999 }, ExpectedResult = 999)]
        [TestCase(new int[] { 1, 2, 4, -1, 7, 3, 1, 3, 999 }, ExpectedResult = 999)]
        [TestCase(new int[] { 1, 2, 3, 999 }, ExpectedResult = 999)]
        [TestCase(new int[] { }, ExpectedException = typeof(InvalidOperationException))]
        public int EnqueueMethod_EnqueueElementFromToQueueAndGetLast(int[] array)
        {
            Queue.Queue<int> queue = new Queue.Queue<int>();
            foreach (var element in array)
            {
                queue.Enqueue(element);
            }

            int count = array.Length;
            while (count-- > 1)
            {
                queue.Dequeue();
            }

            return queue.Dequeue();
        }

        [TestCase(new int[] { 1, 2, 4 }, ExpectedResult = "124")]
        [TestCase(new int[] { }, ExpectedResult = "")]
        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(new int[] { 2, 4, 5, 6, 7, 8, 9, 19, 234 }, ExpectedResult = "245678919234")]
        public string GetEnumeratorMethod_EnumerateElementsOfTheQueue(int[] array)
        {
            Queue.Queue<int> queue = new Queue.Queue<int>(array);
            StringBuilder builder = new StringBuilder();
            foreach (var element in queue)
            {
                builder.Append(element.ToString());
            }

            return builder.ToString();
        }

        [TestCase(new int[] { 2, 4, 5, 6 }, 1, ExpectedException = typeof(InvalidOperationException))]
        public void GetEnumeratorMethod_EnumerateElementsOfTheQueueIfChange(int[] array, int value)
        {
            Queue.Queue<int> queue = new Queue.Queue<int>(array);
            IEnumerator<int> enumerator = queue.GetEnumerator();
            enumerator.MoveNext();
            queue.Enqueue(value);
            int current = enumerator.Current;
            enumerator.Dispose();
        }
    }
}
