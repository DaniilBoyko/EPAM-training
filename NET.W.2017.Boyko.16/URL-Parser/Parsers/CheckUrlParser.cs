using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using NLog;
using URL_Parser.Exceptions;

namespace URL_Parser.Parsers
{
    /// <inheritdoc />
    /// <summary>
    /// Check url parser.
    /// </summary>
    public class CheckUrlParser : Parser
    {
        /// <summary>
        /// Constructor initialize the instance of the <see cref="CheckUrlParser"/> class.
        /// </summary>
        public CheckUrlParser()
        {
            this.Logger = new NLogLogger(LogManager.GetCurrentClassLogger());
        }

        /// <summary>
        /// Logger of the check url parser.
        /// </summary>
        private Interfaces.ILogger Logger { get; }

        /// <inheritdoc />
        /// <summary>
        /// Method for parse url.
        /// </summary>
        /// <param name="url">url for parse</param>
        /// <param name="urlElement">xml element to write data</param>
        public override void Parse(string url, XElement urlElement)
        {
            var regex = new Regex("\\w+:\\/\\/[\\w@][\\w.:@]+\\/?[\\w\\.?=%&=\\-@/$,]*");
            var matches = regex.Matches(url);

            if (matches.Count == 0)
            {
                Exception e = new InvalidUrlException($"{url} - not a url");
                this.Logger.Error(string.Empty, e);
                throw e;
            }

            NextParser?.Parse(url, urlElement);
        }
    }
}
