using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Reflection;

namespace IHMHR_System
{
    public partial class FrmExcel : Form
    {
        public FrmExcel()
        {
            InitializeComponent();
        }

        private void FrmExcel_Load(object sender, EventArgs e)
        {
            /*using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;DATABASE=relatorio;USER ID=root;PWD="))
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                System.Data.DataSet ds = new System.Data.DataSet();
                MySqlCommand comando = new MySqlCommand();

            }*/
            Salvar();
        }

        private void Salvar()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Salvar arquivo excel";
            save.Filter = "Versão 2007 (*.xls)|*.xls|Versão 2010 (*.xlsx)|*xlsx";
            save.FilterIndex = 1;
            save.RestoreDirectory = true;
            save.DefaultExt = "xls";
            save.ShowDialog();
        }
    }
}
