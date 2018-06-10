using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.App.Domain.Validation
{
    public class ExcessDepositRule : IPayInRule
    {

        public bool IsMatch(decimal paidIn)
        {
            
            return (paidIn > Account.PayInLimit);

        }

        public void Execute(Account account)
        {
                throw new InvalidOperationException("Account pay in limit reached");
        }

    }
}
