using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models.Exceptions
{
    class AccountHasMoneyException : Exception
    {
        /// <summary>
        /// Create an instance of AccountHasMoneyException
        /// </summary>
        /// <param name="message">message of exception</param>
        public AccountHasMoneyException(string message) : base(message) { }
    }
}
