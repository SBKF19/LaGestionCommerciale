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
using UtilisateursBLL;

namespace LaGestionCommerciale
{
    public partial class FrmClient : Form
    {
        public FrmClient()
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

        private void FrmClient_Load(object sender, EventArgs e)
        {
            // Récupérer la liste des produits depuis la BLL
            List<Client> lesClients = GestionClients.GetClients();

            // Active le retour à la ligne
            dgvClient.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Autoriser les lignes à s’ajuster en hauteur
            dgvClient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Permet de ne pas modifier une case du DataGridView
            dgvClient.ReadOnly = true;

            // Permet de sélectionner une ligne entière
            dgvClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Permet de ne sélectionner qu'une seule ligne à la fois
            dgvClient.MultiSelect = false;

            // Empêche l'ajout manuel de lignes
            dgvClient.AllowUserToAddRows = false;

            // Désactive l'événement pour éviter les mises à jour incomplètes
            dgvClient.SelectionChanged -= dgvClient_SelectionChanged;

            // Afficher les données dans le DataGridView
            dgvClient.Rows.Clear();

            foreach (var c in lesClients)
            {
                dgvClient.Rows.Add(
                     c.IdClient,
                     c.NomClient,

                     // Adresse facturation visible
                     c.NumRueFacture + " " + c.NomRueFacture + ", " + c.VilleFacture + " " + c.CodePostalFacture,

                     // Adresse livraison visible
                     c.NumRueLivraison + " " + c.NomRueLivraison + ", " + c.VilleLivraison + " " + c.CodePostalLivraison,

                     c.NumPhoneClient,
                     c.NumFaxClient,
                     c.MailClient,

                     // Colonnes cachées (dans le même ordre que ton DataGridView)
                     c.NumRueFacture,
                     c.NomRueFacture,
                     c.VilleFacture,
                     c.CodePostalFacture,

                     c.NumRueLivraison,
                     c.NomRueLivraison,
                     c.VilleLivraison,
                     c.CodePostalLivraison
                 );
            }

            // Sélectionne la première ligne
            if (dgvClient.Rows.Count > 0)
                dgvClient.Rows[0].Selected = true;

            // Réactive l'événement
            dgvClient.SelectionChanged += dgvClient_SelectionChanged;

            // Remplit les champs pour la première ligne
            RemplirChampsDepuisLigne(0);
        }

        // Événement déclenché lors de la sélection d'une ligne dans le DataGridView
        private void dgvClient_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClient.CurrentRow != null)
            {
                RemplirChampsDepuisLigne(dgvClient.CurrentRow.Index);
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            LaGestionCommerciale.FrmAjoutDeClients frm = new LaGestionCommerciale.FrmAjoutDeClients();
            frm.Show();
            this.Hide();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupération et trim des champs
                string nom = txtNom.Text.Trim();
                string phone = txtTelephone.Text.Trim();
                string fax = txtFax.Text.Trim();
                string email = txtEmail.Text.Trim();

                string numRueFactureStr = txtNumeroRueFacturation.Text.Trim();
                string nomRueFacture = txtRueFacturation.Text.Trim();
                string postalFacture = txtCodePostalFacturation.Text.Trim();
                string nomVilleFacture = txtVilleFacturation.Text.Trim();

                string numRueLivraisonStr = txtNumeroRueLivraison.Text.Trim();
                string nomRueLivraison = txtRueLivraison.Text.Trim();
                string postalLivraison = txtCodePostalLivraison.Text.Trim();
                string nomVilleLivraison = txtVilleLivraison.Text.Trim();

                // Vérification des champs obligatoires
                if (string.IsNullOrWhiteSpace(nom) ||
                    string.IsNullOrWhiteSpace(phone) ||
                    string.IsNullOrWhiteSpace(fax) ||
                    string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(numRueFactureStr) ||
                    string.IsNullOrWhiteSpace(nomRueFacture) ||
                    string.IsNullOrWhiteSpace(postalFacture) ||
                    string.IsNullOrWhiteSpace(nomVilleFacture) ||
                    string.IsNullOrWhiteSpace(numRueLivraisonStr) ||
                    string.IsNullOrWhiteSpace(nomRueLivraison) ||
                    string.IsNullOrWhiteSpace(postalLivraison) ||
                    string.IsNullOrWhiteSpace(nomVilleLivraison))
                {
                    throw new Exception("Veuillez remplir tous les champs.");
                }

                // Vérifications numériques

                string patternEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(email, patternEmail))
                    throw new Exception("L'adresse email n'est pas valide.");
                if (!phone.All(char.IsDigit) || phone.Length != 10)
                    throw new Exception("Le numéro de téléphone doit contenir 10 chiffres.");
                if (!fax.All(char.IsDigit))
                    throw new Exception("Le numéro de fax doit contenir uniquement des chiffres.");
                if (!postalFacture.All(char.IsDigit) || postalFacture.Length != 5)
                    throw new Exception("Le code postal de facturation doit contenir 5 chiffres.");
                if (!postalLivraison.All(char.IsDigit) || postalLivraison.Length != 5)
                    throw new Exception("Le code postal de livraison doit contenir 5 chiffres.");
                if (!numRueFactureStr.All(char.IsDigit))
                    throw new Exception("Le numéro de rue de facturation doit contenir uniquement des chiffres.");
                if (!numRueLivraisonStr.All(char.IsDigit))
                    throw new Exception("Le numéro de rue de livraison doit contenir uniquement des chiffres.");


                // Vérifier qu'une ligne est sélectionnée
                if (dgvClient.SelectedRows.Count == 0)
                    throw new Exception("Veuillez sélectionner un client à modifier.");

