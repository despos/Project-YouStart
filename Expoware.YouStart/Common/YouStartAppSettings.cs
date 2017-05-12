///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System;
using System.Configuration;

namespace Expoware.YouStart.Common
{
    public class YouStartAppSettings
    {
        /// <summary>
        /// App title
        /// </summary>
        public string ApplicationTitle { get; private set; }

        public static YouStartAppSettings Initialize()
        {
            var titleBase0 = ConfigurationManager.AppSettings["starterkit:app-title-base0"] ?? String.Empty;
            var settings = new YouStartAppSettings
            {
                ApplicationTitle = String.Format("{0}", titleBase0),
            };

            return settings;
        }
    }
}