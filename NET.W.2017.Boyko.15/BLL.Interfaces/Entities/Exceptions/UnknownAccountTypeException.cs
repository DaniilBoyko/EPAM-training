using System;

namespace BLL.Interfaces.Entities.Exceptions
{
    /// <summary>
    /// Exception for fabric, which create account with unknown type.
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
