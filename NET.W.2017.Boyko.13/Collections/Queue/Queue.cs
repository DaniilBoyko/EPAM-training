using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections.Queue
{
    /// <summary>
    /// Model of the queue.
    /// </summary>
    /// <typeparam name="T">type of element of the queue</typeparam>
    public partial class Queue<T>
    {
        #region private Constants

        private const int MinimumGrow = 4;
        private const int StandartCapacity = 32;
        private const float StandartGrowFactor = 2.0f;
        private const float MinGrowFactor = 1.0f;
        private const float MaxGrowFactor = 10.0f;

        #endregion // !private Constans

        #region private Fields

        /// <summary>
        /// Store elements of the queue
        /// </summary>
        private T[] _array;

        /// <summary>
        /// First valid element of the queue.
        /// </summary>
        private int _head;

        /// <summary>
        /// Last valid element of the queue.
        /// </summary>
        private int _tail;

        /// <summary>
        /// Number of elements.
        /// </summary>
        private int _size;

        /// <summary>
        /// 100 = 1.0, 130 = 1.3, 200 = 2.0
        /// </summary>
        private int _growFactor;

        /// <summary>
        /// Version of the queue;
        /// </summary>
        private int _version;

        #endregion // !private Fields

        #region public Constructors

        /// <summary>
        /// Constructor initialize the instance of the <see cref="Queue{T}"/> class default values of
        /// capacity and growFactor.
        /// </summary>
        public Queue() : this(StandartCapacity, StandartGrowFactor)
        {
        }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="Queue{T}"/> class default value of grow factor.
        /// </summary>
        /// <param name="capacity">capacity of the start queue</param>
        public Queue(int capacity) : this(capacity, StandartGrowFactor)
        {
        }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="capacity">capacity of the start queue</param>
        /// <param name="growFactor">factor of grow capacity</param>
        public Queue(int capacity, float growFactor)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)} should be more then 0 or equals", nameof(capacity));
            }

            if (growFactor < MinGrowFactor || growFactor > MaxGrowFactor)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)} should be between (1.0, 10.0)", nameof(growFactor));
            }

            _array = new T[capacity];
            _head = 0;
            _tail = 0;
            _size = 0;
            _growFactor = (int)(growFactor * 100);
        }

        /// <summary>
        /// Constructor fills <see cref="Queue{T}"/> with the elements
        /// of an ICollection.
        /// </summary>
        /// <param name="collection"></param>
        public Queue(IEnumerable<T> collection) : this(collection?.Count() ?? StandartCapacity)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var element in collection)
            {
                Enqueue(element);
            }
        }

        #endregion // !public Constructors
            
        #region public Properties

        /// <summary>
        /// Get count of elements in queue.
        /// </summary>
        public int Count => _size;

        #endregion // !public Properties

        #region public Methods

        /// <summary>
        /// Clear queue.
        /// </summary>
        public void Clear()
        {
            if (_head < _tail)
            {
                Array.Clear(_array, _head, _size);
            }
            else
            {
                Array.Clear(_array, _head, _array.Length - _head);
                Array.Clear(_array, 0, _tail);
            }

            _head = 0;
            _tail = 0;
            _size = 0;
            _version++;
        }

        /// <summary>
        /// Add element to the tail of the queue.
        /// </summary>
        /// <param name="element">adding element</param>
        public void Enqueue(T element)
        {
            if (_size == _array.Length)
            {
                int newcapacity = (int)((long)_array.Length * (long)_growFactor / 100);
                if (newcapacity < _array.Length + MinimumGrow)
                {
                    newcapacity = _array.Length + MinimumGrow;
                }

                SetCapacity(newcapacity);
            }

            _array[_tail] = element;
            _tail = (_tail + 1) % _array.Length;
            _size++;
            _version++;
        }

        /// <summary>
        /// Remove element from the head of the queue and returns it.
        /// </summary>
        /// <returns>Removed element.</returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue has no elements.");
            }

            T removed = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % _array.Length;
            _size--;
            _version++;

            return removed;
        }

        /// <summary>
        /// Returns the element at the head of the queue.
        /// The element remains in the queue.
        /// </summary>
        /// <returns>Element at the head of the queue.</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue has no elements.");
            }

            return _array[_head];
        }

        /// <summary>
        /// Check if queue contains element.
        /// </summary>
        /// <param name="element">checking element</param>
        /// <returns>True if queue contains element, false otherwise.</returns>
        public bool Contains(T element)
        {
            int index = _head;
            int count = _size;

            while (count-- > 0)
            {
                if (_array[index].Equals(element))
                {
                    return true;
                }

                index = (index + 1) % _array.Length;
            }

            return false;
        }

        /// <summary>
        /// Get enumerator of the queue.
        /// </summary>
        /// <returns>Enumerator of the queue.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        #endregion // !public Methods

        #region private internal Methods

        /// <summary>
        /// Get element a index from head.
        /// </summary>
        /// <param name="index">index from head</param>
        /// <returns>Element of the queue.</returns>
        internal T GetElement(int index)
        {
            return _array[(_head + index) % _array.Length];
        }

        /// <summary>
        /// Grows the buffer to hold capacity elements.
        /// Capacity must be >= _size.
        /// </summary>
        /// <param name="capacity"></param>
        private void SetCapacity(int capacity)
        {
            T[] newarray = new T[capacity];
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_array, 0, newarray, 0, _size);
                }
                else
                {
                    Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
                    Array.Copy(_array, 0, newarray, _array.Length - _head, _tail);
                }
            }

            _array = newarray;
            _head = 0;
            _tail = (_size == capacity) ? 0 : _size;
            _version++;
        }

        #endregion // !private internal Methods
    }
}
