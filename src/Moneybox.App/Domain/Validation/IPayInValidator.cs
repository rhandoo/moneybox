using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.App.Domain.Validation
{
    public interface IPayInValidator
    {
        void Validate(Account account, decimal payInAmount);
    }
}
