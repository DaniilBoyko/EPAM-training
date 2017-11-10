using System;
using System.Collections.Generic;
using System.IO;
using Library.Models.Interfaces;

namespace Library.Models
{
    /// <inheritdoc />
    /// <summary>
    /// This class implements interface IBookStorage for save and load books.
    /// </summary>
    public class BookListStorage : IBookStorage
    {
        #region public Interface Methods

        /// <summary>
        /// Read books from file.
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns>List of books.</returns>
        public IEnumerable<Book> ReadBooks(string path)
        {
            var books = new List<Book>();

            using (var binReader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (binReader.PeekChar() > -1)
                {
                    string isbn = binReader.ReadString();
                    string author = binReader.ReadString();
                    string title = binReader.ReadString();
                    string publisher = binReader.ReadString();
                    int publicationYear = binReader.ReadInt32();
                    int countPages = binReader.ReadInt32();
                    double price = binReader.ReadDouble();
                    books.Add(new Book(isbn, author, title, publisher, publicationYear, countPages, price));
                }
            }

            return books;
        }

        /// <summary>
        /// Write list of books to file.
        /// </summary>
        /// <param name="books">list of books</param>
        /// <param name="path">path to file</param>
        public void WriteBooks(IEnumerable<Book> books, string path)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            using (BinaryWriter binWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Book book in books)
                {
                    binWriter.Write(book.Isbn);
                    binWriter.Write(book.Author);
                    binWriter.Write(book.Title);
                    binWriter.Write(book.Publisher);
                    binWriter.Write(book.PublicationYear);
                    binWriter.Write(book.CountPages);
                    binWriter.Write(book.Price);
                }
            }
        }

        #endregion public Interface Methods
    }
}
