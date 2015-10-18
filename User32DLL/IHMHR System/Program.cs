using System;
using System.Windows.Forms;

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
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);*/
            try
            {
                MessageBox.Show(@"Olá " + System.Environment.UserName + ", seja bem vindo !", @"IHMHR System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Run(new FrmMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro ao Inicializar IHMHR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
