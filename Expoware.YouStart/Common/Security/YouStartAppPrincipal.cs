///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System.Security.Principal;

namespace Expoware.YouStart.Common.Security
{
    public class YouStartAppPrincipal : IPrincipal
    {
        //private readonly User _theUser;
        //private readonly UserRepository _userRepository = new UserRepository();

        public YouStartAppPrincipal(IPrincipal user)
        {
            Identity = new GenericIdentity(user.Identity.Name);
            //_theUser = _userRepository.FindUserByName(Identity.Name);
        }

        #region IPrincipal
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (!Identity.IsAuthenticated)
                return false;
            if (string.IsNullOrWhiteSpace(role))
                return false;

            return true;
        }
        #endregion

        //public User LoggedUser
        //{
        //    get { return _theUser; }
        //}
    }
}