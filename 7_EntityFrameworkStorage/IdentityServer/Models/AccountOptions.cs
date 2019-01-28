using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AccountOptions
    {
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromMinutes(30);
    }
}
