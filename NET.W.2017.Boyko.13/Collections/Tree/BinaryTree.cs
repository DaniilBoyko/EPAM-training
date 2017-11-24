using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Tree
{
    /// <summary>
    /// Model of binary tree.
    /// </summary>
    /// <typeparam name="T">Type of elements in binary tree.</typeparam>
    public partial class BinaryTree<T> : IEnumerable<T>
    {
        #region private Fields
        /// <summary>
        /// Store comparer for elements.
        /// </summary>
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Store head of the tree.
        /// </summary>
        private BinaryTreeNode<T> _head;
        #endregion // !private Fields

        #region public Constructors
        /// <summary>
        /// Constructor initialize the instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        public BinaryTree() : this(Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">for compare values in nodes</param>
        public BinaryTree(Comparer<T> comparer)
        {
            _head = null;
            Count = 0;
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="comparison">delegate for compare values</param>
        public BinaryTree(Comparison<T> comparison) : this(Comparer<T>.Create(comparison))
        {
        }

        /// <summary>
        /// Constructor initialize the instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="enumerable">Enumerable of elements.</param>
        public BinaryTree(IEnumerable<T> enumerable) : this()
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            foreach (var element in enumerable)
            {
                Add(element);
            }
        }
        #endregion // !public Constructors

        #region public Properties
        /// <summary>
        /// Count elements in binary tree.
        /// </summary>
        public int Count { get; private set; }
        #endregion // !public Properties

        #region public Methods
        /// <summary>
        /// Add value to the tree.
        /// </summary>
        /// <param name="value">adding value</param>
        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }

            Count++;
        }

        /// <summary>
        /// Clear values in binary tree.
        /// </summary>
        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        /// <summary>
        /// Check for contains value in binary tree.
        /// </summary>
        /// <param name="value">searching value</param>
        /// <returns>True if find, false otherwise.</returns>
        public bool Conatins(T value)
        {
            return FindWithParent(value, out _) != null;
        }

        /// <summary>
        /// Remove value from binary tree.
        /// </summary>
        /// <param name="value">removing value</param>
        /// <returns>True if remove success, false otherwise.</returns>
        public bool Remove(T value)
        {
            var current = FindWithParent(value, out var parent);

            if (current == null)
            {
                return false;
            }

            Count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    var result = _comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    var result = _comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                var leftMost = current.Right.Left;
                var leftMostParent = current.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftMost;
                }
                else
                {
                    var result = _comparer.Compare(parent.Value, current.Value);

                    if (result > 0)
                    {
                        parent.Left = leftMost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftMost;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Pre order bypass of binary tree.
        /// </summary>
        /// <returns>Enumerable of bypass.</returns>
        public IEnumerable<T> PreorderBypass()
        {
            BinaryTreeNode<T> current = _head;
            List<T> elements = new List<T>();

            Bypass(current, elements, 1);

            return elements;
        }

        /// <summary>
        /// In order bypass of binary tree.
        /// </summary>
        /// <returns>Enumerable of bypass.</returns>
        public IEnumerable<T> InorderBypass()
        {
            BinaryTreeNode<T> current = _head;
            List<T> elements = new List<T>();

            Bypass(current, elements, 2);

            return elements;
        }

        /// <summary>
        /// Post order bypass of binary tree.
        /// </summary>
        /// <returns>Enumerable of bypass.</returns>
        public IEnumerable<T> PostorderBypass()
        {
            BinaryTreeNode<T> current = _head;
            List<T> elements = new List<T>();

            Bypass(current, elements, 3);

            return elements;
        }
        #endregion // !public Methods 

        #region public Interface Methods
        /// <summary>
        /// Get IEnumerator of binary tree.
        /// </summary>
        /// <returns>IEnumerator of binary tree.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InorderBypass().GetEnumerator();
        }
        #endregion // !public Interface Mthods

        #region private Methods
        /// <summary>
        /// Get IEnumerator.
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Find value in binary tree and its parent.
        /// </summary>
        /// <param name="value">searching value</param>
        /// <param name="parent">parent of searching value</param>
        /// <returns>Node of searching value.</returns>
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            var current = _head;
            parent = null;

            while (current != null)
            {
                var result = _comparer.Compare(current.Value, value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        /// <summary>
        /// Add value to binary tree from node.
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="value">adding value</param>
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (_comparer.Compare(value, node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        /// <summary>
        /// Binary tree bypass.
        /// </summary>
        /// <param name="node">from node bypass</param>
        /// <param name="list">list for adding values</param>
        /// <param name="mode">mode of bypass</param>
        private void Bypass(BinaryTreeNode<T> node, List<T> list, int mode)
        {
            if (mode == 1)
            {
                list.Add(node.Value);
            }

            if (node.Left != null)
            {
                Bypass(node.Left, list, mode);
            }

            if (mode == 2)
            {
                list.Add(node.Value);
            }

            if (node.Right != null)
            {
                Bypass(node.Right, list, mode);
            }

            if (mode == 3)
            {
                list.Add(node.Value);
            }
        }
        #endregion // !private Methods
    }
}
