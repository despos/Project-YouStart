///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//


using Expoware.Youbiquitous.Extensions;

namespace Expoware.YouStart.Models
{
    public class ViewModelBase
    {
        public ViewModelBase(string title = "")
        {
            if (title.IsNullOrWhitespace())
                title = StarterKitApplication.AppSettings.ApplicationTitle;
            Title = title;
        }

        public string Title { get; set; }
    }
}