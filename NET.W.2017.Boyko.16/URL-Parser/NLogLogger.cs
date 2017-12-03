using System;
using NLog;

namespace URL_Parser
{
    /// <inheritdoc />
    /// <summary>
    /// Logger with NLog framework.
    /// </summary>
    public class NLogLogger : Interfaces.ILogger
    {
        #region public Constructors

        /// <summary>
        /// Constructor initialize new instance of the <see cref="NLogLogger"/> class.
        /// </summary>
        /// <param name="logger">NLog logger</param>
        public NLogLogger(Logger logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion // !public Constructors

        #region private Properties

        /// <summary>
        /// Store example of logger.
        /// </summary>
        private Logger Logger { get; }

        #endregion //!private Fields

        #region public Interface Methods

        /// <inheritdoc></inheritdoc>
        public void Error(string additionalMessage, Exception exception)
        {
            Logger.Error(exception, additionalMessage);
        }

        /// <inheritdoc></inheritdoc>
        public void Error(string additionalMessage)
        {
            Logger.Error(additionalMessage);
        }

        /// <inheritdoc></inheritdoc>
        public void Fatal(string additionalMessage, Exception exception)
        {
            Logger.Fatal(exception, additionalMessage);
        }

        /// <inheritdoc></inheritdoc>
        public void Fatal(string additionalMessage)
        {
            Logger.Fatal(additionalMessage);
        }

        /// <inheritdoc></inheritdoc>
        public void Warn(string additionalMessage)
        {
            Logger.Warn(additionalMessage);
        }

        /// <inheritdoc></inheritdoc>
        public void Trace(string additionalMessage)
        {
            Logger.Trace(additionalMessage);
        }

        /// <inheritdoc></inheritdoc>
        public void Debug(string additionalMessage)
        {
            Logger.Debug(additionalMessage);
        }

        /// <inheritdoc></inheritdoc>
        public void Info(string additionalMessage)
        {
            Logger.Info(additionalMessage);
        }

        #endregion // !public Interface Methods
    }
}
