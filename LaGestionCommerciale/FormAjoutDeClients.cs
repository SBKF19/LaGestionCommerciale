using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaGestionCommerciale
{
    public partial class FormAjoutDeClients : Form
    {
        public FormAjoutDeClients()
        {
            InitializeComponent();
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
                int.TryParse(phone, out int phoneInt);

                if (phone.Length != 10 || !phone.All(char.IsDigit))
                {
                    throw new Exception("Le numéro de téléphone doit contenir 10 chiffres et uniquement des chiffres.");
                }

                int.TryParse(fax, out int faxInt);
                if (!fax.All(char.IsDigit))
                {
                    throw new Exception("Le numéro de fax doit contenir uniquement des chiffres.");
                }

                int.TryParse(postalFacture, out int postalFactureInt);
                if (postalFacture.Length != 5 || !postalFacture.All(char.IsDigit))
                {
                    throw new Exception("Le code postal de facturation doit contenir 5 chiffres et uniquement des chiffres.");
                }

                int.TryParse(postalLivraison, out int postalLivraisonInt);
                if (postalLivraison.Length != 5 || !postalLivraison.All(char.IsDigit))
                {
                    throw new Exception("Le code postal de livraison doit contenir 5 chiffres et uniquement des chiffres.");
                }

                int.TryParse(numRueFacture, out int numRueFactureInt);
                if (!numRueFacture.All(char.IsDigit))
                {
                    throw new Exception("Le numéro de rue de facturation doit contenir uniquement des chiffres.");
                }
                int.TryParse(numRueLivraison, out int numRueLivraisonInt);
                if (!numRueLivraison.All(char.IsDigit))
                {
                    throw new Exception("Le numéro de rue de livraison doit contenir uniquement des chiffres.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du client : " + ex.Message);
            }
        }
    }
}
