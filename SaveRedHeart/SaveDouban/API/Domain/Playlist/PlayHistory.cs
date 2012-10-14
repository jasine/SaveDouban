#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	PlayHistory.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChobiQ.DoubanFMAPICodePack
{
    class PlayHistory
    {
        private struct HistoryItem
        {
            public string SongID;
            public string TypeCode;
        }

        private Queue<HistoryItem> _history;

        public int Count
        {
            get
            {
                return _history.Count;
            }
        }

        public PlayHistory()
        {
            _history = new Queue<HistoryItem>();
        }

        public void AddSong(Song song, PlayOperation operation)
        {
            _history.Enqueue(new HistoryItem()
            {
                SongID = song.SongID,
                TypeCode = DataConvert.ToTypeCode(operation)
            });

            if (_history.Count > 20)
                _history.Dequeue();
        }

        public string GetHistoryCode()
        {
            string historyCode = String.Empty;

            foreach (var item in _history)
            {
                historyCode += String.Format("%7C{0}%3A{1}",
                    item.SongID, item.TypeCode);
            }

            return historyCode;
        }
    }
}
