using BLL; // Nécessaire pour appeler GestionDevis
using LaGestionCommerciale;
using System;
using System.Configuration; // Nécessaire pour ConfigurationManager
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1. Initialisation de la chaîne de connexion à partir du fichier de configuration
            var chset = ConfigurationManager.ConnectionStrings["gestion_commerciale"];

            if (chset == null)
            {
                MessageBox.Show("Chaîne de connexion 'gestion_commerciale' introuvable dans App.config ! L'application va s'arrêter.");
                return; // Arrête l'application si la config est manquante
            }

            // 2. Transférer la chaîne de connexion à la couche BLL/DAL
            GestionDevis.SetchaineConnexion(chset);

            // 3. Démarrage de l'application (CETTE PARTIE DOIT VENIR EN DERNIER)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmDevis());

            // REMARQUE : La ligne de connexion directe n'est plus nécessaire ici.
        }
    }
}