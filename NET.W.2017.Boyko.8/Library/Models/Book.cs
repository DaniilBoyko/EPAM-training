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

        private const int BottomYearBorder = 100;
        private const int BottomPagesBorder = 3;
        private const int TopPagesBorder = 3000;

        #endregion // !private Consts


        #region private Fields 

        private string _isbn;
        private string _aughotr;
        private string _title;
        private string _publisher;
        private int _publicationYear;
        private int _countPages;
        private double _price;

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
        /// Contains book isbn.
        /// </summary>
        /// <exception cref="ArgumentException">If passing string null or empty.</exception>
        public string Isbn
        {
            get => _isbn;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(Isbn)} can't be null or empty.", nameof(Isbn));
                _isbn = value;
            }

        }

        /// <summary>
        /// Contains name of author of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing string null or empty.</exception>
        public string Author
        {
            get => _aughotr;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(Author)} can't be empty.", nameof(Author));
                _aughotr = value;
            }
        }

        /// <summary>
        /// Contains title of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing string is null or empty</exception>
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(Title)} can't be null or empty", nameof(Title));
                _title = value;
            }
        }

        /// <summary>
        /// Contains publisher of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing string null or empty.</exception>
        public string Publisher
        {
            get => _publisher;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(Publisher)} can't be null or empty", nameof(Publisher));
                _publisher = value;
            }
        }

        /// <summary>
        /// Contains publication year of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing year less then BOTTOM_YEAR_BORDER or more the current year</exception>
        public int PublicationYear
        {
            get => _publicationYear;
            set
            {
                if (value < BottomYearBorder || value > DateTime.Now.Year)
                    throw new ArgumentException($"{nameof(PublicationYear)} can't be less then {BottomYearBorder} and more then current year", nameof(PublicationYear));
                _publicationYear = value;
            }
        }

        /// <summary>
        /// Contains count pages in the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing count pages less then BOTTOM_PAGES_BORDER or more then TOP_PAGES_BORDER</exception>
        public int CountPages
        {
            get => _countPages;
            set
            {
                if (value <= BottomPagesBorder || value >= TopPagesBorder)
                    throw new ArgumentException($"{nameof(CountPages)} can't be less then {BottomPagesBorder} and more the {TopPagesBorder}", nameof(CountPages));
                _countPages = value;
            }
        }

        /// <summary>
        /// Contains price of the book.
        /// </summary>
        /// <exception cref="ArgumentException">If passing price less then zero.</exception>
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(Price)} can't be less then zero", nameof(Price));
                _price = value;
            }
        }


        

        #endregion // !public Properties
        

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

        #endregion // !public Constructors


        #region public Methods

        /// <summary>
        /// Compare two books by tag.
        /// </summary>
        /// <param name="book"></param>
        /// <param name="tagString">tag for compare</param>
        /// <returns>If greater - 1, if equal - 0, otherwise - (-1)</returns>
        public int CompareToByTag(Book book, string tagString)
        {
            if (ReferenceEquals(book, null)) return 1;
            if (ReferenceEquals(this, book)) return 0;

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
                case Tag.Isbn: return String.Compare(Isbn, book.Isbn, StringComparison.Ordinal);
                case Tag.Author: return String.Compare(Author, book.Author, StringComparison.Ordinal);
                case Tag.Title: return String.Compare(Title, book.Title, StringComparison.Ordinal);
                case Tag.Publisher: return String.Compare(Publisher, book.Publisher, StringComparison.Ordinal);
                case Tag.PublicationYear: return PublicationYear.CompareTo(book.PublicationYear);
                case Tag.CountPages: return CountPages.CompareTo(book.CountPages);
                case Tag.Price: return Price.CompareTo(book.Price);
                default: throw new ArgumentException("Incompetable tag", nameof(tag));
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

        /// <summary>
        /// Compare two books.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>If book title more - (1), if book title less - (-1), else 0.</returns>
        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null)) return -1;
            if (ReferenceEquals(this, book)) return 0;

            return String.Compare(Title, book.Title, StringComparison.Ordinal);
        }



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
            return CompareTo(book);
        }

        /// <summary>
        /// Create clone of Book.
        /// </summary>
        /// <returns>Clone of Book.</returns>
        object ICloneable.Clone()
        {
            return new Book(Isbn, Author, Title, Publisher, PublicationYear, CountPages, Price);
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

        #endregion // !public Override Methods

        #endregion // !public Methods
        
        #endregion
    }
}
