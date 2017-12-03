using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using URL_Parser.Interfaces;

namespace URL_Parser.Parsers
{
    /// <inheritdoc />
    /// <summary>
    /// Class for parse uri of url.
    /// </summary>
    public class UriParser : Parser
    {
        /// <inheritdoc />
        /// <summary>
        /// Method for parse uri of url.
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="urlElement">xml element for store data</param>
        public override void Parse(string url, XElement urlElement)
        {
            Regex regex = new Regex("(?<=[^/]/)([^/]+?)(/|\\?|$)");
            MatchCollection matches = regex.Matches(url);

            XElement uriElement = new XElement("uri");
            foreach (Match match in matches)
            {
                uriElement.Add(new XElement("segment", match.Groups[1].Value));
            }

            if (matches.Count != 0)
            {
                urlElement.Add(uriElement);
            }

            NextParser?.Parse(url, urlElement);
        }
    }
}
