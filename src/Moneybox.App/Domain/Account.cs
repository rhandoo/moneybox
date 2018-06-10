using Moneybox.App.Domain.Services;
using Moneybox.App.Domain.Validation;
using System;

namespace Moneybox.App
{
    public class Account
    {
        private IPayoutValidator payoutValidator;
        private IPayInValidator payInValidator;

        public Account(IPayoutValidator payoutValidator, IPayInValidator payInValidator)
        {
            this.payoutValidator = payoutValidator;
            this.payInValidator = payInValidator;
        }

        public const decimal PayInLimit = 4000m;

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; set; }

        public decimal Withdrawn { get; set; }

        public decimal PaidIn { get; set; }


        public void Withdraw(decimal amount)
        {

            var balance = this.Balance - amount;
            this.payoutValidator.Validate(this, balance);
            this.Balance = this.Balance - amount;
            this.Withdrawn = this.Withdrawn - amount;

        }


        public void Deposit(decimal amount)
        {
            var paidIn = this.PaidIn + amount;
            this.payInValidator.Validate(this, paidIn);
            this.Balance = this.Balance + amount;
            this.PaidIn = this.PaidIn + amount;
        }
    }
}
