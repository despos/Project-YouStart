﻿///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

namespace Expoware.Ybq.Server.Models.Sample
{
    public class FormInputModel : ViewModelBase
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string CountryCode { get; set; }
        public string Gender { get; set; }
    }
}