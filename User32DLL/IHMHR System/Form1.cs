using System;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace IHMHR_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = string.Empty;
            StreamReader sr = new StreamReader(@"C:\IHMHR\txt.txt");
            //char[] spliter = {'|', ';'};
            //string[] valores = new string[2000];
            List<string> valores = new List<string>();
            string[] texto = sr.ReadLine().Split(';');
            int contador = 0;
            foreach (var item in texto)
            {
                contador++;
                //valores[contador] = item;
                valores.Add(item);
            }
            #region SQL
            //sql = "INSERT INTO info VALUES (NULL,'+" valores[1] + "','" + valores[2] + "','" + valores[3].Replace("'", "~") + "','" + valores[4] + "','" + valores[5] + "','" + valores[6] + "')";    
            /*sql = "INSERT INTO info VALUES ";
            for (int i = 0; i < ((valores.Count-1) /6); i++)
            {
                sql += "(NULL,";
                sql += "'" + valores[i] + "',";
                sql += "'" + valores[i + 1] + "',";
                sql += "'" + valores[i + 2].Replace("'", "~").Replace("´", "~") + "',";
                sql += "'" + valores[i + 3] + "',";
                sql += "'" + valores[i + 4] + "',";
                sql += "'" + valores[i + 5] + "'";
                sql += "),";
            }
            sql = sql.Substring(0, sql.Length - 1);
            MessageBox.Show(sql);
            Clipboard.SetText(sql);*/
            #endregion
            List<string> dados = CriarQuery(texto);
            using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;DATABASE=relatorio;USER ID=root;PWD="))
            {
                con.Open();
                foreach (var row in dados)
                {
                    MySqlCommand com = new MySqlCommand(row,con);
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        try
                        {
                            com.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }   
                }
            }
        }

        private static List<string> CriarQuery(string[] rows) 
        {
            try
            {
                List<string> todasFilas = new List<string>(rows.Length-1);
                string sql = string.Empty;
                foreach (var item in rows)
                {
                    if (item == "")
                    {
                        //
                    }
                    else
                    {
                        string[] fila = item.Split('|');
                        sql = "INSERT INTO info VALUES ";
                        sql += "(NULL,";
                        sql += "'" + fila[0] + "',";
                        sql += "'" + fila[1] + "',";
                        sql += "'" + fila[2].Replace("'", "~") + "',";
                        sql += "'" + fila[3].Replace(":", "") + "',";/**/
                        sql += "'" + fila[4] + "',";
                        sql += "'" + Convert.ToDateTime(fila[5]).ToString("yyyy-MM-dd HH:MM:ss") + "'";
                        sql += ")";
                        /*MessageBox.Show(sql);
                        Clipboard.SetText(sql);*/
                        todasFilas.Add(sql);
                        sql = string.Empty;
                    }
                }
                return todasFilas;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro CriarQuery" + ex.Message.ToString());
            }
        }
    }
}


/*
 +----------+--------------+------+-----+---------+----------------+
| Field    | Type         | Null | Key | Default | Extra          |
+----------+--------------+------+-----+---------+----------------+
| id       | int(11)      | NO   | PRI | NULL    | auto_increment |
| user     | varchar(30)  | NO   |     | NULL    |                |
| pesquisa | varchar(255) | NO   |     | NULL    |                |
**| comando  | varchar(600) | NO   |     | NULL    |                |** - VARCHAR(1000)
**| tempo    | varchar(20)  | NO   |     | NULL    |                |** - DECIMAL(9,7) |CAUSE m MUST BE >= d|
| retorno  | int(11)      | NO   |     | NULL    |                |
**| data     | varchar(35)  | NO   |     | NULL    |                |** - DATETIME
+----------+--------------+------+-----+---------+----------------+
 */



/*
 SELECT
    user AS 'Usuário',
    pesquisa AS 'Termo pesquisado',
    count(*) AS 'Quantidade de vezes',
    tempo AS 'Tempo para exibir',
    retorno AS 'Linhas retornadas'
FROM
    info
GROUP BY
    pesquisa
ORDER BY 
    count(*) DESC;
 */