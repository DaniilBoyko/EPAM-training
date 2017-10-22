using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecialFunctions.Tests
{
    [TestClass]
    public class FunctionsTests
    {
        [TestMethod]
        public void InsertNumberMethod_1InsertInto1From31To31_Mines2147483647Returned()
        {
            //Arrange
            int numberSource = 1;
            int numberInsert = 1;
            int fromPosition = 31;
            int toPosition = 31;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);

            //Assert
            Assert.AreEqual(-2147483647, result);
        }

        [TestMethod]
        public void InsertNumberMethod_1InsertInto1From30To30_1073741825Returned()
        {
            //Arrange
            int numberSource = 1;
            int numberInsert = 1;
            int fromPosition = 30;
            int toPosition = 30;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);

            //Assert
            Assert.AreEqual(1073741825, result);
        }
        
        [TestMethod]
        public void InsertNumberMethod_16InsertInto16From0To4_16Returned()
        {
            //Arrange
            int numberSource = 16;
            int numberInsert = 16;
            int fromPosition = 0;
            int toPosition = 4;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);

            //Assert
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void InsertNumberMethod_15InsertInto15From0To0_15Returned()
        {
            //Arrange
            int numberSource = 15;
            int numberInsert = 15;
            int fromPosition = 0;
            int toPosition = 0;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);

            //Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void InsertNumberMethod_15InsertInto8From0To0_9Returned()
        {
            //Arrange
            int numberSource = 8;
            int numberInsert = 15;
            int fromPosition = 0;
            int toPosition = 0;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);

            //Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void InsertNumberMethod_15InsertInto8From3To8_120Returned()
        {
            //Arrange
            int numberSource = 8;
            int numberInsert = 15;
            int fromPosition = 3;
            int toPosition = 8;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);

            //Assert
            Assert.AreEqual(120, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberMethod_15InsertInto8FromMines3To8_ReturnedArgumentAoutOfRangeException()
        {
            //Arrange
            int numberSource = 8;
            int numberInsert = 15;
            int fromPosition = -3;
            int toPosition = 8;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberMethod_15InsertInto8From3ToMines8_ReturnedArgumentAoutOfRangeException()
        {
            //Arrange
            int numberSource = 8;
            int numberInsert = 15;
            int fromPosition = 3;
            int toPosition = -8;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberMethod_15InsertInto8From3To32_ReturnedArgumentAoutOfRangeException()
        {
            //Arrange
            int numberSource = 8;
            int numberInsert = 15;
            int fromPosition = 3;
            int toPosition = 32;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberMethod_15InsertInto8From8To3_ReturnedArgumentException()
        {
            //Arrange
            int numberSource = 8;
            int numberInsert = 15;
            int fromPosition = 8;
            int toPosition = 3;

            //Act
            int result = Functions.InsertNumber(numberSource, numberInsert, fromPosition, toPosition);
        }
    }
}
