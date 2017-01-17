namespace FoheartUpload2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看上传列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置服务器地址ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置代理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pathStr = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.filesize = new System.Windows.Forms.Label();
            this.buckss = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.设置SToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(719, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建上传ToolStripMenuItem,
            this.查看上传列表ToolStripMenuItem,
            this.退出软件ToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(F)";
            // 
            // 新建上传ToolStripMenuItem
            // 
            this.新建上传ToolStripMenuItem.Name = "新建上传ToolStripMenuItem";
            this.新建上传ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新建上传ToolStripMenuItem.Text = "新建上传";
            this.新建上传ToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // 查看上传列表ToolStripMenuItem
            // 
            this.查看上传列表ToolStripMenuItem.Name = "查看上传列表ToolStripMenuItem";
            this.查看上传列表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看上传列表ToolStripMenuItem.Text = "查看上传列表";
            this.查看上传列表ToolStripMenuItem.Click += new System.EventHandler(this.查看上传列表ToolStripMenuItem_Click);
            // 
            // 退出软件ToolStripMenuItem
            // 
            this.退出软件ToolStripMenuItem.Name = "退出软件ToolStripMenuItem";
            this.退出软件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出软件ToolStripMenuItem.Text = "退出软件";
            this.退出软件ToolStripMenuItem.Click += new System.EventHandler(this.退出软件ToolStripMenuItem_Click);
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置服务器地址ToolStripMenuItem,
            this.配置代理ToolStripMenuItem});
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.设置SToolStripMenuItem.Text = "设置(S)";
            // 
            // 配置服务器地址ToolStripMenuItem
            // 
            this.配置服务器地址ToolStripMenuItem.Name = "配置服务器地址ToolStripMenuItem";
            this.配置服务器地址ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.配置服务器地址ToolStripMenuItem.Text = "配置";
            this.配置服务器地址ToolStripMenuItem.Click += new System.EventHandler(this.配置服务器地址ToolStripMenuItem_Click);
            // 
            // 配置代理ToolStripMenuItem
            // 
            this.配置代理ToolStripMenuItem.Name = "配置代理ToolStripMenuItem";
            this.配置代理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.配置代理ToolStripMenuItem.Text = "配置代理";
            this.配置代理ToolStripMenuItem.Visible = false;
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用帮助ToolStripMenuItem,
            this.关于软件ToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(H)";
            // 
            // 使用帮助ToolStripMenuItem
            // 
            this.使用帮助ToolStripMenuItem.Name = "使用帮助ToolStripMenuItem";
            this.使用帮助ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.使用帮助ToolStripMenuItem.Text = "使用帮助";
            this.使用帮助ToolStripMenuItem.Visible = false;
            // 
            // 关于软件ToolStripMenuItem
            // 
            this.关于软件ToolStripMenuItem.Name = "关于软件ToolStripMenuItem";
            this.关于软件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关于软件ToolStripMenuItem.Text = "关于软件";
            this.关于软件ToolStripMenuItem.Click += new System.EventHandler(this.关于软件ToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(14, 133);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(690, 392);
            this.textBox1.TabIndex = 1;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Enabled = false;
            this.uploadBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uploadBtn.Location = new System.Drawing.Point(617, 84);
            this.uploadBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(87, 31);
            this.uploadBtn.TabIndex = 2;
            this.uploadBtn.Text = "开始上传";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "已经选择：";
            // 
            // pathStr
            // 
            this.pathStr.AutoSize = true;
            this.pathStr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pathStr.Location = new System.Drawing.Point(82, 44);
            this.pathStr.Name = "pathStr";
            this.pathStr.Size = new System.Drawing.Size(0, 17);
            this.pathStr.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(617, 42);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "选择文件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.progressBar1.ForeColor = System.Drawing.Color.OrangeRed;
            this.progressBar1.Location = new System.Drawing.Point(13, 533);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(691, 25);
            this.progressBar1.Step = 100;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Tag = "222";
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "文件结果：";
            // 
            // filesize
            // 
            this.filesize.AutoSize = true;
            this.filesize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filesize.Location = new System.Drawing.Point(543, 112);
            this.filesize.Name = "filesize";
            this.filesize.Size = new System.Drawing.Size(56, 17);
            this.filesize.TabIndex = 8;
            this.filesize.Text = "文件大小";
            // 
            // buckss
            // 
            this.buckss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buckss.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buckss.FormattingEnabled = true;
            this.buckss.Location = new System.Drawing.Point(85, 74);
            this.buckss.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buckss.Name = "buckss";
            this.buckss.Size = new System.Drawing.Size(140, 25);
            this.buckss.TabIndex = 9;
            this.buckss.SelectedIndexChanged += new System.EventHandler(this.changeBuckt);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(11, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "选择仓库";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 27);
            this.button1.TabIndex = 11;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 566);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buckss);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.filesize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pathStr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "七牛文件上传工具";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建上传ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看上传列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出软件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置服务器地址ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置代理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于软件ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pathStr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label filesize;
        private System.Windows.Forms.ComboBox buckss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

