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
    public class WithdrawMoneyUnitTest
    {
        private Mock<IAccountRepository> mockAccountRepository;
        
        private Mock<IPayoutValidator> mockPayOutValidator;
        private Mock<IPayInValidator> mockPayInValidator;


        private WithdrawMoney withdrawMoney;

        [TestInitialize]
        public void SetUp()
        {
            mockAccountRepository = new Mock<IAccountRepository>();
            mockPayOutValidator = new Mock<IPayoutValidator>();
            mockPayInValidator = new Mock<IPayInValidator>();

            this.withdrawMoney = new WithdrawMoney(mockAccountRepository.Object);
        }

        [TestMethod]
        public void WhenWithdrawMoneyFromAccountIsSuccessful()
        {
            //Arrange
            var accountId = new Guid();
            decimal amount = 1000m;

            mockAccountRepository.Setup(x => x.GetAccountById(It.IsAny<Guid>())).Returns(Fakes.AccountFake.GetAccount(mockPayOutValidator.Object, mockPayInValidator.Object));

            //Act
            this.withdrawMoney.Execute(accountId, amount);

            //Assert
            mockAccountRepository.Verify(s => s.Update(It.IsAny<Account>()));
        }

    }

}
