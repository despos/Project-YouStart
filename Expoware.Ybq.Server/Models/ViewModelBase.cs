///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Expoware.Ybq.Server.Common;
using Expoware.Youbiquitous.Extensions;

namespace Expoware.Ybq.Server.Models
{
    public class ViewModelBase
    {
        protected ViewModelBase(string title = "")
        {
            Settings = StarterKitApplication.AppSettings;
            if (title.IsNullOrWhitespace())
                title = Settings.ApplicationTitle;
            Title = title;
        }

        public static ViewModelBase Default(string title = "")
        {
            var model = new ViewModelBase(title);
            return model;
        }

        public string Title { get; set; }

        public YbqAppSettings Settings { get; private set; }
    }
}