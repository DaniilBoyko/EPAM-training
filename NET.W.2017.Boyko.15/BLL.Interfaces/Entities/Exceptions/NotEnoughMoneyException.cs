using System;

namespace BLL.Interfaces.Entities.Exceptions
{
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
