#region "Copyright"
/*======================================================================
Filename :QianQianLrcer.cs
Description :

修改记录：
Created by 吕亮 at 2009-1-15 10:08:16
算法来源于网络
======================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace QianQianLrc {
    public class QianQianLrcer {
        public QianQianLrcer(bool needproxy) {
            this.needproxy = needproxy;
        }
        public static readonly string SearchPath = "http://ttlrcct2.qianqian.com/dll/lyricsvr.dll?sh?Artist={0}&Title={1}&Flags=0";
        public static readonly string DownloadPath = "http://ttlrcct2.qianqian.com/dll/lyricsvr.dll?dl?Id={0}&Code={1}";
        private bool needproxy = false;
        private WebProxy proxy;

        public bool NeedProxy {
            get { return needproxy; }
            set { needproxy = value; }
        }

        private XmlNode currentSong;

        public XmlNode CurrentSong {
            get { return currentSong; }
            set { currentSong = value; }
        }
	

        public WebProxy Proxy {
            get { return proxy; }
            set { proxy = value; }
        }

        public string RequestALink(string link) {
            WebRequest request = WebRequest.Create(link);
            if (this.needproxy) {
                if (this.proxy == null) {
                    this.OnInitializeProxy();
                }
                request.Proxy = this.proxy;
            }
            
            StringBuilder sb = new StringBuilder();
            try {
                using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream())) {
                    sb.Append(sr.ReadToEnd());
                }
            } catch (WebException ex) {
                this.OnWebException(ex);
            }
            return sb.ToString();
        }

        public string DownloadLrc(string singer, string title) {
            this.currentSong = null;
            XmlDocument xml = SearchLrc(singer, title);
            string retStr = "没有找到该歌词";
            if (xml == null)
                return retStr;

            XmlNodeList list = xml.SelectNodes("/result/lrc");
            if (list.Count > 0) {
                this.OnSelectSong(list);
                if (this.currentSong == null)
                    this.currentSong = list[0];
            } else if (list.Count == 1) {
                this.currentSong = list[0];
            } else {
                return retStr;
            }
            if (this.currentSong == null)
                return retStr;

            XmlNode node = this.currentSong;
            int lrcId = -1;
            if (node != null && node.Attributes != null && node.Attributes["id"] != null) {
                string sLrcId = node.Attributes["id"].Value;
                if (int.TryParse(sLrcId, out lrcId)) {
                    string xSinger = node.Attributes["artist"].Value;
                    string xTitle = node.Attributes["title"].Value;
                    retStr = RequestALink(string.Format(DownloadPath, lrcId, 
                        EncodeHelper.CreateQianQianCode(xSinger, xTitle, lrcId)));
                }
            }
            return retStr;
        }

        public event EventHandler InitializeProxy;
        public event EventHandler SelectSong;
        public event EventHandler WebException;
        protected void OnInitializeProxy() {
            if (this.InitializeProxy != null) {
                this.InitializeProxy(this, new EventArgs());
            }
        }

        protected void OnWebException(WebException ex) {
            if (this.WebException != null) {
                this.WebException(ex, new EventArgs());
            } else {
                throw ex;
            }
        }

        protected void OnSelectSong(XmlNodeList list) {
            if (this.SelectSong != null) {
                this.SelectSong(list, new EventArgs());
            }
        }

        public XmlDocument SearchLrc(string singer, string title) {
            singer = singer.ToLower().Replace(" ", "").Replace("'", "");
            title = title.ToLower().Replace(" ", "").Replace("'", "");
            string x = RequestALink(string.Format(SearchPath, 
                EncodeHelper.ToQianQianHexString(singer, Encoding.Unicode), 
                EncodeHelper.ToQianQianHexString(title, Encoding.Unicode)));
            XmlDocument xml = new XmlDocument();
            try {
                xml.LoadXml(x);
            } catch (Exception) {
            }
            return xml;
        }
    }

    public class SongBase {
        public SongBase(int id,string artist,string title) {
            this.id = id;
            this.artist = artist;
            this.title = title;
        }
        private int id;
        private string artist;
        private string title;

        public string Title {
            get { return title; }
            set { title = value; }
        }
	

        public string Artist {
            get { return artist; }
            set { artist = value; }
        }
	

        public int Id {
            get { return id; }
            set { id = value; }
        }
	
    }
}
