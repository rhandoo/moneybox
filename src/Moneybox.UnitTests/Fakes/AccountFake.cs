using Moneybox.App;
using Moneybox.App.Domain.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.UnitTests.Fakes
{
    public class AccountFake
    {
        public static Account GetAccount(IPayoutValidator payoutValidator, IPayInValidator payInValidator)
        {
            return new Account(payoutValidator, payInValidator) { Id = new Guid(), Balance = 300, PaidIn = 100, User = UserFake.GetUser(), Withdrawn = 50 };
        }


    }
}
