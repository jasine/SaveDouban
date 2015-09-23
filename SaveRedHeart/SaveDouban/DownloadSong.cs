using ChobiQ.DoubanFMAPICodePack;
using ID3;
using ID3.ID3v2Frames.BinaryFrames;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Diagnostics;


namespace SaveDouban
{
    class DownloadSong
    {
        DoubanFMClient client;
        LoginResponse resp;
        Dictionary<string, Song> dic;
        Image image;
        MemoryStream ms;
        Thread thr;
        private string coverPath;
        private string lyricPath;
        private string path;
        QianQianLrc.DownloadLyrics downloadLrc;
       
        int percent;//当前歌曲的下载百分比
        Song currentSong;
        FileStream fs;//用于保存mp3文件的文件流

        public string UserName { get; private set; }
        public int Total { get; set; }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        /// <summary>
        /// 封面路径
        /// </summary>
        public string CoverPath
        {
            get
            {
                return coverPath;
            }
            set
            {
                if (value != "")
                {
                    if (Directory.Exists(value) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(value);
                    }
                }   
                coverPath = value;
            }
        }
        /// <summary>
        /// 歌词路径
        /// </summary>
        public string LyricPath
        {
            get
            {
                return lyricPath;
            }
            set
            {
                if (value!="")
                {
                    if (Directory.Exists(value) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(value);
                    }
                }               
                lyricPath = value;
            }
        }
        public int ID3Version { get; set; }
        public int Success { get; private set; }
        public int Exist { get; private set; }
        public int Fail { get; private set; }

        /// <summary>
        /// 当前下载进度事件
        /// </summary>
        public event Action<int> Progress;

        /// <summary>
        /// 新的一首歌
        /// </summary>
        public event Action<int, Image, string, string> NewSong;

        /// <summary>
        /// 尝试遍历次数过多，询问是否停止
        /// </summary>
        public event Func<bool> AskStop;

        /// <summary>
        /// 下载完成，或尝试次数过多的停止消息
        /// </summary>
        public event Action<int, int, int, string> Msg;



