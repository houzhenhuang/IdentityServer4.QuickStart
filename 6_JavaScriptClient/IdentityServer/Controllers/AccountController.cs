using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using IdentityServer4.Test;
using IdentityServer.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using IdentityServer.Models;
using Microsoft.AspNetCore.Http;

namespace IdentityServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly TestUserStore _users;
        public AccountController(TestUserStore users)
        {
            _users = users;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var vm = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel loginInputModel)
        {
            if (ModelState.IsValid)
            {
                if (_users.ValidateCredentials(loginInputModel.Username, loginInputModel.Password))
                {
                    var user = _users.FindByUsername(loginInputModel.Username);
                    if (user == null)
                    {
                        ModelState.AddModelError("FindByUsername", "not exists user info");
                    }
                    else
                    {
                        AuthenticationProperties props = null;
                        if (loginInputModel.RememberLogin)
                        {
                            props = new AuthenticationProperties
                            {
                                IsPersistent = true,//是否持久化
                                ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration)//设置过期时间
                            };
                        }
                        await HttpContext.SignInAsync(user.SubjectId, user.Username, props);

                        return RedirectToLoacl(loginInputModel.ReturnUrl);
                    }
                }
                ModelState.AddModelError("ValidateCredentials", "validdate credential error");
            }
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            // delete local authentication cookie
            await HttpContext.SignOutAsync();

            return Redirect("~/");
        }
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            var vm = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Register(RegisterInputModel registerInputModel)
        {



            return View();
        }

        #region private method
        private IActionResult RedirectToLoacl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion
    }
}