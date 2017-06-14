﻿///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Expoware.Ybq.Server.Common;
using Expoware.Ybq.Server.Common.Exceptions;
using Expoware.Ybq.Server.Models;
using Expoware.Ybq.Server.Models.Sample;
using Expoware.Ybq.Server.Resources;
using Expoware.Youbiquitous.Mvc.Filters;

namespace Expoware.Ybq.Server.Controllers
{
    //[Authorize]
    public class SampleController : AppController
    {
        public ActionResult Throw()
        {
            throw new YbqAppException("Deliberate exception",
                "http://www.google.com", "http://www.stackoverflow.com");
        }

        public async Task<ActionResult> Download()
        {
            var model = new DownloadViewModel();
            model.BeforeThread = Thread.CurrentThread.ManagedThreadId.ToString();

            // I/O-bound operation
            var client = new HttpClient();
            var before = DateTime.Now;
            await client.GetStringAsync("http://www.google.com");
            var after = DateTime.Now;

            model.AfterThread = Thread.CurrentThread.ManagedThreadId.ToString();
            model.Elapsed = (after - before).TotalMilliseconds;
            return View(model);
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View(ViewModelBase.Default());
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Form(FormInputModel input)
        {
            // Do some work 
            Thread.Sleep(2000);

            // Now return
            var success = DateTime.Now.Second % 2;
            if (success > 0)
                return Json(CommandResponse.Ok.AddMessage(Strings_UI.Generic_OperationSuccess));
            return Json(CommandResponse.Fail.AddMessage(Strings_UI.Generic_OperationFailure));
        }

        [HttpGet]
        public ActionResult LargeForm()
        {
            return View(ViewModelBase.Default());
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult LargeForm(LargeFormInputModel input)
        {
            // Do some work 
            Thread.Sleep(2000);

            // Now return
            var success = DateTime.Now.Second % 2;
            if (success > 0)
                return Json(CommandResponse.Ok.AddMessage(Strings_UI.Generic_OperationSuccess));
            return Json(CommandResponse.Fail.AddMessage(Strings_UI.Generic_OperationFailure));
        }

    }
}