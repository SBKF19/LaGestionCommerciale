using BLL;
using BO;
using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaGestionCommerciale
{
    public partial class FrmAjoutDeClients : Form
    {
        public FrmAjoutDeClients()
        {
            InitializeComponent();

            // Initialisation de la connexion à la BD
            var chset = ConfigurationManager.ConnectionStrings["gestion_commerciale"];

            if (chset == null)
            {
                MessageBox.Show("Chaîne de connexion 'gestion_commerciale' introuvable dans App.config !");
                return;
            }

            GestionClients.SetchaineConnexion(chset);
        }

        private void btnAjoutClient_Click(object sender, EventArgs e)
        {
            try
            {
                //Vérifiions que les champs sont bien remplis
                string nom = txtNom.Text?.Trim();
                string phone = txtPhone.Text?.Trim();
                string fax = txtFax.Text?.Trim();
                string email = txtMail.Text?.Trim();

                string numRueFacture = txtNumRueFacture.Text?.Trim();
                string nomRueFacture = txtNomRueFacture.Text?.Trim();
                string postalFacture = txtCodePostalFacture.Text?.Trim();
                string nomVilleFacture = txtNomVilleFacture.Text?.Trim();

                string numRueLivraison = txtNumRueLivre.Text?.Trim();
                string nomRueLivraison = txtNomRueLivre.Text?.Trim();
                string postalLivraison = txtCodePostalLivre.Text?.Trim();
                string nomVilleLivraison = txtNomVilleLivre.Text?.Trim();

                if (string.IsNullOrWhiteSpace(nom) ||
                    string.IsNullOrWhiteSpace(phone) ||
                    string.IsNullOrWhiteSpace(fax) ||
                    string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(numRueFacture) ||
                    string.IsNullOrWhiteSpace(nomRueFacture) ||
                    string.IsNullOrWhiteSpace(postalFacture) ||
                    string.IsNullOrWhiteSpace(nomVilleFacture) ||
                    string.IsNullOrWhiteSpace(numRueLivraison) ||
                    string.IsNullOrWhiteSpace(nomRueLivraison) ||
                    string.IsNullOrWhiteSpace(postalLivraison) ||
                    string.IsNullOrWhiteSpace(nomVilleLivraison))
                {
                    throw new Exception("Veuillez remplir tous les champs.");
                }

                // Conversion et vérification des champs numériques
                string patternEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(email, patternEmail))
                    throw new Exception("L'adresse email n'est pas valide.");
                if (phone.Length != 10 || !phone.All(char.IsDigit))
                {
                    throw new Exception("Le numéro de téléphone doit contenir 10 chiffres et uniquement des chiffres.");
                }

                if (!fax.All(char.IsDigit))
                {
                    throw new Exception("Le numéro de fax doit contenir uniquement des chiffres.");
                }

                if (postalFacture.Length != 5 || !postalFacture.All(char.IsDigit))
                {
                    throw new Exception("Le code postal de facturation doit contenir 5 chiffres et uniquement des chiffres.");
                }

                if (postalLivraison.Length != 5 || !postalLivraison.All(char.IsDigit))
                {
                    throw new Exception("Le code postal de livraison doit contenir 5 chiffres et uniquement des chiffres.");
                }

                if (!numRueFacture.All(char.IsDigit))
                {
                    throw new Exception("Le numéro de rue de facturation doit contenir uniquement des chiffres.");
                }

                if (!numRueLivraison.All(char.IsDigit))
                {
                    throw new Exception("Le numéro de rue de livraison doit contenir uniquement des chiffres.");
                }

                // Conversion des valeurs numériques en string pour la creation du client
                int numRueFactureInt = int.Parse(numRueFacture);
                int numRueLivraisonInt = int.Parse(numRueLivraison);

                // --- Création du client ---
                Client nouveauClient = new Client(
                    nom,                    // nomClient
                    fax,                    // numFaxClient
                    email,                  // mailClient
                    phone,                  // numPhoneClient
                    postalFacture,          // codePostalFacture
                    nomVilleFacture,        // villeFacture
                    numRueFactureInt,       // numRueFacture
                    nomRueFacture,          // nomRueFacture
                    postalLivraison,        // codePostalLivraison
                    nomVilleLivraison,      // villeLivraison
                    numRueLivraisonInt,     // numRueLivraison
                    nomRueLivraison         // nomRueLivraison
                );

                // Ajout du client
                GestionClients.AjouterClient(nouveauClient);

                MessageBox.Show("Client ajouté avec succès !");
                ViderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du client : " + ex.Message);
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            // Ouvre le formulaire FrmClient
            FrmClient Client = new FrmClient();
            Client.Show();

            // Ferme le formulaire actuel
            this.Close();
        }

        private void ViderChamps()
        {
            txtNom.Clear();
            txtPhone.Clear();
            txtFax.Clear();
            txtMail.Clear();
            txtNumRueFacture.Clear();
            txtNomRueFacture.Clear();
            txtCodePostalFacture.Clear();
            txtNomVilleFacture.Clear();
            txtNumRueLivre.Clear();
            txtNomRueLivre.Clear();
            txtCodePostalLivre.Clear();
            txtNomVilleLivre.Clear();
            txtNumRueLivre.Clear();
            txtCodePostalLivre.Clear();
            txtNomVilleLivre.Clear();
        }

        private void FrmAjoutDeClients_Load(object sender, EventArgs e)
        {

        }
    }
}
