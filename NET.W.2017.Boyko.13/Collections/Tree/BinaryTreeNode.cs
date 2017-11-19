using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Tree
{
    public class BinaryTreeNode<T>
    {
        #region public Constructors
        public BinaryTreeNode(T value)
        {
            Value = value;
        }
        #endregion // !public Constructors

        #region public Properties

        public BinaryTreeNode<T> Left { get; internal set; }

        public BinaryTreeNode<T> Right { get; internal set; }

        public T Value { get; }

        #endregion
    }
}
