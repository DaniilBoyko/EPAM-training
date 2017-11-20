using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// Extends class matrix and its 
    /// </summary>
    public static class MatrixExtensions
    {
        /// <summary>
        /// Add quadratic matrix to quadratic matrix
        /// </summary>
        /// <typeparam name="T">type of elements in matrix</typeparam>
        /// <param name="leftMatrix">left matrix</param>
        /// <param name="rightMatrix">right matrix</param>
        /// <returns>Result quadratic matrix.</returns>
        public static QuadraticMatrix<T> Add<T>(this QuadraticMatrix<T> leftMatrix, QuadraticMatrix<T> rightMatrix)
        {
            QuadraticMatrix<T> result = leftMatrix.Clone();

            for (int i = 0; i < result.Height; i++)
            {
                for (int j = 0; j < result.Width; j++)
                {
                    dynamic value = rightMatrix[i, j];
                    result[i, j] += value;
                }
            }

            return result;
        }

        /// <summary>
        /// Add quadratic matrix to symmetric matrix.
        /// </summary>
        /// <typeparam name="T">type of elements</typeparam>
        /// <param name="leftMatrix">left matrix</param>
        /// <param name="rightMatrix">right matrix</param>
        /// <returns>Result quadratic matrix</returns>
        public static QuadraticMatrix<T> Add<T>(this QuadraticMatrix<T> leftMatrix, SymmetricMatrix<T> rightMatrix)
        {
            return leftMatrix.Add((QuadraticMatrix<T>)rightMatrix);
        }

        public static QuadraticMatrix<T> Add<T>(this QuadraticMatrix<T> leftMatrix, DiagonalMatrix<T> rightMatrix)
        {
            QuadraticMatrix<T> result = leftMatrix.Clone();

            for (int i = 0; i < result.Width; i++)
            {
                dynamic value = rightMatrix[i, i];
                result[i, i] += value;
            }

            return result;
        }

        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> leftMatrix, DiagonalMatrix<T> rightMatrix)
        {
            DiagonalMatrix<T> result = leftMatrix.Clone();

            for (int i = 0; i < result.Width; i++)
            {
                dynamic value = rightMatrix[i, i];
                result[i, i] += value;
            }

            return result;
        }

        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> leftMatrix, SymmetricMatrix<T> rightMatrix)
        {
            SymmetricMatrix<T> result = leftMatrix.Clone();

            for (int i = 0; i < result.Height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    dynamic value = rightMatrix[i, j];
                    result[i, j] += value;
                }
            }

            return result;
        }

        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> leftMatrix, DiagonalMatrix<T> rightMatrix)
        {
            SymmetricMatrix<T> result = leftMatrix.Clone();

            for (int i = 0; i < result.Height; i++)
            {
                dynamic value = rightMatrix[i, i];
                result[i, i] += value;
            }

            return result;
        }
    }
}
