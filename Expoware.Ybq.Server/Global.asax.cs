///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Expoware.Ybq.Server.Common;
using Expoware.Ybq.Server.Common.Security;
using Expoware.Ybq.Server.Controllers;
using Expoware.Youbiquitous.Mvc.Filters;

namespace Expoware.Ybq.Server
{
    public class StarterKitApplication : HttpApplication
    {
        public static YbqAppSettings AppSettings { get; private set; }

        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CultureAttribute.Register();

            // Load configuration data
            AppSettings = YbqAppSettings.Initialize();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();
            InvokeErrorAction(httpContext, exception);
        }


        protected void Application_PostAuthenticateRequest()
        {
            var customPrincipal = new YbqAppPrincipal(User);
            HttpContext.Current.User = customPrincipal;
        }


        #region PRIVATE (Error handling)
        private static void InvokeErrorAction(HttpContext httpContext, Exception exception)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = "app";
            routeData.Values["action"] = "error";
            routeData.Values["exception"] = exception;

            using (var controller = new AppController())
            {
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
        }
        #endregion
    }
}
