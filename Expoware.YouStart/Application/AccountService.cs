///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System;
using Expoware.YouStart.Common.Security;
using Expoware.YouStart.Models.Account;
using Expoware.YouStart.Resources;

namespace Expoware.YouStart.Application
{
    public class AccountService
    {
        public AttemptedLoginResponse TryAuthenticate(LoginInputModel input)
        {
            var response = new AttemptedLoginResponse { Message = Strings_UI.Account_UnknownUser };

            if (String.IsNullOrWhiteSpace(input.Username) ||
                String.IsNullOrWhiteSpace(input.Password))
            {
                response.Message = Strings_UI.Account_IncompleteCredentials;
                return response;
            }

            // Check credentials
            response = ValidateCredentials(input.Username, input.Password);
            if (response.Success)
            {
                // Authenticate
                AppAuthentication.SignInWithApplication(response.Name, input.RememberMe);
            }

            return response;
        }


        private AttemptedLoginResponse ValidateCredentials(string name, string password)
        {
            return new AttemptedLoginResponse(true) { Name = name };
        }
    }
}