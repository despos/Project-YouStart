///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System.Web.Security;

namespace Expoware.YouStart.Common.Security
{
    public class AppAuthentication
    {
        public static void SignInWithApplication(string username, bool rememberMe = true)
        {
            //var durationInHours = rememberMe ? 240 : 8;
            ////var userData = SerializeUserInfoInternal(user, rememberMe);

            //var authTicket = new FormsAuthenticationTicket(
            //    1,                                          // version number
            //    user.UserName,                              // name of the cookie
            //    DateTime.Now,                               // issue date
            //    DateTime.Now.AddHours(durationInHours),     // expiration
            //    true,                                       // survives browser sessions
            //    null);                                      // user data (serialized)

            //var ticket = FormsAuthentication.Encrypt(authTicket);
            //var cookie = FormsAuthentication.GetAuthCookie(FormsAuthentication.FormsCookieName, rememberMe);
            //cookie.Value = ticket;
            //HttpContext.Current.Response.Cookies.Add(cookie);
            FormsAuthentication.SetAuthCookie(username, rememberMe);
        }

        public static void SignOutFromApplication()
        {
            FormsAuthentication.SignOut();
        }
    }
}