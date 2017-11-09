//// <copyright file="Book.cs" company="RelCode">Boyko Daniil</copyright>
namespace Library.Models
{
    using System;
    using System.Text;

    /// <summary>
    /// Mode of the book.
    /// Contains main field for storing information.
    /// Contains some methods for manipulation with data.
    /// </summary>
    public class Book : IComparable, IEquatable<Book>, ICloneable
    {
        #region Private

        #region private Consts

        /// <summary>
        /// Contains bottom year border for book.
        /// </summary>
        private const int BottomYearBorder = 100;

        /// <summary>
        /// Contains bottom pages border for book.
        /// </summary>
        private const int BottomPagesBorder = 3;

        /// <summary>
        /// Contains top pages border for book.
        /// </summary>
        private const int TopPagesBorder = 3000;

        #endregion // !private Consts

        #region private Fields 

        /// <summary>
        /// Contains international standard book number of the book.
        /// </summary>
        private string isbn;

        /// <summary>
        /// Stores author.
        /// </summary>
        private string author;

        /// <summary>
        /// Stores title of the book.
        /// </summary>
        private string title;

        /// <summary>
        /// Contains publisher of the book.
        /// </summary>
        private string publisher;

        /// <summary>
        /// Stores publication year of the book.
        /// </summary>
        private int publicationYear;

        /// <summary>
        /// Stores count pages of the book.
        /// </summary>
        private int countPages;

        /// <summary>
        /// Stores price of the book. 
        /// </summary>
        private double price;

        #endregion // !private Fields

        #endregion /// !Private

        #region Public

        #region public Consts

        /// <summary>
        /// Contains tag of the book.
        /// </summary>
        public enum Tag
        {
            /// <summary>
            /// ISBN of the book.
            /// </summary>
            Isbn,

            /// <summary>
            /// Author of the book.
            /// </summary>
            Author,

            /// <summary>
            /// Title of the book.
            /// </summary>
            Title,

            /// <summary>
            /// Publisher of the book.
            /// </summary>
            Publisher,

            /// <summary>
            /// Publication year of the book.
            /// </summary>
            PublicationYear,

            /// <summary>
            /// Count pages of the book.
            /// </summary>
            CountPages,

            /// <summary>
            /// Price of the book.
            /// </summary>
            Price
        }

        #endregion // !public Consts

        #region public Properties

