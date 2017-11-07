using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book : IComparable, IEquatable<Book>, ICloneable
    {
        #region Public

        #region public Properties

        public string Isbn { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public int CountPages { get; set; }
        public double Price { get; set; }

        public enum Tags { Isbn, Author, Title, Publisher, PublicationYear, CountPages, Price}

        #endregion public Properties



        #region public Constructors

        /// <summary>
        /// Create the instance of Book.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">aouthor of the book</param>
        /// <param name="title">title of the book</param>
        /// <param name="publisher">publisher of the book</param>
        /// <param name="publicationYear">publication year of the book</param>
        /// <param name="countPages">count pagse of the book</param>
        /// <param name="price">price of the book</param>
        public Book(string isbn, string author, string title, string publisher, int publicationYear, int countPages,
            double price)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            PublicationYear = publicationYear;
            CountPages = countPages;
            Price = price;
        }

        /// <summary>
        /// Create the instance of Book.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">aouthor of the book</param>
        /// <param name="title">title of the book</param>
        public Book(string isbn, string author, string title) : this(isbn, author, title, "", 0, 0, 0) { }

        /// <summary>
        /// Create the instance of Book.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">aouthor of the book</param>
        /// <param name="title">title of the book</param>
        /// <param name="publisher">publisher of the book</param>
        public Book(string isbn, string author, string title, string publisher) : this(isbn, author, title, publisher, 0, 0, 0) { }

        /// <summary>
        /// Create the instance of Book.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">aouthor of the book</param>
        /// <param name="title">title of the book</param>
        /// <param name="publisher">publisher of the book</param>
        /// <param name="publicationYear">publication year of the book</param>
        public Book(string isbn, string author, string title, string publisher, int publicationYear) :
            this(isbn, author, title, publisher, publicationYear, 0, 0) { }

        /// <summary>
        /// Create the instance of Book.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">aouthor of the book</param>
        /// <param name="title">title of the book</param>
        /// <param name="publisher">publisher of the book</param>
        /// <param name="publicationYear">publication year of the book</param>
        /// <param name="countPages">count pagse of the book</param>
        public Book(string isbn, string author, string title, string publisher, int publicationYear, int countPages) :
            this(isbn, author, title, publisher, publicationYear, countPages, 0) { }

        #endregion public Constructors



        #region public Methods

        /// <summary>
        /// Compare two books by tag.
        /// </summary>
        /// <param name="book"></param>
        /// <param name="tag">tag for compare</param>
        /// <returns>If greater - 1, if equal - 0, otherwise - (-1)</returns>
        public int CompareToByTag(Book book, string tag)
        {
            if (ReferenceEquals(book, null)) return 1;
            if (ReferenceEquals(this, book)) return 0;

            switch (tag)
            {
                case "Isbn": return String.Compare(Isbn, book.Isbn, StringComparison.Ordinal);
                case "Author": return String.Compare(Author, book.Author, StringComparison.Ordinal);
                case "Title": return String.Compare(Title, book.Title, StringComparison.Ordinal);
                case "Publisher": return String.Compare(Publisher, book.Publisher, StringComparison.Ordinal);
                case "PublicationYear": return PublicationYear.CompareTo(book.PublicationYear);
                case "CountPages": return CountPages.CompareTo(book.CountPages);
                case "Price": return Price.CompareTo(book.Price);
                default: throw new ArgumentException($"Incompetable tag", nameof(tag));
            }
        }

        /// <summary>
        /// Compare two books.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>If books equal - true, otherwise - false.</returns>
        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null)) return false;
            if (ReferenceEquals(this, book)) return true;
            if (GetType() != book.GetType()) return false;

            if (Isbn.Equals(book.Isbn) &&
                Author.Equals(book.Author) &&
                Title.Equals(book.Title) &&
                Publisher.Equals(book.Publisher) &&
                PublicationYear.Equals(book.PublicationYear) &&
                CountPages.Equals(book.CountPages) &&
                Price.Equals(book.Price)) return true;

            return false;
        }

        /// <summary>
        /// Create clone of Book.
        /// </summary>
        /// <returns>Clone of Book.</returns>
        public Book Clone()
        {
            return new Book(Isbn, Author, Title, Publisher, PublicationYear, CountPages, Price);
        }

        #endregion public Methods



        #region public Interface Methods

        /// <summary>
        /// Compare book and object.
        /// </summary>
        /// <param name="obj">object for compare</param>
        /// <returns>If book title more - (1), if book title less - (-1), else 0.</returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null)) return -1;
            if (ReferenceEquals(this, obj)) return 0;
            if (GetType() != obj.GetType()) return -1;

            Book book = (Book)obj;
            return String.Compare(Title, book.Title, StringComparison.Ordinal);
        }

        /// <summary>
        /// Create clone of Book.
        /// </summary>
        /// <returns>Clone of Book.</returns>
        object ICloneable.Clone()
        {
            return new Book(Isbn, Author, Title, Publisher, PublicationYear, CountPages, Price);
        }

        #endregion public Interface Methods



        #region public Override Methods

        /// <summary>
        /// Build string representation of the book.
        /// </summary>
        /// <returns>String representation of the book.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("ISBN: {0}\n", Isbn);
            stringBuilder.AppendFormat("Author: {0}\n", Author);
            stringBuilder.AppendFormat("Title: {0}\n", Title);
            stringBuilder.AppendFormat("Publisher: {0}\n", Publisher);
            stringBuilder.AppendFormat("Publication year: {0}\n", PublicationYear);
            stringBuilder.AppendFormat("Count pages: {0}\n", CountPages);
            stringBuilder.AppendFormat("Price: {0}\n", Price);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Compare book and object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>If equal - true, otherwise - false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return Equals((Book)obj);
        }

        /// <summary>
        /// Calculate hash code of the book.
        /// </summary>
        /// <returns>Hash code of the book.</returns>
        public override int GetHashCode()
        {
            int hashCode = Isbn.GetHashCode();
            hashCode ^= Author.GetHashCode();
            hashCode ^= Title.GetHashCode();
            hashCode ^= Publisher.GetHashCode();
            hashCode ^= PublicationYear.GetHashCode();
            hashCode ^= CountPages.GetHashCode();
            hashCode ^= Price.GetHashCode();
            return hashCode;
        }

        #endregion public Override Methods

        #endregion
    }
}
