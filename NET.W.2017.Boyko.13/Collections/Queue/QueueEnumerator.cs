using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public partial class Queue<T>
    { 
        private sealed class QueueEnumerator : IEnumerator<T>
        {
            #region private Fields

            private readonly Queue<T> _queue;
            private int _index;
            private int _version;
            private T _currentElement;

            #endregion // !private Fields

            #region internal Constructors

            /// <summary>
            /// Constructor initialize the instance of the <see cref="QueueEnumerator"/> class.
            /// </summary>
            /// <param name="queue">queue</param>
            internal QueueEnumerator(Queue<T> queue)
            {
                _queue = queue;
                _version = _queue._version;
                _index = 0;
                if (_queue._size == 0)
                {
                    _index = -1;
                }
            }

            #endregion // !internal Constructors

            #region public Properties

            /// <summary>
            /// Get current element.
            /// </summary>
            public T Current
            {
                get
                {
                    CheckVersion();

                    if (_queue._array.Length == 0)
                    {
                        throw new InvalidOperationException("Queue has no elements.");
                    }

                    if (_index < 0)
                    {
                        return _queue.GetElement(_queue._size - 1);
                    }

                    return _currentElement;
                }
            }

            /// <inheritdoc />
            /// <summary>
            /// Get current element.
            /// </summary>
            object IEnumerator.Current
            {
                get;
            }
            
            #endregion // !public Properties

            #region public Methods

            /// <summary>
            /// Get next element of the queue.
            /// </summary>
            /// <returns>Return true if has next element, false otherwise.</returns>
            public bool MoveNext()
            {
                CheckVersion();

                if (_index < 0)
                {
                    return false;
                }

                _currentElement = _queue.GetElement(_index);
                _index++;

                if (_index == _queue._size)
                {
                    _index = -1;
                }

                return true;
            }

            /// <summary>
            /// Reset enumerator.
            /// </summary>
            public void Reset()
            {
                CheckVersion();
                if (_queue._size == 0)
                {
                    _index = -1;
                }
                else
                {
                    _index = 0;
                }
            }

            /// <summary>
            /// Dispose instance of <see cref="QueueEnumerator"/> class
            /// </summary>
            public void Dispose()
            {
            }

            #endregion // !public Methods

            #region private Methods

            private void CheckVersion()
            {
                if (_version != _queue._version)
                {
                    throw new InvalidOperationException("The queue was changed.");
                }
            }

            #endregion // private Methods
        }
    }
}
