using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;

namespace BLL.Tests.Fakes
{
    public class FakeAccountRepository : IAccountRepository
    {
        public readonly List<DalAccount> Accounts = new List<DalAccount>();

        public IEnumerable<DalAccount> GetAll()
        {
            foreach (var account in Accounts)
            {
                yield return account;
            }
        }

        public DalAccount GetById(string id)
        {
            foreach (var account in Accounts)
            {
                if (account.Id.Equals(id))
                {
                    return account;
                }
            }

            return null;
        }

        public DalAccount GetByPredicate(Predicate<DalAccount> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(DalAccount dalAccount)
        {
            Accounts.Add(dalAccount);
        }

        public void Delete(DalAccount dalAccount)
        {
            DalAccount deleteAccount = GetById(dalAccount.Id);
            if (deleteAccount == null)
            {
                return;
            }

            Accounts.Remove(deleteAccount);
        }

        public void Update(DalAccount dalAccount)
        {
            foreach (var account in Accounts)
            {
                if (!account.Id.Equals(dalAccount.Id))
                {
                    continue;
                }

                account.Name = dalAccount.Name;
                account.Surname = dalAccount.Surname;
                account.Amount = dalAccount.Amount;
                account.Points = dalAccount.Points;
            }
        }
    }
}
