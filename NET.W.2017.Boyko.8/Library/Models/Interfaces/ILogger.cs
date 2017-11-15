using System;

namespace Library.Models.Interfaces
{
    /// <summary>
    /// Interface for logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log exception.
        /// </summary>
        /// <param name="additionalMessage">additional message of the exception</param>
        /// <param name="exception">exception</param>
        void Error(string additionalMessage, Exception exception);
    }
}
