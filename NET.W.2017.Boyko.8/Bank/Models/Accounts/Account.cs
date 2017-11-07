using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Models.Exceptions;

namespace Bank.Models
{
    public abstract class Account
    {
        #region Public

        #region public Properties

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public double Amount { get; private set; }
        public int Points { get; private set; }

        #endregion public Properties


        #region public Constructors

        /// <summary>
        /// Create an instance of Account.
        /// </summary>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        public Account(string name, string surname) : this(name, surname, 0) { }

        /// <summary>
        /// Create an instance of Account.
        /// </summary>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        /// <param name="amount">start amount on the account</param>
        public Account(string name, string surname, double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException($"{nameof(amount)} shouldn't bme less the zero.");

            Id = Guid.NewGuid().ToString();
            Name = name;
            Surname = surname;
            Amount = amount;
            Points = 0;
        }

        #endregion


        #region public Methods

        /// <summary>
        /// Deposit money to account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>True if OK, false otherwise.</returns>
        public bool Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException($"{nameof(amount)} should be more then 0", nameof(amount));

            Amount += amount;
            Points += AddPoints(amount);
            return true;
        }

        /// <summary>
        /// Withdraw money from account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns></returns>
        public bool Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException($"{nameof(amount)} should be more then 0.", nameof(amount));
            if (Amount - amount < 0)
                throw new NotEnoughMoneyException("Not enough money on the account.");

            Amount -= amount;
            Points -= SubtractPoints(amount);
            return true;
        }
        
        /// <summary>
        /// Build info about account.
        /// </summary>
        /// <returns>Info in string representation.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Name of owner: {0}\n", Name);
            stringBuilder.AppendFormat("Surname of owner: {0}\n", Surname);
            stringBuilder.AppendFormat("Amount: {0}\n", Amount);
            stringBuilder.AppendFormat("Points: {0}\n", Points);
            stringBuilder.AppendFormat("Points: {0}\n", Points);
            stringBuilder.AppendFormat("Account type: {0}\n", GetAccountType());
            stringBuilder.AppendFormat("Account ID: {0}\n", Id);
            return stringBuilder.ToString();
        }

        #endregion public Methods


        #region public Abstract Methods

        /// <summary>
        /// Get typ of the Account.
        /// </summary>
        /// <returns>Name of the tipe.</returns>
        public abstract string GetAccountType();

        #endregion

        #endregion Public


        #region Protected

        /// <summary>
        /// Add points accordint to amount of money.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Calculated points.</returns>
        protected abstract int AddPoints(double amount);

        /// <summary>
        /// Subtract points accordint to amount of money.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Calculated points.</returns>
        protected abstract int SubtractPoints(double amount);

        #endregion Proteted


    }
}
