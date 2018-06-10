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
    public class AccountUnitTests
    {

        private Mock<IPayoutValidator> mockPayOutValidator;
        private Mock<IPayInValidator> mockPayInValidator;


        private Account account;

        [TestInitialize]
        public void SetUp()
        {
            
            mockPayOutValidator = new Mock<IPayoutValidator>();
            mockPayInValidator = new Mock<IPayInValidator>();
        }

        [TestMethod]
        public void WhenWithdrawValidBalanceIsSuccessful()
        {
            //Arrange
            
            this.account = Fakes.AccountFake.GetAccount(mockPayOutValidator.Object, mockPayInValidator.Object);
            decimal withdrawAmount = 300m;
            decimal balance = 1000m;
            this.account.Balance = balance;

            //Act
            this.account.Withdraw(withdrawAmount);

            //Assert
            Assert.IsTrue(this.account.Balance == balance - withdrawAmount);
        }

        [TestMethod]
        public void WhenDepositValidBalanceIsSuccessful()
        {
            //Arrange

            this.account = Fakes.AccountFake.GetAccount(mockPayOutValidator.Object, mockPayInValidator.Object);
            decimal paidInAmount = 300m;
            decimal balance = 1000m;
            this.account.Balance = balance;

            //Act
            this.account.Deposit(paidInAmount);

            //Assert
            Assert.IsTrue(this.account.Balance == balance + paidInAmount);
            Assert.IsTrue(this.account.PaidIn == paidInAmount);
        }

    }
}


