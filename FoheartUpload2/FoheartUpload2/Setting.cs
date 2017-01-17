using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FoheartUpload2
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }
        
        private void saveConfigBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("setting");
                string txt = sr.ReadToEnd();
                sr.Close();
                JObject json = JObject.Parse(txt);
                json["AK"] = AKinput.Text;
                json["SK"] = SKinput.Text;
                json["domain"] = Doinput.Text;
                StreamWriter sw = new StreamWriter("setting");
                sw.WriteLine(json.ToString());
                sw.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
                MessageBox.Show("保存成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show("错误："+ex.Message);
            }
            
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("setting");
            string txt = sr.ReadToEnd();
            JObject json = JObject.Parse(txt);
            AKinput.Text = json["AK"].ToString();
            SKinput.Text = json["SK"].ToString();
            Doinput.Text = json["domain"].ToString();
            sr.Close();
        }
    }
}
