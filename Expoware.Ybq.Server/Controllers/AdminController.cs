///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Web.Mvc;
using Expoware.Ybq.Server.Application;

namespace Expoware.Ybq.Server.Controllers
{
    [Authorize]
    public class AdminController : AppController
    {
        private readonly HomeService _service = new HomeService();

        public ActionResult Index()
        {
            var model = _service.GetHomeViewModel();
            return View(model);
        }
    }
}