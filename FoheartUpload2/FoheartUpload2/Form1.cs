using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qiniu.Util;
using System.IO;
using Newtonsoft.Json.Linq;
using Qiniu.Storage;
using Qiniu.Http;
using System.Threading;
using Qiniu.Storage.Model;

namespace FoheartUpload2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private  string AK = "";
        private  string SK = "";
        private string domain = "";
        private string BK = "";
        private String filePath = "";
        private string fileMd5 = "";
        private string BKS = "";
        private JArray Uplist = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateConfig();
            if (File.Exists("list"))
            {
                StreamReader sw = new StreamReader("list");
                string txt1 = sw.ReadToEnd();
                sw.Close();
                if (!txt1.Equals(""))
                {
                    Uplist = JArray.Parse(txt1);
                }
            }
            else
            {
                Uplist = new JArray();
               StreamWriter  fs = File.CreateText("list");
                fs.Write("[]");
                //File.SetAttributes("list", FileAttributes.Hidden);
                fs.Close();
            }
            
        }

        private void UpdateConfig()
        {
            if (File.Exists("setting"))
            {
                StreamReader sw = new StreamReader("setting");
                string txt = sw.ReadToEnd();
                sw.Close();
                JObject json = JObject.Parse(txt);
                SK = json["SK"].ToString();
                AK = json["AK"].ToString();
                BK = json["BK"].ToString();
                if (json["BKS"] == null)
                {
                    BKS = "";
                   
                }
                else
                {
                    BKS = json.GetValue("BKS").ToString();
                }
                domain = json["domain"].ToString();
                if (!AK.Equals(""))
                {
                    reflushBuckt();
                }
                else
                {
                    if ((new Setting().ShowDialog()) == DialogResult.OK){
                        UpdateConfig();
                        reflushBuckt();

                    }
                }
            }
            else
            {
                //配置信息
                JObject json = new JObject();
                json["AK"] = "";
                json["SK"] = "";
                json["domain"] = "";
                json["BK"]= "";
                json["BKS"] = "";
                StreamWriter sw = new StreamWriter("setting");

                sw.Write(json.ToString());
                sw.Close();
               // File.SetAttributes("setting", FileAttributes.Hidden);
                if ((new Setting().ShowDialog()) == DialogResult.OK)
                {
                    UpdateConfig();
                    reflushBuckt();
                    
                }
            }
        }
        private void saveConfig(string key,String value)
        {
            if (File.Exists("setting"))
            {
                StreamReader sr = new StreamReader("setting");
                string txt = sr.ReadToEnd();
                sr.Close();
                JObject json = JObject.Parse(txt);
                json[key] = value;                
                StreamWriter sw = new StreamWriter("setting");
                sw.WriteLine(json.ToString());
                sw.Close();

            }
            else
            {
                //配置信息
                Setting st = new Setting();

                if (st.ShowDialog() == DialogResult.OK)
                {
                    UpdateConfig();
                }

            }
        }
        private void changeBuckt(object sender, EventArgs e)
        {
            if (buckss.SelectedItem != null)
            {
                saveConfig("BK", buckss.SelectedItem.ToString());
                BK = buckss.SelectedItem.ToString();
            }
            
        }

        private void reflushBuckt()
        {
            try
            {
                Mac mac = new Mac(AK, SK);
                BucketManager bkm = new BucketManager(mac);
                BucketsResult bucketsResult = bkm.buckets();

                if (bucketsResult.ResponseInfo.isOk())
                {
                    List<string> buckets = bucketsResult.Buckets;
                    JArray ja = new JArray();
                    buckss.Items.Clear();
                    foreach (string bucket in buckets)
                    {
                        var zoneId = Qiniu.Common.AutoZone.Query(AK, bucket);
                        buckss.Items.Add(bucket);
                        ja.Add(bucket);
                        if (bucket.Equals(BK))
                        {
                            buckss.SelectedIndex = buckss.Items.IndexOf(bucket);
                        }
                    }
                    BKS = ja.ToString();
                    saveConfig("BKS", BKS);
                }
                else
                {
                    MessageBox.Show("出错：无法获取仓库信息,请检查网络或者配置");
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show("出错：" + ex.Message);
               
            }

        }

        private void uploadFile(string file)
        {

            Thread th = new Thread(new ThreadStart(()=>{
                //计算md5
                fileMd5 =getMD5ByMD5CryptoService(file);
                setBtndisable(false);//开始上传
                PutPolicy putPolicy = new PutPolicy();
                // 设置要上传的目标空间
                putPolicy.Scope = BK;
                // 上传策略的过期时间(单位:秒)
                putPolicy.SetExpires(3600);
                var zoneId = Qiniu.Common.AutoZone.Query(AK, BK);

                Qiniu.Common.Config.ConfigZone(zoneId);
                setBtndisable(false);
                try
                {
                    Mac mac = new Mac(AK, SK); // Use AK & SK here
                                               // 生成上传凭证
                    string uploadToken = Auth.createUploadToken(putPolicy, mac);
                    UploadOptions uploadOptions = new UploadOptions(
                          null, // ExtraParams
                          null, // MimeType
                          false,  // CheckCrc32
                          new UpProgressHandler(OnUploadProgressChanged), // 上传进度
                          null // CancelSignal
                          );

                    // 上传完毕事件处理
                    UpCompletionHandler uploadCompleted = new UpCompletionHandler(OnUploadCompleted);

                    UploadManager um = new UploadManager();
                    um.uploadFile(filePath, Path.GetFileName(filePath), uploadToken, uploadOptions, uploadCompleted);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }));
            th.Start();
            // 上传策略
          

        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                this.filePath = file;
                pathStr.Text = file;
                uploadBtn.Enabled = true;
                MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileInfo fileInfo = new FileInfo(filePath);
                CheckFileExt(fileInfo.Name);
                filesize.Text = (fileInfo.Length / 1024.0).ToString("N2") + "KB";
            }
        }

        private  void OnUploadProgressChanged(string key, double percent)
        {
            
            int pro = (int)(percent * 100);
           // MessageBox.Show(percent.ToString());
            SetProgress(pro);
        }
        private  void OnUploadCompleted(string key, ResponseInfo respInfo, string respJson)
        {
            // respInfo.StatusCode
            // respJson是返回的json消息，示例: { "key":"FILE","hash":"HASH","fsize":FILE_SIZE }
            JObject json = JObject.Parse(respJson);
            if (json["error"] == null)
            {
             FileInfo fileInfo = new FileInfo(filePath);
            respJson = json.ToString();
            JObject backdata = new JObject();
            backdata.Add("md5", fileMd5);
            backdata.Add("size", fileInfo.Length.ToString());
            backdata.Add("url", "//" + domain + "/" + json["key"]);
            backdata.Add("filename", fileInfo.Name);
            backdata.Add("hash", json["hash"]);
            backdata.Add("savename", json["key"]);
            
           backdata.Add("ext",Path.GetExtension(fileInfo.Name).Substring(1));
           SetText(backdata.ToString());
           SaveList(backdata.ToString());
            SetProgress(100);
            }
            else
            {
                SetText(respJson);
            }
           
           
        }
        private void setBtndisable(bool a)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(setBtndisable), a);
            }
            else
            {
                uploadBtn.Enabled = a;
            }
        }
        private void SetText(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetText), value);
            }
            else
            {
                textBox1.Text = value;
            }
        }
        private void SetProgress(int  percent)
        {
            
            if (InvokeRequired)
            {
                Invoke(new Action<int>(SetProgress),percent);
            }
            else
            {
                
                progressBar1.Value = percent;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
           
            uploadFile(filePath);
        }

        private void CheckFileExt(string filename)
        {
            //PutPolicy putPolicy = new PutPolicy();
            //// 设置要上传的目标空间
            //putPolicy.Scope = BK;
            //var zoneId = Qiniu.Common.AutoZone.Query(AK, BK);
            //Qiniu.Common.Config.ConfigZone(zoneId);
            //Mac mac = new Mac(AK, SK); // Use AK & SK here
            //BucketManager bm = new BucketManager(mac);
            
            //HttpResult hr = bm.prefetch(BK, filename);
            
            //textBox1.Text = hr.ResponseInfo.ToString();
        }
        public  string getMD5ByMD5CryptoService(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException(string.Format("<{0}>, 不存在", path));
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            System.Security.Cryptography.MD5CryptoServiceProvider md5Provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] buffer = md5Provider.ComputeHash(fs);
            string resule = BitConverter.ToString(buffer);
            resule = resule.Replace("-", "");
            md5Provider.Clear();
            fs.Close();
            return resule;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void 配置服务器地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting st = new Setting();
            
           if (st.ShowDialog() == DialogResult.OK)
            {
                UpdateConfig();
            }

        }
        /// <summary>
        /// 保存文件列表
        /// </summary>
        private void SaveList(string str)
        {
            Uplist.Add(JObject.Parse(str));
            StreamWriter sw = new StreamWriter("list");
            sw.Write(Uplist.ToString());
            sw.Close();

        }

        private void 查看上传列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finlist st = new Finlist();
            st.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reflushBuckt();
        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            
            string[] path = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            string file = path[0];
            this.filePath = file;
            pathStr.Text = file;
            uploadBtn.Enabled = true;
            MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FileInfo fileInfo = new FileInfo(filePath);
            CheckFileExt(fileInfo.Name);
            filesize.Text = (fileInfo.Length / 1024.0).ToString("N2") + "KB";
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))    //判断拖来的是否是文件  
                e.Effect = DragDropEffects.Link;                //是则将拖动源中的数据连接到控件  
            else e.Effect = DragDropEffects.None;
        }

        private void 退出软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


}
