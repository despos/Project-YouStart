///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System;
using System.Configuration;
using Expoware.Youbiquitous.Extensions;

namespace Expoware.YouStart.Common
{
    public class YouStartAppSettings
    {
        /// <summary>
        /// Application title
        /// </summary>
        public string ApplicationTitle { get; private set; }

        /// <summary>
        /// Whether it should provide internal details of unexpected 500 errors
        /// </summary>
        public bool ShouldShowErrorDetails { get; set; }

        /// <summary>
        /// Indicates the tier of the app and determines the features to enable.
        /// </summary>
        public int ApplicationTier { get; set; }

        public static YouStartAppSettings Initialize()
        {
            var titleBase0 = ConfigurationManager.AppSettings["sk:app-title-base0"] ?? String.Empty;
            var shouldShowErrorDetails = (ConfigurationManager.AppSettings["sk:show-error-details"] ?? "false").ToBool();
            var appLevel = (ConfigurationManager.AppSettings["sk:app-tier"] ?? "0").ToInt();

            var settings = new YouStartAppSettings
            {
                ApplicationTitle = $"{titleBase0}",
                ShouldShowErrorDetails = shouldShowErrorDetails,
                ApplicationTier = appLevel
            };

            return settings;
        }
    }
}