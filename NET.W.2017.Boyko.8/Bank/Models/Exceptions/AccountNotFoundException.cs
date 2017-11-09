//// <copyright file="AccountNotFoundException.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models.Exceptions
{
    using System;

    /// <summary>
    /// Exception for bank service, when account not found.
    /// </summary>
    public class AccountNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountNotFoundException"/> class.
        /// </summary>
        /// <param name="message">message of exception</param>
        public AccountNotFoundException(string message) : base(message)
        {
        }
    }
}
