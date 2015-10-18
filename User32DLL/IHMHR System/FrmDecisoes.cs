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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
