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
        public static StarterKitPrincipal StarterKitPrincipal(this HttpContext context)
        {
            var appUser = context.User as StarterKitPrincipal;
            if (appUser == null)
                return new StarterKitPrincipal(context.User);
            return appUser;
        }

        public static StarterKitPrincipal StarterKitPrincipal(this HttpContextBase context)
        {
            var appUser = context.User as StarterKitPrincipal;
            if (appUser == null)
                return new StarterKitPrincipal(context.User);
            return appUser;
        }
    }
}