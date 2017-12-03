using System;

namespace URL_Parser.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// Exception for invalid url.
    /// </summary>
    public class InvalidUrlException : Exception
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructor initialize the instance of the <see cref="T:URL_Parser.Exceptions.InvalidUrlException" /> class.
        /// </summary>
        public InvalidUrlException()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Constructor initialize the instance of the <see cref="T:URL_Parser.Exceptions.InvalidUrlException" /> class.
        /// </summary>
        /// <param name="message">additional message</param>
        public InvalidUrlException(string message) : base(message)
        {
        }
    }
}
