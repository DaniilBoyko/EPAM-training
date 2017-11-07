using System;

namespace Library.Models.Exceptions
{
    class BookExistException : Exception
    {
        /// <summary>
        /// Create new instance of BookExistException.
        /// </summary>
        /// <param name="message">message of exception</param>
        public BookExistException(string message) : base(message) { }
    }
}
