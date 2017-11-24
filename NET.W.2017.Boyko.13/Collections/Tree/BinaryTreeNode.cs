using System;

namespace Collections.Tree
{
    /// <summary>
    /// Part of binary tree model, which contains binary tree node.
    /// </summary>
    public partial class BinaryTree<T>
    {
        /// <summary>
        /// Model of binary tree node.
        /// </summary>
        /// <typeparam name="TK">Type of value in tree node.</typeparam>
        private class BinaryTreeNode<TK>
        {
            #region public Constructors

            /// <summary>
            /// Constructor initialize the instance of the <see cref="BinaryTreeNode{TK}"/> class.
            /// </summary>
            /// <param name="value"></param>
            public BinaryTreeNode(TK value)
            {
                Value = value;
            }

            #endregion // !public Constructors

            #region public Properties

            /// <summary>
            /// Left node.
            /// </summary>
            public BinaryTreeNode<TK> Left { get; internal set; }

            /// <summary>
            /// Right node.
            /// </summary>
            public BinaryTreeNode<TK> Right { get; internal set; }

            /// <summary>
            /// Value of node.
            /// </summary>
            public TK Value { get; }

            #endregion
        }
    }
}
