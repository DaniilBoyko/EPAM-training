using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models.Exceptions
{
    class UnknownAccountTypeException : Exception
    {
        /// <summary>
        /// Create an instance of UnknownAccountTypeException.
        /// </summary>
        /// <param name="message">message of exception</param>
        public UnknownAccountTypeException(string message) : base(message) { }
    }
}
