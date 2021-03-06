﻿//// <copyright file="GoldAccount.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models.Accounts
{
    using System;

    /// <summary>
    /// Account with gold privileges.
    /// </summary>
    [Serializable]
    public class GoldAccount : Account
    {
        #region Public

        #region public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        public GoldAccount(string name, string surname) : base(name, surname)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        /// <param name="amount">start money on the account</param>
        public GoldAccount(string name, string surname, double amount) : base(name, surname, amount)
        {
        }

        #endregion

        #region public Methods

        /// <summary>
        /// Get type of account.
        /// </summary>
        /// <returns>Name of type.</returns>
        public override string GetAccountType()
        {
            return "Gold";
        }

        #endregion public Methods

        #endregion Public

        #region Protected

        /// <summary>
        /// Calculate add points according to amount of money.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Calculating points.</returns>
        protected override int AddPoints(double amount)
        {
            return (int)(amount / 10 * 2);
        }

        /// <summary>
        /// Calculate subtract points according to amount of money.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Calculating points.</returns>
        protected override int SubtractPoints(double amount)
        {
            return (int)(amount / 10 / 3);
        }

        #endregion
    }
}
