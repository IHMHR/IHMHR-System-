using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;

namespace IHMHR_System
{
    public partial class FrmMain : Form
    {
        [DllImport("User32.dll", ExactSpelling = true)]
        private static extern bool MessageBeep(uint type);

        public static void beep(beepType type)
        {
            MessageBeep((uint)type);
        }

        public enum beepType
        {
            /// <summary>
            /// A simple windows beep
            /// </summary>            
            SimpleBeep = -1,
            /// <summary>
            /// A standard windows OK beep
            /// </summary>
            OK = 0x00,
            /// <summary>
            /// A standard windows Question beep
            /// </summary>
            Question = 0x20,
            /// <summary>
            /// A standard windows Exclamation beep
            /// </summary>
            Exclamation = 0x30,
            /// <summary>
            /// A standard windows Asterisk beep
            /// </summary>
            Asterisk = 0x40,
        }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(@"Olá " + System.Environment.UserName + ", seja bem vindo !", @"IHMHR System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radioButton1.Text = "Desligar";
                radioButton2.Text = "Reiniciar";
                radioButton3.Text = "Hibernar";
                panel1.Visible = !panel1.Visible;
                button4.Location = new System.Drawing.Point(0, 44);
                button5.Location = new System.Drawing.Point(0, 66);
                button6.Location = new System.Drawing.Point(0, 88);
                button7.Location = new System.Drawing.Point(0, 110);
                //button8.Location = new System.Drawing.Point(0, 132);
                panel2.Visible = !panel2.Visible;
                textBox5.Visible = !textBox5.Visible;
                label5.Visible = !label5.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Load FrmMain", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\WINDOWS\system32\rundll32.exe", @"user32.dll,LockWorkStation");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Button1 Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Process.Start(@"shutdown", "-s -t 120 -c \"120 segundos\"");
                panel1.Visible = !panel1.Visible;
                //button1.Visible = !button1.Visible;
                
                button1.Focus();
                button4.Visible = !button4.Visible;
                button5.Visible = !button5.Visible;
                button6.Visible = !button6.Visible;
                button7.Visible = !button7.Visible;
                radioButton1.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Button2 Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    if (textBox1.Text.Equals(string.Empty))
                    {
                        FrmMain.beep(beepType.Exclamation);
                        Thread.Sleep(100);
                    }
                    else if (!textBox2.Text.Equals(string.Empty))
                    {
                        if (!textBox3.Text.Equals(string.Empty))
                        {
                            Process.Start(@"shutdown", @"-s -t " + textBox1.Text + " -c \"" + textBox2.Text + "\" -m \\\\" + textBox3.Text);
                            //MessageBox.Show(@"shutdown -s -t " + textBox1.Text + " -c \"" + textBox2.Text + "\" -m " + "\\\\" + textBox3.Text);
                        }
                        else
                        {
                            Process.Start(@"shutdown", @"-s -t " + textBox1.Text + " -c \"" + textBox2.Text + "\"");
                        }
                    }
                    else
                    {
                        Process.Start(@"shutdown", @"-s -t " + textBox1.Text);
                    }

                }
                else if (radioButton2.Checked)
                {
                    if (textBox1.Text.Equals(string.Empty))
                    {
                        FrmMain.beep(beepType.Exclamation);
                        Thread.Sleep(100);
                    }
                    else if (!textBox2.Text.Equals(string.Empty))
                    {
                        if (!textBox3.Text.Equals(string.Empty))
                        {
                            Process.Start(@"shutdown", @"-r -t " + textBox1.Text + " -c \"" + textBox2.Text + "\" -m \\\\" + textBox3.Text);
                        }
                        else
                        {
                            Process.Start(@"shutdown", @"-r -t " + textBox1.Text + " -c \"" + textBox2.Text + "\"");
                        }
                    }
                    else
                    {
                        Process.Start(@"shutdown", @"-r -t " + textBox1.Text);
                    }
                }
                else if (radioButton3.Checked)
                {
                    Process.Start(@"shutdown", @"-h");
                }
                else
                {
                    MessageBox.Show("Erro !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Button3 Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\WINDOWS\system32\rundll32.exe", @"user32.dll,SwapMouseButton");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Button4 Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            //Clipboard.SetDataObject(new DataObject());
            Clipboard.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Button5 Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_DoubleClick(object sender, EventArgs e)
        {
            try { 
            MessageBox.Show("Nome da Aplcação: " + Application.ProductName + "\n" + "Versão: " + Application.ProductVersion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Label3 DblClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try 
            {
                //button7.Location = new System.Drawing.Point(0, 205);
                button7.Visible = !button7.Visible;
                panel2.Visible = !panel2.Visible;
                panel2.Location = new System.Drawing.Point(0, 110);
            if (textBox4.Text.Equals(""))
            {
                Process[] processos = Process.GetProcesses();
                foreach (var item in processos)
                {
                    listBox1.Items.Add(item.ProcessName);
                }
            }
            else
            {
                Process[] processos = Process.GetProcesses(textBox4.Text);
                foreach (var item in processos)
                {
                    listBox1.Items.Add(item.ProcessName);
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Button6 Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            //MessageBox.Show(listBox1.SelectedItem.ToString() + ".exe");
            if (MessageBox.Show("Você tem certeza que quer finalizar o processo '" + listBox1.SelectedItem + "'?", "Confirmação do usuário", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(@"taskkill", @"/f /im " + listBox1.SelectedItem + ".exe /t");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro ListBox Selected Index Changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            try
            {
            if (textBox4.Text.Equals(""))
            {
                Process[] processos = Process.GetProcesses();
                foreach (var item in processos)
                {
                    listBox1.Items.Add(item.ProcessName);
                }
            }
            else
            {
                Process[] processos = Process.GetProcesses(textBox4.Text);
                foreach (var item in processos)
                {
                    listBox1.Items.Add(item.ProcessName);
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Txt4 Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Txt1 Key Press", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void FrmMain_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox5.Visible = !textBox5.Visible;
                textBox5.Focus();
                label5.Visible = !label5.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro DblClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                {
                    this.Hide();
                    FrmSolucoes sol = new FrmSolucoes(textBox5.Text);
                    sol.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Txt5 Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox5.Text != "")
                    {
                        this.Hide();
                        FrmSolucoes sol = new FrmSolucoes(textBox5.Text);
                        sol.Show();    
                    }
                }
                else if (e.KeyCode == Keys.Tab)
                {
                    if (textBox5.Text != "")
                    {
                        this.Hide();
                        FrmSolucoes sol = new FrmSolucoes(textBox5.Text);
                        sol.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Txt5 Key Down", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FrmDecisoes tom = new FrmDecisoes();
                tom.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Label5 dblClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Hide();
                Form1 ff = new Form1();
                ff.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Label4 dblClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaximo maximo = new FrmMaximo();
                maximo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Btn7 Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