        /// <summary>
        /// Gets international standard book number.
        /// </summary>
        /// <exception cref="ArgumentException">If passing string null or empty.</exception>
        public string Isbn
        {
            get => this.isbn;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Isbn)} can't be null or empty.", nameof(this.Isbn));
                }

                this.isbn = value;
            }
        }

        /// <summary>
        /// Gets name of author of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing string null or empty.</exception>
        public string Author
        {
            get => this.author;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Author)} can't be empty.", nameof(this.Author));
                }

                this.author = value;
            }
        }

        /// <summary>
        /// Gets title of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing string is null or empty</exception>
        public string Title
        {
            get => this.title;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Title)} can't be null or empty", nameof(this.Title));
                }

                this.title = value;
            }
        }

        /// <summary>
        /// Gets or sets publisher of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing string null or empty.</exception>
        public string Publisher
        {
            get => this.publisher;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Publisher)} can't be null or empty", nameof(this.Publisher));
                }

                this.publisher = value;
            }
        }

        /// <summary>
        /// Gets or sets publication year of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing year less then BOTTOM_YEAR_BORDER or more the current year</exception>
        public int PublicationYear
        {
            get => this.publicationYear;
            set
            {
                if (value < BottomYearBorder || value > DateTime.Now.Year)
                {
                    throw new ArgumentException(
                        $"{nameof(this.PublicationYear)} can't be less then {BottomYearBorder} and more then current year",
                        nameof(this.PublicationYear));
                }

                this.publicationYear = value;
            }
        }

        /// <summary>
        /// Gets or sets count pages in the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing count pages less then BOTTOM_PAGES_BORDER or more then TOP_PAGES_BORDER</exception>
        public int CountPages
        {
            get => this.countPages;
            set
            {
                if (value <= BottomPagesBorder || value >= TopPagesBorder)
                {
                    throw new ArgumentException(
                        $"{nameof(this.CountPages)} can't be less then {BottomPagesBorder} and more the {TopPagesBorder}",
                        nameof(this.CountPages));
                }

                this.countPages = value;
            }
        }

        /// <summary>
        /// Gets or sets price of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing price less then zero.</exception>
        public double Price
        {
            get => this.price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Price)} can't be less then zero", nameof(this.Price));
                }

                this.price = value;
            }
        }
   
        #endregion // !public Properties
        
        #region public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">author of the book</param>
        /// <param name="title">title of the book</param>
        /// <param name="publisher">publisher of the book</param>
        /// <param name="publicationYear">publication year of the book</param>
        /// <param name="countPages">count pages of the book</param>
        /// <param name="price">price of the book</param>
        public Book(string isbn, string author, string title, string publisher, int publicationYear, int countPages, double price)
        {
            this.Isbn = isbn;
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
            this.PublicationYear = publicationYear;
            this.CountPages = countPages;
            this.Price = price;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">author of the book</param>
        /// <param name="title">title of the book</param>
        public Book(string isbn, string author, string title) : this(isbn, author, title, string.Empty, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">author of the book</param>
        /// <param name="title">title of the book</param>
        /// <param name="publisher">publisher of the book</param>
        public Book(string isbn, string author, string title, string publisher) : this(isbn, author, title, publisher, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">author of the book</param>
        /// <param name="title">title of the book</param>
        /// <param name="publisher">publisher of the book</param>
        /// <param name="publicationYear">publication year of the book</param>
        public Book(string isbn, string author, string title, string publisher, int publicationYear) :
            this(isbn, author, title, publisher, publicationYear, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">author of the book</param>
        /// <param name="title">title of the book</param>
        /// <param name="publisher">publisher of the book</param>
        /// <param name="publicationYear">publication year of the book</param>
        /// <param name="countPages">count pages of the book</param>
        public Book(string isbn, string author, string title, string publisher, int publicationYear, int countPages) :
            this(isbn, author, title, publisher, publicationYear, countPages, 0)
        {
        }

        #endregion // !public Constructors

        #region public Methods

        /// <summary>
        /// Compare two books by tag.
        /// </summary>
        /// <param name="book">book for compare</param>
        /// <param name="tagString">tag for compare</param>
        /// <returns>If greater - 1, if equal - 0, otherwise - (-1)</returns>
        public int CompareToByTag(Book book, string tagString)
        {
            if (ReferenceEquals(book, null))
            {
                return 1;
            }

            if (ReferenceEquals(this, book))
            {
                return 0;
            }

            Tag tag;
            try
            {
                tag = (Tag)Enum.Parse(typeof(Tag), tagString);
            }
            catch (Exception)
            {
                throw new ArgumentException("Incompetable tag", nameof(tag));
            }

            switch (tag)
            {
                case Tag.Isbn: return string.Compare(this.Isbn, book.Isbn, StringComparison.Ordinal);
                case Tag.Author: return string.Compare(this.Author, book.Author, StringComparison.Ordinal);
                case Tag.Title: return string.Compare(this.Title, book.Title, StringComparison.Ordinal);
                case Tag.Publisher: return string.Compare(this.Publisher, book.Publisher, StringComparison.Ordinal);
                case Tag.PublicationYear: return this.PublicationYear.CompareTo(book.PublicationYear);
                case Tag.CountPages: return this.CountPages.CompareTo(book.CountPages);
                case Tag.Price: return this.Price.CompareTo(book.Price);
                default: throw new ArgumentException("Incompetable tag", nameof(tag));
            }
        }

        /// <summary>
        /// Compare two books.
        /// </summary>
        /// <param name="book">book for equal</param>
        /// <returns>If books equal - true, otherwise - false.</returns>
        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return false;
            }

            if (ReferenceEquals(this, book))
            {
                return true;
            }

            if (GetType() != book.GetType())
            {
                return false;
            }

            if (this.Isbn.Equals(book.Isbn) &&
                this.Author.Equals(book.Author) &&
                this.Title.Equals(book.Title) &&
                this.Publisher.Equals(book.Publisher) &&
                this.PublicationYear.Equals(book.PublicationYear) &&
                this.CountPages.Equals(book.CountPages) &&
                this.Price.Equals(book.Price))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Create clone of Book.
        /// </summary>
        /// <returns>Clone of Book.</returns>
        public Book Clone()
        {
            return new Book(this.Isbn, this.Author, this.Title, this.Publisher, this.PublicationYear, this.CountPages, this.Price);
        }

        /// <summary>
        /// Compare two books.
        /// </summary>
        /// <param name="book">book for compare</param>
        /// <returns>If book title more - (1), if book title less - (-1), else 0.</returns>
        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return -1;
            }

            if (ReferenceEquals(this, book))
            {
                return 0;
            }

            return string.Compare(this.Title, book.Title, StringComparison.Ordinal);
        }

        #region public Interface Methods

        /// <summary>
        /// Compare book and object.
        /// </summary>
        /// <param name="obj">object for compare</param>
        /// <returns>If book title more - (1), if book title less - (-1), else 0.</returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return -1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            if (GetType() != obj.GetType())
            {
                return -1;
            }

            Book book = (Book)obj;
            return this.CompareTo(book);
        }

        /// <summary>
        /// Create clone of Book.
        /// </summary>
        /// <returns>Clone of Book.</returns>
        object ICloneable.Clone()
        {
            return new Book(this.Isbn, this.Author, this.Title, this.Publisher, this.PublicationYear, this.CountPages, this.Price);
        }

        #endregion // !public Interface Methods

        #region public Override Methods

        /// <summary>
        /// Build string representation of the book.
        /// </summary>
        /// <returns>String representation of the book.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("ISBN: {0}\n", this.Isbn);
            stringBuilder.AppendFormat("Author: {0}\n", this.Author);
            stringBuilder.AppendFormat("Title: {0}\n", this.Title);
            stringBuilder.AppendFormat("Publisher: {0}\n", this.Publisher);
            stringBuilder.AppendFormat("Publication year: {0}\n", this.PublicationYear);
            stringBuilder.AppendFormat("Count pages: {0}\n", this.CountPages);
            stringBuilder.AppendFormat("Price: {0}\n", this.Price);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Compare book and object.
        /// </summary>
        /// <param name="obj">object for equals</param>
        /// <returns>If equal - true, otherwise - false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals((Book)obj);
        }

        /// <summary>
        /// Calculate hash code of the book.
        /// </summary>
        /// <returns>Hash code of the book.</returns>
        public override int GetHashCode()
        {
            int hashCode = this.Isbn.GetHashCode();
            hashCode ^= this.Author.GetHashCode();
            hashCode ^= this.Title.GetHashCode();
            hashCode ^= this.Publisher.GetHashCode();
            hashCode ^= this.PublicationYear.GetHashCode();
            hashCode ^= this.CountPages.GetHashCode();
            hashCode ^= this.Price.GetHashCode();
            return hashCode;
        }

        #endregion // !public Override Methods

        #endregion // !public Methods
        
        #endregion
    }
}
