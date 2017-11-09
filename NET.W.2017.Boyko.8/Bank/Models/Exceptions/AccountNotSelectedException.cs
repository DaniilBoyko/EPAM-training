//// <copyright file="AccountNotSelectedException.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models.Exceptions
{
    using System;

    /// <summary>
    /// Exception of bank service, when account not selected.
    /// </summary>
    public class AccountNotSelectedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountNotSelectedException"/> class.
        /// </summary>
        /// <param name="message">message of exception</param>
        public AccountNotSelectedException(string message) : base(message)
        {
        }
    }
}
