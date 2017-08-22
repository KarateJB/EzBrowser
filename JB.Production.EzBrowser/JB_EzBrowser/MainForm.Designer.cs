namespace JB_EzBrowser
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tb_url = new System.Windows.Forms.TextBox();
            this.cb_myFav = new System.Windows.Forms.ComboBox();
            this.lb_openMyFavFile = new System.Windows.Forms.LinkLabel();
            this.Panel_fake = new System.Windows.Forms.Panel();
            this.timer_slide = new System.Windows.Forms.Timer(this.components);
            this.bt_uploadpic = new System.Windows.Forms.Button();
            this.lb_refresh = new System.Windows.Forms.LinkLabel();
            this.bt_addfav = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.bt_bgcolor = new System.Windows.Forms.Button();
            this.pb_TheForce = new System.Windows.Forms.PictureBox();
            this.picbox_fake = new System.Windows.Forms.PictureBox();
            this.bt_stop = new System.Windows.Forms.Button();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.bt_forward = new System.Windows.Forms.Button();
            this.bt_back = new System.Windows.Forms.Button();
            this.bt_Home = new System.Windows.Forms.Button();
            this.Panel_fake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.tabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_TheForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_fake)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_url
            // 
            this.tb_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tb_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tb_url, "tb_url");
            this.tb_url.Name = "tb_url";
            // 
            // cb_myFav
            // 
            this.cb_myFav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this.cb_myFav, "cb_myFav");
            this.cb_myFav.FormattingEnabled = true;
            this.cb_myFav.Name = "cb_myFav";
            this.cb_myFav.SelectedIndexChanged += new System.EventHandler(this.cb_myFav_SelectedIndexChanged);
            // 
            // lb_openMyFavFile
            // 
            resources.ApplyResources(this.lb_openMyFavFile, "lb_openMyFavFile");
            this.lb_openMyFavFile.Name = "lb_openMyFavFile";
            this.lb_openMyFavFile.TabStop = true;
            this.lb_openMyFavFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_openMyFavFile_LinkClicked);
            // 
            // Panel_fake
            // 
            this.Panel_fake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel_fake.Controls.Add(this.picbox_fake);
            resources.ApplyResources(this.Panel_fake, "Panel_fake");
            this.Panel_fake.Name = "Panel_fake";
            // 
            // timer_slide
            // 
            this.timer_slide.Interval = 30;
            this.timer_slide.Tick += new System.EventHandler(this.timer_slide_Tick);
            // 
            // bt_uploadpic
            // 
            resources.ApplyResources(this.bt_uploadpic, "bt_uploadpic");
            this.bt_uploadpic.Name = "bt_uploadpic";
            this.bt_uploadpic.UseVisualStyleBackColor = true;
            this.bt_uploadpic.Click += new System.EventHandler(this.bt_uploadpic_Click);
            // 
            // lb_refresh
            // 
            resources.ApplyResources(this.lb_refresh, "lb_refresh");
            this.lb_refresh.Name = "lb_refresh";
            this.lb_refresh.TabStop = true;
            this.lb_refresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_refresh_LinkClicked);
            // 
            // bt_addfav
            // 
            resources.ApplyResources(this.bt_addfav, "bt_addfav");
            this.bt_addfav.Name = "bt_addfav";
            this.bt_addfav.UseVisualStyleBackColor = true;
            this.bt_addfav.Click += new System.EventHandler(this.bt_addfav_Click);
            // 
            // trackBar
            // 
            resources.ApplyResources(this.trackBar, "trackBar");
            this.trackBar.LargeChange = 10;
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.SmallChange = 5;
            this.trackBar.TickFrequency = 10;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.Value = 100;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabCtrl, "tabCtrl");
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // pBar
            // 
            resources.ApplyResources(this.pBar, "pBar");
            this.pBar.Name = "pBar";
            this.pBar.Step = 1;
            // 
            // bt_bgcolor
            // 
            resources.ApplyResources(this.bt_bgcolor, "bt_bgcolor");
            this.bt_bgcolor.Name = "bt_bgcolor";
            this.bt_bgcolor.UseVisualStyleBackColor = true;
            this.bt_bgcolor.Click += new System.EventHandler(this.bt_bgcolor_Click);
            // 
            // pb_TheForce
            // 
            this.pb_TheForce.BackgroundImage = global::JB_EzBrowser.Properties.Resources.Force;
            resources.ApplyResources(this.pb_TheForce, "pb_TheForce");
            this.pb_TheForce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_TheForce.Name = "pb_TheForce";
            this.pb_TheForce.TabStop = false;
            this.pb_TheForce.Click += new System.EventHandler(this.pb_TheForce_Click);
            // 
            // picbox_fake
            // 
            resources.ApplyResources(this.picbox_fake, "picbox_fake");
            this.picbox_fake.Name = "picbox_fake";
            this.picbox_fake.TabStop = false;
            this.picbox_fake.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.picbox_fake.MouseEnter += new System.EventHandler(this.MainForm_MouseEnter);
            this.picbox_fake.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.picbox_fake.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.picbox_fake.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // bt_stop
            // 
            this.bt_stop.BackgroundImage = global::JB_EzBrowser.Properties.Resources.stop;
            resources.ApplyResources(this.bt_stop, "bt_stop");
            this.bt_stop.FlatAppearance.BorderSize = 0;
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // bt_refresh
            // 
            this.bt_refresh.BackgroundImage = global::JB_EzBrowser.Properties.Resources.refresh;
            resources.ApplyResources(this.bt_refresh, "bt_refresh");
            this.bt_refresh.FlatAppearance.BorderSize = 0;
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // bt_forward
            // 
            this.bt_forward.BackgroundImage = global::JB_EzBrowser.Properties.Resources.forward01;
            resources.ApplyResources(this.bt_forward, "bt_forward");
            this.bt_forward.FlatAppearance.BorderSize = 0;
            this.bt_forward.Name = "bt_forward";
            this.bt_forward.UseVisualStyleBackColor = true;
            this.bt_forward.Click += new System.EventHandler(this.bt_forward_Click);
            // 
            // bt_back
            // 
            this.bt_back.BackgroundImage = global::JB_EzBrowser.Properties.Resources.back01;
            resources.ApplyResources(this.bt_back, "bt_back");
            this.bt_back.FlatAppearance.BorderSize = 0;
            this.bt_back.Name = "bt_back";
            this.bt_back.UseVisualStyleBackColor = true;
            this.bt_back.Click += new System.EventHandler(this.bt_back_Click);
            // 
            // bt_Home
            // 
            this.bt_Home.BackgroundImage = global::JB_EzBrowser.Properties.Resources.home;
            resources.ApplyResources(this.bt_Home, "bt_Home");
            this.bt_Home.FlatAppearance.BorderSize = 0;
            this.bt_Home.Name = "bt_Home";
            this.bt_Home.UseVisualStyleBackColor = true;
            this.bt_Home.Click += new System.EventHandler(this.bt_Home_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.Panel_fake);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.lb_openMyFavFile);
            this.Controls.Add(this.cb_myFav);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.bt_forward);
            this.Controls.Add(this.bt_back);
            this.Controls.Add(this.bt_uploadpic);
            this.Controls.Add(this.lb_refresh);
            this.Controls.Add(this.bt_addfav);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.bt_bgcolor);
            this.Controls.Add(this.bt_Home);
            this.Controls.Add(this.pb_TheForce);
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DoubleClick += new System.EventHandler(this.MainForm_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.MainForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Panel_fake.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.tabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_TheForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_fake)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_back;
        private System.Windows.Forms.Button bt_forward;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.ComboBox cb_myFav;
        private System.Windows.Forms.LinkLabel lb_openMyFavFile;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.Panel Panel_fake;
        private System.Windows.Forms.PictureBox picbox_fake;
        private System.Windows.Forms.Timer timer_slide;
        private System.Windows.Forms.Button bt_uploadpic;
        private System.Windows.Forms.LinkLabel lb_refresh;
        private System.Windows.Forms.Button bt_addfav;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button bt_bgcolor;
        private System.Windows.Forms.Button bt_Home;
        private System.Windows.Forms.PictureBox pb_TheForce;

    }
}

