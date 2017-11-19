using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Tree
{
    /// <summary>
    /// Model of binary tree.
    /// </summary>
    /// <typeparam name="T">Type of elements in binary tree.</typeparam>
    public class BinaryTree<T>
    {
        #region private Fields

        private BinaryTreeNode<T> _head;
        private IComparer<T> _comparer;

        #endregion // !private Fields

        #region public Constructors
        public BinaryTree() : this(Comparer<T>.Default)
        {
        }

        public BinaryTree(Comparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            _head = null;
            Count = 0;
            _comparer = comparer;
        }

        #endregion // !public Constructors

        #region public Methods
        public int Count { get; private set; }

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

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public bool Conatins(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        public bool Remove(T value)
        {
            BinaryTreeNode<T> parent;

            var current = FindWithParent(value, out parent);

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

        public IEnumerable<T> PreoredBypass()
        {
            BinaryTreeNode<T> current = _head;
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();

            while (true)
            {
                yield return current.Value;
                if (current.Left != null)
                {
                    if (current.Right != null)
                    {
                        stack.Push(current.Right);
                    }

                    current = current.Left;
                    continue;
                }

                if (current.Right != null)
                {
                    current = current.Right;
                    continue;
                }

                if (stack.Count != 0)
                {
                    current = stack.Pop();
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
        #endregion // !public Methods 

        #region private Methods

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
        #endregion // !private Methods      
    }
}
