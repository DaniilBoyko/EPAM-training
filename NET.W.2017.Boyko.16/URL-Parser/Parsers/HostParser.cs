using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace URL_Parser.Parsers
{
    /// <inheritdoc />
    /// <summary>
    /// Class for parse host.
    /// </summary>
    public class HostParser : Parser
    {
        /// <inheritdoc />
        /// <summary>
        /// Method for parse host of url.
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="urlElement">xml element to write data</param>
        public override void Parse(string url, XElement urlElement)
        {
            Regex regex = new Regex("://(.+?)/");
            Match match = regex.Match(url);
            string hostValue = match.Groups[1].Value;

            XElement host = new XElement("host");
            XAttribute attribute = new XAttribute("name", hostValue);
            host.Add(attribute);

            urlElement.Add(host);

            NextParser?.Parse(url, urlElement);
        }
    }
}
