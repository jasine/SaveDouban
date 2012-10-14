#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	Channel.cs
      
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
    /// Specifies available channels on DoubanFM radio.
    /// </summary>
    [Serializable]
    public enum Channel
    {
        RedHeart=-3,
        Private = 0,
        Chinese = 1,
        Western = 2,
        Eighties = 4,
        Coffie = 32,
        Light = 9,
        Cantonese = 6,
        Nineties = 5,
        Newsongs = 61,
        XiaoQingXin = 76,
        Folk = 8,
        RAndB = 16,
        Classic = 27,
        Female = 20,
        Jazz = 13,
        Japanese = 17,
        Movie = 10,
        Korean = 18,
        Seventies = 3,
        ACG = 28,
        Rocks = 7,
        French = 22,
        Easy = 77,
        Rap = 15,
        Electronic = 14,
        DoubanMusicians = 26,
        NineOneOne = 78,
        ThreeOEightChoices = 83
    }
}
