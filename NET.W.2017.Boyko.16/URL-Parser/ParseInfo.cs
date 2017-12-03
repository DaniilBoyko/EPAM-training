using System;
using System.IO;
using System.Xml.Linq;
using URL_Parser.Exceptions;
using URL_Parser.Parsers;

namespace URL_Parser
{
    /// <summary>
    /// Class for parse url to xml.
    /// </summary>
    public class ParseInfo
    {
        /// <summary>
        /// Parse one url to xml.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="element">xml element to write info</param>
        /// <param name="parsers">parsers for parse url</param>
        public static void ParseOneUrl(string url, XElement element, params Parser[] parsers)
        {
            if (parsers == null)
            {
                throw new ArgumentNullException(nameof(parsers));
            }

            if (parsers.Length == 0)
            {
                throw new ArgumentException($"Count of elements in {nameof(parsers)} should be more than 0");
            }

            for (var i = 1; i < parsers.Length; i++)
            {
                parsers[i - 1].NextParser = parsers[i];
            }

            parsers[0].Parse(url, element);
        }

        /// <summary>
        /// Parse universal resource locators in file.
        /// </summary>
        /// <param name="filepath">path to file</param>
        /// <returns>Xml document with universal resource locators.</returns>
        public static XDocument ParseFileWithUrls(string filepath)
        {
            XElement urlAddreses = new XElement("urlAddreses");
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), urlAddreses);

            string[] urls;
            try
            {
                urls = File.ReadAllLines(filepath);
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentException("invalid filepath");
            }

            foreach (var url in urls)
            {
                try
                {
                    XElement urlAddress = new XElement("urlAddress");
                    ParseOneUrl(url, urlAddress, new CheckUrlParser(), new HostParser(), new Parsers.UriParser(), new ParametersParser());

                    urlAddreses.Add(urlAddress);
                }
                catch (InvalidUrlException)
                {
                }
            }

            return xDoc;
        }
    }
}
