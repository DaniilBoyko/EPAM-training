using System;

/**
 * Техника внедрения зависимости (dependency injection)
 * 
 * */

namespace Library.Models.Interfaces
{
    /// <summary>
    /// Interface for logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log error.
        /// </summary>
        /// <param name="additionalMessage">additional message of the exception</param>
        /// <param name="exception">exception</param>
        void Error(string additionalMessage, Exception exception);

        /// <summary>
        /// Log exception.
        /// </summary>
        /// <param name="additionalMessage">additional message of the exception</param>
        void Error(string additionalMessage);

        /// <summary>
        /// Log fatal error.
        /// </summary>
        /// <param name="additionalMessage">additional message of the fatal error</param>
        /// <param name="exception">exception</param>
        void Fatal(string additionalMessage, Exception exception);

        /// <summary>
        /// Log fatal error.
        /// </summary>
        /// <param name="additionalMessage">additional message of the fatal error</param>
        void Fatal(string additionalMessage);

        /// <summary>
        /// Log warn.
        /// </summary>
        /// <param name="additionalMessage">additional message to the warn</param>
        void Warn(string additionalMessage);

        /// <summary>
        /// Log trace.
        /// </summary>
        /// <param name="additionalMessage">additional message to the trace</param>
        void Trace(string additionalMessage);

        /// <summary>
        /// Log debug.
        /// </summary>
        /// <param name="additionalMessage">additional message to the debug</param>
        void Debug(string additionalMessage);

        /// <summary>
        /// Log debug.
        /// </summary>
        /// <param name="additionalMessage">additional message to the debug</param>
        void Info(string additionalMessage);
    }
}
