//// <copyright file="AccountCreator.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models
{
    using Accounts;
    using Exceptions;

    /// <summary>
    /// Class for create an instance of classes: BaseAccount, GoldAccount, PlatinumAccount
    /// </summary>
    public static class AccountCreator
    {
        /// <summary>
        /// Contains account types.
        /// </summary>
        public enum AccountType
        {
            /// <summary>
            /// Base account type.
            /// </summary>
            Base,

            /// <summary>
            /// Gold account type.
            /// </summary>
            Gold,

            /// <summary>
            /// Platinum account type.
            /// </summary>
            Platinum
        }

        /// <summary>
        /// Create an instance of account
        /// </summary>
        /// <param name="accountType">type of account</param>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        /// <param name="amount">start amount of money on account</param>
        /// <returns>An instance of account.</returns>
        public static Account CreateAccount(AccountType accountType, string name, string surname, double amount = 0)
        {
            switch (accountType)
            {
                case AccountType.Base: return new BaseAccount(name, surname, amount);
                case AccountType.Gold: return new GoldAccount(name, surname, amount);
                case AccountType.Platinum: return new PlatinumAccount(name, surname, amount);
                default: throw new UnknownAccountTypeException("Unknown account type");
            }
        }

        /// <summary>
        /// Create an instance of account
        /// </summary>
        /// <param name="accountType">type of account</param>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        /// <param name="amount">start amount of money on account</param>
        /// <returns>An instance of account.</returns>
        public static Account CreateAccount(string accountType, string name, string surname, double amount = 0)
        {
            switch (accountType)
            {
                case "Base": return CreateAccount(AccountType.Base, name, surname, amount);
                case "Gold": return CreateAccount(AccountType.Base, name, surname, amount);
                case "Platinum": return CreateAccount(AccountType.Base, name, surname, amount);
                default: throw new UnknownAccountTypeException("Unknown account type");
            }
        }
    }
}
