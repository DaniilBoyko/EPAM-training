using BLL.Interfaces;
using BLL.Interfaces.Entities.Exceptions;
using BLL.Services;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using Moq;
using NUnit.Framework;

namespace BLL.Tests.Services
{
    [TestFixture]
    public class BankServiceTests
    {
        [Test]
        public void Test_CreateNewAccount_Calls_Create_And_Commit_And_Generate()
        {
            // Aragne
            var accountRepository = new Mock<IAccountRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var generateId = new Mock<IGenerateId>();

            var bankService = new BankService(unitOfWork.Object, accountRepository.Object, generateId.Object);

            // Act
            bankService.CreateNewAccount("Gold", "Daniil", "Boyko");

            // Assert
            // Check that Commit method of IUnitOfWork was called.
            unitOfWork.Verify(uow => uow.Commit(), Times.Once);

            // Check that Create method of IAccountRepository was called.
            accountRepository.Verify(ar => ar.Create(It.IsAny<DalAccount>()), Times.Once);

            // Check taht Generate methods of IGenerateId was called.
            generateId.Verify(gi => gi.Generate(), Times.Once);
        }

        [Test]
        public void Test_DepositToAccount_Calls_Update_And_Commit()
        {
            // Aragne
            var accountRepository = new Mock<IAccountRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var bankService = new BankService(unitOfWork.Object, accountRepository.Object);
            bankService.CreateNewAccount("Gold", "Daniil", "Boyko");

            // Act
            bankService.DepositToAccount(100);

            // Assert
            // Check that Commit method of IUnitOfWork was called.
            unitOfWork.Verify(uow => uow.Commit(), Times.AtLeast(2));

            // Check that Update method of IAccountRepository was called.
            accountRepository.Verify(ar => ar.Update(It.IsAny<DalAccount>()));
        }

        [Test]
        public void Test_WithdrawFromAccount_Calls_Update_And_Commit()
        {
            // Aragne
            var accountRepository = new Mock<IAccountRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var bankService = new BankService(unitOfWork.Object, accountRepository.Object);
            bankService.CreateNewAccount("Gold", "Daniil", "Boyko", 1000);

            // Act
            bankService.WithdrawFromAccount(100);

            // Assert
            // Check that Commit method of IUnitOfWork was called.
            unitOfWork.Verify(uow => uow.Commit(), Times.AtLeast(2));

            // Check that Update method of IAccountRepository was called.
            accountRepository.Verify(ar => ar.Update(It.IsAny<DalAccount>()));
        }

        [Test]
        public void Test_DeleteAccount_Calls_DeleteAccount_And_Commit()
        {
            // Aragne
            var accountRepository = new Mock<IAccountRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var bankService = new BankService(unitOfWork.Object, accountRepository.Object);
            bankService.CreateNewAccount("Gold", "Daniil", "Boyko");

            // Act
            bankService.DeleteAccount();

            // Assert
            // Check that Commit method of IUnitOfWork was called.
            unitOfWork.Verify(uow => uow.Commit(), Times.AtLeast(2));

            // Check that Delete method of IAccountRepository was called.
            accountRepository.Verify(ar => ar.Delete(It.IsAny<DalAccount>()));
        }

        [TestCase("124123")]
        [TestCase("1451234")]
        public void Test_SelectAccount_Calls_SelectAccount_And_Commit(string id)
        {
            // Aragne
            var accountRepository = new Mock<IAccountRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var bankService = new BankService(unitOfWork.Object, accountRepository.Object);

            // Act
            try
            {
                bankService.SelectAccount(id);
            }
            catch (AccountNotFoundException)
            {
            }

            // Assert
            // Check that GetById method of IAccountRepository was called.
            accountRepository.Verify(ar => ar.GetById(id));
        }

        [Test]
        public void Test_CreateNewAccount_NewAccountAddedToTheRepository()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var fakeAccountRepository = new Fakes.FakeAccountRepository();
            BankService bankService = new BankService(unitOfWork.Object, fakeAccountRepository, new Fakes.GenerateIdEasy());

            // Act
            bankService.CreateNewAccount("Gold", "Daniil", "Boyko", 1000);

            // Asser
            Assert.That(fakeAccountRepository.GetById("1") != null);
        }

        [Test]
        public void Test_DepositToAccount_DepositMoneyToAccount()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var fakeAccountRepository = new Fakes.FakeAccountRepository();
            BankService bankService = new BankService(unitOfWork.Object, fakeAccountRepository, new Fakes.GenerateIdEasy());
            bankService.CreateNewAccount("Gold", "Daniil", "Boyko", 1000);

            // Act
            bankService.DepositToAccount(1000);

            // Asser
            Assert.That(fakeAccountRepository.GetById("1").Amount - 2000 < double.Epsilon);
        }

        [Test]
        public void Test_WithdrawFromAccount_WithdrawMoneyFromAccount()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var fakeAccountRepository = new Fakes.FakeAccountRepository();
            BankService bankService = new BankService(unitOfWork.Object, fakeAccountRepository, new Fakes.GenerateIdEasy());
            bankService.CreateNewAccount("Gold", "Daniil", "Boyko", 1000);

            // Act
            bankService.WithdrawFromAccount(1000);

            // Asser
            Assert.That(fakeAccountRepository.GetById("1").Amount - 0 < double.Epsilon);
        }

        [Test]
        public void Test_SelectAccount_SelectAccountForWorkWith()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var fakeAccountRepository = new Fakes.FakeAccountRepository();
            BankService bankService = new BankService(unitOfWork.Object, fakeAccountRepository, new Fakes.GenerateIdEasy());
            bankService.CreateNewAccount("Gold", "Daniil", "Boyko", 1000);
            bankService.CreateNewAccount("Base", "Piter", "Melow", 123);

            // Act
            bankService.SelectAccount("1");
            bankService.DepositToAccount(100);

            // Asser
            Assert.That(fakeAccountRepository.GetById("1").Amount - 1100 < double.Epsilon);
        }

        [Test]
        public void Test_DeleteAccount_DeleteCurrentAccount()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var fakeAccountRepository = new Fakes.FakeAccountRepository();
            BankService bankService = new BankService(unitOfWork.Object, fakeAccountRepository, new Fakes.GenerateIdEasy());
            bankService.CreateNewAccount("Gold", "Daniil", "Boyko", 1000);
            bankService.CreateNewAccount("Base", "Piter", "Melow");

            // Act
            bankService.DeleteAccount();

            // Asser
            Assert.That(fakeAccountRepository.GetById("2") == null);
        }
    }
}
