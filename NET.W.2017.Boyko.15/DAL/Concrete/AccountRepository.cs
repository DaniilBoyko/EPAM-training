using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    /// <summary>
    /// Repository for accounts.
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// Context of database.
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// Initialize the instance of the account repository.
        /// </summary>
        /// <param name="context">database context</param>
        public AccountRepository(DbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc></inheritdoc>
        public IEnumerable<DalAccount> GetAll()
        {
            return _context.Set<OrmAccount>().Select(account => account.ToDalAccount());
        }

        /// <inheritdoc></inheritdoc>
        public DalAccount GetById(string id)
        {
            var ormAccount = _context.Set<OrmAccount>().FirstOrDefault(account => account.Id == id);
            return ormAccount.ToDalAccount();
        }

        /// <inheritdoc></inheritdoc>
        public DalAccount GetByPredicate(Predicate<DalAccount> predicate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc></inheritdoc>
        public void Create(DalAccount dalAccount)
        {
            var account = dalAccount.ToOrmAccount();
            _context.Set<OrmAccount>().Add(account);
        }

        /// <inheritdoc></inheritdoc>
        public void Delete(DalAccount dalAccount)
        {
            var account = dalAccount.ToOrmAccount();
            account = _context.Set<OrmAccount>().Single(acc => acc.Id == account.Id);
            _context.Set<OrmAccount>().Remove(account);
        }

        /// <inheritdoc></inheritdoc>
        public void Update(DalAccount entity)
        {
            Delete(entity);
            Create(entity);
        }
    }
}
