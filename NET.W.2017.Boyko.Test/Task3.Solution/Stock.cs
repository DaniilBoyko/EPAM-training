using System;

namespace Task3.Solution
{
    /// <summary>
    /// Model of stock.
    /// </summary>
    /// <typeparam name="T">type of sending data</typeparam>
    public class Stock<T> : IObservable<T> where T : new()
    {
        /// <summary>
        /// Store some info.
        /// </summary>
        private T _info;

        /// <summary>
        /// Store event for observers.
        /// </summary>
        public event EventHandler<T> ChangeInfo;

        /// <summary>
        /// Constructore initialize the instance of the <see cref="Stock{T}"/> class.
        /// </summary>
        public Stock()
        {
            _info = new T();
        }

        ///<inheritdoc></inheritdoc>
        public void Register(Solution.IObserver<T> observer) => ChangeInfo += observer.Update;

        /// <inheritdoc></inheritdoc>
        public void Unregister(Solution.IObserver<T> observer) => ChangeInfo -= observer.Update;

        /// <inheritdoc></inheritdoc>
        public void Notify()
        {
            ChangeInfo(this, _info);
        }

        /// <summary>
        /// Methods for chante info.
        /// </summary>
        /// <param name="newInfo">new info</param>
        public void Market(T newInfo)
        {
            _info = newInfo;
            Notify();
        }
    }
}
