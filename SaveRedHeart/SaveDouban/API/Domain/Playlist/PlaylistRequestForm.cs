#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	PlaylistRequestForm.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChobiQ.DoubanFMAPICodePack
{
    class PlaylistRequestForm : FormData
    {
        public string app_name { get; set; }
        public string version { get; set; }

        public string user_id { get; set; }
        public string token { get; set; }
        public string expire { get; set; }

        public string sid { get; set; }
        public string channel { get; set; }
        public string h { get; set; }
        public string type { get; set; }

       //add by jasine 2012.10.11
        public string r { get; set; }

        public PlaylistRequestForm(PlaylistRequest request)
        {
            byte[] bytes = new byte[8];
            Random random = new Random();
            random.NextBytes(bytes);
            r= (BitConverter.ToUInt64(bytes, 0) % 0xFFFFFFFFFF).ToString("x10");
            app_name = "radio";
            version = "100";

            if (request.UserStatus != null)
            {
                user_id = request.UserStatus.UserID;
                token = request.UserStatus.Token;
                expire = request.UserStatus.Expire;
            }
            else
            {
                user_id = token = expire = null;
            }

            type = DataConvert.ToTypeCode(request.Operation);
            channel = DataConvert.ToChannelCode(request.RequestChannel);

            switch (request.Operation)
            {
            case PlayOperation.NewList:
                sid = String.Empty;
                h = String.Empty;
                break;

            case PlayOperation.PlaysToEnd:
                sid = request.LastPlay.SongID;
                h = null;
                break;

            case PlayOperation.Skip:
            case PlayOperation.Bin:
            case PlayOperation.PlayingLast:
            case PlayOperation.Like:
            case PlayOperation.Unlike:
                sid = request.LastPlay.SongID;
                h = request.History.GetHistoryCode();
                break;
            }
        }
    }
}
