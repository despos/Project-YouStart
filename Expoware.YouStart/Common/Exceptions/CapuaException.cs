///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//


using System;

namespace Expoware.YouStart.Common.Exceptions
{
    public class StarterKitException : Exception
    {
        public StarterKitException(string message)
            : base(message)
        {
        }
        public StarterKitException(int code, string message, string line1 = "", string line2 = "")
            : base(message)
        {
            Line1 = line1;
            Line2 = line2;
            StatusCode = code;
        }

        public string Title { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int StatusCode { get; set; }

        public bool IsAppSpecificError { get; set; }
    }
}