using BLL; // Nécessaire pour appeler GestionDevis
using LaGestionCommerciale;
using System;
using System.Configuration; // Nécessaire pour ConfigurationManager
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());

            // REMARQUE : La ligne de connexion directe n'est plus nécessaire ici.
        }
    }
}