///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Expoware.YouStart.Common;
using Expoware.YouStart.Controllers;

namespace Expoware.YouStart
{
    public class StarterKitApplication : HttpApplication
    {
        public static YouStartAppSettings AppSettings { get; private set; }

        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Load configuration data
            AppSettings = YouStartAppSettings.Initialize();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();
            InvokeErrorAction(httpContext, exception);
        }


        //protected void Application_PostAuthenticateRequest()
        //{
        //    var customPrincipal = new YouStartAppPrincipal(User);
        //    HttpContext.Current.User = customPrincipal;
        //}


        #region PRIVATE (Error handling)
        private static void InvokeErrorAction(HttpContext httpContext, Exception exception)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = "home";
            routeData.Values["action"] = "error";
            routeData.Values["exception"] = exception;

            using (var controller = new HomeController())
            {
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
        }
        #endregion
    }
}
