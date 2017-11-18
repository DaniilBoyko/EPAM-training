using System;

namespace Matrix
{
    /// <summary>
    /// Model of the symmetric matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements in symmetric matrix.</typeparam>
    public class SymmetricMatrix<T> : TriangularMatrix<T>, ICloneable
    {
        #region public Constructors
        /// <summary>
        /// Constructor initialize the instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">size of symmetric matrix</param>
        public SymmetricMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">source data for symmetric matrix</param>
        public SymmetricMatrix(T[][] matrix) : base(matrix)
        {
        }
        #endregion // !public Constructors

        #region override Indexers
        /// <summary>
        /// Get and set value in symmetric matrix.
        /// </summary>
        /// <param name="row">row of cell</param>
        /// <param name="column">column of cell</param>
        /// <returns>Value in cell.</returns>
        public override T this[int row, int column]
        {
            get
            {
                if (row > column)
                {
                    return base[column, row];
                }

                return base[row, column];
            }

            set
            {
                if (row > column)
                {
                    base[column, row] = value;
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
        public new SymmetricMatrix<T> Clone()
        {
            SymmetricMatrix<T> symmetricMatrix = new SymmetricMatrix<T>(this.Height);

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    symmetricMatrix[i, j] = this[i, j];
                }
            }

            return symmetricMatrix;
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
    }
}
