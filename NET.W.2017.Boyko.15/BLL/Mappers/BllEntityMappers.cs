using BLL.Interfaces.Entities.Account;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Class for mapping account and data access layer account.
    /// </summary>
    public static class BllEntityMappers
    {
        /// <summary>
        /// Convert account to data access layer account 
        /// </summary>
        /// <param name="account">account</param>
        /// <returns>Data access layer account.</returns>
        public static DalAccount ToDalAccount(this Account account)
        {
            return new DalAccount()
            {
                Id = account.Id,
                Name = account.Name,
                Surname = account.Surname,
                Amount = account.Amount,
                Points = account.Points,
                Type = account.GetAccountType()
            };
        }

        /// <summary>
        /// Convert data access layer account to account
        /// </summary>
        /// <param name="dalAccount">data access layer</param>
        /// <returns>Account.</returns>
        public static Account ToBllAccount(this DalAccount dalAccount)
        {
            return AccountCreator.CreateAccount(dalAccount.Type, dalAccount.Id, dalAccount.Name, dalAccount.Surname, dalAccount.Amount, dalAccount.Points);
        }
    }
}
