using Task5.Solution;
using Task5.Solution.Collectors;
using Task5.Solution.Converters;
using Task5.Solution.DocumentParts;

namespace Task5.Console
{
    using System.Collections.Generic;
    using System;
    using Task5;

    class Program
    {
        static void Main(string[] args)
        {
            List<DocumentPart> parts = new List<DocumentPart>
                {
                    new PlainText {Text = "Some plain text"},
                    new Hyperlink {Text = "google.com", Url = "https://www.google.by/"},
                    new BoldText {Text = "Some bold text"}
                };

            Document document = new Document(parts);

            Console.WriteLine(document.Convert(new ToHtmlConverter(), new SimpleCollector()));

            Console.WriteLine(document.Convert(new ToLaTeXConverter(), new SimpleCollector()));

            Console.WriteLine(document.Convert(new ToPlainTestConverter(), new SimpleCollector()));
        }
    }
}
