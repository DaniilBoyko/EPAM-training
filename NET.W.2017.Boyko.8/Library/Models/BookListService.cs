using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Library.Models.Exceptions;
using Library.Models.Interfaces;
using NLog;

namespace Library.Models
{
    /// <summary>
    /// Service for works with list of books.
    /// </summary>
    public class BookListService : IEnumerable<Book>
    {
        #region public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        public BookListService()
        {
            Books = new List<Book>();
            Logger = new NLogLogger(LogManager.GetCurrentClassLogger());
        }

        #endregion // !public Constructors

        #region private Properties

        /// <summary>
        /// Logger of the book service.
        /// </summary>
        private Interfaces.ILogger Logger { get; set; }

        /// <summary>
        /// Gets or sets list of books.
        /// </summary>
        private List<Book> Books { get; set; }

        #endregion // !private Properties

        #region public Methods

        /// <summary>
        /// Load books from file.
        /// </summary>
        /// <param name="bookStorage">has method for load books</param>
        public void LoadBooksFromFile(IBookStorage bookStorage)
        {
            if (bookStorage == null)
            {
                throw new ArgumentNullException(nameof(bookStorage));
            }

            try
            {
                Books = bookStorage.ReadBooks().ToList();
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
                throw;
            }
        }

        /// <summary>
        /// Write books to file.
        /// </summary>
        /// <param name="bookStorage">has method for save books</param>
        public void SaveBooksToFile(IBookStorage bookStorage)
        {
            if (bookStorage == null)
            {
                throw new ArgumentNullException(nameof(bookStorage));
            }

            try
            {
                bookStorage.WriteBooks(Books);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
                throw;
            }
        }

        /// <summary>
        /// Add book in list, if doesn't contain such book.
        /// </summary>
        /// <param name="book">adding book</param>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (ContainsBook(book))
            {
                throw new BookExistException($"Book with title \"{book.Title}\" already exist in list.");
            }

            Books.Add(book);
        }

        /// <summary>
        /// Remove book from list, if it exists.
        /// </summary>
        /// <param name="book">removing book</param>
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (!ContainsBook(book))
            {
                throw new BookExistException("Book doesn\'t exist in list.");
            }

            Books.Remove(book);
        }

        /// <summary>
        /// Get enumerator of list of books.
        /// </summary>
        /// <returns>Enumerator of list of books.</returns>
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in Books)
            {
                yield return book;
            }
        }

        /// <summary>
        /// Find Book by predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Finding book or null.</returns>
        public Book FindBookByTag(Predicate<Book> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            foreach (Book book in Books)
            {
                if (predicate(book))
                {
                    return book.Clone();
                }
            }

            return null;
        }

        /// <summary>
        /// Sort list of books.
        /// </summary>
        /// <param name="comparer">contains methods for compare two books</param>
        public void Sort(IComparer<Book> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            for (int i = 0; i < Books.Count; i++)
            {
                for (int j = Books.Count - 1; j > i; j--)
                {
                    Book leftBook = Books[j - 1];
                    Book rightBook = Books[j];
                    if (comparer.Compare(leftBook, rightBook) == -1)
                    {
                        Books[j - 1] = rightBook;
                        Books[j] = leftBook;
                    }
                }
            }
        }

        #endregion // !public Methods

        #region Interface Methods

        /// <summary>
        /// Get enumerator for list of books.
        /// </summary>
        /// <returns>Enumerator of books.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion // !Interface Methods

        #region private Methods

        /// <summary>
        /// Check if list of books contains book.
        /// </summary>
        /// <param name="book">searching book</param>
        /// <returns>True - if contains, false otherwise.</returns>
        private bool ContainsBook(Book book)
        {
            foreach (var curBook in Books)
            {
                if (curBook.Equals(book))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion // !private Methods        
    }
}
