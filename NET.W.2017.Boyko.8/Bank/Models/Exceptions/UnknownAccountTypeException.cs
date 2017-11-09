//// <copyright file="UnknownAccountTypeException.cs" company="RelCode">Boyko Daniil</copyright>
namespace Bank.Models.Exceptions
{
    using System;

    /// <summary>
    /// Exception for fabric, which create accounts.
    /// </summary>
    public class UnknownAccountTypeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownAccountTypeException"/> class.
        /// </summary>
        /// <param name="message">message of exception</param>
        public UnknownAccountTypeException(string message) : base(message)
        {
        }
    }
}
