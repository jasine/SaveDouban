namespace SaveDouban
{
    partial class SaveDouban
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveDouban));
            this.tb_name = new System.Windows.Forms.TextBox();
            this.lb_name = new System.Windows.Forms.Label();
            this.tb_pwd = new System.Windows.Forms.TextBox();
            this.lb_pwd = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.prb_process = new System.Windows.Forms.ProgressBar();
            this.gb_id3 = new System.Windows.Forms.GroupBox();
            this.rdb_id3v2 = new System.Windows.Forms.RadioButton();
            this.rdb_id3v1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_lyric = new System.Windows.Forms.GroupBox();
            this.chb_lyric = new System.Windows.Forms.CheckBox();
            this.rdb_lyric = new System.Windows.Forms.RadioButton();
            this.rdb_lcurrent = new System.Windows.Forms.RadioButton();
            this.btn_download = new System.Windows.Forms.Button();
            this.rdb_ccurrent = new System.Windows.Forms.RadioButton();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_dir = new System.Windows.Forms.TextBox();
            this.rdb_ccover = new System.Windows.Forms.RadioButton();
            this.btn_seeting = new System.Windows.Forms.Button();
            this.lb_num = new System.Windows.Forms.Label();
            this.lb_title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chb_cover = new System.Windows.Forms.CheckBox();
            this.lb_artist = new System.Windows.Forms.Label();
            this.lb_progess = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_songNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_msg = new System.Windows.Forms.Label();
            this.pic_cover = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_id3.SuspendLayout();
            this.gb_lyric.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(47, 6);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(112, 21);
            this.tb_name.TabIndex = 0;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(12, 9);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(29, 12);
            this.lb_name.TabIndex = 1;
            this.lb_name.Text = "邮箱";
            // 
            // tb_pwd
            // 
            this.tb_pwd.Location = new System.Drawing.Point(204, 5);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.PasswordChar = '*';
            this.tb_pwd.Size = new System.Drawing.Size(106, 21);
            this.tb_pwd.TabIndex = 0;
            // 
            // lb_pwd
            // 
            this.lb_pwd.AutoSize = true;
            this.lb_pwd.Location = new System.Drawing.Point(165, 9);
            this.lb_pwd.Name = "lb_pwd";
            this.lb_pwd.Size = new System.Drawing.Size(29, 12);
            this.lb_pwd.TabIndex = 1;
            this.lb_pwd.Text = "密码";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(316, 4);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(59, 23);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "内嵌简单信息，大部分MP3和系统都支持";
            // 
            // prb_process
            // 
            this.prb_process.Location = new System.Drawing.Point(197, 171);
            this.prb_process.Name = "prb_process";
            this.prb_process.Size = new System.Drawing.Size(141, 15);
            this.prb_process.TabIndex = 5;
            // 
            // gb_id3
            // 
            this.gb_id3.Controls.Add(this.rdb_id3v2);
            this.gb_id3.Controls.Add(this.rdb_id3v1);
            this.gb_id3.Controls.Add(this.label1);
            this.gb_id3.Controls.Add(this.label3);
            this.gb_id3.Location = new System.Drawing.Point(392, 35);
            this.gb_id3.Name = "gb_id3";
            this.gb_id3.Size = new System.Drawing.Size(320, 101);
            this.gb_id3.TabIndex = 6;
            this.gb_id3.TabStop = false;
            this.gb_id3.Text = "ID3信息";
            // 
            // rdb_id3v2
            // 
            this.rdb_id3v2.AutoSize = true;
            this.rdb_id3v2.Checked = true;
            this.rdb_id3v2.Location = new System.Drawing.Point(6, 60);
            this.rdb_id3v2.Name = "rdb_id3v2";
            this.rdb_id3v2.Size = new System.Drawing.Size(77, 16);
            this.rdb_id3v2.TabIndex = 0;
            this.rdb_id3v2.TabStop = true;
            this.rdb_id3v2.Text = "ID3V2版本";
            this.rdb_id3v2.UseVisualStyleBackColor = true;
            // 
            // rdb_id3v1
            // 
            this.rdb_id3v1.AutoSize = true;
            this.rdb_id3v1.Location = new System.Drawing.Point(6, 20);
            this.rdb_id3v1.Name = "rdb_id3v1";
            this.rdb_id3v1.Size = new System.Drawing.Size(77, 16);
            this.rdb_id3v1.TabIndex = 0;
            this.rdb_id3v1.Text = "ID3V1版本";
            this.rdb_id3v1.UseVisualStyleBackColor = true;
            this.rdb_id3v1.CheckedChanged += new System.EventHandler(this.rdb_id3v1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "内嵌专辑封面，豆瓣评分等较多信息,大部分MP3不支持";
            // 
            // gb_lyric
            // 
            this.gb_lyric.Controls.Add(this.chb_lyric);
            this.gb_lyric.Controls.Add(this.rdb_lyric);
            this.gb_lyric.Controls.Add(this.rdb_lcurrent);
            this.gb_lyric.Location = new System.Drawing.Point(392, 142);
            this.gb_lyric.Name = "gb_lyric";
            this.gb_lyric.Size = new System.Drawing.Size(320, 44);
            this.gb_lyric.TabIndex = 6;
            this.gb_lyric.TabStop = false;
            this.gb_lyric.Text = "歌词";
            // 
            // chb_lyric
            // 
            this.chb_lyric.AutoSize = true;
            this.chb_lyric.Location = new System.Drawing.Point(13, 17);
            this.chb_lyric.Name = "chb_lyric";
            this.chb_lyric.Size = new System.Drawing.Size(72, 16);
            this.chb_lyric.TabIndex = 1;
            this.chb_lyric.Text = "下载歌词";
            this.chb_lyric.UseVisualStyleBackColor = true;
            this.chb_lyric.CheckedChanged += new System.EventHandler(this.chb_lyric_CheckedChanged);
            // 
            // rdb_lyric
            // 
            this.rdb_lyric.AutoSize = true;
            this.rdb_lyric.Checked = true;
            this.rdb_lyric.Enabled = false;
            this.rdb_lyric.Location = new System.Drawing.Point(88, 16);
            this.rdb_lyric.Name = "rdb_lyric";
            this.rdb_lyric.Size = new System.Drawing.Size(119, 16);
            this.rdb_lyric.TabIndex = 0;
            this.rdb_lyric.TabStop = true;
            this.rdb_lyric.Text = "当前文件夹\\lyric";
            this.rdb_lyric.UseVisualStyleBackColor = true;
            this.rdb_lyric.CheckedChanged += new System.EventHandler(this.rdb_lyric_CheckedChanged);
            // 
            // rdb_lcurrent
            // 
            this.rdb_lcurrent.AutoSize = true;
            this.rdb_lcurrent.Enabled = false;
            this.rdb_lcurrent.Location = new System.Drawing.Point(213, 16);
            this.rdb_lcurrent.Name = "rdb_lcurrent";
            this.rdb_lcurrent.Size = new System.Drawing.Size(83, 16);
            this.rdb_lcurrent.TabIndex = 0;
            this.rdb_lcurrent.Text = "当前文件夹";
            this.rdb_lcurrent.UseVisualStyleBackColor = true;
            // 
            // btn_download
            // 
            this.btn_download.Enabled = false;
            this.btn_download.Location = new System.Drawing.Point(254, 32);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(56, 23);
            this.btn_download.TabIndex = 2;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // rdb_ccurrent
            // 
            this.rdb_ccurrent.AutoSize = true;
            this.rdb_ccurrent.Enabled = false;
            this.rdb_ccurrent.Location = new System.Drawing.Point(213, 22);
            this.rdb_ccurrent.Name = "rdb_ccurrent";
            this.rdb_ccurrent.Size = new System.Drawing.Size(83, 16);
            this.rdb_ccurrent.TabIndex = 0;
            this.rdb_ccurrent.Text = "当前文件夹";
            this.rdb_ccurrent.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(667, 6);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(40, 23);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "浏览";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_dir
            // 
            this.tb_dir.Location = new System.Drawing.Point(431, 6);
            this.tb_dir.Name = "tb_dir";
            this.tb_dir.ReadOnly = true;
            this.tb_dir.Size = new System.Drawing.Size(230, 21);
            this.tb_dir.TabIndex = 0;
            // 
            // rdb_ccover
            // 
            this.rdb_ccover.AutoSize = true;
            this.rdb_ccover.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdb_ccover.Checked = true;
            this.rdb_ccover.Enabled = false;
            this.rdb_ccover.Location = new System.Drawing.Point(88, 21);
            this.rdb_ccover.Name = "rdb_ccover";
            this.rdb_ccover.Size = new System.Drawing.Size(119, 16);
            this.rdb_ccover.TabIndex = 0;
            this.rdb_ccover.TabStop = true;
            this.rdb_ccover.Text = "当前文件夹\\cover";
            this.rdb_ccover.UseVisualStyleBackColor = true;
            this.rdb_ccover.CheckedChanged += new System.EventHandler(this.rdb_ccover_CheckedChanged);
            // 
            // btn_seeting
            // 
            this.btn_seeting.Location = new System.Drawing.Point(316, 32);
            this.btn_seeting.Name = "btn_seeting";
            this.btn_seeting.Size = new System.Drawing.Size(59, 23);
            this.btn_seeting.TabIndex = 2;
            this.btn_seeting.Text = "设值>>";
            this.btn_seeting.UseVisualStyleBackColor = true;
            this.btn_seeting.Click += new System.EventHandler(this.btn_seeting_Click);
            // 
            // lb_num
            // 
            this.lb_num.AutoSize = true;
            this.lb_num.Location = new System.Drawing.Point(195, 76);
            this.lb_num.Name = "lb_num";
            this.lb_num.Size = new System.Drawing.Size(53, 12);
            this.lb_num.TabIndex = 7;
            this.lb_num.Text = "下载进度";
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_title.Location = new System.Drawing.Point(193, 104);
            this.lb_title.MaximumSize = new System.Drawing.Size(180, 21);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(76, 21);
            this.lb_title.TabIndex = 7;
            this.lb_title.Text = "歌曲名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chb_cover);
            this.groupBox1.Controls.Add(this.rdb_ccover);
            this.groupBox1.Controls.Add(this.rdb_ccurrent);
            this.groupBox1.Location = new System.Drawing.Point(392, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 44);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "封面";
            // 
            // chb_cover
            // 
            this.chb_cover.AutoSize = true;
            this.chb_cover.Location = new System.Drawing.Point(13, 22);
            this.chb_cover.Name = "chb_cover";
            this.chb_cover.Size = new System.Drawing.Size(72, 16);
            this.chb_cover.TabIndex = 2;
            this.chb_cover.Text = "下载封面";
            this.chb_cover.UseVisualStyleBackColor = true;
            this.chb_cover.CheckedChanged += new System.EventHandler(this.chb_cover_CheckedChanged);
            // 
            // lb_artist
            // 
            this.lb_artist.AutoSize = true;
            this.lb_artist.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_artist.ForeColor = System.Drawing.Color.Black;
            this.lb_artist.Location = new System.Drawing.Point(196, 136);
            this.lb_artist.MaximumSize = new System.Drawing.Size(180, 16);
            this.lb_artist.Name = "lb_artist";
            this.lb_artist.Size = new System.Drawing.Size(56, 16);
            this.lb_artist.TabIndex = 7;
            this.lb_artist.Text = "演唱者";
            // 
            // lb_progess
            // 
            this.lb_progess.AutoSize = true;
            this.lb_progess.Location = new System.Drawing.Point(344, 174);
            this.lb_progess.Name = "lb_progess";
            this.lb_progess.Size = new System.Drawing.Size(29, 12);
            this.lb_progess.TabIndex = 7;
            this.lb_progess.Text = "进度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "路径";
            // 
            // tb_songNum
            // 
            this.tb_songNum.Location = new System.Drawing.Point(208, 32);
            this.tb_songNum.Name = "tb_songNum";
            this.tb_songNum.Size = new System.Drawing.Size(44, 21);
            this.tb_songNum.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "下载数量(从豆瓣电台主页查看总数)";
            // 
            // lb_msg
            // 
            this.lb_msg.AutoSize = true;
            this.lb_msg.Location = new System.Drawing.Point(197, 204);
            this.lb_msg.Name = "lb_msg";
            this.lb_msg.Size = new System.Drawing.Size(29, 12);
            this.lb_msg.TabIndex = 7;
            this.lb_msg.Text = "信息";
            // 
            // pic_cover
            // 
            this.pic_cover.Location = new System.Drawing.Point(14, 60);
            this.pic_cover.Name = "pic_cover";
            this.pic_cover.Size = new System.Drawing.Size(162, 156);
            this.pic_cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_cover.TabIndex = 3;
            this.pic_cover.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "jasinechen@gmail.com";
            // 
            // SaveDouban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(381, 250);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_songNum);
            this.Controls.Add(this.lb_artist);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.lb_progess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_msg);
            this.Controls.Add(this.lb_num);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_lyric);
            this.Controls.Add(this.gb_id3);
            this.Controls.Add(this.prb_process);
            this.Controls.Add(this.pic_cover);
            this.Controls.Add(this.btn_seeting);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lb_pwd);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.tb_dir);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.tb_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SaveDouban";
            this.Text = "豆瓣加心歌曲下载器";
            this.Load += new System.EventHandler(this.SaveReadHeart_Load);
            this.gb_id3.ResumeLayout(false);
            this.gb_id3.PerformLayout();
            this.gb_lyric.ResumeLayout(false);
            this.gb_lyric.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.TextBox tb_pwd;
        private System.Windows.Forms.Label lb_pwd;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.PictureBox pic_cover;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar prb_process;
        private System.Windows.Forms.GroupBox gb_id3;
        private System.Windows.Forms.GroupBox gb_lyric;
        private System.Windows.Forms.RadioButton rdb_id3v2;
        private System.Windows.Forms.RadioButton rdb_id3v1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chb_lyric;
        private System.Windows.Forms.RadioButton rdb_ccover;
        private System.Windows.Forms.RadioButton rdb_ccurrent;
        private System.Windows.Forms.RadioButton rdb_lcurrent;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_dir;
        private System.Windows.Forms.Button btn_seeting;
        private System.Windows.Forms.Label lb_num;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chb_cover;
        private System.Windows.Forms.RadioButton rdb_lyric;
        private System.Windows.Forms.Label lb_artist;
        private System.Windows.Forms.Label lb_progess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_songNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_msg;
        private System.Windows.Forms.Label label5;
    }
}