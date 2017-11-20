using System;

namespace Collections.Tree
{
    /// <summary>
    /// Model of binary tree node.
    /// </summary>
    /// <typeparam name="T">Type of value in tree node.</typeparam>
    public class BinaryTreeNode<T> : ICloneable
    {
        #region public Constructors
        /// <summary>
        /// Constructor initialize the instance of the <see cref="BinaryTreeNode{T}"/> class.
        /// </summary>
        /// <param name="value"></param>
        public BinaryTreeNode(T value)
        {
            Value = value;
        }
        #endregion // !public Constructors

        #region public Properties
        /// <summary>
        /// Left node.
        /// </summary>
        public BinaryTreeNode<T> Left { get; internal set; }

        /// <summary>
        /// Right node.
        /// </summary>
        public BinaryTreeNode<T> Right { get; internal set; }

        /// <summary>
        /// Value of node.
        /// </summary>
        public T Value { get; }
        #endregion

        #region inteface Methods 
        /// <summary>
        /// Get clone of binary tree node.
        /// </summary>
        /// <returns>Clone of binary tree.</returns>
        public BinaryTreeNode<T> Clone()
        {
            return new BinaryTreeNode<T>(Value);
        }

        /// <summary>
        /// Get clone of binary tree node.
        /// </summary>
        /// <returns>Clone of binary tree.</returns>
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion // !interface Methods
    }
}
