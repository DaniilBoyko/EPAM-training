using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models.Exceptions
{
    class NotEnoughMoneyException : Exception
    {
        /// <summary>
        /// Create an instance of NotEnoughMoneyException
        /// </summary>
        /// <param name="message">message of exception</param>
        public NotEnoughMoneyException(string message) : base(message) { }
    }
}
