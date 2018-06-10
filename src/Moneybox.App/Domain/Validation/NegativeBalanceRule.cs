using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.App.Domain.Validation
{
    public class NegativeBalanceRule : IPayoutRule
    {
        public bool IsMatch( decimal paidOut)
        {
            return (paidOut < 0m);
        }

        public void Execute(Account account)
        {
            throw new InvalidOperationException("Insufficient funds to make transfer");
        }
    }
}
