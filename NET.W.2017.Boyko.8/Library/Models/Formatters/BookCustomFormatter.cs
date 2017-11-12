using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Formatters
{
    /// <summary>
    /// Custom formatter for the book.
    /// </summary>
    public class BookCustomFormatter : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider _parant;

        /// <summary>
        /// Constructor for initialize the instance of the <see cref="BookCustomFormatter"/> class.
        /// </summary>
        public BookCustomFormatter() : this(CultureInfo.CurrentCulture)
        {
        }

        /// <summary>
        /// Constructor for initialize the instance of the <see cref="BookCustomFormatter"/> class.
        /// </summary>
        /// <param name="formatProvider">format provider</param>
        public BookCustomFormatter(IFormatProvider formatProvider)
        {
            _parant = formatProvider;
        }

        /// <summary>
        /// Get format
        /// </summary>
        /// <param name="formatType">format type</param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return CultureInfo.CurrentCulture.GetFormat(formatType);
        }

        /// <summary>
        /// Convert book to custom string format.
        /// </summary>
        /// <param name="format">string format</param>
        /// <param name="arg">object for format</param>
        /// <param name="formatProvider">format provider</param>
        /// <returns>Custom string format of the book.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "IAT" || arg.GetType() != typeof(Book))
            {
                return string.Format(_parant, "{0:" + format + "}", arg);
            }

            Book book = (Book)arg;
            StringBuilder result = new StringBuilder();
            result.AppendFormat("ISBN = {0}, Author = {1}, Title = {2}", book.Isbn, book.Author, book.Title);
            return result.ToString();
        }
    }
}
