using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoheartUpload2
{
    public partial class Finlist : Form
    {
        public Finlist()
        {
            InitializeComponent();
        }

        private void Finlist_Load(object sender, EventArgs e)
        {
            JArray ja = new JArray();
            if (File.Exists("list"))
            {
                StreamReader sw = new StreamReader("list");
                string txt1 = sw.ReadToEnd();
                sw.Close();
                if (!txt1.Equals(""))
                {
                    ja = JArray.Parse(txt1);


                    updateView(ja);
                }
            }
            else
            {


            }
        }
        
        private void updateView(JArray ja)
        {
            for(int i =0; i < ja.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ja[i]["filename"].ToString();
                lvi.SubItems.Add(ja[i]["size"].ToString());
                lvi.SubItems.Add(ja[i]["md5"].ToString());
                lvi.SubItems.Add(ja[i]["url"].ToString());
                listView1.Items.Add(lvi);
            }
           
        }

    }
}
