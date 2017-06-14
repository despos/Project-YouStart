///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Expoware.Ybq.Server.Models.Home;

namespace Expoware.Ybq.Server.Application
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