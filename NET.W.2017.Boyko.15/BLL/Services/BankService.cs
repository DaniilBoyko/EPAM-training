using System;
using System.Collections.Generic;
using BLL.Interfaces;
using BLL.Interfaces.Entities.Account;
using BLL.Interfaces.Entities.Exceptions;
using BLL.Interfaces.Services;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces.Repository;
using System.Linq;

namespace BLL.Services
{
    /// <summary>
    /// Class for manipulation with bank accounts.
    /// </summary>
    public class BankService : IAccountService
    {
        #region public Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="accountRepository">contains methods for manipulate with accounts</param>
        public BankService(IUnitOfWork unitOfWork, IAccountRepository accountRepository) 
            : this(unitOfWork, accountRepository, new GenerateId())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class
        /// </summary>
        /// <param name="unitOfWork">contains methods for commit after solve unit of work</param>
        /// <param name="accountRepository">repository for accounts</param>
        /// <param name="generateId">contains method for generate id</param>
        public BankService(IUnitOfWork unitOfWork, IAccountRepository accountRepository, IGenerateId generateId)
        {
            AccountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            GenerateId = generateId ?? throw new ArgumentNullException(nameof(generateId));
        }
        #endregion

        #region private Properties
        /// <summary>
        /// Gets account repository.
        /// </summary>
        private IAccountRepository AccountRepository { get; }

        /// <summary>
        /// Gets unit of work.
        /// </summary>
        private IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Gets or sets current account.
        /// </summary>
        private Account CurrentAccount { get; set; }

        /// <summary>
        /// Gets id generator.
        /// </summary>
        private IGenerateId GenerateId { get; }
        #endregion // !private Properties

        #region public Methods
        /// <summary>
        /// Deposit to current account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>True if success, false otherwise.</returns>
        public bool DepositToAccount(double amount)
        {
            if (CurrentAccount == null)
            {
                throw new AccountNotSelectedException("Account not selected. Please, select account.");
            }

            if (CurrentAccount.Deposit(amount))
            {
                AccountRepository.Update(CurrentAccount.ToDalAccount());
                UnitOfWork.Commit();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Withdraw money from current account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>True if success, false otherwise.</returns>
        public bool WithdrawFromAccount(double amount)
        {
            if (CurrentAccount == null)
            {
                throw new AccountNotSelectedException("Account not selected. Please, select account.");
            }

            if (CurrentAccount.Withdraw(amount))
            {
                AccountRepository.Update(CurrentAccount.ToDalAccount());
                UnitOfWork.Commit();
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
        public void CreateNewAccount(string accountType, string name, string surname, double amount = 0)
        {
            Account account = AccountCreator.CreateAccount(accountType, GenerateId.Generate(), name, surname, amount);
            AccountRepository.Create(account.ToDalAccount());
            UnitOfWork.Commit();
            CurrentAccount = account;
        }


        /// <summary>
        /// Delete Account
        /// </summary>
        /// <exception cref="AccountHasMoneyException">When account has money</exception>
        public void DeleteAccount()
        {
            if (CurrentAccount.Amount > 0)
            {
                throw new AccountHasMoneyException("Account has money. Please withdraw money.");
            }

            AccountRepository.Delete(CurrentAccount.ToDalAccount());
            UnitOfWork.Commit();
            CurrentAccount = null;
        }

        /// <summary>
        /// Show current account info.
        /// </summary>
        public void ShowAccountInfo()
        {
            if (CurrentAccount == null)
            {
                throw new AccountNotSelectedException("Account not selected. Please, select account.");
            }

            Console.WriteLine(CurrentAccount);
        }

        /// <summary>
        /// Select current account.
        /// </summary>
        /// <param name="id">id of bank account</param>
        public void SelectAccount(string id)
        {
            Account account = AccountRepository.GetById(id)?.ToBllAccount();
            CurrentAccount = account ?? throw new AccountNotFoundException("Account not found.");
        }

        public List<Account> SelectAll(string name, string surname)
        {
            List<Account> accounts = AccountRepository.GetAll(name, surname)?.Select(ac => ac.ToBllAccount()).ToList();
            return accounts;
        }
        #endregion // !public Methods
    }
}
