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
    public partial class FrmClient : Form
    {
        public FrmClient()
        {
            InitializeComponent();

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
            try
            {
                cbxProvenance.DataSource = GestionProvenances.GetProvenances();
                cbxProvenance.DisplayMember = "NomPays";
                cbxProvenance.ValueMember = "IdProvenances";

                List<Client> lesClients = GestionClients.GetClients();

                dgvClient.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvClient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvClient.ReadOnly = true;
                dgvClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvClient.MultiSelect = false;
                dgvClient.AllowUserToAddRows = false;
                dgvClient.SelectionChanged -= dgvClient_SelectionChanged;

                dgvClient.Rows.Clear();

                foreach (var c in lesClients)
                {
                    // Gestion d'affichage si Provenance est NULL
                    string libellePays = (c.Provenance != null) ? c.Provenance.NomPays : "Inconnue";

                    int index = dgvClient.Rows.Add(
                          c.IdClient,
                          c.NomClient,
                          libellePays,
                          c.NumRueFacture + " " + c.NomRueFacture + ", " + c.VilleFacture + " " + c.CodePostalFacture,
                          c.NumRueLivraison + " " + c.NomRueLivraison + ", " + c.VilleLivraison + " " + c.CodePostalLivraison,
                          c.NumPhoneClient,
                          c.NumFaxClient,
                          c.MailClient,
                          c.NumRueFacture,
                          c.NomRueFacture,
                          c.VilleFacture,
                          c.CodePostalFacture,
                          c.NumRueLivraison,
                          c.NomRueLivraison,
                          c.VilleLivraison,
                          c.CodePostalLivraison
                      );

                    dgvClient.Rows[index].Tag = c;
                }

                if (dgvClient.Rows.Count > 0)
                {
                    dgvClient.Rows[0].Selected = true;
                    RemplirChampsDepuisLigne(0);
                }

                dgvClient.SelectionChanged += dgvClient_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur au chargement : " + ex.Message);
            }
        }

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
                if (dgvClient.SelectedRows.Count == 0)
                    throw new Exception("Veuillez sélectionner un client à modifier.");

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

                if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
                {
                    throw new Exception("Veuillez remplir au moins le Nom, Téléphone et Email.");
                }

                if (cbxProvenance.SelectedItem == null)
                {
                    throw new Exception("Veuillez sélectionner un pays (Provenance).");
                }

                string patternEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(email, patternEmail)) throw new Exception("Email invalide.");
                if (!phone.All(char.IsDigit) || phone.Length != 10) throw new Exception("Téléphone invalide (10 chiffres).");

                int numRueFacture = int.Parse(numRueFactureStr);
                int numRueLivraison = int.Parse(numRueLivraisonStr);
                int idClient = Convert.ToInt32(dgvClient.SelectedRows[0].Cells[0].Value);

                Provenance prov = (Provenance)cbxProvenance.SelectedItem;

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
                    nomRueLivraison,
                    prov
                );

                int nb = GestionClients.ModifierClient(client);
                if (nb == 0) throw new Exception("Echec modification SQL.");

                var row = dgvClient.SelectedRows[0];
                row.Cells[1].Value = nom;
                row.Cells[2].Value = prov.NomPays; 
                row.Cells[3].Value = $"{numRueFacture} {nomRueFacture}, {nomVilleFacture} {postalFacture}";
                row.Cells[4].Value = $"{numRueLivraison} {nomRueLivraison}, {nomVilleLivraison} {postalLivraison}";
                row.Cells[5].Value = phone;
                row.Cells[6].Value = fax;
                row.Cells[7].Value = email;

                row.Tag = client;

                MessageBox.Show("Client modifié avec succès.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvClient.SelectedRows.Count == 0) return;

            Client client = (Client)dgvClient.SelectedRows[0].Tag;

            var confirm = MessageBox.Show($"Supprimer le client '{client.NomClient}' ?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (GestionClients.ClientEstUtilise(client.IdClient))
                        throw new Exception("Ce client est lié à des devis, suppression impossible.");

                    int nb = GestionClients.DeleteClient(client.IdClient);
                    if (nb > 0)
                    {
                        dgvClient.Rows.Remove(dgvClient.SelectedRows[0]);
                        MessageBox.Show("Client supprimé.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void RemplirChampsDepuisLigne(int index)
        {
            if (index < 0 || index >= dgvClient.Rows.Count) return;

            Client c = (Client)dgvClient.Rows[index].Tag;

            if (c != null)
            {
                txtNom.Text = c.NomClient;
                txtTelephone.Text = c.NumPhoneClient;
                txtFax.Text = c.NumFaxClient;
                txtEmail.Text = c.MailClient;

                txtNumeroRueFacturation.Text = c.NumRueFacture.ToString();
                txtRueFacturation.Text = c.NomRueFacture;
                txtVilleFacturation.Text = c.VilleFacture;
                txtCodePostalFacturation.Text = c.CodePostalFacture;

                txtNumeroRueLivraison.Text = c.NumRueLivraison.ToString();
                txtRueLivraison.Text = c.NomRueLivraison;
                txtVilleLivraison.Text = c.VilleLivraison;
                txtCodePostalLivraison.Text = c.CodePostalLivraison;

                if (c.Provenance != null)
                {
                    cbxProvenance.SelectedValue = c.Provenance.IdProvenances;
                }
                else
                {
                    cbxProvenance.SelectedIndex = -1; 
                }
            }
        }

        private void produitsToolStripMenuItem1_Click(object sender, EventArgs e) { new FrmProduit().Show(); this.Hide(); }
        private void devisToolStripMenuItem1_Click(object sender, EventArgs e) { new FrmDevis().Show(); this.Hide(); }
        private void clientsToolStripMenuItem1_Click(object sender, EventArgs e) { }
    }
}