//// <copyright file="Account.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models.Accounts
{
    /*
 * Добавить в сервис изменяемую логику генерации номера счета.
 */
    using System;
    using System.Text;
    using Exceptions;

    /// <summary>
    /// Base class for all accounts
    /// </summary>
    [Serializable]
    public abstract class Account
    {
        #region Public

        #region public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        protected Account(string name, string surname) : this(name, surname, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        /// <param name="amount">start amount on the account</param>
        protected Account(string name, string surname, double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} shouldn't bme less the zero.");
            }

            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Surname = surname;
            this.Amount = amount;
            this.Points = 0;
        }

        #endregion

        #region public Properties

        /// <summary>
        /// Gets id of the account.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets name of the owner of the account.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets name of the owner of the account.
        /// </summary>
        public string Surname { get; }

        /// <summary>
        /// Gets amount money on the account.
        /// </summary>
        public double Amount { get; private set; }

        /// <summary>
        /// Gets bonus points of the account.
        /// </summary>
        public int Points { get; private set; }

        #endregion public Properties

        #region public Methods

        /// <summary>
        /// Deposit money to account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>True if OK, false otherwise.</returns>
        public bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"{nameof(amount)} should be more then 0", nameof(amount));
            }

            this.Amount += amount;
            this.Points += this.AddPoints(amount);
            return true;
        }

        /// <summary>
        /// Withdraw money from account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>True if success, false otherwise.</returns>
        public bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"{nameof(amount)} should be more then 0.", nameof(amount));
            }

            if (this.Amount - amount < 0)
            {
                throw new NotEnoughMoneyException("Not enough money on the account.");
            }

            this.Amount -= amount;
            this.Points -= this.SubtractPoints(amount);
            return true;
        }
        
        /// <summary>
        /// Build info about account.
        /// </summary>
        /// <returns>Info in string representation.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Name of owner: {0}\n", this.Name);
            stringBuilder.AppendFormat("Surname of owner: {0}\n", this.Surname);
            stringBuilder.AppendFormat("Amount: {0}\n", this.Amount);
            stringBuilder.AppendFormat("Points: {0}\n", this.Points);
            stringBuilder.AppendFormat("Account type: {0}\n", this.GetAccountType());
            stringBuilder.AppendFormat("Account ID: {0}\n", this.Id);
            return stringBuilder.ToString();
        }

        #endregion public Methods

        #region public Abstract Methods

        /// <summary>
        /// Get type of the Account.
        /// </summary>
        /// <returns>Name of the type.</returns>
        public abstract string GetAccountType();

        #endregion

        #endregion Public

        #region Protected

        /// <summary>
        /// Add points according to amount of money.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Calculated points.</returns>
        protected abstract int AddPoints(double amount);

        /// <summary>
        /// Subtract points according to amount of money.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Calculated points.</returns>
        protected abstract int SubtractPoints(double amount);

        #endregion Proteted
    }
}
