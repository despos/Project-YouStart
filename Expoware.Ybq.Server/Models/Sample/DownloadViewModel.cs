﻿///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

namespace Expoware.Ybq.Server.Models.Sample
{
    public class DownloadViewModel : ViewModelBase
    {
        public string BeforeThread { get; set; }
        public string AfterThread { get; set; }

        public double Elapsed { get; set; }
    }
}