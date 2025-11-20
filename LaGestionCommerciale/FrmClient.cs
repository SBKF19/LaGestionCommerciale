using BLL;
using BO;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;

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

            // Afficher les données dans le DataGridView
            dgvClient.Rows.Clear();

            foreach (var c in lesClients)
            {
                dgvClient.Rows.Add(c.IdClient, c.NomClient, c.NumRueFacture + " " + c.NomRueFacture + ", " + c.VilleFacture + " " + c.CodePostalFacture, c.NumRueLivraison 
                    + " " + c.NomRueLivraison + ", " + c.VilleLivraison + " " + c.CodePostalLivraison, c.NumPhoneClient, c.NumFaxClient, c.MailClient);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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



    }
}
