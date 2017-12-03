using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace URL_Parser.Parsers
{
    /// <inheritdoc />
    /// <summary>
    /// Class for parse parameters in url.
    /// </summary>
    public class ParametersParser : Parser
    {
        /// <inheritdoc />
        /// <summary>
        /// Method for parse parameters in url.
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="urlElement">xml element for store data</param>
        public override void Parse(string url, XElement urlElement)
        {
            var regex = new Regex("(\\?|&)(.+?)=(.+?)(&|$)");
            var matches = regex.Matches(url);

            var uriElement = new XElement("parameters");
            foreach (Match match in matches)
            {
                XElement parametr = new XElement("parametr");
                XAttribute key = new XAttribute("key", match.Groups[2].Value);
                XAttribute value = new XAttribute("value", match.Groups[3].Value);
                parametr.Add(key);
                parametr.Add(value);

                uriElement.Add(parametr);
            }

            if (matches.Count != 0)
            {
                urlElement.Add(uriElement);
            }

            NextParser?.Parse(url, urlElement);
        }
    }
}
