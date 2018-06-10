﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.App.Domain.Validation
{
    public interface IPayoutRule
    {
        bool IsMatch(decimal amount);
        void Execute(Account account);
    }
}
