///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Collections.Generic;

namespace Expoware.Ybq.Server.Models.Sample
{
    public class ChangePasswordOption
    {
        public ChangePasswordOption(string name, int id)
        {
            DisplayName = name;
            OptionId = id;
        }

        public string DisplayName { get; set; }
        public int OptionId { get; set; }

        public static IList<ChangePasswordOption> All = new List<ChangePasswordOption>()
        {
            new ChangePasswordOption("Never", 0),
            new ChangePasswordOption("Every month", 2),
            new ChangePasswordOption("Every three month", 3),
            new ChangePasswordOption("Every year", 4),
        };
    }
}