///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

namespace Expoware.YouStart.Models.Account
{
    public class LoginInputModel
    {
        public LoginInputModel()
        {
            RememberMe = true;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}