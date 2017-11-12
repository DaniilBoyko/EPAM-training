using System.Globalization;
using Library.Models;
using NUnit.Framework;

namespace Library.Tests.Models
{
    [TestFixture]
    public class BookTests
    {
        [TestCase("ISBN 13: {0:I}, {0:A}, {0:T}, {0:PS}, {0:Y}, P.{0:PG}, {0:PR}", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P.826, $59.99")]
        [TestCase("ISBN = {0:I}, AuthorName = {0:A}", ExpectedResult = "ISBN = 978-0-7356-6745-7, AuthorName = Jeffrey Richter")]
        [TestCase("{0:A}, {0:T}, {0:PS}, {0:Y}", ExpectedResult = "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012")]
        [TestCase("ISBN 13: {0:I}, {0:A}, {0:T}, {0:PS}, {0:Y}, P.{0:PG}", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P.826")]
        [TestCase("{0:A}, {0:T}", ExpectedResult = "Jeffrey Richter, CLR via C#")]
        public string ToStringMethod_GetStringFormatRepresentationOfTheBook(string format)
        {
            CultureInfo uk = CultureInfo.GetCultureInfo("en-US");
            Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            return string.Format(uk, format, book);
        }
    }
}
