#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	PlaylistRequest.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChobiQ.DoubanFMAPICodePack
{
    class PlaylistRequest
    {
        public Song LastPlay { get; set; }
        public Channel RequestChannel { get; set; }
        public PlayOperation Operation { get; set; }
        public PlayHistory History { get; private set; }
        public UserStatus UserStatus { get; private set; }


        public PlaylistRequest(UserStatus userStatus, PlayHistory history,
            PlayOperation operation, Channel channel, Song lastPlay)
        {
            UserStatus     = userStatus;
            History        = history;
            Operation      = operation;
            RequestChannel = channel;
            LastPlay       = lastPlay;
        }

        public PlaylistResponse GetResponse()
        {
            PlaylistRequestForm form = new PlaylistRequestForm(this);

            if (Operation == PlayOperation.PlaysToEnd ||
                Operation == PlayOperation.Like ||
                Operation == PlayOperation.Unlike)
            {
                ConnectionManager.GetResponseStream(
                    ConnectionManager.PlaylistUri, form);

                return null;
            }

            var jResp = ConnectionManager.GetResponse(
                ConnectionManager.PlaylistUri, form);

            return new PlaylistResponse(jResp);
        }
    }
}
