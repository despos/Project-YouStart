﻿///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;

namespace Expoware.Ybq.Server.Common
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse(true);
        public static CommandResponse Fail = new CommandResponse();

        public CommandResponse(bool success = false, string message = "")
        {
            Success = success;
            Message = message;
            RedirectUrl = String.Empty;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string Key { get; private set; }
        public string ExtraData { get; private set; }
        public string RedirectUrl { get; private set; }

        public CommandResponse AddMessage(string message)
        {
            Message = message;
            return this;
        }

        public CommandResponse AddKey(string key)
        {
            Key = key;
            return this;
        }

        public CommandResponse AddRedirectUrl(string url)
        {
            RedirectUrl = url;
            return this;
        }

        public CommandResponse AddExtra(string data)
        {
            ExtraData = data;
            return this;
        }
    }
}