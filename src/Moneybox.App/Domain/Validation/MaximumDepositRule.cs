using Moneybox.App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.App.Domain.Validation
{
    public class MaximumDepositRule : IPayInRule
    {
        private INotificationService notificationService;

        public MaximumDepositRule() : this(new NotificationService()) // TODO: Get the NotificationService reference From IOC
        { }

        public MaximumDepositRule(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public bool IsMatch(decimal paidIn)
        {
            return (Account.PayInLimit - paidIn < 500m);
        }

        public void Execute(Account account)
        {
            this.notificationService.NotifyApproachingPayInLimit(account.User.Email);
        }


    }
}
