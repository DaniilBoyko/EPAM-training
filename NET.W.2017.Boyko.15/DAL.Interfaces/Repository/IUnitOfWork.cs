using System;

namespace DAL.Interfaces.Repository
{
    /// <summary>
    /// Interface of unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit part of work.
        /// </summary>
        void Commit();
    }
}
