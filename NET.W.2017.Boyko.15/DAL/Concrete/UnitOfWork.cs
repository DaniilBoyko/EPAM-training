using System.Data.Entity;
using DAL.Interfaces.Repository;

namespace DAL.Concrete
{
    /// <summary>
    /// Class of unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Initialize the instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">database context</param>
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Gets database context.
        /// </summary>
        public DbContext Context { get; private set; }

        /// <summary>
        /// Dispose <see cref="UnitOfWork"/>
        /// </summary>
        public void Dispose()
        {
            Context?.Dispose();
        }

        /// <inheritdoc></inheritdoc>
        public void Commit()
        {
            Context?.SaveChanges();
        }
    }
}
