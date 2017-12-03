using System.IO;
using System.Xml.Linq;
using URL_Parser.Exceptions;

namespace URL_Parser.Tests.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "/resource.txt";
                XDocument xdoc = ParseInfo.ParseFileWithUrls(path);

                System.Console.WriteLine(xdoc);

                xdoc.Save(Directory.GetCurrentDirectory() + "/urls.xml");

            }
            catch (InvalidUrlException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
