using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.DirectoryServices.AccountManagement;

namespace IHMHR_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //MessageBox.Show(UserPrincipal.Current.DisplayName);
                /*string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                MessageBox.Show(userName.Remove(0,9));*/
                StringBuilder sb = new StringBuilder();
                sb.Append("Olá ");
                sb.Append(System.Environment.UserName);
                //sb.Append(UserPrincipal.Current.DisplayName);
                sb.Append(", ");
                sb.AppendLine("seja bem vindo ao IHMHR System !");
                sb.Append("Este sistema foi desenvolvido para uso dentro do SDESK Localiza.");
                //MessageBox.Show(@"Olá " + System.Environment.UserName + ", seja bem vindo !", @"IHMHR System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(sb.ToString(), @"IHMHR System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Run(new FrmMain());
                //Application.Run(new FrmExcel());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro ao Inicializar IHMHR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
