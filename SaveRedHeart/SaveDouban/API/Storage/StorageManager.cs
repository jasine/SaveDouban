#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:25

      Project:  DoubanFM API Code Pack
         File:	StorageManager.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChobiQ.DoubanFMAPICodePack
{
    static class StorageManager
    {
        static DirectoryInfo s_QFMDir;
        static FileInfo s_statusFile;
        static FileInfo s_channelFile;

        static StorageManager()
        {
            string appDataPath = Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData);

            string qFMRelPath = "Chobi-Q\\QFM";

            s_QFMDir = new DirectoryInfo(Path.Combine(
                appDataPath, qFMRelPath));
            s_QFMDir.Create();

            s_statusFile = new FileInfo(Path.Combine(
                s_QFMDir.FullName, "UserStatus.bin"));
            s_channelFile = new FileInfo(Path.Combine(
                s_QFMDir.FullName, "Channel.bin"));
        }

        public static bool UserStatusExists
        {
            get
            {
                return s_statusFile.Exists;
            }
        }

        public static bool LastChannelExists
        {
            get
            {
                return s_channelFile.Exists;
            }
        }

        public static UserStatus LoadUserStatus()
        {
            if (!UserStatusExists)
                return null;

            IFormatter format = new BinaryFormatter();

            UserStatus status = (UserStatus)format.Deserialize(
                s_statusFile.Open(FileMode.Open));

            return status;
        }

        public static void SaveUserStatus(UserStatus status)
        {
            IFormatter format = new BinaryFormatter();
            using (FileStream fs = s_statusFile.Open(FileMode.OpenOrCreate))
            {
                format.Serialize(fs,status);
            }
            //format.Serialize(
            //    s_statusFile.Open(FileMode.OpenOrCreate),
            //    status);
        }

        public static void ClearUserStatus()
        {
            if (UserStatusExists)
            {
                s_statusFile.Delete();
            }
        }

        public static Channel LoadLastChannel()
        {
            if (!UserStatusExists)
                return Channel.Chinese;

            IFormatter format = new BinaryFormatter();

            Channel ch = (Channel)format.Deserialize(
                s_channelFile.Open(FileMode.Open));

            return ch;
        }

        public static void SaveLastChannel(Channel channel)
        {
            IFormatter format = new BinaryFormatter();

            format.Serialize(
                s_channelFile.Open(FileMode.OpenOrCreate),
                channel);
        }

        public static void ClearLastChannel()
        {
            if (LastChannelExists)
            {
                s_channelFile.Delete();
            }
        }
    }
}
