namespace Task3.Solution
{
    /// <summary>
    /// Interface for observable models.
    /// </summary>
    /// <typeparam name="T">type of the sending data</typeparam>
    public interface IObservable<T>
    {
        /// <summary>
        /// Register new observer.
        /// </summary>
        /// <param name="observer">observer</param>
        void Register(IObserver<T> observer);

        /// <summary>
        /// Unregister observer.
        /// </summary>
        /// <param name="observer">observer</param>
        void Unregister(IObserver<T> observer);

        /// <summary>
        /// Notify all observers.
        /// </summary>
        void Notify();
    }
}
