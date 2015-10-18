using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IHMHR_System
{
    public partial class FrmDecisoes : Form
    {
        public FrmDecisoes()
        {
            InitializeComponent();
            tabPage1.Text = "Info básica";
            tabPage2.Text = "Todas informações";
            tabPage3.Text = "Média de demora";
            tabPage4.Text = "Média de pesquisa";
        }

        private void FrmDecisoes_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;DATABASE=relatorio;USER ID=root;PWD="))
                {
                    con.Open();
                    string sql = "SELECT user AS 'Usuario',pesquisa AS 'Termo pesquisado',count(*) AS 'Quantidade de vezes',tempo AS 'Tempo para exibir',retorno AS 'Linhas retornadas' FROM info GROUP BY pesquisa ORDER BY count(*) DESC";
                    MySqlCommand com = new MySqlCommand(sql,con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = com;
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = tabControl1.SelectedIndex;
            switch (i)
            {
                case 1:
                    using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;DATABASE=relatorio;USER ID=root;PWD="))
                    {
                        con.Open();
                        string sql = "SELECT * FROM info";
                        MySqlCommand com = new MySqlCommand(sql, con);
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = com;
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                    break;
                case 2:
                    using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;DATABASE=relatorio;USER ID=root;PWD="))
                    {
                        con.Open();
                        string sql = "SELECT AVG(tempo) AS 'Media tempo para exibir' FROM info WHERE tempo <> '0.0000000'";
                        MySqlCommand com = new MySqlCommand(sql, con);
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = com;
                        da.Fill(dt);
                        dataGridView3.DataSource = dt;
                    }
                    break;
                case 3:
                    using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;DATABASE=relatorio;USER ID=root;PWD="))
                    {
                        con.Open();
                        string sql = "SELECT user AS 'Usuario',SUM(retorno) AS 'Quantidade retornada',AVG(retorno) AS 'Media de valores retornados', pesquisa AS 'Termo pesquisado',count(1) AS 'Quantidade de vezes' FROM info GROUP BY pesquisa ORDER BY retorno DESC";
                        MySqlCommand com = new MySqlCommand(sql, con);
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = com;
                        da.Fill(dt);
                        dataGridView4.DataSource = dt;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
