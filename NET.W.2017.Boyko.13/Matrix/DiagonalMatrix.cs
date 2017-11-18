using System;

namespace Matrix
{
    /// <summary>
    /// Model of diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements in matrix.</typeparam>
    public class DiagonalMatrix<T> : QuadraticMatrix<T>, ICloneable
    {
        #region public Constructors

        /// <summary>
        /// Constructor initialize the instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">size of the diagonal matrix</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="array"></param>
        public DiagonalMatrix(T[] array) : this(array.Length)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                this[i, i] = array[i];
            }
        }

        #endregion // !public Constructors

        #region override Indexers

        /// <summary>
        /// Set value in diagonal matrix.
        /// </summary>
        /// <param name="row">row of matrix</param>
        /// <param name="column">column of matrix</param>
        /// <returns>Value of cell.</returns>
        public override T this[int row, int column]
        {
            get
            {
                if (column >= this.Width)
                {
                    throw new ArgumentOutOfRangeException("Column out of range.");
                }

                T value = base[row, 0];
                if (row != column)
                {
                    return default(T);
                }

                return value;
            }

            set
            {
                if (row != column)
                {
                    throw new InvalidOperationException("Can't set value not on diagonal.");
                }

                base[row, 0] = value;
            }
        }

        #endregion // !override Indexers

        #region Interface Methods

        /// <summary>
        /// Create clone of diagonal matrix.
        /// </summary>
        /// <returns>Clone of diagonal matrix.</returns>
        public new DiagonalMatrix<T> Clone()
        {
            DiagonalMatrix<T> diagonalMatrix = new DiagonalMatrix<T>(this.Height);

            for (int i = 0; i < this.Height; i++)
            {
                diagonalMatrix[i, i] = this[i, i];
            }

            return diagonalMatrix;
        }

        /// <summary>
        /// Create clone of diagonal matrix.
        /// </summary>
        /// <returns>Clone of diagonal.</returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        #endregion // !Interface Methods

        #region override Methods

        /// <summary>
        /// Method for create one row of container matrix.
        /// </summary>
        /// <param name="number">number of row</param>
        /// <returns>Array for row.</returns>
        protected override T[] CreateMethod(int number)
        {
            return new T[1];
        }

        #endregion // !override Methods
    }
}
