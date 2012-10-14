#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	PlayOperation.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChobiQ.DoubanFMAPICodePack
{
    enum PlayOperation
    {
        //Code:n, App start. Get new list. sid=&h=&
        //Cookie received. Following request send this cookie.
        NewList,

        //Code:s, User click skip or switch to another channel. Get new list.
        //History needed.
        Skip,

        //Code:b, User click bin. Get new list. History needed.
        //User status needed.
        //Private needed.
        Bin,

        //Code:e, A song plays to end. No response data. No history needed.
        PlaysToEnd,

        //Code:p, When playing last song in the list. Get new list.
        //Use last song's sid. History needed.
        PlayingLast,

        //Code:r, User click like. History needed. User status needed.
        Like,

        //Code:u, User click unlike. History needed. User status needed.
        Unlike
    }
}
