//// <copyright file="IBankStorage.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models.Interfaces
{
    using System.Collections.Generic;
    using Accounts;

    /// <summary>
    /// Interface for load and save accounts.
    /// </summary>
    public interface IBankStorage
    {
        /// <summary>
        /// Load accounts.
        /// </summary>
        /// <param name="path">path to storage</param>
        /// <returns>Enumerable of accounts.</returns>
        IEnumerable<Account> LoadAccounts(string path);

        /// <summary>
        /// Save accounts.
        /// </summary>
        /// <param name="accounts">enumerable of accounts</param>
        /// <param name="path">path to storage</param>
        void SaveAccounts(IEnumerable<Account> accounts, string path);
    }
}
