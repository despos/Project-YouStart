///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using System.Collections.Generic;
using System.Linq;

namespace Expoware.Ybq.Server.Common.Exceptions
{
    public class YbqAppException : Exception
    {
        public YbqAppException(string message, params string[] links)
            : this(0, message, links)
        {
        }
        public YbqAppException(int code, string message, params string[] links)
            : base(message)
        {
            IsAppSpecificError = true;
            AdditionalInfo = string.Empty;
            StatusCode = code;
            RecoveryLinks = new List<string>();
            if (links.Length > 0)
                RecoveryLinks = links.ToList();
        }

        public string Title { get; set; }
        public string AdditionalInfo { get; set; }
        public int StatusCode { get; set; }
        public bool IsAppSpecificError { get; set; }
        public List<string> RecoveryLinks { get; private set; }
    }
}