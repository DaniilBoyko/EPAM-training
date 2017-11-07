using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models.Exceptions
{
    class AccountNotSelectedException : Exception
    {
        /// <summary>
        /// Create an instance of AccountNotSelectedAxception.
        /// </summary>
        /// <param name="message">message of exception</param>
        public AccountNotSelectedException(string message) : base(message) { }
    }
}
