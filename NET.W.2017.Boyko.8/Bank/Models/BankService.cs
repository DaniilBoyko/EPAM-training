using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Models.Interfaces;
using Bank.Models.Exceptions;

namespace Bank.Models
{
    class BankService
    {
        #region Public 

        #region public Constructors

        /// <summary>
        /// Create an instance of BankService.
        /// </summary>
        /// <param name="fileWorker">contains methods of save and load accounts</param>
        public BankService(IFileWorker fileWorker)
        {
            if (fileWorker == null)
                throw new ArgumentNullException(nameof(fileWorker));
            FileWorker = fileWorker;
        }

        #endregion


        #region public Methods

        /// <summary>
        /// Load accounts from file.
        /// </summary>
        /// <param name="path">path to file</param>
        public void LoadAccountsFromFile(string path)
        {
            Accounts = FileWorker.LoadAccountsFromFile(path);
        }

        /// <summary>
        /// Save accounts to file.
        /// </summary>
        /// <param name="path">path to file</param>
        public void SaveAccountsToFile(string path)
        {
            FileWorker.SaveAccountsToFile(Accounts, path);
        }
        
        /// <summary>
        /// Deposit to current account.
        /// </summary>
        /// <param name="amount">amount of monety</param>
        public bool DepositToCurrentAccount(double amount)
        {
            if (CurrentAccount == null)
                throw new AccountNotSelectedException("Current account not selected. Please, select current account.");
            if (CurrentAccount.Deposit(amount))
                return true;
            return false;
        }

        /// <summary>
        /// Withdraw money from current account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        public bool WithdrawFromCurrentAccount(double amount)
        {
            if (CurrentAccount == null)
                throw new AccountNotSelectedException("Current account not selected. Please, select current account.");
            if (CurrentAccount.Withdraw(amount))
                return true;
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
            Accounts.Add(account);
            CurrentAccount = account;

        }

        /// <summary>
        /// Close current account.
        /// </summary>
        public void CloseCurrentAccount()
        {
            if (CurrentAccount.Amount > 0)
                throw new AccountHasMoneyException("Current account not selected. Please, select current account.");
            Accounts.Remove(CurrentAccount);
            CurrentAccount = null;
        }

        /// <summary>
        /// Show current account info.
        /// </summary>
        public void ShowCurrentAccountInfo()
        {
            if (CurrentAccount == null)
                throw new AccountNotSelectedException("Current account not selected. Please, select current account.");
            Console.WriteLine(CurrentAccount);
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
            foreach (Account act in Accounts)
            {
                if (act.Id.Equals(id) && act.Name.Equals(name) && act.Surname.Equals(surname))
                {
                    account = act;
                    break;
                }
            }
            if (account == null)
                throw new AccountNotFoundException("Account not found.");
            CurrentAccount = account;
        }

        #endregion public Methods


        #endregion Public


        #region Private

        #region private Properties

        private List<Account> Accounts { get; set; }
        private IFileWorker FileWorker { get; set; }
        private Account CurrentAccount { get; set; }

        #endregion

        #endregion
    }
}
