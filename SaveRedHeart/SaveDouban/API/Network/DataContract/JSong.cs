#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	JSong.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ChobiQ.DoubanFMAPICodePack
{
    [DataContract]
    class JSong
    {
        [DataMember]
        public string picture { get; set; }
        [DataMember]
        public string albumtitle { get; set; }
        [DataMember]
        public string company { get; set; }
        [DataMember]
        public string rating_avg { get; set; }
        [DataMember]
        public string public_time { get; set; }
        [DataMember]
        public string ssid { get; set; }
        [DataMember]
        public string album { get; set; }
        [DataMember]
        public string like { get; set; }
        [DataMember]
        public string artist { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string subtype { get; set; }
        [DataMember]
        public string length { get; set; }
        [DataMember]
        public string sid { get; set; }
        [DataMember]
        public string aid { get; set; }
    }
}
