#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	JResponse.cs
      
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
    class JResponse
    {
        [DataMember(IsRequired = true)]
        public string r { get; set; }

        [DataMember(IsRequired = false)]
        public string err { get; set; }

        //Login Data.
        [DataMember(IsRequired = false)]
        public string user_id { get; set; }
        [DataMember(IsRequired = false)]
        public string token { get; set; }
        [DataMember(IsRequired = false)]
        public string expire { get; set; }
        [DataMember(IsRequired = false)]
        public string user_name { get; set; }
        [DataMember(IsRequired = false)]
        public string email { get; set; }

        //Song Data.
        [DataMember(IsRequired = false)]
        public string version_max { get; set; }
        [DataMember(IsRequired = false)]
        public List<JSong> song { get; set; }
    }
}
