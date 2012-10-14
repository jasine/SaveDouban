using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChobiQ.DoubanFMAPICodePack;

namespace SaveDouban
{
    public partial class SaveDouban : Form
    {
        DownloadSong download;
        public SaveDouban()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            tb_dir.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\豆瓣加心歌曲\";
            download = new DownloadSong(tb_dir.Text);
            download.NewSong += NewSong;
            download.Progress+=download_Progress;
            //download.AskStop += download_AskStop;
            download.Msg += download_Msg;
            
            pic_cover.Image = Properties.Resources.cover;
        }




        

        private void SaveReadHeart_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 展开和关闭设值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_seeting_Click(object sender, EventArgs e)
        {
            if (this.Width<=397)
            {
                this.Width = 740;
                btn_seeting.Text = "设置<<";
            }
            else
            {
                this.Width = 397;
                btn_seeting.Text = "设置>>";
            }
        }

        /// <summary>
        /// 登陆事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_name.Text) || string.IsNullOrEmpty(tb_pwd.Text))
            {
                return;
            }

            string rsp = download.Login(tb_name.Text, tb_pwd.Text);
            if (rsp == "登录成功")
            {
                btn_login.Text = "注销";
                tb_name.Enabled = false;
                lb_pwd.Text = "您好 " + download.UserName;
                tb_pwd.Visible = false;
                btn_download.Enabled = true;
                btn_login.Visible = false;
                tb_songNum.Visible = true;
            }
            else
            {
                MessageBox.Show(rsp);
            }
//             if (tb_pwd.Visible==true)
//             {
//                 if (string.IsNullOrEmpty(tb_name.Text) || string.IsNullOrEmpty(tb_pwd.Text))
//                 {
//                     return;
//                 }
// 
//                 string rsp = download.Login(tb_name.Text, tb_pwd.Text);
//                 if (rsp == "登录成功")
//                 {
//                     btn_login.Text = "注销";
//                     tb_name.Enabled = false;
//                     lb_pwd.Text = "您好 " + download.UserName;
//                     tb_pwd.Visible = false;
//                     btn_download.Enabled = true;
//                 }
//                 else
//                 {
//                     MessageBox.Show(rsp);
//                 }
//             }
//             else
//             {
//                 tb_name.Enabled = true;
//                 tb_pwd.Visible = true;
//                 lb_pwd.Text = "密码";
//                 //download = new DownloadSong(tb_dir.Text);
//                 btn_login.Text = "登录";
//                 btn_download.Enabled = false;
//                 btn_save.Enabled = true;
//             }
                      
        }

        /// <summary>
        /// 设置存放路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton=true;
            fbd.Description="请选择存放路径";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                download.Path = fbd.SelectedPath+@"\";
                tb_dir.Text = download.Path;
            }
        }

        /// <summary>
        /// 开始下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_download_Click(object sender, EventArgs e)
        {
            if (btn_download.Text=="下载")
            {
                int num=0;
                if (!int.TryParse(tb_songNum.Text,out num))
                {
                    MessageBox.Show("下载歌曲数输入有误!");
                    return;
                }
                tb_songNum.Enabled = false;
                chb_cover.Enabled = false;
                chb_lyric.Enabled = false;
                btn_save.Enabled = false;
                rdb_lyric.Enabled = false;
                rdb_lcurrent.Enabled = false;
                rdb_ccover.Enabled = false;
                rdb_ccurrent.Enabled = false;
                rdb_id3v1.Enabled = false;
                rdb_id3v2.Enabled = false;
                btn_download.Text = "停止";
                download.Total = num;
                download.Start();
            }
            else
            {                
                download.Stop();
                SetBackStatue();
            }
            
        }

        /// <summary>
        /// 停止或者成功后还原控件状态
        /// </summary>
        private void SetBackStatue()
        {
            lb_msg.Text = "信息";
            tb_songNum.Enabled = true;
            chb_cover.Enabled = true;
            chb_lyric.Enabled = true;
            btn_save.Enabled = true;
            rdb_id3v1.Enabled = true;
            rdb_id3v2.Enabled = true;
            if (chb_cover.Checked == true)
            {
                rdb_ccover.Enabled = true;
                rdb_ccurrent.Enabled = true;
            }
            if (chb_lyric.Checked == true)
            {
                rdb_lyric.Enabled = true;
                rdb_lcurrent.Enabled = true;
            }
            btn_download.Text = "下载";
            lb_num.Text = "下载进度";
            lb_title.Text = "歌曲名";
            lb_artist.Text = "演唱者";
            lb_progess.Text = "进度";
            prb_process.Value = 0;
            pic_cover.Image = Properties.Resources.cover;
        }


        #region 底层DownloadSong类事件
        /// <summary>
        /// 当前下载的歌曲信息
        /// </summary>
        /// <param name="num"></param>
        /// <param name="img"></param>
        /// <param name="title"></param>
        /// <param name="artist"></param>
        private void NewSong(int num, Image img, string title, string artist)
        {
            lb_num.Text = "第" + num + "首";
            lb_title.Text = title;//.Length<=8?title:title.Substring(0,7)+"..";
            lb_artist.Text = artist;
            pic_cover.Image = img;
        }

        /// <summary>
        /// 当前歌曲的下载进度
        /// </summary>
        /// <param name="obj"></param>
        private void download_Progress(int pro)
        {
            prb_process.Value = pro;
            lb_progess.Text = pro.ToString() + "%";
        }


        /// <summary>
        /// 下载完成事件
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        void download_Msg(int success, int fail, int exist, string msg)
        {

            lb_msg.Text = "成功" + success + "首 已存在" + exist + "首 失败" + fail + "首";
            if (msg!="")
            {
                MessageBox.Show(msg + "\n  成功" + success + "首  失败" + fail + "首 " + exist + "首已存在在");
                SetBackStatue();
            }           
        }

        //         bool download_AskStop()
        //         {
        //             if (MessageBox.Show("尝试获取次数过多，建议关闭程序，半个小时后候再在原文件夹下载,是否继续尝试？", "提示", MessageBoxButtons.YesNo) == DialogResult.OK)
        //             {
        //                 return false;
        //             }
        //             else
        //             {
        //                 return true;
        //                 
        //             }
        //         } 
        #endregion





        /// <summary>
        /// 用户更改要嵌入音乐的ID3版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_id3v1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_id3v1.Checked==true)
            {
                download.ID3Version = 1;
            }
            else
            {
                download.ID3Version = 2;
            }
        }

        #region 封面下载相关事件
        /// <summary>
        /// 用户选择是否同时下载封面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chb_cover_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_cover.Checked == true)
            {
                rdb_ccover.Enabled = true;
                rdb_ccurrent.Enabled = true;
                download.CoverPath = tb_dir.Text + (rdb_ccover.Checked ? @"cover\" : "");
            }
            else
            {
                download.CoverPath = "";
                rdb_ccover.Enabled = false;
                rdb_ccurrent.Enabled = false;
            }
        }
        /// <summary>
        /// 用户选择封面路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_ccover_CheckedChanged(object sender, EventArgs e)
        {           
            download.CoverPath = tb_dir.Text + (rdb_ccover.Checked ? @"cover\" : "");
        }
        
        #endregion


        #region 歌词下载相关事件
        /// <summary>
        /// 用户选择是否同时下载歌词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chb_lyric_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_lyric.Checked == true)
            {
                rdb_lyric.Enabled = true;
                rdb_lcurrent.Enabled = true;
                download.LyricPath = tb_dir.Text + (rdb_ccover.Checked ? @"lyric\" : "");
            }
            else
            {
                rdb_lyric.Enabled = false;
                rdb_lcurrent.Enabled = false;
                download.LyricPath = "";
            }
        }
        /// <summary>
        /// 用户选择歌词路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_lyric_CheckedChanged(object sender, EventArgs e)
        {
            download.LyricPath = tb_dir.Text + (rdb_lyric.Checked ? @"lyric\" : "");
        } 
        #endregion
        



    }
}
