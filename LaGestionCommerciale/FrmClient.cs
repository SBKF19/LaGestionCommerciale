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
using BLL;
using BO;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace LaGestionCommerciale
{
    public partial class FrmClient : Form
    {
        public FrmClient()
        {
            InitializeComponent();
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
        }

        // Remplit les champs de texte dans le menu "détail" lorsque l'utilisateur clique sur une ligne du DataGridView
        private void dgvClient_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClient.CurrentRow != null)
            {
                RemplirChampsDepuisLigne(dgvClient.CurrentRow.Index);
            }
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

                int idClient = int.Parse(dgvClient.SelectedRows[0].Cells["Code"].Value.ToString());

                Client client = new Client(
                    idClient,
                    txtNom.Text,
                    txtFax.Text,
                    txtEmail.Text,
                    txtTelephone.Text,

                    txtCodePostalFacturation.Text,
                    txtVilleFacturation.Text,
                    int.Parse(txtNumeroRueFacturation.Text),
                    txtRueFacturation.Text,

                    txtCodePostalLivraison.Text,
                    txtVilleLivraison.Text,
                    int.Parse(txtNumeroRueLivraison.Text),
                    txtRueLivraison.Text
                );

                int nb = GestionClients.ModifierClient(client);

                if (nb == 0)
                    throw new Exception("Aucun client trouvé avec cet ID.");

                // Mise à jour du DataGridView
                var row = dgvClient.SelectedRows[0];

                row.Cells["Client"].Value = txtNom.Text;
                row.Cells["AdresseFacturation"].Value =
                    $"{txtNumeroRueFacturation.Text} {txtRueFacturation.Text}, {txtCodePostalFacturation.Text} {txtVilleFacturation.Text}";
                row.Cells["AdresseLivraison"].Value =
                    $"{txtNumeroRueLivraison.Text} {txtRueLivraison.Text}, {txtCodePostalLivraison.Text} {txtVilleLivraison.Text}";
                row.Cells["Téléphone"].Value = txtTelephone.Text;
                row.Cells["Fax"].Value = txtFax.Text;
                row.Cells["Email"].Value = txtEmail.Text;

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
    }
}
