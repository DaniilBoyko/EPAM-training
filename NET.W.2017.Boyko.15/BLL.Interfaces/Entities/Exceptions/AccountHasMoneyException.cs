using System;

namespace BLL.Interfaces.Entities.Exceptions
{
    /// <summary>
    /// Exception for delete account, when it has money.
    /// </summary>
    public class AccountHasMoneyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHasMoneyException"/> class.
        /// </summary>
        /// <param name="message">message of exception</param>
        public AccountHasMoneyException(string message) : base(message)
        {
        }
    }
}
