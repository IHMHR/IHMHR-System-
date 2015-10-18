using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace IHMHR_System
{
    public partial class FrmSolucoes : Form
    {
        public string MyProperty { get; set; }
        Stopwatch tempo = Stopwatch.StartNew();
        TimeSpan elapsed;
        StreamWriter sw;
        protected static string comando;
        public FrmSolucoes(string campo)
        {
            try
            {
                tempo.Start();
                Cursor.Current = Cursors.WaitCursor;
                InitializeComponent();
                MyProperty = campo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro FrmSolucoes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSolucoes_Load(object sender, EventArgs e)
        {
            try
            {
                //Excel();
                using (SqlConnection con = new SqlConnection(@"Data Source=MARTINELLI-07\SQLEXPRESS;Initial Catalog=SS;Integrated Security=True"))
                {
                    string sql = "SELECT TOP 50 Chamado AS [Numero do Chamado],Desc_Chamado AS [Descrição do Chamado],Desc_detalhada AS [Detalhes do Chamado],Causa,resolucao AS Resolução,sintoma AS Sintoma,Resposta_cliente AS [Resposta ao Cliente],[Solucionador por] AS [Analista responsável] FROM Plan1$ WHERE Chamado IS NOT NULL AND resolucao IS NOT NULL AND Resposta_cliente IS NOT NULL AND ";
                    sql = sql + FormatarLike(MyProperty, false);
                    sql += " ORDER BY Chamado DESC";
                    comando = sql;

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);

                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    if (dataGridView1.RowCount <= 0)
                    {
                        MessageBox.Show("Nenhum dado encontrado");
                        this.Close();
                        FrmMain mm = new FrmMain();
                        mm.Show();
                    }
                }
            }
            catch (Exception)// ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "Erro Load FrmSolucoes (popular dgv)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Excel();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                tempo.Stop();
                elapsed = tempo.Elapsed;
                //MessageBox.Show(elapsed.ToString());
                tempo.Reset();
            }
        }

        private string FormatarLike(string texto, bool palavraInteira)
        {

            string[] textoSeparado = texto.Split(' ');
            string textoLike="";

            if (palavraInteira)
            {
                textoLike =  "(Desc_Chamado LIKE '%" + texto + "%' OR Desc_detalhada LIKE '%" + texto + "%' OR Causa LIKE '%" + texto + "%' OR resolucao like '%" + texto + "%' OR sintoma like '%" + texto + "%' OR resposta_cliente like '%" + texto + "%')";
   
            }
            else
            {


                foreach (string palavra in textoSeparado)
                {
                    textoLike = textoLike + "(Desc_Chamado LIKE '%" + palavra + "%' OR Desc_detalhada LIKE '%" + palavra + "%' OR Causa LIKE '%" + palavra + "%' OR resolucao like '%" + palavra + "%' OR sintoma like '%" + palavra + "%' OR resposta_cliente like '%" + palavra + "%')";
                    if (palavra != textoSeparado[textoSeparado.Length - 1])
                        textoLike += " AND ";
                }
            }
            return textoLike;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ExibirMensagem();
        }

        private void ExibirMensagem()
        {
            try
            {
                //MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
                MessageBox.Show(dataGridView1.CurrentRow.Cells["Descrição do Chamado"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n" +
                                dataGridView1.CurrentRow.Cells["Detalhes do Chamado"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n" +
                                dataGridView1.CurrentRow.Cells["Resposta ao cliente"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n\n" +
                                dataGridView1.CurrentRow.Cells["Causa"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n" +
                                dataGridView1.CurrentRow.Cells["resolução"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n"
                                );
            }
            catch (Exception)// ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "Erro Dvg CellContentClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(dataGridView1.CurrentRow.Cells["Desc_Chamado"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n" +
                                dataGridView1.CurrentRow.Cells["Desc_detalhada"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n" +
                                dataGridView1.CurrentRow.Cells["Resposta_cliente"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n\n" +
                                dataGridView1.CurrentRow.Cells["Causa"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n" +
                                dataGridView1.CurrentRow.Cells["resolucao"].Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n").Replace("<div>", "").Replace("</div>", "").Replace(@"<\div>", "") + "\n\n"
                                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                this.Close();
                FrmMain mm = new FrmMain();
                mm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro Button1 Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Excel()
        {
            DataSet ds = new DataSet();
            string cnnString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", @"C:\IHMHR\BaseConhecimento.xlsx");//@"C:\Users\Martinelli\Desktop\N8\Projeto Base de conhecimento\Base de Conhecimento\Base de Conhecimento\bin\Debug\BaseConhecimento.xlsx");
            string isql = "SELECT TOP 50 Chamado AS [Numero do Chamado],Desc_Chamado AS [Descrição do Chamado],Desc_detalhada AS [Detalhes do Chamado],Causa,resolucao AS [Resolução],sintoma AS [Sintoma],Resposta_cliente AS [Resposta ao Cliente],[Solucionador por] AS [Analista responsável] FROM [{0}$] WHERE chamado IS NOT NULL AND resolucao IS NOT NULL AND Resposta_cliente IS NOT NULL AND " + FormatarLike(MyProperty, false) + " ORDER BY Chamado DESC";
            System.Data.OleDb.OleDbConnection cnn = new System.Data.OleDb.OleDbConnection(cnnString);
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(String.Format(isql, "Plan1"), cnn);
            comando = String.Format(isql, "Plan1");

            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            //lblQtdRegistros.Text = dataGridView1.RowCount.ToString();
            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show("Nenhum dado encontrado");
                this.Close();
                FrmMain mm = new FrmMain();
                mm.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clipboard.SetText(dataGridView1.CurrentCell.Value.ToString().Replace("<!-- RICH TEXT -->", "").Replace("</ br>", "/n").Replace("<br />", "\n"));
            ExibirMensagem();
        }

        private void FrmSolucoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            sw = File.AppendText(@"C:\IHMHR\pesquisa.txt");
            sw.Write(System.Environment.UserName + "|");
            sw.Write(MyProperty + "|");
            sw.Write(comando + "|");
            sw.Write(elapsed + "|");
            sw.Write(dataGridView1.RowCount + "|");
            sw.Write(DateTime.Now.ToShortDateString() + " ");
            sw.Write(DateTime.Now.ToShortTimeString());
            sw.Write(";");
            sw.Close();
        }
    }
}
