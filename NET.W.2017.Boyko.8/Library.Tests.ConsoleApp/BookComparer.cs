using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Tests.ConsoleApp
{
    class BookComparer: IComparer<Book>
    {
        public int Compare(Book leftBook, Book rightBook)
        {
            if (ReferenceEquals(leftBook, rightBook))
                return 0;
            if (leftBook == null)
                return 1;
            if (rightBook == null)
                return -1;

            return leftBook.Price.CompareTo(rightBook.Price);
        }
    }
}
