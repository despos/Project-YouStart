///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System;

namespace Expoware.YouStart.Common.Extensions
{
    public static class BoolExtensions
    {
        public static String Humanize(this bool theOption, string yes = "Yes", string no = "No")
        {
            return theOption
                ? yes
                : no;
        }

        public static String ToJavaScriptBoolean(this bool theOption)
        {
            return theOption.ToString().ToLower();
        }

    }
}