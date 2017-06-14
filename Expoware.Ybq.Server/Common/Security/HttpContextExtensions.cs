﻿///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Web;

namespace Expoware.Ybq.Server.Common.Security
{
    public static class HttpContextExtensions
    {
        public static YbqAppPrincipal YouStartAppPrincipal(this HttpContext context)
        {
            var appUser = context.User as YbqAppPrincipal;
            if (appUser == null)
                return new YbqAppPrincipal(context.User);
            return appUser;
        }

        public static YbqAppPrincipal YouStartAppPrincipal(this HttpContextBase context)
        {
            var appUser = context.User as YbqAppPrincipal;
            if (appUser == null)
                return new YbqAppPrincipal(context.User);
            return appUser;
        }
    }
}