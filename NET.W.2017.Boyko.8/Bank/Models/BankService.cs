//// <copyright file="BankService.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models
{
    /*
 * - Обязательная зависимость - в конструкторе
 * - Необязательная зависимость просто как параметр метода, здесь лучше как необзательную зависисмость сделать.
 * - Можно убрать лист и работать только с одним счетом.
 */
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Accounts;
    using Exceptions;
    using Interfaces;

    /// <summary>
    /// Class for manipulation bank accounts.
    /// </summary>
    public class BankService
    {
        #region Private

        #region private Properties

        /// <summary>
        /// Gets or sets list of accounts.
        /// </summary>
        private List<Account> Accounts { get; set; }

        /// <summary>
        /// Gets or sets bank storage.
        /// </summary>
        private IBankStorage BankStorage { get; set; }

        /// <summary>
        /// Gets or sets current account.
        /// </summary>
        private Account CurrentAccount { get; set; }

        #endregion

        #endregion

        #region Public 

        #region public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class.
        /// </summary>
        /// <param name="fileWorker">contains methods of save and load accounts</param>
        public BankService(IBankStorage fileWorker)
        {
            this.Accounts = new List<Account>();
            this.BankStorage = fileWorker ?? throw new ArgumentNullException(nameof(fileWorker));
        }

        #endregion

        #region public Methods

        /// <summary>
        /// Load accounts from file.
        /// </summary>
        /// <param name="path">path to file</param>
        public void LoadAccountsFromFile(string path)
        {
            this.Accounts = this.BankStorage.LoadAccounts(path).ToList();
        }

        /// <summary>
        /// Save accounts to file.
        /// </summary>
        /// <param name="path">path to file</param>
        public void SaveAccountsToFile(string path)
        {
            this.BankStorage.SaveAccounts(this.Accounts, path);
        }

        /// <summary>
        /// Deposit to current account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>True if success, false otherwise.</returns>
        public bool DepositToCurrentAccount(double amount)
        {
            if (this.CurrentAccount == null)
            {
                throw new AccountNotSelectedException("Current account not selected. Please, select current account.");
            }

            if (this.CurrentAccount.Deposit(amount))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Withdraw money from current account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>True if success, false otherwise.</returns>
        public bool WithdrawFromCurrentAccount(double amount)
        {
            if (this.CurrentAccount == null)
            {
                throw new AccountNotSelectedException("Current account not selected. Please, select current account.");
            }

            if (this.CurrentAccount.Withdraw(amount))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Create new account.
        /// </summary>
        /// <param name="accountType">type of account</param>
        /// <param name="name">name of owner</param>
        /// <param name="surname">surname of owner</param>
        /// <param name="amount">start amount of money</param>
        public void CreateNewAccount(AccountCreator.AccountType accountType, string name, string surname, double amount = 0)
        {
            Account account = AccountCreator.CreateAccount(accountType, name, surname, amount);
            this.Accounts.Add(account);
            this.CurrentAccount = account;
        }

        /// <summary>
        /// Close current account.
        /// </summary>
        public void CloseCurrentAccount()
        {
            if (this.CurrentAccount.Amount > 0)
            {
                throw new AccountHasMoneyException("Current account has money. Please withdraw money.");
            }

            this.Accounts.Remove(this.CurrentAccount);
            this.CurrentAccount = null;
        }

        /// <summary>
        /// Show current account info.
        /// </summary>
        public void ShowCurrentAccountInfo()
        {
            if (this.CurrentAccount == null)
            { 
                throw new AccountNotSelectedException("Current account not selected. Please, select current account.");
            }

            Console.WriteLine(this.CurrentAccount);
        }

        /// <summary>
        /// Select current account.
        /// </summary>
        /// <param name="id">id of bank account</param>
        /// <param name="name">name of owner of bank account</param>
        /// <param name="surname">surname of owner of bank account</param>
        public void SelectCurrentAccount(string id, string name, string surname)
        {
            Account account = null;
            foreach (Account act in this.Accounts)
            {
                if (act.Id.Equals(id) && act.Name.Equals(name) && act.Surname.Equals(surname))
                {
                    account = act;
                    break;
                }
            }

            this.CurrentAccount = account ?? throw new AccountNotFoundException("Account not found.");
        }

        #endregion public Methods
        
        #endregion Public
    }
}
