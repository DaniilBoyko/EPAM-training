namespace Task1.Solution
{
    /// <summary>
    /// Interface for repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Create password
        /// </summary>
        /// <param name="password">password</param>
        void Create(string password);
    }
}
