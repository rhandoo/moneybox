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
    public class PayoutValidatorUnitTest
    {
        private PayoutValidator payoutValidator;

        [TestInitialize]
        public void SetUp()
        {
            this.payoutValidator = new PayoutValidator();
        }

        [TestMethod]
        public void WhenValidateNegativeBalanceThrowException()
        {
            //Arrange
            decimal amount = -100m;
            var account = Fakes.AccountFake.GetAccount(new Mock<IPayoutValidator>().Object, new Mock<IPayInValidator>().Object);

            //Act
            try
            {
                this.payoutValidator.Validate(account, amount);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is InvalidOperationException);
            }
        }

    }
}
