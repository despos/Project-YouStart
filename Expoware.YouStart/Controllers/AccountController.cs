///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System;
using System.Web.Mvc;
using Expoware.YouStart.Application;
using Expoware.YouStart.Common;
using Expoware.YouStart.Common.Security;
using Expoware.YouStart.Models;
using Expoware.YouStart.Models.Account;
using Expoware.YouStart.Resources;

namespace Expoware.YouStart.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _service = new AccountService();

        /// <summary>
        /// Presents the LOGIN page
        /// </summary>
        /// <returns>Redirect</returns>
        [HttpGet]
        public ActionResult Login()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        /// <summary>
        /// Validate provided credentials
        /// </summary>
        /// <param name="input">Values of the login input form</param>
        /// <returns>JSON command response</returns>
        [HttpPost]
        public JsonResult Auth(LoginInputModel input)
        {
            if (String.IsNullOrWhiteSpace(input.Username) || String.IsNullOrWhiteSpace(input.Password))
                return Json(CommandResponse.Fail);

            var response = _service.TryAuthenticate(input);

            if (response.Success)
            {
                AppAuthentication.SignInWithApplication(response.Name);
                return Json(CommandResponse.Ok.AddRedirectUrl(Url.Action("index", "home")));
            }

            return Json(CommandResponse.Fail.AddMessage(response.Message));
        }

        /// <summary>
        /// Logs current user out
        /// </summary>
        /// <returns>Redirect</returns>
        public ActionResult Logout()
        {
            AppAuthentication.SignOutFromApplication();
            return RedirectToAction("index", "home");
        }

        /// <summary>
        /// Presents the RECOVER PASSWORD page
        /// </summary>
        /// <returns>Redirect</returns>
        [HttpGet]
        public ActionResult Recover()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        /// <summary>
        /// Resets the password
        /// </summary>
        /// <param name="email">Email address to send new password</param>
        /// <returns>Redirect</returns>
        [HttpPost]
        public JsonResult Recover(string email)
        {
            // Do some work and return
            var success = DateTime.Now.Second % 2;
            if (success > 0)
                return Json(CommandResponse.Ok.AddMessage(Strings_UI.Account_PassworcChanged));

            return Json(CommandResponse.Fail.AddMessage(Strings_UI.Account_CouldntChangePassword));
        }

        #region PRIVATE

        #endregion
    }
}