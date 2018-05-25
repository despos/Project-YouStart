///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Collections.Generic;
using Expoware.Ybq.Server.Common.Features.Geo;

namespace Expoware.Ybq.Server.Models.Sample
{
    public class LargeFormInputModel : ViewModelBase
    {
        public string ContactName { get; set; }
        public Address Address { get; set; }
        public string[] Emails { get; set; }
        public string Password { get; set; }

        public IList<ChangePasswordOption> ChangePasswordOptions { get; set; }
    }
}