#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	ConnectionManager.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ChobiQ.DoubanFMAPICodePack
{
    static class ConnectionManager
    {
        public const string LoginUri
            = "/j/app/login";
        public const string PlaylistUri
            = "/j/app/radio/people";
           // = "/j/mine/playlist";
        static CookieContainer s_cookies;

        static ConnectionManager()
        {
            s_cookies = new CookieContainer();
        }

        public static Stream GetPostResponseStream(string requestUri,
            FormData data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                "http://www.douban.com" + requestUri);
            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version11;

            request.Headers.Add("Origin", "onering://radio");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) " 
                + "AppleWebKit/535.19 "
                + "(KHTML, like Gecko) Chrome/18.0.1025.151 Safari/535.19";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.KeepAlive = true;

            request.CookieContainer = s_cookies;

            using (StreamWriter writer = new StreamWriter(
                request.GetRequestStream()))
            {
                writer.Write(data.GetFormString());
                writer.Close();
            }

            return request.GetResponse().GetResponseStream();
        }

        public static JResponse GetPostResponse(string requestUri,
            FormData data)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(
                typeof(JResponse));

            return (JResponse)ser.ReadObject(GetPostResponseStream(
                requestUri, data));
        }

        public static Stream GetResponseStream(string requestUri,
            FormData data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                "http://www.douban.com" + requestUri 
                + "?" + data.GetFormString());
            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version11;

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) "
                + "AppleWebKit/535.19 "
                + "(KHTML, like Gecko) Chrome/18.0.1025.151 Safari/535.19";

            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.KeepAlive = true;

            request.CookieContainer = s_cookies;
            

            return request.GetResponse().GetResponseStream();
        }

        public static JResponse GetResponse(string requestUri,
            FormData data)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(
                typeof(JResponse));

            return (JResponse)ser.ReadObject(GetResponseStream(
                requestUri, data));
        }
    }
}
