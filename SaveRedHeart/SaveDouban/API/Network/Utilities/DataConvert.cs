#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	DataConvert.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChobiQ.DoubanFMAPICodePack
{
    static class DataConvert
    {
        internal static string ToTypeCode(PlayOperation operation)
        {
            switch (operation)
            {
            case PlayOperation.NewList:
                return "n";
            case PlayOperation.Skip:
                return "s";
            case PlayOperation.Bin:
                return "b";
            case PlayOperation.PlaysToEnd:
                return "e";
            case PlayOperation.PlayingLast:
                return "p";
            case PlayOperation.Like:
                return "r";
            case PlayOperation.Unlike:
                return "u";
            default:
                return String.Empty;
            }
        }

        internal static string ToChannelCode(Channel channel)
        {
            return Convert.ToInt32(channel).ToString();
        }

        public static string ToChinese(Channel channel)
        {
            switch (channel)
            {
            case Channel.ACG:
                return "动漫";
            case Channel.Cantonese:
                return "粤语";
            case Channel.Chinese:
                return "华语";
            case Channel.Classic:
                return "古典";
            case Channel.Coffie:
                return "咖啡";
            case Channel.DoubanMusicians:
                return "豆瓣音乐人";
            case Channel.Easy:
                return "Easy";
            case Channel.Eighties:
                return "八零";
            case Channel.Electronic:
                return "点子";
            case Channel.Female:
                return "女声";
            case Channel.Folk:
                return "民谣";
            case Channel.French:
                return "法语";
            case Channel.Japanese:
                return "日语";
            case Channel.Jazz:
                return "爵士";
            case Channel.Korean:
                return "韩语";
            case Channel.Light:
                return "轻音乐";
            case Channel.Movie:
                return "电影原声";
            case Channel.Newsongs:
                return "新歌";
            case Channel.NineOneOne:
                return "91.1";
            case Channel.Nineties:
                return "九零";
            case Channel.Private:
                return "私人";
            case Channel.RAndB:
                return "R&B";
            case Channel.Rap:
                return "说唱";
            case Channel.Rocks:
                return "摇滚";
            case Channel.Seventies:
                return "七零";
            case Channel.ThreeOEightChoices:
                return "308选择出色";
            case Channel.Western:
                return "欧美";
            case Channel.XiaoQingXin:
                return "小清新";
            default:
                return String.Empty;
            }
        }

        public static string ToChineseMHz(Channel channel)
        {
            return ToChinese(channel) + "MHz";
        }
    }
}
