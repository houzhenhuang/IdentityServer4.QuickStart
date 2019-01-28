using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.ViewModels.Account
{
    public class LoginViewModel:LoginInputModel
    {
        /// <summary>
        /// 是否允许 记住我的登录信息
        /// </summary>
        public bool AllowRememberLogin { get; set; } = true;
    }
}
