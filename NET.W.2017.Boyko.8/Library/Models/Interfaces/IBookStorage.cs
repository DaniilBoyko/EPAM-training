//// <copyright file="IBookStorage.cs" company="RelCode">Boyko Daniil</copyright>
namespace Library.Models.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for read and write books to storage.
    /// </summary>
    public interface IBookStorage
    {
        /// <summary>
        /// Read books from storage
        /// </summary>
        /// <param name="path">path to storage</param>
        /// <returns>Enumerable of books.</returns>
        IEnumerable<Book> ReadBooks(string path);

        /// <summary>
        /// Write books to storage
        /// </summary>
        /// <param name="books">enumerable of books</param>
        /// <param name="path">path to storage</param>
        void WriteBooks(IEnumerable<Book> books, string path);
    }
}
