using BLL;
using BO;
using System;
using System.ComponentModel;
using System.Configuration; // IMPORTANT pour ConfigurationManager
using System.Drawing;
using System.Windows.Forms;

namespace LaGestionCommerciale
{
    public partial class FrmAjoutDeDevis : Form
    {
        private Devis devisCourant;
        private BindingList<Contenir> lignesBinding;

        public FrmAjoutDeDevis()
        {
            InitializeComponent();

            // CORRECTION : Initialisation Chaîne de connexion
            var chset = ConfigurationManager.ConnectionStrings["gestion_commerciale"];
            if (chset != null) GestionDevis.SetchaineConnexion(chset);

            devisCourant = new Devis();
            lignesBinding = new BindingList<Contenir>(devisCourant.Lignes);

            ConfiguerGrille();
            ChargerListes();
        }

        private void ChargerListes()
        {
            try
            {
                cbClient.DataSource = GestionClients.GetClients();
                cbClient.DisplayMember = "NomClient"; cbClient.ValueMember = "IdClient";

                // Utilisation de GestionDevis pour les statuts
                cbStatut.DataSource = GestionDevis.GetStatuts();
                cbStatut.DisplayMember = "Nom_statut"; cbStatut.ValueMember = "IdStatut";

                cbProduit.DataSource = GestionProduits.GetProduits();
                cbProduit.DisplayMember = "Libelle"; cbProduit.ValueMember = "Code";

                cbClient.SelectedIndex = -1;
                cbProduit.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Erreur listes: " + ex.Message); }
        }

        private void ConfiguerGrille()
        {
            dgvLignes.AutoGenerateColumns = false;
            dgvLignes.DataSource = lignesBinding;
            dgvLignes.Columns.Clear();
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Produit", DataPropertyName = "ProduitBO.Libelle", ReadOnly = true });
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Code", DataPropertyName = "ProduitBO.Code", ReadOnly = true, Width = 50 });
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Catég.", ReadOnly = true, Width = 80 }); // Catégorie via CellFormatting
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "PU HT", DataPropertyName = "PrixUnitaire", ReadOnly = true, Width = 70, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Qté", DataPropertyName = "Quantite_commandee", Width = 50 });
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Rem.%", DataPropertyName = "Remise_par_ligne", Width = 50 });
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total HT", DataPropertyName = "MontantHT_AvecRemise", ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClient.SelectedItem is Client c)
                lblClientInfos.Text = $"Fact: {c.NumRueFacture} {c.NomRueFacture}, {c.CodePostalFacture} {c.VilleFacture}\nLivr: {c.NumRueLivraison} {c.NomRueLivraison}, {c.CodePostalLivraison} {c.VilleLivraison}\nTél: {c.NumPhoneClient} | Email: {c.MailClient}";
        }

        private void btnAjouterLigne_Click(object sender, EventArgs e)
        {
            if (cbProduit.SelectedItem is ProduitBO p)
            {
                foreach (var l in lignesBinding) if (l.ProduitBO.Code == p.Code) return;
                lignesBinding.Add(new Contenir(p, devisCourant, 1, 0));
                RecalculerTotaux();
            }
        }

        private void RecalculerTotaux()
        {
            devisCourant.TVA_devis = (float)nudTauxTVA.Value;
            devisCourant.Taux_remise_global_devis = (float)nudTauxRemiseGlobale.Value;
            devisCourant.RecalculerTotaux();

            lblValHT.Text = devisCourant.Montant_HT_devis.ToString("C2");
            float tva = devisCourant.Montant_HT_devis * (devisCourant.TVA_devis / 100);
            lblValTVA.Text = tva.ToString("C2");
            lblValTTC.Text = (devisCourant.Montant_HT_devis + tva).ToString("C2");
        }

        private void dgvLignes_CellEndEdit(object sender, DataGridViewCellEventArgs e) { dgvLignes.Refresh(); RecalculerTotaux(); }
        private void nudTauxTVA_ValueChanged(object sender, EventArgs e) { RecalculerTotaux(); }

        private void dgvLignes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLignes.Columns[e.ColumnIndex].HeaderText == "Catég.")
            {
                var row = dgvLignes.Rows[e.RowIndex].DataBoundItem as Contenir;
                // Attention: Assurez-vous que ProduitBO a une propriété Categorie et Categorie a NomCategorie
                if (row?.ProduitBO?.Categorie != null) e.Value = row.ProduitBO.Categorie.NomCategorie;
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cbClient.SelectedItem == null || lignesBinding.Count == 0) return;
            devisCourant.Client = (Client)cbClient.SelectedItem;
            devisCourant.Statut = (Statut)cbStatut.SelectedItem;
            devisCourant.Date_devis = dtpDate.Value;

            try
            {
                GestionDevis.AjouterDevis(devisCourant);
                MessageBox.Show("Devis ajouté !");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Erreur: " + ex.Message); }
        }
        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAjoutDeDevis_Load(object sender, EventArgs e)
        {

        }
    }
}