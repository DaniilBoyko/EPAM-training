using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Library.Models
{
    /// <summary>
    /// Logger with NLog framework.
    /// </summary>
    public class NLogLogger : Interfaces.ILogger
    {
        #region private Fields

        /// <summary>
        /// Store example of logger.
        /// </summary>
        private readonly Logger logger;

        #endregion //!private Fields

        #region public Constructors

        /// <summary>
        /// Constructor initialize new instance of the <see cref="NLogLogger"/> class.
        /// </summary>
        /// <param name="logger">NLog logger</param>
        public NLogLogger(Logger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion // !public Constructors

        #region public Interface Methods

        /// <summary>
        /// Log error.
        /// </summary>
        /// <param name="additionalMessage">additional message</param>
        /// <param name="exception">exception</param>
        public void Error(string additionalMessage, Exception exception)
        {
            this.logger.Error(exception, additionalMessage);
        }

        #endregion // !public Interface Methods
    }
}
