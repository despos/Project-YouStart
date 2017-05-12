///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using Expoware.YouStart.Models.Home;

namespace Expoware.YouStart.Application
{
    public class HomeService
    {
        public HomeViewModel GetHomeViewModel()
        {
            var model = new HomeViewModel();
            return model;
        }
    }
}