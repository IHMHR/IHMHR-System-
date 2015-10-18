using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace IHMHR_System
{
    public partial class FrmMaximo : Form
    {
        List<String> sites = new List<string>();
        StreamWriter sw;
        byte ibm = 2;
        public FrmMaximo()
        {
            //https://sdesk.localiza.com/maximo/ui/?event=loadapp&value=sr&uniqueid=991603&uisessionid=4661&csrftoken=u7v69kduuen8quh7dl5ir3tg3j
            InitializeComponent();
            toolStripStatusLabel1.Text = System.Environment.MachineName + " - " + System.Environment.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (tabCtrol1.SelectedIndex.Equals(0))
                webBrowser1.Refresh();
            else
                webBrowser2.Refresh();*/
            int teste = tabCtrol1.SelectedIndex;
            switch (tabCtrol1.SelectedIndex)
            {
                case 0:
                    webBrowser1.Refresh();
                    break;

                case 1:
                    webBrowser2.Refresh();
                    break;

                default:
                    break;
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int teste = tabCtrol1.SelectedIndex;
            switch (tabCtrol1.SelectedIndex)
            {
                case 0:
                    webBrowser1.GoBack();
                    break;

                case 1:
                    webBrowser2.GoBack();
                    break;

                default:
                    break;
            }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            sites.Add(e.Url.AbsoluteUri);
        }

        private void FrmMaximo_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte i = 0;
            sw = File.AppendText(@"C:\IHMHR\url.txt");
            foreach (var item in sites)
            {
                sw.Write(item);
                if (i != sites.Count-1)
                    sw.Write("|");
                i++;
            }
            sw.Write(";");
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //adicionar mais 1 aba com 1 webbrowser com o maximo para criar novo chamado
            ibm++;
            TabPage pag3 = new TabPage("Máximo "+ibm);
            pag3.Controls.Add(this.webBrowser2);
            pag3.Location = new System.Drawing.Point(4, 22);
            pag3.Padding = new System.Windows.Forms.Padding(3);
            pag3.Size = new System.Drawing.Size(1366, 725);
            pag3.TabIndex = 4;
            pag3.UseVisualStyleBackColor = true;
        }
    }
}
