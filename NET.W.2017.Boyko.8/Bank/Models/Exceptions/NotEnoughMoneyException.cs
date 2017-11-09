//// <copyright file="NotEnoughMoneyException.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models.Exceptions
{
    using System;

    /// <summary>
    /// Exception for account, when not enough money for withdraw.
    /// </summary>
    public class NotEnoughMoneyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotEnoughMoneyException"/> class.
        /// </summary>
        /// <param name="message">message of exception</param>
        public NotEnoughMoneyException(string message) : base(message)
        {
        }
    }
}
