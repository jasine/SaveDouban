#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	LoginRequestForm.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChobiQ.DoubanFMAPICodePack
{
    class LoginRequestForm : FormData
    {
        public string email { get; set; }
        public string password { get; set; }
        public string app_name { get; set; }
        public string version { get; set; }

        public LoginRequestForm(string email, string password)
        {
            this.email = email;
            this.password = password;
            this.app_name = "radio_desktop_win";
            this.version = "100";
        }

        public LoginRequestForm(LoginRequest request)
            : this(request.Email, request.Password)
        {

        }
    }
}
