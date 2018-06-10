using Moneybox.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneybox.UnitTests.Fakes
{
    public class UserFake
    {
        public static User GetUser()
        {
            return (new User() {Email="test@yahoo.com",Id=Guid.NewGuid(),Name="TestUser1" });
        }

    }
}
