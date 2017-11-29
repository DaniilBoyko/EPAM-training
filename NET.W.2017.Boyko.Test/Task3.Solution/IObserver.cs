namespace Task3.Solution
{
    /// <summary>
    /// Interface for models, which can bs observer.
    /// </summary>
    /// <typeparam name="T">type of the sending data</typeparam>
    public interface IObserver<T>
    {
        /// <summary>
        /// Call on observer, when observable send message.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="data">sending data</param>
        void Update(object sender, T data);
    }
}
