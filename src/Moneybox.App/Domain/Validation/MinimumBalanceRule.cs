using Moneybox.App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.App.Domain.Validation
{
    public class MinimumBalanceRule : IPayoutRule
    {
        private INotificationService notificationService;

        public MinimumBalanceRule() : this(new NotificationService()) // TODO: Get the NotificationService reference From IOC
        { }

        public MinimumBalanceRule(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        
        public bool IsMatch(decimal paidOut)
        {
            return (paidOut < 500m);
        }

        public void Execute(Account account)
        {
            this.notificationService.NotifyFundsLow(account.User.Email);
        }
    }
}
