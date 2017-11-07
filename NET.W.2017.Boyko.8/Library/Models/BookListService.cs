using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Library.Models.Exceptions;
using Library.Models.Interfaces;

namespace Library.Models.Services
{
    public class BookListService : IEnumerable<Book>
    {
        #region Private

        #region private Properties

        private List<Book> Books { get; set; }
        private IFileWorker FileWorker { get; set; }

        #endregion private Properties



        #region private Methods

        /// <summary>
        /// Check if list of books contains book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>True - if conteins, false otherwise.</returns>
        private bool ContainsBook(Book book)
        {
            foreach (var curBook in Books)
            {
                if (curBook.Equals(book))
                    return true;
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
                    property = propertyInfo;
            }

            return property;
        }

        /// <summary>
        /// Sort list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        private void SortByTag(string tag)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                for (int j = Books.Count - 1; j > i; j--)
                {
                    Book leftBook = Books[j - 1];
                    Book rightBook = Books[j];
                    if (leftBook.CompareToByTag(rightBook, tag) == 1)
                    {
                        Books[j - 1] = rightBook;
                        Books[j] = leftBook;
                    }
                }
            }
        }

        #endregion private Methods



        #region private Interface Methods

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #endregion Private



        #region Public

        #region public Constructors

        /// <summary>
        /// Create an instance of BookListService.
        /// </summary>
        public BookListService()
        {
            Books = new List<Book>();
        }

        /// <summary>
        /// Create an instance of BookListSevice.
        /// </summary>
        /// <param name="fileWorker">contains methods of work with file</param>
        public BookListService(IFileWorker fileWorker)
        {
            FileWorker = fileWorker;
        }

        #endregion



        #region public Methods

        /// <summary>
        /// Set file worker.
        /// </summary>
        /// <param name="fileWorker"></param>
        public void SetFileWorker(IFileWorker fileWorker)
        {
            FileWorker = fileWorker ?? throw new ArgumentNullException(nameof(fileWorker));
        }

        /// <summary>
        /// Load books from file.
        /// </summary>
        /// <param name="path">path to file</param>
        public void LoadBooksFromFile(string path)
        {
            if (FileWorker == null)
                throw new Exception("FileWorker is null. Please, set FileWorker.");

            Books = FileWorker.ReadBooksFromFile(path);
        }

        /// <summary>
        /// Write books to file.
        /// </summary>
        /// <param name="path">path to file</param>
        public void SaveBooksToFile(string path)
        {
            if (FileWorker == null)
                throw new Exception("FileWorker is null. Please, set FileWorker.");

            FileWorker.WriteBooksToFile(Books, path);
        }

        /// <summary>
        /// Add book in list, if doesn't contain such book.
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            if (ContainsBook(book))
                throw new BookExistException($"Book with title \"{book.Title}\" already exist in list.");

            Books.Add(book);
        }

        /// <summary>
        /// Remove book from list, if it exitst.
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            if (!ContainsBook(book))
                throw new BookExistException($"Book doesn't exist in list.");

            Books.Remove(book);
        }

        /// <summary>
        /// Get enumerator of list of books.
        /// </summary>
        /// <returns>Enumerator of list of books.</returns>
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in Books)
                yield return book;
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
                throw new ArgumentNullException(nameof(value));

            PropertyInfo property= GetPropertyByTag(tag);

            if (property == null)
                throw new ArgumentException($"Tag not found {nameof(tag)}", nameof(tag));
            if (property.PropertyType != value.GetType())
                throw new ArgumentException($"Invalid type of {nameof(value)}. It should be {property.PropertyType}",
                    nameof(value));

            foreach (Book book in Books)
            {
                if (book.GetType().GetProperty(property.Name).GetValue(book).Equals(value))
                    return book.Clone();
            }

            return null;
        }

        /// <summary>
        /// Find Book by tag and its value.
        /// </summary>
        /// <param name="tag">tag for search</param>
        /// <param name="value">the value of tag</param>
        /// <returns>Finding book or null.</returns>
        public Book FindBookByTag(Book.Tags tag, object value)
        {
            return FindBookByTag(tag.ToString(), value);
        }

        /// <summary>
        /// Sort in ascending order list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        public void SortAscendingByTag(string tag)
        {
            SortByTag(tag);
        }

        /// <summary>
        /// Sort in ascending order list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        public void SortAscendingByTag(Book.Tags tag)
        {
            SortAscendingByTag(tag.ToString());
        }

        /// <summary>
        /// Sort in descending order list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        public void SortDescendingByTag(Book.Tags tag)
        {
            SortAscendingByTag(tag);
            Books.Reverse();
        }

        /// <summary>
        /// Sort in descending order list of books by tag.
        /// </summary>
        /// <param name="tag">tag for sorting</param>
        public void SortDescendingByTag(string tag)
        {
            SortAscendingByTag(tag);
            Books.Reverse();
        }

        /// <summary>
        /// Sort list of books.
        /// </summary>
        /// <param name="comparer">contains methods for compare two books</param>
        public void Sort(IComparer<Book> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

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

        #endregion public Methods

        #endregion Public
    }
}
