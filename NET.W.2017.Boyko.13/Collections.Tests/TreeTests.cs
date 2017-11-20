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

            foreach (var value in binaryTree.PreorderBypass())
            {
                result[i++] = value;
            }

            return result;
        }

        [TestCase(new int[] { 5, 9, 4, 1 }, ExpectedResult = new int[] { 1, 4, 5, 9 })]
        [TestCase(new int[] { 5, 4, 9 }, ExpectedResult = new int[] { 4, 5, 9 })]
        public int[] InoredBypassMethod_CreateTreeAndGetItInoredBypass(int[] array)
        {
            Tree.BinaryTree<int> binaryTree = new Tree.BinaryTree<int>();
            foreach (var element in array)
            {
                binaryTree.Add(element);
            }

            int[] result = new int[array.Length];
            int i = 0;

            foreach (var value in binaryTree.InorderBypass())
            {
                result[i++] = value;
            }

            return result;
        }

        [TestCase]
        public void InoredBypassMethod_CreateTreeWithStringAndGetItInoredBypass()
        {
            string[] elements = new string[] { "fffff", "kkkkkkkkk", "aaaa", "c" };
            string[] expectedResult = new string[] { "c", "aaaa", "fffff", "kkkkkkkkk" };

            Tree.BinaryTree<string> binaryTree = new Tree.BinaryTree<string>((left, right) => left.Length.CompareTo(right.Length));
            foreach (var element in elements)
            {
                binaryTree.Add(element);
            }

            string[] result = new string[elements.Length];
            int i = 0;

            foreach (var value in binaryTree.InorderBypass())
            {
                result[i++] = value;
            }

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(new int[] { 5, 3, 4 }, ExpectedResult = new int[] { 4, 3, 5 })]
        [TestCase(new int[] { 5, 4, 9 }, ExpectedResult = new int[] { 4, 9, 5 })]
        public int[] PostoredBypassMethod_CreateTreeAndGetItPostoredBypass(int[] array)
        {
            Tree.BinaryTree<int> binaryTree = new Tree.BinaryTree<int>();
            foreach (var element in array)
            {
                binaryTree.Add(element);
            }

            int[] result = new int[array.Length];
            int i = 0;

            foreach (var value in binaryTree.PostorderBypass())
            {
                result[i++] = value;
            }

            return result;
        }
    }
}
