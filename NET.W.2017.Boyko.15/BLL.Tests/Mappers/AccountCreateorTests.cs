using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities.Account;
using BLL.Mappers;
using NUnit.Framework;

namespace BLL.Tests.Mappers
{
    [TestFixture]
    public class AccountCreateorTests
    {
        [TestCase(typeof(BaseAccount), "Base", "12345", "Daniil", "Boyko", 1000, 100)]
        [TestCase(typeof(GoldAccount), "Gold", "12345", "Daniil", "Boyko", 1000, 100)]
        [TestCase(typeof(PlatinumAccount), "Platinum", "12345", "Daniil", "Boyko", 1000, 100)]
        public void Test_CreateAccount(Type t, string type, string id, string name, string surname, double amout, int points)
        {
            Account account = AccountCreator.CreateAccount(type, id, name, surname, amout, points);

            Assert.That(account.GetType, Is.EqualTo(t));
            Assert.That(account.Name, Is.EqualTo(name));
            Assert.That(account.Id, Is.EqualTo(id));
            Assert.That(account.Surname, Is.EqualTo(surname));
            Assert.That(account.Amount, Is.EqualTo(amout));
            Assert.That(account.Points, Is.EqualTo(points));
        }

        [TestCase(typeof(BaseAccount), AccountCreator.AccountType.Base, "12345", "Daniil", "Boyko", 1000, 100)]
        [TestCase(typeof(GoldAccount), AccountCreator.AccountType.Gold, "12345", "Daniil", "Boyko", 1000, 100)]
        [TestCase(typeof(PlatinumAccount), AccountCreator.AccountType.Platinum, "12345", "Daniil", "Boyko", 1000, 100)]
        public void Test_CreateAccount(Type t, AccountCreator.AccountType type, string id, string name, string surname, double amout, int points)
        {
            Account account = AccountCreator.CreateAccount(type, id, name, surname, amout, points);

            Assert.That(account.GetType, Is.EqualTo(t));
            Assert.That(account.Name, Is.EqualTo(name));
            Assert.That(account.Id, Is.EqualTo(id));
            Assert.That(account.Surname, Is.EqualTo(surname));
            Assert.That(account.Amount, Is.EqualTo(amout));
            Assert.That(account.Points, Is.EqualTo(points));
        }
    }
}
