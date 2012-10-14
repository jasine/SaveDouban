#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	LoginRequest.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChobiQ.DoubanFMAPICodePack
{
    class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginRequest() { }
        public LoginRequest(string email, string password)
        {
            this.Email    = email;
            this.Password = password;
        }

        public LoginResponse GetResponse()
        {
            LoginRequestForm form = new LoginRequestForm(this);

            var jResp = ConnectionManager.GetPostResponse(
                ConnectionManager.LoginUri, form);

            return new LoginResponse(jResp);
        }
    }
}
