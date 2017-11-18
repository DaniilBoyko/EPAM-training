using System;

namespace Matrix
{
    /// <summary>
    /// Model of triangular matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements in triangular matrix.</typeparam>
    public class TriangularMatrix<T> : QuadraticMatrix<T>, ICloneable
    {
        #region public Constructors

        /// <summary>
        /// Initialize the instance of the <see cref="TriangularMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">size of the triangular matrix</param>
        public TriangularMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Initialize the instance of the <see cref="TriangularMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">source data</param>
        public TriangularMatrix(T[][] matrix) : base(matrix.Length)
        {
            this.CheckMatrix(matrix);
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    this[i, j] = matrix[i][j];
                }
            }
        }

        #endregion // !public Constructors 

        #region override Indexers

        /// <summary>
        /// Set cell value in triangular matrix.
        /// </summary>
        /// <param name="row">row of cell</param>
        /// <param name="column">column of cell</param>
        /// <returns>Value of cell.</returns>
        public override T this[int row, int column]
        {
            get
            {
                T value = base[row, column];
                if (column > row)
                {
                    return default(T);
                }

                return value;
            }

            set
            {
                if (column > row)
                {
                    throw new InvalidOperationException("Can't set value out of triangle in triangular matrix");
                }

                base[row, column] = value;
            }
        }

        #endregion // !override Indexers

        #region Interface Methods

        /// <summary>
        /// Create clone of triangular matrix.
        /// </summary>
        /// <returns>Clone of triangular matrix.</returns>
        public new TriangularMatrix<T> Clone()
        {
            TriangularMatrix<T> triangularMatrix = new TriangularMatrix<T>(this.Height);

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    triangularMatrix[i, j] = this[i, j];
                }
            }

            return triangularMatrix;
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
            return new T[number + 1];
        }

        #endregion // !override Methods

        #region private Methods

        /// <summary>
        /// Check for contains triangular matrix.
        /// </summary>
        /// <param name="matrix">passing matrix</param>
        private void CheckMatrix(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Length < i + 1)
                {
                    throw new ArgumentException($"{nameof(matrix)} should contains triangular matrix.");
                }
            }
        }

        #endregion // !private Methods
    }
}
