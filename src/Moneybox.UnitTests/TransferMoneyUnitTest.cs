using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using Moneybox.App.Features;
using Moq;
using Moneybox.App.Domain.Validation;
using Moneybox.App;

namespace Moneybox.UnitTests
{
    [TestClass()]
    public class TransferMoneyUnitTest
    {
        private Mock<IAccountRepository> mockAccountRepository;
        private Mock<IPayoutValidator> mockPayOutValidator;
        private Mock<IPayInValidator> mockPayInValidator;
        


        private TransferMoney transferMoney;

        [TestInitialize]
        public void SetUp()
        {
            mockAccountRepository = new Mock<IAccountRepository>();
         
            mockPayOutValidator = new Mock<IPayoutValidator>();
            mockPayInValidator = new Mock<IPayInValidator>();

            this.transferMoney = new TransferMoney(mockAccountRepository.Object);
        }

        [TestMethod]
        public void WhenTransferMoneyInAccountIsSuccessful()
        {
            //Arrange
            
            decimal amount = 1000m;
            var fromAccountId  = new Guid();
            var toAccountId = new Guid();
            var account = Fakes.AccountFake.GetAccount(mockPayOutValidator.Object, mockPayInValidator.Object);

            mockAccountRepository.Setup(x => x.GetAccountById(It.IsAny<Guid>())).Returns(account);

            //Act
            this.transferMoney.Execute(fromAccountId, toAccountId, amount);

            //Assert
            mockAccountRepository.Verify(s => s.Update(It.IsAny<Account>()));
            
        }
    }
}
