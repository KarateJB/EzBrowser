using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace JB_EzBrowser
{
    public partial class MainForm : Form
    {
        private ContextMenuStrip cmenustrip_tp= new ContextMenuStrip(); //for TabControl
        string [][] myFavFileList=new string [0][]; //記錄我的最愛
        public MainForm()
        {
            //Master commit
            InitializeComponent();
            this.KeyPreview = true;  //處理按鍵事件
            Show_myFavFileList(); //顯示我的最愛

            //設定TabPage的右鍵選單
            SetContextMenuStrip_TP();
            //設定每個WebBrowser的PreKeyDown事件
            foreach (TabPage tp in tabCtrl.Controls)
            {
                foreach (WebBrowser wb in tp.Controls)
                {
                    wb.PreviewKeyDown += new PreviewKeyDownEventHandler(webBrowser_PreviewKeyDown);
                }
            }


            //試用版限制
            //bt_addfav.Enabled = false;
            //cb_myFav.Enabled = false;
            
        }

        //----------------------------------------------------------
        //函式名稱: MainForm_Shown
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void MainForm_Shown(object sender, EventArgs e)
        {
            //webBrowser1.Url = new Uri("http://www.google.com.tw");
            //tb_url.Text = "http://www.google.com.tw";
            //設定URL列的網址為首頁
            Set_HomePage_Url();

            //設定Panel_fake
            Panel_fake.Width = 590;
            Panel_fake.Height = 320; //ps. Form啟始高度357
            Panel_fake.Left= this.Width;
            //設定圖檔
            if (File.Exists("fake.jpg"))
            {
                picbox_fake.BackgroundImage = new Bitmap("fake.jpg"); 
            }
        }

        //----------------------------------------------------------
        //函式名稱: MainForm_FormClosed
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //清除記憶體空間
            Array.Clear(myFavFileList, 0, myFavFileList.Length); 
        }

        //----------------------------------------------------------
        //函式名稱: MainForm_Resize
        //說明: 改變視窗大小時，同步改變原件大小
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //Web Browser
            tabCtrl.Height = this.Height - 90;
            tabCtrl.Width = this.Width - 170;
            tb_url.Width = tabCtrl.Width - 155;
           
            //Panel_fake
            Panel_fake.Width = this.Width;
            Panel_fake.Height = this.Height - 37;
            if(Panel_fake.Left!=0) Panel_fake.Left = this.Width;
        }
        //----------------------------------------------------------
        //函式名稱: SetContextMenuStrip_TP
        //說明: TabControl右鍵選單內容
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void SetContextMenuStrip_TP()
        {
            ToolStripMenuItem tsmi_newpage = new ToolStripMenuItem("新分頁", null, new EventHandler(tsmi_newpage_Click));
            ToolStripMenuItem tsmi_closepage = new ToolStripMenuItem("關閉", null, new EventHandler(tsmi_closepage_Click));
            cmenustrip_tp.Items.Add(tsmi_newpage);
            cmenustrip_tp.Items.Add(tsmi_closepage);
            tabCtrl.ContextMenuStrip = cmenustrip_tp;
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_newpage_Click
        //說明: tabControl [新分頁] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_newpage_Click(object sender, EventArgs e)
        {
            if (tabCtrl.TabPages.Count > 10)
            {
                MessageBox.Show("無法再新增新的查詢頁面!", "系統警告");
                return;
            }
            TabPage tp = new TabPage("分頁(" + (tabCtrl.TabPages.Count + 1).ToString() + ")");
            tabCtrl.TabPages.Add(tp);
            tabCtrl.SelectedIndex = tabCtrl.TabPages.Count - 1;
            //WebBrowser----------------------------------
            WebBrowser new_wb = new WebBrowser();
            new_wb.Parent = tp;
            new_wb.Dock = DockStyle.Fill;
            new_wb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser_PreviewKeyDown);
            new_wb.Focus();

            //自動連結到複製的網址
            tb_url.Text = Clipboard.GetText();
            bt_refresh_Click(sender, null);
        }
        //----------------------------------------------------------
        //函式名稱: tsmi_closepage_Click
        //說明: tabControl [關閉] CLICK事件
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void tsmi_closepage_Click(object sender, EventArgs e)
        {
            TabPage tp = tabCtrl.TabPages[tabCtrl.SelectedIndex];
            if (tp.Text== "主頁")
            {
                MessageBox.Show("您不能關閉此系統預設分頁!", "系統警告");
            }
            else
            {
                foreach (WebBrowser wb in tp.Controls)
                {
                    wb.Dispose(); //Dispose WebBrowser
                }
                tp.Dispose(); //Dispose 分頁
            }
            tp = null;
        }
        //----------------------------------------------------------
        //函式名稱: Show_myFavFileList
        //說明: 顯示我的最愛
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void Show_myFavFileList()
        {
            cb_myFav.Items.Clear();
            Array.Clear(myFavFileList, 0, myFavFileList.Length);
            if (File.Exists("我的最愛.txt"))
            {
                 StreamReader sr = new StreamReader("我的最愛.txt");
                int index=0;
                while (!sr.EndOfStream)
                {     
                    string str = sr.ReadLine();
                    if (str != "")
                    {
                        if (str.IndexOf("@") > 0)
                        {
                            string web_name = str.Substring(0, str.IndexOf("@"));
                            string web_url = str.Substring(str.IndexOf("@") + 1, str.Length - str.IndexOf("@") - 1);
                            Array.Resize(ref myFavFileList, myFavFileList.Length + 1); //擴充記憶體空間
                            myFavFileList[index] = new string[] { web_name, web_url }; //放入web_name和web_url
                            cb_myFav.Items.Add(web_name);
                            index++;
                        }
                    }
                }//while
                sr.Close();
                sr = null;
            }
        }
        //----------------------------------------------------------
        //函式名稱: cb_myFav_SelectedIndexChanged
        //說明: 選擇我的最愛
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void cb_myFav_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < myFavFileList.Length; i++)
            {
                if (cb_myFav.SelectedItem.ToString() == myFavFileList[i][0])
                {
                    tb_url.Text = myFavFileList[i][1];
                    break;
                }
            }
        }
        //----------------------------------------------------------
        //函式名稱: bt_Home_Click
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_Home_Click(object sender, EventArgs e)
        {
            //設定URL列的網址為首頁
            Set_HomePage_Url();
            //前往網址
            bt_refresh_Click(sender, null);
        }

        //----------------------------------------------------------
        //函式名稱: Set_HomePage_Url
        //說明: 設定URL列的網址為首頁
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void Set_HomePage_Url()
        {
            //設定網址為我的最愛的第一個項目的URL
            tb_url.Text = myFavFileList[0][1];
        }

        //----------------------------------------------------------
        //函式名稱: bt_refresh_Click
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_refresh_Click(object sender, EventArgs e)
        {
            if (!bgWorker.IsBusy) //當作業背景不忙碌時
            {
                pBar.Value = 0;
                Form.CheckForIllegalCrossThreadCalls = false; //設定Thread可存取元件
                tabCtrl.Enabled = false;
                bgWorker.RunWorkerAsync(); //執行bgWorker_DoWork
            }
            else
            {
                MessageBox.Show("Loading Web Content...plz wait!");
            }
        }
        //----------------------------------------------------------
        //函式名稱: bgWorker_DoWork
        //說明: 背景作業的執行程式碼
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            /*Thread.Sleep(5000);
            for(int i=0;i<100;i++)
            {
                bgWorker.ReportProgress(i);
                Thread.Sleep(10);
            }*/

            // 前往網址輸入框中的網址
            TabPage tp = tabCtrl.TabPages[tabCtrl.SelectedIndex];
            foreach (WebBrowser wb in tp.Controls)
            {
                wb.Navigate(tb_url.Text);
            }
            tp = null;
        }
        //----------------------------------------------------------
        //函式名稱: bgWorker_ProgressChanged
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.Value = e.ProgressPercentage;  //依據ReportProgress方法的傳入參數改變Progressbar的Value 
            //Label3.Text = "進度i=" & e.ProgressPercentage & "/ 時間：" & Now.ToString("HH:mm:ss.fffffff") <==顯示每一次ProgressBar改變的時間
        }
        //----------------------------------------------------------
        //函式名稱: bgWorker_RunWorkerCompleted
        //說明: 背景作業完成時
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tabCtrl.Enabled = true;
            pBar.Value = pBar.Maximum;
            Form.CheckForIllegalCrossThreadCalls = true;
        }
        //----------------------------------------------------------
        //函式名稱: LLB_EditBigSql_LinkClicked
        //說明: 顯示EditSqlForm
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_stop_Click(object sender, EventArgs e)
        {
            //停止
            TabPage tp = tabCtrl.TabPages[tabCtrl.SelectedIndex];
            foreach (WebBrowser wb in tp.Controls)
            {
                wb.Stop();
            }
            tp = null;
        }
        //----------------------------------------------------------
        //函式名稱: LLB_EditBigSql_LinkClicked
        //說明: 顯示EditSqlForm
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_back_Click(object sender, EventArgs e)
        {
            //上一頁
            if (!bgWorker.IsBusy)
            {
                TabPage tp = tabCtrl.TabPages[tabCtrl.SelectedIndex];
                foreach (WebBrowser wb in tp.Controls)
                {
                    wb.GoBack();
                }
                tp = null;
            }
        }
        //----------------------------------------------------------
        //函式名稱: LLB_EditBigSql_LinkClicked
        //說明: 顯示EditSqlForm
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_forward_Click(object sender, EventArgs e)
        {
            //下一頁
            if (!bgWorker.IsBusy)
            {
                TabPage tp = tabCtrl.TabPages[tabCtrl.SelectedIndex];
                foreach (WebBrowser wb in tp.Controls)
                {
                    wb.GoForward();
                }
                tp = null;
            }
        }
        //----------------------------------------------------------
        //函式名稱: lb_openMyFavFile_LinkClicked
        //說明: 開啟我的最愛.txt
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void lb_openMyFavFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists("我的最愛.txt"))
            {
                Process.Start("notepad", "我的最愛.txt");
            }
            else
            {
                MessageBox.Show("我的最愛.txt 不存在（請置於執行檔相同資料夾)!!", "檔案遺失!");
            }
        }
        //----------------------------------------------------------
        //函式名稱: MainForm-MouseEnter,MouseLeave,MouseDown,MouseUp,MouseMove
        //說明: 
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private int ms_xPos_s;
        private int ms_xPos_e;
        private string direction_flg;
        private void MainForm_MouseEnter(object sender, EventArgs e)
        {
            ms_xPos_s = 0; 
            ms_xPos_e = 0;
        }
        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            ms_xPos_s = 0; 
            ms_xPos_e = 0;
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ms_xPos_s = e.X;
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            ms_xPos_e = e.X;
            if (ms_xPos_e == ms_xPos_s)
            {
                ms_xPos_s = 0;
                ms_xPos_e = 0;
            }
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (ms_xPos_s != 0 && ms_xPos_e != 0)
            {
                if (ms_xPos_e - ms_xPos_s > 40) //往右滑動
                {
                    direction_flg = "right";
                    timer_slide.Enabled = true;
                }
                else if (ms_xPos_e - ms_xPos_s < -40) //往左滑動
                {
                    direction_flg = "left";
                    timer_slide.Enabled = true;
                }
                else
                { ms_xPos_s = 0; ms_xPos_e = 0; }
            }
        }
        //----------------------------------------------------------
        //函式名稱: timer_slide_Tick
        //說明: 每次對Panel_fake進行X座標的位移
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void timer_slide_Tick(object sender, EventArgs e)
        {
            switch(direction_flg)
            {
                case "left": //滑進來
                    if (Panel_fake.Left > 0)
                    {
                        Panel_fake.Left = Panel_fake.Left - 30;
                    }
                    else
                    {
                        timer_slide.Enabled = false;
                        Panel_fake.Left = 0;
                    }
                    break;
                case "right": //滑出去
                    if (Panel_fake.Left < this.Width)
                    {
                        Panel_fake.Left = Panel_fake.Left + 30;
                    }
                    else
                    {
                        timer_slide.Enabled = false;
                        Panel_fake.Left = this.Width;
                    }
                    break;
                default:
                    timer_slide.Enabled = false;
                    break;
            }
        }
        //----------------------------------------------------------
        //函式名稱: bt_uploadpic_Click
        //說明: 上傳新的fake.jpg，無條件覆蓋!
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_uploadpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openfd.OpenFile());
                try
                {
                    //先取消圖片的使用權
                    picbox_fake.BackgroundImage.Dispose(); 

                    string orgFilePath = openfd.FileName; //選擇圖片的路徑
                    string destFilePath = Application.StartupPath.ToString() + @"\fake.jpg";  //儲存目的地路徑
                    File.Copy(orgFilePath,destFilePath,true);  //複製，第三個參數表示是否直接覆蓋

                    //重新reload圖片
                    picbox_fake.BackgroundImage = new Bitmap("fake.jpg");  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法儲存圖檔!\n原因:"+ ex.Message);
                }
                finally
                {
                    openfd.Dispose();
                    sr.Close();
                    sr = null;
                }
            }
        }
        //----------------------------------------------------------
        //函式名稱: lb_refresh_LinkClicked
        //說明: 重新Reload我的最愛清單
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void lb_refresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Show_myFavFileList(); //顯示我的最愛
        }
        //----------------------------------------------------------
        //函式名稱: MainForm_DoubleClick
        //說明: DoubleCLick MainForm直接把Panel_fake帶出來
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void MainForm_DoubleClick(object sender, EventArgs e)
        {
            Panel_fake.Left = 0;
            this.Size = new Size(591, 357);   
        }
        //----------------------------------------------------------
        //函式名稱: bt_addfav_Click
        //說明: 加入最愛
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_addfav_Click(object sender, EventArgs e)
        {
            TabPage tp = tabCtrl.TabPages[tabCtrl.SelectedIndex];
            foreach (WebBrowser wb in tp.Controls)
            {
                if (wb.Document != null)
                {
                    string myFav_Text = "";
                    try
                    {
                        Stream myStream_r, myStream_w;
                        //讀出內容------------------------------------------------
                        myStream_r = File.Open("我的最愛.txt", FileMode.Open);
                        StreamReader sr = new StreamReader(myStream_r, System.Text.Encoding.UTF8);
                        myFav_Text = sr.ReadToEnd();//將內容讀出來
                        sr.Close();
                        sr = null;
                        myStream_r.Close();
                        myStream_r = null;

                        //寫入內容-------------------------------------------------
                        myStream_w = File.Open("我的最愛.txt", FileMode.Open);
                        StreamWriter sw = new StreamWriter(myStream_w, System.Text.Encoding.UTF8);
                        //sw.Write(myFav_Text + "\n" + webBrowser1.DocumentTitle + "@" + webBrowser1.Url.ToString()); //寫入,但最末不斷行
                        sw.WriteLine(myFav_Text + wb.DocumentTitle + "@" + wb.Url.ToString()); //寫入,最後會自動斷行
                        sw.Close();
                        sw = null;
                        myStream_w.Close();
                        myStream_w = null;
                        MessageBox.Show("已儲存至[我的最愛]!", "訊息");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("無法儲存! 錯誤訊息:" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("無法儲存! 請先開啟此網頁!");
                }
            }
            tp = null;

        }


        //----------------------------------------------------------
        //函式名稱: trackBar_Scroll
        //說明: 設定透明度
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (double)trackBar.Value/100;  //設定MainForm透明度
        }
        //----------------------------------------------------------
        //函式名稱: bt_bgcolor_Click
        //說明: 設定背景顏色
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void bt_bgcolor_Click(object sender, EventArgs e)
        {
            ColorDialog colordialog = new ColorDialog();
            if (colordialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colordialog.Color;
                tb_url.BackColor = colordialog.Color;
            }
        }
        //----------------------------------------------------------
        //函式名稱: MainForm_KeyDown
        //說明: 快速鍵設定透明度
        //參數: 無
        //回傳值: 無
        //----------------------------------------------------------
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: //F1=不透明度0%(全部隱藏)
                    trackBar.Value = 0;
                    break;
                case Keys.F2: //F2=不透明度25%
                    trackBar.Value = 25;
                    break;
                case Keys.F3: //F3=不透明度50%
                    trackBar.Value = 50;
                    break;
                case Keys.F4: //F4=不透明度75%
                    trackBar.Value = 75;
                    break;
                case Keys.F5: //F5=顯示圖片
                    MainForm_DoubleClick(this, null);
                    break;
                case Keys.F6: //F6=不透明度100%
                    trackBar.Value = 100;
                    break;
            }
            this.Opacity = (double)trackBar.Value / 100;
        }

        private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: //F1=不透明度0%(全部隱藏)
                    trackBar.Value = 0;
                    break;
                case Keys.F2: //F2=不透明度25%
                    trackBar.Value = 25;
                    break;
                case Keys.F3: //F3=不透明度50%
                    trackBar.Value = 50;
                    break;
                case Keys.F4: //F4=不透明度75%
                    trackBar.Value = 75;
                    break;
                case Keys.F5: //F5=顯示圖片
                    MainForm_DoubleClick(this, null);
                    break;
                case Keys.F6: //F6=不透明度100%
                    trackBar.Value = 100;
                    break;
            }
            this.Opacity = (double)trackBar.Value / 100;
        }

        private void pb_TheForce_Click(object sender, EventArgs e)
        {
            //欲開啟的網址
            string target = @"http://karatejb.blogspot.com/";
            //當系統未安裝預設的程式來開啟相對應的資源的話，會出現例外錯誤
            try 
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        


    }
}