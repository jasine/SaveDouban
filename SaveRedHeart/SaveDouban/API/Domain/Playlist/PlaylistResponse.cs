#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	PlaylistResponse.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChobiQ.DoubanFMAPICodePack
{
    class PlaylistResponse
    {
        public Song[] Songs { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string MaxVersion { get; private set; }

        public PlaylistResponse(JResponse jResp)
        {
            Success = jResp.r == "0";

            if (Success)
            {
                Message = "ok";

                MaxVersion = jResp.version_max;

                List<Song> songList = new List<Song>();

                foreach (var item in jResp.song)
                {
                    try
                    {
                        songList.Add(new Song(item));
                    }
                    catch
                    {
                    	
                    }                  
                }

                Songs = songList.ToArray();
            }
            else
            {
                Songs      = null;
                Message    = jResp.err;
                MaxVersion = null;
            }
        }
    }
}
