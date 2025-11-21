using BO;
using LaGestionCommerciale;
using System;
using System.Configuration;
using System.Windows.Forms;
using UtilisateursBLL;

namespace GUI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            // Initialisation de la connexion à la BD
            var chset = ConfigurationManager.ConnectionStrings["gestion_commerciale"];

            if (chset == null)
            {
                MessageBox.Show("Chaîne de connexion 'gestion_commerciale' introuvable dans App.config !");
                return;
            }

            LoginUtilisateur.SetchaineConnexion(chset);
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string mdp = txtMotDePasse.Text.Trim();

            //Erreur si un champ est vide
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(mdp))
            {
                MessageBox.Show("Veuillez insérer votre nom et votre mot de passe.",
                                "Champs manquants",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; 
            }

            //Erreur si le nom ou le mot de passe est incorrect
            if (!LoginUtilisateur.VerifierConnexion(nom, mdp))
            {
                MessageBox.Show("Nom ou mot de passe incorrect.",
                                "Erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return; 
            }

            //Connexion OK
            MessageBox.Show("Connexion réussie !",
                            "Succès",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            FrmClient Client = new FrmClient();
            Client.Show();
            this.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}