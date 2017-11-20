using System;

namespace Matrix
{
    /// <summary>
    /// Model lf quadratic matrix.
    /// </summary>
    /// <typeparam name="T">Type of element in quadratic matrix.</typeparam>
    public class QuadraticMatrix<T> : Matrix<T>, ICloneable
    {
        #region public Constructors

        /// <summary>
        /// Constructor initialize the instance of the <see cref="QuadraticMatrix{T}"/> class.
        /// </summary>
        /// <param name="size"></param>
        public QuadraticMatrix(int size) : base(size, size)
        {
        }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="QuadraticMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">Matrix for souse data.</param>
        public QuadraticMatrix(T[][] matrix) : base(matrix.Length, matrix.Length)
        {
            this.CheckMatrix(matrix);

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    this[i, j] = matrix[i][j];
                }
            }
        }

        #endregion // !public Constructors

        #region Interface Methods

        /// <summary>
        /// Create clone of quadratic matrix.
        /// </summary>
        /// <returns>Clone of quadratic matrix.</returns>
        public QuadraticMatrix<T> Clone()
        {
            QuadraticMatrix<T> quadraticMatrix = new QuadraticMatrix<T>(this.Height);

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    quadraticMatrix[i, j] = this[i, j];
                }
            }

            return quadraticMatrix;
        }

        /// <summary>
        /// Create clone of quadratic matrix.
        /// </summary>
        /// <returns>Clone of quadratic matrix.</returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        #endregion // !Interface Methods

        #region override Methods and Indexers

        /// <summary>
        /// Method for create one row of container matrix.
        /// </summary>
        /// <param name="number">number of row</param>
        /// <returns>Array for row.</returns>
        protected override T[] CreateMethod(int number)
        {
            return new T[Width];
        }

        #endregion // !override Methods and Indexers

        #region private Methods

        private static void CheckMatrix(Matrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"Can't add null matrix.");
            }
        }

        /// <summary>
        /// Check for quadratic.
        /// </summary>
        /// <param name="matrix">passing matrix</param>
        private void CheckMatrix(T[][] matrix)
        {
            int height = matrix.Length;
            for (int i = 0; i < height; i++)
            {
                if (matrix[i].Length != height)
                {
                    throw new ArgumentException($"{nameof(matrix)} should be quadratic.");
                }
            }
        }

        #endregion // !private Methods
    }
}
