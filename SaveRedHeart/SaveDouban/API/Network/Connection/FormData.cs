#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	FormData.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ChobiQ.DoubanFMAPICodePack
{
    class FormData
    {
        public virtual string GetFormString()
        {
            Type t = this.GetType();
            var props = t.GetProperties();

            string s = String.Empty;

            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];

                var value = prop.GetValue(this, new Object[] { });

                if (value != null)
                    s += String.Format("{0}={1}{2}",
                        prop.Name, value,
                        (i == props.Length - 1 ? String.Empty : "&"));
            }

            return s;
        }

        public override string ToString()
        {
            return GetFormString();
        }
    }
}
