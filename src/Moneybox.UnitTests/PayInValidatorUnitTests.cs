using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moneybox.App.Domain.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.UnitTests
{


    [TestClass()]
    public class PayInValidatorUnitTests
    {
        private PayInValidator payInValidator;

        [TestInitialize]
        public void SetUp()
        {
            this.payInValidator = new PayInValidator();
        }

        [TestMethod]
        public void WhenValidateExceedsDepositThrowException()
        {
            //Arrange
            decimal amount = 10000m;
            var account = Fakes.AccountFake.GetAccount(new Mock<IPayoutValidator>().Object, new Mock<IPayInValidator>().Object);

            //Act
            try
            {
                this.payInValidator.Validate(account, amount);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is InvalidOperationException);
            }
        }

    }

}
