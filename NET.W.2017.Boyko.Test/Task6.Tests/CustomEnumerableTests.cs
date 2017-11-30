using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Test6.Solution;

namespace Task6.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            int[] expected = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};

            Assert.That(expected, Is.EqualTo(Generator<int>.Generate(1, 1, (xn1, xn) => xn + xn1, expected.Length)));
        }

        [Test]
        public void Generator_ForSequence2()
        {
            int[] expected = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

            Assert.That(expected, Is.EqualTo(Generator<int>.Generate(1, 2, (xn1, xn) => 6 * xn - 8 * xn1, expected.Length)));
        }

        [Test]
        public void Generator_ForSequence3()
        {
            double[] expected = { 1, 2, 2.5, 3.3, 4.05757575757576, 4.87086926018965, 5.70389834408211, 6.55785277425587, 7.42763417076325, 8.31053343902137 };

            List<double> generateEl = Generator<double>.Generate(1, 2, (xn1, xn) => xn + xn1 / xn, expected.Length).ToList();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], generateEl[i], 0.000001);
            }
        }
    }
}
