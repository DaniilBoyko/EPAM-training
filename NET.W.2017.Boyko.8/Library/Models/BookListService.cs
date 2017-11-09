//// <copyright file="BookListService.cs" company="RelCode">Boyko Daniil</copyright>
namespace Library.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Exceptions;
    using Interfaces;

    /// <summary>
    /// Service for works with list of books.
    /// </summary>
    public class BookListService : IEnumerable<Book>
    {
        #region Public

        #region public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        public BookListService()
        {
            this.Books = new List<Book>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="bookStorage">contains methods of work with file</param>
        public BookListService(IBookStorage bookStorage)
        {
            this.BookStorage = bookStorage;
        }

        #endregion

        #region public Methods

        /// <summary>
        /// Set file worker.
        /// </summary>
        /// <param name="bookStorage">set book storage</param>
        public void SetFileWorker(IBookStorage bookStorage)
        {
            this.BookStorage = bookStorage ?? throw new ArgumentNullException(nameof(bookStorage));
        }

        /// <summary>
        /// Load books from file.
        /// </summary>
        /// <param name="path">path to file</param>
        public void LoadBooksFromFile(string path)
        {
            if (this.BookStorage == null)
            {
                throw new Exception("BookStorage is null. Please, set BookStorage.");
            }

            this.Books = this.BookStorage.ReadBooks(path).ToList();
        }

        /// <summary>
        /// Write books to file.
        /// </summary>
        /// <param name="path">path to file</param>
        public void SaveBooksToFile(string path)
        {
            if (this.BookStorage == null)
            {
                throw new Exception("BookStorage is null. Please, set BookStorage.");
            }

            this.BookStorage.WriteBooks(this.Books, path);
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

            if (this.ContainsBook(book))
            {
                throw new BookExistException($"Book with title \"{book.Title}\" already exist in list.");
            }

            this.Books.Add(book);
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

            if (!this.ContainsBook(book))
            {
                throw new BookExistException("Book doesn\'t exist in list.");
            }

            this.Books.Remove(book);
        }

        /// <summary>
        /// Get enumerator of list of books.
        /// </summary>
        /// <returns>Enumerator of list of books.</returns>
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in this.Books)
            {
                yield return book;
            }
        }

        /// <summary>
        /// Find Book by tag and its value.
        /// </summary>
        /// <param name="tag">tag for search</param>
        /// <param name="value">the value of tag</param>
        /// <returns>Finding book or null.</returns>
        public Book FindBookByTag(string tag, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            PropertyInfo property = this.GetPropertyByTag(tag);

            if (property == null)
            {
                throw new ArgumentException($"Tag not found {nameof(tag)}", nameof(tag));
            }

            if (property.PropertyType != value.GetType())
            {
                throw new ArgumentException($"Invalid type of {nameof(value)}. It should be {property.PropertyType}", nameof(value));
            }

            foreach (Book book in this.Books)
            {
                if (book.GetType().GetProperty(property.Name).GetValue(book).Equals(value))
                {
                    return book.Clone();
                }
            }

            return null;
        }

        /// <summary>
        /// Find Book by tag and its value.
        /// </summary>
        /// <param name="tag">tag for search</param>
        /// <param name="value">the value of tag</param>
        /// <returns>Finding book or null.</returns>
        public Book FindBookByTag(Book.Tag tag, object value)
        {
            return this.FindBookByTag(tag.ToString(), value);
        }

        /// <summary>
        /// Sort in ascending order list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        public void SortAscendingByTag(string tag)
        {
            this.SortByTag(tag);
        }

        /// <summary>
        /// Sort in ascending order list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        public void SortAscendingByTag(Book.Tag tag)
        {
            this.SortAscendingByTag(tag.ToString());
        }

        /// <summary>
        /// Sort in descending order list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        public void SortDescendingByTag(Book.Tag tag)
        {
            this.SortAscendingByTag(tag);
            this.Books.Reverse();
        }

        /// <summary>
        /// Sort in descending order list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        public void SortDescendingByTag(string tag)
        {
            this.SortAscendingByTag(tag);
            this.Books.Reverse();
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

            for (int i = 0; i < this.Books.Count; i++)
            {
                for (int j = this.Books.Count - 1; j > i; j--)
                {
                    Book leftBook = this.Books[j - 1];
                    Book rightBook = this.Books[j];
                    if (comparer.Compare(leftBook, rightBook) == -1)
                    {
                        this.Books[j - 1] = rightBook;
                        this.Books[j] = leftBook;
                    }
                }
            }
        }

        #endregion public Methods

        #endregion Public

        #region Private

        #region private Properties

        /// <summary>
        /// Gets or sets list of books.
        /// </summary>
        private List<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets book storage.
        /// </summary>
        private IBookStorage BookStorage { get; set; }

        #endregion private Properties

        #region private Methods

        /// <summary>
        /// Check if list of books contains book.
        /// </summary>
        /// <param name="book">searching book</param>
        /// <returns>True - if contains, false otherwise.</returns>
        private bool ContainsBook(Book book)
        {
            foreach (var curBook in this.Books)
            {
                if (curBook.Equals(book))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get property by tag from Book class.
        /// </summary>
        /// <param name="tag">tag for find</param>
        /// <returns>PropertyInfo of finding property or null.</returns>
        private PropertyInfo GetPropertyByTag(string tag)
        {
            List<PropertyInfo> listProperies = typeof(Book).GetProperties().ToList();
            PropertyInfo property = null;

            foreach (PropertyInfo propertyInfo in listProperies)
            {
                if (propertyInfo.Name.Equals(tag))
                {
                    property = propertyInfo;
                }
            }

            return property;
        }

        /// <summary>
        /// Sort list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        private void SortByTag(string tag)
        {
            for (int i = 0; i < this.Books.Count; i++)
            {
                for (int j = this.Books.Count - 1; j > i; j--)
                {
                    Book leftBook = this.Books[j - 1];
                    Book rightBook = this.Books[j];
                    if (leftBook.CompareToByTag(rightBook, tag) == 1)
                    {
                        this.Books[j - 1] = rightBook;
                        this.Books[j] = leftBook;
                    }
                }
            }
        }

        #endregion private Methods

        #region private Interface Methods

        /// <summary>
        /// Get enumerator for list of books.
        /// </summary>
        /// <returns>Enumerator of books.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #endregion Private
    }
}
