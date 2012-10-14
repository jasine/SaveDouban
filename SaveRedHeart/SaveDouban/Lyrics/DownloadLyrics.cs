using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Xml;
using System.IO;

namespace QianQianLrc
{
    public class DownloadLyrics
    {
        QianQianLrcer q = null;
        public string Atrist { get; set; }
        public string Title{get;set;}

        public DownloadLyrics() {
            //加true参数代表是网络访问是需要代理，否则设置为false。
            q = new QianQianLrcer(false);
            q.InitializeProxy += new EventHandler(q_InitializeProxy);
            q.WebException += new EventHandler(q_WebException);
            q.SelectSong += new EventHandler(q_SelectSong);
        }

        void q_SelectSong(object sender, EventArgs e) {
            XmlNodeList list = sender as XmlNodeList;
            double dist = double.MaxValue;
            string lArtist = Atrist.Trim().ToLower();
            string lTitle = Title.Trim().ToLower();
            foreach (XmlNode node in list)
            {
                string iArtist = node.Attributes["artist"].Value.ToLower();
			    string iTitle = node.Attributes["title"].Value.ToLower();
                if (lArtist == iArtist && lTitle == iTitle)
                {
                    q.CurrentSong =node;
                    break;
                }
                else if (lArtist.Length < 100 && lTitle.Length < 100 && iArtist.Length < 100 && iTitle.Length < 100)
                {
                    int dist1 = Distance(lArtist, iArtist);
                    int dist2 = Distance(lTitle, iTitle);
                    double temp = ((double)(dist1 + dist2)) / (lArtist.Length + lTitle.Length);
                    if (temp < dist)
                    {
                        dist = temp;
                        q.CurrentSong = node;
                    }
                }
            }
        }
        /// <summary>
        /// Levenshtein Distance算法，计算两个字符串之间的差异
        /// </summary>
        static int Distance(string a, string b)
        {
            if (string.IsNullOrEmpty(a)) return b.Length;
            if (string.IsNullOrEmpty(a)) return a.Length;
            int[][] d = new int[a.Length + 1][];
            for (int i = 0; i < d.Length; ++i)
                d[i] = new int[b.Length + 1];

            for (int i = 0; i <= a.Length; ++i)
                d[i][0] = i;
            for (int j = 0; j <= b.Length; ++j)
                d[0][j] = j;
            for (int i = 1; i <= a.Length; ++i)
                for (int j = 1; j <= b.Length; ++j)
                {
                    d[i][j] = int.MaxValue;
                    if (d[i - 1][j] + 1 < d[i][j]) d[i][j] = d[i - 1][j] + 1;
                    if (d[i][j - 1] + 1 < d[i][j]) d[i][j] = d[i][j - 1] + 1;
                    if (d[i - 1][j - 1] + (a[i - 1] == b[j - 1] ? 0 : 1) < d[i][j])
                        d[i][j] = d[i - 1][j - 1] + (a[i - 1] == b[j - 1] ? 0 : 1);
                }
            return d[a.Length][b.Length];
        }
        void q_WebException(object sender, EventArgs e) {
            WebException ex = sender as WebException;
            Debug.WriteLine(ex.Message);
        }

        void q_InitializeProxy(object sender, EventArgs e) {
//             WebProxy proxy = null;
//             //frmProxy f2 = new frmProxy();
//             f2.OkButton.Click += new EventHandler(delegate(object _sender, EventArgs _e) {
//                 proxy = new WebProxy(f2.Host.Text, int.Parse(f2.Port.Text));
//                 proxy.Credentials = new NetworkCredential(f2.Username.Text, f2.PwdText.Text);
//                 f2.Close();
//             });
//             //f2.ShowDialog();
//             q.Proxy = proxy;
        }
        
        public string GetLyric(string artist,string title) {
            Atrist = artist;
            Title = title;
            return q.DownloadLrc(Atrist, Title);
        }

        public bool SaveLyric(string artist, string title, string path)
        {
            try
            {
                File.WriteAllText(path,GetLyric(artist,title));
                return true;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
