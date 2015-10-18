namespace IHMHR_System
{
    partial class FrmMaximo
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabCtrol1 = new System.Windows.Forms.TabControl();
            this.Aba1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.aba2 = new System.Windows.Forms.TabPage();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabCtrol1.SuspendLayout();
            this.Aba1.SuspendLayout();
            this.aba2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 758);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1378, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel2";
            // 
            // tabCtrol1
            // 
            this.tabCtrol1.Controls.Add(this.Aba1);
            this.tabCtrol1.Controls.Add(this.aba2);
            this.tabCtrol1.Location = new System.Drawing.Point(0, 0);
            this.tabCtrol1.Name = "tabCtrol1";
            this.tabCtrol1.SelectedIndex = 0;
            this.tabCtrol1.Size = new System.Drawing.Size(1374, 751);
            this.tabCtrol1.TabIndex = 3;
            // 
            // Aba1
            // 
            this.Aba1.Controls.Add(this.webBrowser1);
            this.Aba1.Location = new System.Drawing.Point(4, 22);
            this.Aba1.Name = "Aba1";
            this.Aba1.Padding = new System.Windows.Forms.Padding(3);
            this.Aba1.Size = new System.Drawing.Size(1366, 725);
            this.Aba1.TabIndex = 1;
            this.Aba1.Text = "Máximo";
            this.Aba1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1360, 719);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://sdesk.localiza.com/maximo/ui/?event=loadapp&value=sr&uniqueid=991603&uise" +
        "ssionid=4661&csrftoken=u7v69kduuen8quh7dl5ir3tg3j", System.UriKind.Absolute);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // aba2
            // 
            this.aba2.Controls.Add(this.webBrowser2);
            this.aba2.Location = new System.Drawing.Point(4, 22);
            this.aba2.Name = "aba2";
            this.aba2.Padding = new System.Windows.Forms.Padding(3);
            this.aba2.Size = new System.Drawing.Size(1366, 725);
            this.aba2.TabIndex = 2;
            this.aba2.Text = "Máximo 2";
            this.aba2.UseVisualStyleBackColor = true;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 3);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(1360, 719);
            this.webBrowser2.TabIndex = 1;
            this.webBrowser2.Url = new System.Uri("https://sdesk.localiza.com/maximo/ui/?event=loadapp&value=sr&uniqueid=991603&uise" +
        "ssionid=4661&csrftoken=u7v69kduuen8quh7dl5ir3tg3j", System.UriKind.Absolute);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 747);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "F5";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(158, 747);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 22);
            this.button2.TabIndex = 1;
            this.button2.Text = "←";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(176, 747);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 22);
            this.button3.TabIndex = 5;
            this.button3.Text = "+ Máximo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmMaximo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabCtrol1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMaximo";
            this.ShowIcon = false;
            this.Text = "FrmMaximo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMaximo_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabCtrol1.ResumeLayout(false);
            this.Aba1.ResumeLayout(false);
            this.aba2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabCtrol1;
        private System.Windows.Forms.TabPage Aba1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage aba2;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}