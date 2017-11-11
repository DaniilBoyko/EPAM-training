using System.Collections.Generic;
using Library.Models;

namespace Library.Tests.ConsoleApp
{
    /// <summary>
    /// Class for compare two books.
    /// </summary>
    public class BookComparer : IComparer<Book>
    {
        /// <summary>
        /// Compare two books.
        /// </summary>
        /// <param name="leftBook">left book</param>
        /// <param name="rightBook">right book</param>
        /// <returns>Integer representation of comparison.</returns>
        public int Compare(Book leftBook, Book rightBook)
        {
            if (ReferenceEquals(leftBook, rightBook))
            {
                return 0;
            }

            if (leftBook == null)
            {
                return 1;
            }

            if (rightBook == null)
            {
                return -1;
            }

            return leftBook.Price.CompareTo(rightBook.Price);
        }
    }
}
