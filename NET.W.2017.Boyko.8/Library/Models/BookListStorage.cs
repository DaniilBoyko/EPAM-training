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
        #region private Fields

        /// <summary>
        /// Store path to file.
        /// </summary>
        private string path;

        #endregion // !private Fields

        #region public Constructors

        /// <summary>
        /// Initialize the instance of the <see cref="BookListStorage"/> class.
        /// </summary>
        /// <param name="path"></param>
        public BookListStorage(string path)
        {
            Path = path;
        }

        #endregion

        #region private Properties

        /// <summary>
        /// Get or set path to the file.
        /// </summary>
        private string Path
        {
            get => path;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Path can't be null or empty.");
                }

                path = value;
            }
        }

        #endregion

        #region public Interface Methods

        /// <summary>
        /// Read books from file.
        /// </summary>
        /// <returns>List of books.</returns>
        public IEnumerable<Book> ReadBooks()
        {
            var books = new List<Book>();

            using (var binReader = new BinaryReader(File.Open(Path, FileMode.Open)))
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
        public void WriteBooks(IEnumerable<Book> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            using (BinaryWriter binWriter = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
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
