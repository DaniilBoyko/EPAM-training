using DAL.Interfaces.DTO;
using ORM;

namespace DAL.Mappers
{
    /// <summary>
    /// Class for mapping object relational account and data access layer.
    /// </summary>
    public static class OrmEntityMappers
    {
        /// <summary>
        /// Convert data access layer account to object relational account.
        /// </summary>
        /// <param name="dalAccount">data access layer account</param>
        /// <returns>Object relation account.</returns>
        public static OrmAccount ToOrmAccount(this DalAccount dalAccount)
        {
            return new OrmAccount()
            {
                Id = dalAccount.Id,
                Name = dalAccount.Name,
                Surname = dalAccount.Surname,
                Amount = dalAccount.Amount,
                Points = dalAccount.Points,
                Type = dalAccount.Type
            };
        }

        /// <summary>
        /// Convert object relation account to data access layer account.
        /// </summary>
        /// <param name="ormAccount">object relation account</param>
        /// <returns>Data access layer account.</returns>
        public static DalAccount ToDalAccount(this OrmAccount ormAccount)
        {
            return new DalAccount()
            {
                Id = ormAccount.Id,
                Name = ormAccount.Name,
                Surname = ormAccount.Surname,
                Amount = ormAccount.Amount,
                Points = ormAccount.Points,
                Type = ormAccount.Type
            };
        }
    }
}
