///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

namespace Expoware.YouStart.Common.Security
{
    public class AttemptedLoginResponse
    {
        public AttemptedLoginResponse(bool success = false)
        {
            Success = success;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
    }
}