///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System;
using System.Net;
using System.Web.Script.Serialization;

namespace Expoware.YouStart.Common.Extensions
{
    public static class WebClientExtensions
    {
        public static T GetJson<T>(this WebClient client, String url) where T : class
        {
            var data = client.DownloadString(url);
            if (data.IsNullOrWhitespace())
                return null;

            var serial = new JavaScriptSerializer();
            var obj = serial.Deserialize<T>(data);
            //var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            //var serializer = new DataContractJsonSerializer(typeof(T));
            //var obj = (T)serializer.ReadObject(stream);
            //stream.Close();
            return obj;
        }
    }
}