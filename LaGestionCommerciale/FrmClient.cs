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
                if (string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("Le nom du client est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvClient.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un client à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idClient = Convert.ToInt32(dgvClient.SelectedRows[0].Cells[0].Value);

                // Conversion sécurisée des champs numériques
                string codePostalFact = txtCodePostalFacturation.Text.Trim();
                string codePostalLiv = txtCodePostalLivraison.Text.Trim();

                int numRueFact = int.TryParse(txtNumeroRueFacturation.Text.Trim(), out int nrf) ? nrf : 0;
                int numRueLiv = int.TryParse(txtNumeroRueLivraison.Text.Trim(), out int nrl) ? nrl : 0;

                Client client = new Client(
                    idClient,
                    txtNom.Text,
                    txtFax.Text,
                    txtEmail.Text,
                    txtTelephone.Text,
                    codePostalFact,
                    txtVilleFacturation.Text,
                    numRueFact,
                    txtRueFacturation.Text,
                    codePostalLiv,
                    txtVilleLivraison.Text,
                    numRueLiv,
                    txtRueLivraison.Text
                );


                int nb = GestionClients.ModifierClient(client);

                if (nb == 0)
                    throw new Exception("La modification a échoué : ID introuvable ou problème SQL.");

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
            if (dgvClient.SelectedRows.Count == 0)
            {
                MessageBox.Show("Aucun client sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupération du client sélectionné
            DataGridViewRow row = dgvClient.SelectedRows[0];
            int idClient = Convert.ToInt32(row.Cells["Code"].Value);
            string nomClient = row.Cells["NomClient"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Confirmer la suppression du client '{nomClient}' ?",
                "Supprimer",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Vérifie si le client est utilisé dans un devis
                    if (GestionClients.ClientEstUtilise(idClient))
                        throw new Exception("Impossible de supprimer ce client car il est lié à un devis.");

                    // Suppression
                    int nb = GestionClients.DeleteClient(idClient);

                    if (nb > 0)
                    {
                        dgvClient.Rows.Remove(row);

                        MessageBox.Show("Client supprimé avec succès.",
                            "Suppression",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception("Le client n'existe pas ou n'a pas pu être supprimé.");
                    }
                }
                catch (Exception ex)
                {
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

        // Menu pour accéder aux autres formulaires
        private void ajouterUnClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAjoutDeClients frm = new FrmAjoutDeClients();
            frm.Show();
            this.Hide();
        }

        private void gérerLesProduitsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProduit frm = new FrmProduit();
            frm.Show();
            this.Hide();
        }

        private void ajouterUnProduitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAjoutDeProduit frm = new FrmAjoutDeProduit();
            frm.Show();
            this.Hide();
        }
    }
}