        /// <summary>
        /// 构造方法
        /// </summary>
        public DownloadSong(string path)
        {
            client = new DoubanFMClient();
            Path = path;
            dic = new Dictionary<string, Song>();
            ID3Version = 2;
            Success = 0;
            Fail = 0;
            Exist = 0;
            downloadLrc = new QianQianLrc.DownloadLyrics();
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>登录结果</returns>
        public string Login(string name, string pwd)
        {
            try
            {
                resp = client.Login(name, pwd, false);
                switch (resp.Message)
                {
                    case "invalidate_email":
                        return "邮件地址格式错误";
                    case "wrong_email":
                        return "用户不存在";
                    case "wrong_password":
                        return "密码错误";
                    case "ok":
                        {
                            UserName = resp.UserName;
                            return "登录成功";
                        }

                    default:
                        return "网络连接错误";
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "网络连接错误,如果您设值了代理，请尝试取消.";
            }
        }

        /// <summary>
        /// 开始下载，另起线程
        /// </summary>
        public void Start()
        {
            Success = 0;
            Fail = 0;
            Exist = 0;
            dic.Clear();
            thr = new Thread(Download);           
            thr.IsBackground = true;
            thr.Start();

        }

        /// <summary>
        /// 停止下载
        /// </summary>
        public void Stop()
        {
            try
            {
                thr.Abort();
                fs.Close();
                fs.Dispose();
                File.Delete(Path + currentSong.Title + ".mp3");                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Function Stop()：" + e.Message);
            }
            try
            {
                File.Delete(CoverPath + currentSong.Title + ".jpg");
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("Function Stop()：" + ex.Message);
            }
            try
            {
                File.Delete(LyricPath + currentSong.Title + ".lrc");
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("Function Stop()：" + ex.Message);
            }
        }

        /// <summary>
        /// 下载红心歌曲
        /// </summary>
        public void Download()
        {
            if (Directory.Exists(Path) == false)//如果不存在就创建文件夹
            {
                Directory.CreateDirectory(Path);
            }
            client.NewList();
            client.SwitchChannel(Channel.RedHeart);
            int times = 0;
            int num = 0;
            while (dic.Count <= Total)
            {
                foreach (Song song in client.Playlist)
                {
                    if (!dic.Keys.Contains(song.SongID))
                    {                       
                        dic.Add(song.SongID, song);
                        num++;
                        currentSong = song;
                        string fileName = Path + song.Title + ".mp3";
                        try
                        {
                            image = Image.FromStream(WebRequest.Create(song.PictureURL).GetResponse().GetResponseStream());
                        }
                        catch (Exception)
                        {
                            image = Properties.Resources.cover;
                        }
                        NewSong.Invoke(num, image, song.Title, song.Artist);
                        if (File.Exists(fileName))
                        {
                            Exist++;
                        }
                        else
                        {
                            if (Downfile(song.MediaURL, fileName))
                            {
                                Success++;
                                ID3Info info = new ID3Info(fileName, true);
                                info.Load();
                                info.ID3v2Info.SetMinorVersion(3);
                                AttachedPictureFrame pic = null;
                                try
                                {
                                    if (!string.IsNullOrEmpty(CoverPath))//保存封面
                                    {
                                        image.Save(CoverPath + song.Title + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }

                                    ms = new System.IO.MemoryStream();
                                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    // 创建新封面
                                    pic = new AttachedPictureFrame(
                                    FrameFlags.Compression, "cover.jpg", TextEncodings.UTF_16, "",
                                    AttachedPictureFrame.PictureTypes.Cover_Front, ms);
                                    info.ID3v2Info.AttachedPictureFrames.Add(pic);
                                    // 添加新封面到MP3中
                                }
                                catch
                                {
                                }

                                if (!string.IsNullOrEmpty(lyricPath))//下载歌词
                                {
                                    downloadLrc.SaveLyric(song.Artist, song.Title, lyricPath + song.Title + ".lrc");
                                }

                                // 设置其它属性(ID3V1)
                                info.ID3v1Info.Title = song.Title;
                                info.ID3v1Info.Artist = song.Artist;
                                info.ID3v1Info.Album = song.AlbumTitle;

                                //jasine fixed 2015.9.23 
                                //info.ID3v1Info.Year = song.PublicationTime;
                                info.ID3v1Info.Year = "";

                                info.ID3v1Info.Comment = "jasinechen@gmail.com";//注释---------添加不上去
                                info.ID3v1Info.Genre = 12;//类型代码Other:12 对应于ID3V2中自定义类型RedHeart

                                // 设置其它属性(ID3V2)
                                info.ID3v2Info.SetTextFrame("TIT2", song.Title);
                                info.ID3v2Info.SetTextFrame("TPE1", song.Artist);
                                info.ID3v2Info.SetTextFrame("TALB", song.AlbumTitle);

                                //jasine fixed 2015.9.23 
                                //info.ID3v2Info.SetTextFrame("TYER", song.PublicationTime);
                                info.ID3v2Info.SetTextFrame("TYER", "");

                                //info.ID3v2Info.SetTextFrame("COMM", "jasinechen@gmail.com");//注释---------添加不上去
                                info.ID3v2Info.SetTextFrame("TCON", "RedHeart");//类型

                                //jasine fixed 2015.9.23 
                                //info.ID3v2Info.SetTextFrame("TPUB", song.Publisher);//发布者，发布单位
                                info.ID3v2Info.SetTextFrame("TPUB", "");//发布者，发布单位

                                // 保存到MP3中
                                if (ID3Version == 1)
                                {
                                    info.ID3v1Info.Save();
                                }
                                else
                                {
                                    info.Save(3);
                                    info.ID3v2Info.PopularimeterFrames.Add(new ID3.ID3v2Frames.TextFrames.PopularimeterFrame(
                                                 FrameFlags.TagAlterPreservation, "fm.douban.com", song.Rating, 0));//豆瓣评分
                                    info.Save(3);
                                }
                            }
                            else
                            {
                                //下载失败
                                Fail++;
                            }
                        }
                        if ((Success + Fail + Exist) >= Total)
                        {
                            Msg.Invoke(Success, Fail, Exist, "下载完成");
                            Stop();
                        }
                        else
                        {
                            Msg.Invoke(Success, Fail, Exist, "");
                        }                                               
                    }
                }
                client.Skip();
                times++;
                if (times > 10000)
                {
                    Fail=Total-(Success+Exist);
                    Msg.Invoke(Success,Fail ,Exist, "尝试次数过多，未成功下载歌曲请过几小时后再在原文件夹下载");
                    Stop();
                }

            }
            Msg.Invoke(Success, Fail, Exist, "下载完成");

        }


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">文件URL</param>
        /// <param name="LocalPath">存放路径</param>
        /// <returns></returns>
        public bool Downfile(string url, string LocalPath)
        {
            try
            {
                Uri u = new Uri(url);
                HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(u);
                //mRequest.Method = "GET";
                //mRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse wr = (HttpWebResponse)mRequest.GetResponse();
                using (Stream sIn = wr.GetResponseStream())
                {
                    using (fs = new FileStream(LocalPath, FileMode.Create, FileAccess.Write))
                    {
                        long i = 0;
                        percent = 0;
                        while (i < wr.ContentLength)
                        {
                            byte[] buffer = new byte[1024 * 100];
                            int len = sIn.Read(buffer, 0, buffer.Length);
                            i += len;
                            fs.Write(buffer, 0, len);
                            if (percent != Convert.ToInt16(Math.Round(Convert.ToDecimal((Convert.ToDouble(i) / Convert.ToDouble(wr.ContentLength)) * 100), 4)))
                            {
                                percent = Convert.ToInt16(Math.Round(Convert.ToDecimal((Convert.ToDouble(i) / Convert.ToDouble(wr.ContentLength)) * 100), 4));
                                Progress.Invoke(percent);
                            }

                        }
                    }
                }
                wr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }       

    }
}
