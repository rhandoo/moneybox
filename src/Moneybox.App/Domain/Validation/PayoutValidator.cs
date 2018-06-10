using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.App.Domain.Validation
{
    public class PayoutValidator: IPayoutValidator
    {
        private readonly IList<IPayoutRule> payoutRules =  new List<IPayoutRule>();

        public PayoutValidator()
        {
            this.payoutRules.Add(new NegativeBalanceRule());
            this.payoutRules.Add(new MinimumBalanceRule());
        }

        public void Validate(Account account, decimal payoutAmount)
        {
            this.payoutRules.First(x => x.IsMatch(payoutAmount)).Execute(account);
        }
    }
}
