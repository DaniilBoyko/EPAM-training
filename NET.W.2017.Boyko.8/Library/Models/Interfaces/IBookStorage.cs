using System.Collections.Generic;

namespace Library.Models.Interfaces
{
    /// <summary>
    /// Interface for read and write books to storage.
    /// </summary>
    public interface IBookStorage
    {
        /// <summary>
        /// Read books from storage
        /// </summary>
        /// <returns>Enumerable of books.</returns>
        IEnumerable<Book> ReadBooks();

        /// <summary>
        /// Write books to storage
        /// </summary>
        /// <param name="books">enumerable of books</param>
        void WriteBooks(IEnumerable<Book> books);
    }
}
