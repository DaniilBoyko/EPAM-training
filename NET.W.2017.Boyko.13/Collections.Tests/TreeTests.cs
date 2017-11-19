using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Collections.Tests
{
    [TestFixture]
    public class TreeTests
    {
        [TestCase(new int[] { 5, 1, 4, 9 }, ExpectedResult = 4)]
        [TestCase(new int[] { 5, 4, 9 }, ExpectedResult = 3)]
        [TestCase(new int[] { 5, 9 }, ExpectedResult = 2)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        public int CountMethod_CreateTreeAndGetCountElements(int[] array)
        {
            Tree.BinaryTree<int> binaryTree = new Tree.BinaryTree<int>();
            foreach (var element in array)
            {
                binaryTree.Add(element);
            }

            return binaryTree.Count;
        }

        [TestCase(new int[] { 5, 1, 4, 9 }, 9, ExpectedResult = true)]
        [TestCase(new int[] { 5, 4, 9 }, 9, ExpectedResult = true)]
        [TestCase(new int[] { 5, 9 }, 4, ExpectedResult = false)]
        [TestCase(new int[] { }, 3, ExpectedResult = false)]
        public bool ContainsMethod_CreateTreeAndCheckForContainsElement(int[] array, int value)
        {
            Tree.BinaryTree<int> binaryTree = new Tree.BinaryTree<int>();
            foreach (var element in array)
            {
                binaryTree.Add(element);
            }

            return binaryTree.Conatins(value);
        }

        [TestCase(new int[] { 5, 9, 4, 1 }, ExpectedResult = new int[] { 5, 4, 1, 9 })]
        [TestCase(new int[] { 5, 4, 9 }, ExpectedResult = new int[] { 5, 4, 9 })]
        public int[] PreoredBypassMethod_CreateTreeAndGetIsPreoredBypass(int[] array)
        {
            Tree.BinaryTree<int> binaryTree = new Tree.BinaryTree<int>();
            foreach (var element in array)
            {
                binaryTree.Add(element);
            }

            int[] result = new int[array.Length];
            int i = 0;

            foreach (var value in binaryTree.PreoredBypass())
            {
                result[i++] = value;
            }

            return result;
        }
    }
}
