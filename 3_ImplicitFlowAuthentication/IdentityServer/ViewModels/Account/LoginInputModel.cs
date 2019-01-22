using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.ViewModels.Account
{
    public class LoginInputModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 是否记住我的登录信息
        /// </summary>
        public bool RememberLogin { get; set; }
        /// <summary>
        /// 返回路径(登录成功后)
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
