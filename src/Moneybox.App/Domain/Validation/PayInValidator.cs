using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.App.Domain.Validation
{
    public class PayInValidator : IPayInValidator
    {
        private readonly IList<IPayInRule> payoutRules = new List<IPayInRule>();

        public PayInValidator()
        {
            payoutRules.Add(new ExcessDepositRule());
            payoutRules.Add(new MaximumDepositRule());
        }

        public void Validate(Account account, decimal payInAmount)
        {
            payoutRules.First(x => x.IsMatch(payInAmount)).Execute(account);
        }
    }
}
