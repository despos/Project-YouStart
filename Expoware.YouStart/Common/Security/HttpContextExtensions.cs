///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System.Web;

namespace Expoware.YouStart.Common.Security
{
    public static class HttpContextExtensions
    {
        public static YouStartAppPrincipal StarterKitPrincipal(this HttpContext context)
        {
            var appUser = context.User as YouStartAppPrincipal;
            if (appUser == null)
                return new YouStartAppPrincipal(context.User);
            return appUser;
        }

        public static YouStartAppPrincipal StarterKitPrincipal(this HttpContextBase context)
        {
            var appUser = context.User as YouStartAppPrincipal;
            if (appUser == null)
                return new YouStartAppPrincipal(context.User);
            return appUser;
        }
    }
}