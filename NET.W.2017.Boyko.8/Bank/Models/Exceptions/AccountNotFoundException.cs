using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models.Exceptions
{
    class AccountNotFoundException : Exception
    {
        /// <summary>
        /// Create new instance of AccountNotFoundException
        /// </summary>
        /// <param name="message">message of exception</param>
        public AccountNotFoundException(string message) : base(message) { }
    }
}
