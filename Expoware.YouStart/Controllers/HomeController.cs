///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Expoware.YouStart.Application;
using Expoware.YouStart.Common.Exceptions;
using Expoware.YouStart.Models;
using Expoware.YouStart.Resources;

namespace Expoware.YouStart.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly HomeService _service = new HomeService();

        public ActionResult Index()
        {
            var model = _service.GetHomeViewModel();
            return View(model);
        }

        /// <summary>
        /// Generic error page to show in case of unhandled exceptions
        /// </summary>
        /// <returns>HTML</returns>
        [AllowAnonymous]
        public ActionResult Error(Exception exception)
        {
            var code = GetStatusCode(exception);
            Response.TrySkipIisCustomErrors = true;

            var message = String.Format(Strings_Errors.Msg_Error500, code);
            var line1 = String.Empty;
            var appSpecific = (exception is StarterKitException);

            if (code == 404)
            {
                message = Strings_Errors.Msg_Error404;
            }
            if (code == 500)
            {
                if (appSpecific)
                    message = exception.Message;
                else
                {
                    line1 = exception.Message;
                }
            }

            var model = new ErrorViewModel(message, appSpecific)
            {
                ErrorOccurred = { StatusCode = code, Line1 = line1 }

            };
            return View("error", model);
        }


        #region PRIVATE
        private static int GetStatusCode(Exception exception)
        {
            var httpException = exception as HttpException;
            return httpException != null ? httpException.GetHttpCode() : (int)HttpStatusCode.InternalServerError;
        }
        #endregion
    }
}