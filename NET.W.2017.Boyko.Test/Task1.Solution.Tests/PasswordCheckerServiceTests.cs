using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Task1.Solution.Tests
{
    [TestFixture]
    class PasswordCheckerServiceTests
    {
        [Test]
        public void Test_CreatePasswordCheckerService_Call_Repository()
        {
            // Arrage
            var repository = new Mock<IRepository>();
            var checker = new PasswordCheckerService(repository.Object);
            ConditionCreator conditionCreator = new ConditionCreator();
            conditionCreator.AddConditions(str => str == string.Empty, "Password is empty");

            // Act
            checker.VerifyPassword(conditionCreator.GetConditions(), "234");

            // Assert
            repository.Verify(rep => rep.Create("234"), Times.Once);
        }

        [Test]
        public void Test_VerifyPassword_Check_Working_Of_Method()
        {
            // Arrage
            var repository = new Mock<IRepository>();
            var checker = new PasswordCheckerService(repository.Object);
            ConditionCreator conditionCreator = new ConditionCreator();
            conditionCreator.AddConditions(str => str == string.Empty, "Password is empty");
            conditionCreator.AddConditions(str => str.Length <= 7, "Password length too short");
            conditionCreator.AddConditions(str => str.Length >= 15, "Password length too long");
            conditionCreator.AddConditions(str => !str.Any(char.IsLetter), "Password hasn't alphanumerical chars");
            conditionCreator.AddConditions(str => !str.Any(char.IsNumber), "Password hasn't digits");



            // Assert
            Assert.That("Password is empty", Is.EqualTo(checker.VerifyPassword(conditionCreator.GetConditions(), string.Empty).Item2));
            Assert.That("Password length too short", Is.EqualTo(checker.VerifyPassword(conditionCreator.GetConditions(), "asdf").Item2));
            Assert.That("Password length too long", Is.EqualTo(checker.VerifyPassword(conditionCreator.GetConditions(), "asasdfassdfasdfdf").Item2));
            Assert.That("Password hasn't alphanumerical chars", Is.EqualTo(checker.VerifyPassword(conditionCreator.GetConditions(), "12345678").Item2));
            Assert.That("Password hasn't digits", Is.EqualTo(checker.VerifyPassword(conditionCreator.GetConditions(), "asdfghjk").Item2));
        }
    }
}
