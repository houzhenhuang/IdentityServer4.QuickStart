using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.ViewModels.Account
{
    public class RegisterInputModel
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
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
    }
}
