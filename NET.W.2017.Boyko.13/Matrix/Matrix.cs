using System;

namespace Matrix
{
    /// <summary>
    /// Model of matrix
    /// </summary>
    /// <typeparam name="T">Type of elements in matrix.</typeparam>
    public abstract class Matrix<T>
    {
        #region private Fields

        private int _height;
        private int _width;
        private T[][] _matrix;

        #endregion // !private Fields

        #region public Constructors

        /// <summary>
        /// Constructor initialize the instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="height">height of the matrix</param>
        /// <param name="width">width of the matrix</param>
        protected Matrix(int height, int width)
        {
            Height = height;
            Width = width;
            CreateMatrix(CreateMethod);
        }

        #endregion // !public Constructors

        #region public Ements

        /// <summary>
        /// Event for notify listeners when some cell changed.
        /// </summary>
        public event EventHandler<ChangeCellEventArgs> ChangeCell = delegate { };

        #endregion

        #region public Properties

        /// <summary>
        /// Get height of the matrix.
        /// </summary>
        public int Height
        {
            get => _height;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Height)} should be more then zero.");
                }

                _height = value;
            }
        }

        /// <summary>
        /// Get width of the matrix.
        /// </summary>
        public int Width
        {
            get => _width;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Height)} should be more then zero.");
                }

                _width = value;
            }
        }

        #endregion // !public Properties

        #region abstract Methods and virtual Indexers

        /// <summary>
        /// Get element of the matrix.
        /// </summary>
        /// <param name="row">row of matrix</param>
        /// <param name="column">column of matrix</param>
        /// <returns></returns>
        public virtual T this[int row, int column]
        {
            get
            {
                CheckRowColumn(row, column);
                return _matrix[row][column];
            }

            set
            {
                CheckRowColumn(row, column);
                _matrix[row][column] = value;
                OnChangeCell(new ChangeCellEventArgs(row, column));
            }
        }

        /// <summary>
        /// Method for create one row of container matrix.
        /// </summary>
        /// <param name="number">number of row</param>
        /// <returns>Array for row.</returns>
        protected abstract T[] CreateMethod(int number);

        #endregion // !abstract Methods and virtual Indexers

        #region private protected Methods

        /// <summary>
        /// Call when event of change cell is happened.
        /// </summary>
        /// <param name="e">Arguments of event.</param>
        protected void OnChangeCell(ChangeCellEventArgs e)
        {
            ChangeCell(this, e);
        }

        /// <summary>
        /// Check row and column of out of range.
        /// </summary>
        /// <param name="row">row of matrix</param>
        /// <param name="column">column of matrix</param>
        private void CheckRowColumn(int row, int column)
        {
            if (row >= this.Height || row < 0 || column >= this.Width || column < 0)
            {
                throw new ArgumentOutOfRangeException($"Row or column out of range.");
            }
        }

        /// <summary>
        /// Create container of matrix.
        /// </summary>
        /// <param name="func">how to create</param>
        private void CreateMatrix(Func<int, T[]> func)
        {
            _matrix = new T[Height][];
            for (int i = 0; i < Height; i++)
            {
                _matrix[i] = func(i);
            }
        }

        #endregion
    }
}
