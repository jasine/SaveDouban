#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	Song.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChobiQ.DoubanFMAPICodePack
{
    /// <summary>
    /// Contains data about a song.
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Gets song's id.
        /// </summary>
        public string SongID { get; private set; }
        /// <summary>
        /// Gets url of album cover picture.
        /// </summary>
        public string PictureURL { get; private set; }
        /// <summary>
        /// Gets title of album.
        /// </summary>
        public string AlbumTitle { get; private set; }
        /// <summary>
        /// Gets web page url of the album.
        /// </summary>
        public string AlbumURL { get; private set; }
        /// <summary>
        /// Gets publication time of the song.
        /// </summary>
        public string PublicationTime { get; private set; }
        /// <summary>
        /// Gets or sets if user like the song.
        /// </summary>
        public bool Like { get; set; }
        /// <summary>
        /// Gets the name of the song's artist.
        /// </summary>
        public string Artist { get; private set; }
        /// <summary>
        /// Gets url of the song's playable media.
        /// </summary>
        public string MediaURL { get; private set; }
        /// <summary>
        /// Gets title of the song.
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// Gets length of the song in TimeSpan.
        /// </summary>
        public TimeSpan Length { get; private set; }

        /// <summary>
        /// Get public company of the song
        /// </summary>
        public string Publisher { get; private set; }

        /// <summary>
        /// Get public company of the song
        /// </summary>
        public byte Rating { get; private set; }

        internal Song(JSong jSong)
        {
            SongID          = jSong.sid;
            PictureURL      = jSong.picture;
            AlbumTitle      = jSong.albumtitle;
            AlbumURL        = "http://music.douban.com" + jSong.album;
            PublicationTime = jSong.public_time;
            Like            = jSong.like == "1";
            Artist          = jSong.artist;
            MediaURL        = jSong.url;
            Title           = jSong.title;
            Length          = TimeSpan.FromSeconds(
                Convert.ToInt32(jSong.length));

            ///Add by jasine 2012.10.10
            Publisher       = jSong.company;
            double rt=0;
            if(Double.TryParse(jSong.rating_avg,out rt))
            {
                Rating=Convert.ToByte((rt/5.0)*255);
                //豆瓣是5分制，ID3的分级信息为0-255，0为未知，微软MediaPlayer分：1，64，128，196，255共5级，区间内舍入分级
            }
            else
            {
                Rating=0;
            }
        }
    }
}
