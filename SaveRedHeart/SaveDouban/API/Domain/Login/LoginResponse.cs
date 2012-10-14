#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	LoginResponse.cs
      
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
    /// Contains data about sign-in result.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets sign-in result.
        /// </summary>
        public LoginResult Result { get; private set; }
        /// <summary>
        /// Gets server message.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets name of the user.
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// Gets email of the user.
        /// </summary>
        public string Email { get; private set; }

        internal LoginResponse(JResponse jResp)
        {
            if (jResp.r == "1")
            {
                if (jResp.err == "wrong_email")
                {
                    this.Result = LoginResult.InvalidEmail;
                }
                else if (jResp.err == "wrong_password")
                {
                    this.Result = LoginResult.InvalidPassword;
                }

                this.Message = jResp.err;
            }
            else
            {
                this.Result = LoginResult.Success;
                this.Message = "ok";

                this.UserName = jResp.user_name;
                this.Email = jResp.email;
            }
        }
    }
}