                int idClient = Convert.ToInt32(dgvClient.SelectedRows[0].Cells[0].Value);

                // Conversion des numéros de rue
                int numRueFacture = int.Parse(numRueFactureStr);
                int numRueLivraison = int.Parse(numRueLivraisonStr);

                // Création de l'objet Client
                Client client = new Client(
                    idClient,
                    nom,
                    fax,
                    email,
                    phone,
                    postalFacture,
                    nomVilleFacture,
                    numRueFacture,
                    nomRueFacture,
                    postalLivraison,
                    nomVilleLivraison,
                    numRueLivraison,
                    nomRueLivraison
                );

                // Modification en base
                int nb = GestionClients.ModifierClient(client);
                if (nb == 0)
                    throw new Exception("La modification a échoué : ID introuvable ou problème SQL.");

                // Mise à jour du DataGridView
                var row = dgvClient.SelectedRows[0];
                row.Cells["NomClient"].Value = nom;
                row.Cells["Téléphone"].Value = phone;
                row.Cells["Fax"].Value = fax;
                row.Cells["Email"].Value = email;

                row.Cells["NumRueFact"].Value = numRueFactureStr;
                row.Cells["RueFact"].Value = nomRueFacture;
                row.Cells["VilleFact"].Value = nomVilleFacture;
                row.Cells["CodePostalFact"].Value = postalFacture;

                row.Cells["NumRueLiv"].Value = numRueLivraisonStr;
                row.Cells["RueLiv"].Value = nomRueLivraison;
                row.Cells["VilleLiv"].Value = nomVilleLivraison;
                row.Cells["CodePostalLiv"].Value = postalLivraison;

                row.Cells["AdresseFacturation"].Value = $"{numRueFactureStr} {nomRueFacture}, {nomVilleFacture} {postalFacture}";
                row.Cells["AdresseLivraison"].Value = $"{numRueLivraisonStr} {nomRueLivraison}, {nomVilleLivraison} {postalLivraison}";

                MessageBox.Show("Client modifié avec succès.",
                                "Modification",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // Vérifie qu'une ligne est sélectionnée dans le DataGridView
            if (dgvClient.SelectedRows.Count == 0)
            {
                MessageBox.Show("Aucun client sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupération de la ligne sélectionnée
            DataGridViewRow row = dgvClient.SelectedRows[0];

            // Récupération de l'ID et du nom du client à supprimer
            // On prend les valeurs des colonnes 0 et 1 (attention à l'ordre des colonnes dans le DataGridView)
            int idClient = Convert.ToInt32(row.Cells[0].Value); // IdClient
            string nomClient = row.Cells[1].Value.ToString();   // NomClient

            // Affiche une boîte de confirmation avant suppression
            var confirm = MessageBox.Show(
                $"Confirmer la suppression du client '{nomClient}' ?",
                "Supprimer",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Si l'utilisateur confirme la suppression
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Vérifie si le client est utilisé dans un devis ou autre (clé étrangère)
                    if (GestionClients.ClientEstUtilise(idClient))
                        throw new Exception("Impossible de supprimer ce client car il est lié à un devis.");

                    // Appelle la méthode BLL pour supprimer le client dans la base
                    int nb = GestionClients.DeleteClient(idClient);

                    // Si la suppression a réussi (nombre de lignes affectées > 0)
                    if (nb > 0)
                    {
                        // Supprime la ligne correspondante du DataGridView
                        dgvClient.Rows.Remove(row);

                        // Message de confirmation
                        MessageBox.Show("Client supprimé avec succès.",
                                        "Suppression",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Si aucune ligne n'a été supprimée, lever une exception
                        throw new Exception("Le client n'existe pas ou n'a pas pu être supprimé.");
                    }
                }
                catch (Exception ex)
                {
                    // Affiche l'erreur si la suppression échoue (ex : contrainte FK, problème SQL)
                    MessageBox.Show(ex.Message, "Impossible de supprimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        // Méthode pour remplir les champs dans le menu "détail" quand on clique sur une ligne du DataGridView
        private void RemplirChampsDepuisLigne(int index)
        {
            // Rows[index] permet d'accéder à la ligne cliquée
            DataGridViewRow row = dgvClient.Rows[index];

            // row.Cells["NomClient"] correspond au nom de la colonne dans le DataGridView
            // .Value?.ToString() permet de récupérer la valeur de la cellule en tant que chaîne de caractères
            // Le "?." gère le cas où la valeur serait null pour éviter une exception
            // toString() convertit la valeur en chaîne de caractères
            txtNom.Text = row.Cells["NomClient"].Value?.ToString();
            txtTelephone.Text = row.Cells["Téléphone"].Value?.ToString();
            txtFax.Text = row.Cells["Fax"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();

            txtNumeroRueFacturation.Text = row.Cells["NumRueFact"].Value?.ToString();
            txtRueFacturation.Text = row.Cells["RueFact"].Value?.ToString();
            txtVilleFacturation.Text = row.Cells["VilleFact"].Value?.ToString();
            txtCodePostalFacturation.Text = row.Cells["CodePostalFact"].Value?.ToString();

            txtNumeroRueLivraison.Text = row.Cells["NumRueLiv"].Value?.ToString();
            txtRueLivraison.Text = row.Cells["RueLiv"].Value?.ToString();
            txtVilleLivraison.Text = row.Cells["VilleLiv"].Value?.ToString();
            txtCodePostalLivraison.Text = row.Cells["CodePostalLiv"].Value?.ToString();
        }

        private void clientsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void produitsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmProduit().Show();
            this.Hide();
        }

        private void devisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmDevis().Show();
            this.Hide();
        }

        private void synthèseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmSyntheseClient().Show();
            this.Hide();
        }
    }
}
