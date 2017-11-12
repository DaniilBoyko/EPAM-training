using Library.Models;
using Library.Models.Formatters;
using NUnit.Framework;

namespace Library.Tests.Formatters
{
    [TestFixture]
    public class BookCustomFormatterTests
    {
        [TestCase("Info = {0:IAT}", ExpectedResult = "Info = ISBN = 978-0-7356-6745-7, Author = Jeffrey Richter, Title = CLR via C#")]
        [TestCase("Info = {0:IAT}, {0:PG}", ExpectedResult = "Info = ISBN = 978-0-7356-6745-7, Author = Jeffrey Richter, Title = CLR via C#, 826")]
        [TestCase("{0:A}, {0:T}", ExpectedResult = "Jeffrey Richter, CLR via C#")]
        public string FormatTests_GetCustomStringFormatOfTheBook(string format)
        {
            BookCustomFormatter bookCustomFormatter = new BookCustomFormatter();
            Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            return string.Format(bookCustomFormatter, format, book);
        }
    }
}
