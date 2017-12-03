using System.Xml.Linq;

namespace URL_Parser.Parsers
{
    /// <summary>
    /// Class for parse info.
    /// </summary>
    public abstract class Parser
    {
        /// <summary>
        /// Get or set next parser.
        /// </summary>
        public Parser NextParser { get; set; }

        /// <summary>
        /// Method for parse info.
        /// </summary>
        /// <param name="info">info</param>
        /// <param name="element">xml element to write data</param>
        public abstract void Parse(string info, XElement element);
    }
}
