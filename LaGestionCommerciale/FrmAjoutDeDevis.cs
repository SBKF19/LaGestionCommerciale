using BLL;
using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace LaGestionCommerciale // ou LaGestionCommerciale
{
    public partial class FrmAjoutDeDevis : Form
    {
        private Devis devisCourant;
        private BindingList<Contenir> lignesBinding;

        public FrmAjoutDeDevis()
        {
            InitializeComponent();

            // On récupère la chaîne de connexion depuis App.config
            var chset = ConfigurationManager.ConnectionStrings["gestion_commerciale"];

            if (chset != null)
            {
                // On transmet la chaîne à la couche BLL/DAL
                GestionDevis.SetchaineConnexion(chset);
            }
            else
            {
                MessageBox.Show("Erreur critique : Chaîne de connexion 'gestion_commerciale' introuvable !");
            }

            // Correction CS1729 : Utilise le nouveau constructeur vide ajouté dans BO/Devis.cs
            devisCourant = new Devis();
            lignesBinding = new BindingList<Contenir>(devisCourant.Lignes);

            ConfiguerGrille();
            ChargerListes();
        }

        private void ChargerListes()
        {
            try
            {
                // Assure-toi que les méthodes GetClients/GetStatuts existent dans tes BLL respectives
                cbClient.DataSource = GestionClients.GetClients();
                cbClient.DisplayMember = "Nom_client"; // SQL: nom_client -> BO: NomClient (Vérifie ton BO Client)
                cbClient.ValueMember = "IdClient";

                cbStatut.DataSource = GestionDevis.GetStatuts();
                cbStatut.DisplayMember = "Nom_statut";
                cbStatut.ValueMember = "IdStatut";

                cbProduit.DataSource = GestionProduits.GetProduits();
                cbProduit.DisplayMember = "Libelle"; // BO Produit: Libelle
                cbProduit.ValueMember = "Code";      // BO Produit: Code

                if (cbStatut.Items.Count > 0) cbStatut.SelectedIndex = 0;
                cbClient.SelectedIndex = -1;
                cbProduit.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement listes: " + ex.Message);
            }
        }

        private void ConfiguerGrille()
        {
            dgvLignes.AutoGenerateColumns = false;
            dgvLignes.DataSource = lignesBinding;
            dgvLignes.Columns.Clear();

            // Produit (Lecture seule)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Produit",
                DataPropertyName = "ProduitBO.Libelle",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Prix Unitaire (Lecture seule)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "P.U.",
                DataPropertyName = "PrixUnitaire",
                ReadOnly = true,
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            // Quantité (Editable)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Qté",
                DataPropertyName = "Quantite_commandee",
                ReadOnly = false,
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightYellow }
            });

            // Remise (Editable)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Rem %",
                DataPropertyName = "Remise_par_ligne",
                ReadOnly = false,
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightYellow }
            });

            // Total HT (Calculé)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total HT",
                DataPropertyName = "MontantHT_AvecRemise",
                ReadOnly = true,
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClient.SelectedItem is Client c)
            {
                lblClientInfos.Text = $"{c.NomClient}\nFact: {c.NumRueFacture} {c.NomRueFacture} {c.CodePostalFacture} {c.VilleFacture}\nTél: {c.NumPhoneClient} | Email: {c.MailClient}";
            }
        }

        private void btnAjouterLigne_Click(object sender, EventArgs e)
        {
            if (cbProduit.SelectedItem is ProduitBO prod)
            {
                foreach (var l in lignesBinding)
                    if (l.ProduitBO.Code == prod.Code) { MessageBox.Show("Produit déjà présent"); return; }

                Contenir ligne = new Contenir(prod, devisCourant, 1, 0);
                lignesBinding.Add(ligne);
                RecalculerTotaux();
            }
        }

        private void dgvLignes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvLignes.Refresh();
            RecalculerTotaux();
        }

        private void nudTauxTVA_ValueChanged(object sender, EventArgs e)
        {
            RecalculerTotaux();
        }

        private void RecalculerTotaux()
        {
            devisCourant.TVA_devis = (float)nudTauxTVA.Value;
            devisCourant.Taux_remise_global_devis = (float)nudTauxRemiseGlobale.Value;
            devisCourant.RecalculerTotaux();

            lblTotalHT.Text = devisCourant.Montant_HT_devis.ToString("C2");
            float tva = devisCourant.Montant_HT_devis * (devisCourant.TVA_devis / 100);
            lblMontantTVA.Text = tva.ToString("C2");
            lblTotalTTC.Text = (devisCourant.Montant_HT_devis + tva).ToString("C2");
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
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void dgvLignes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLignes.Columns[e.ColumnIndex].HeaderText == "Produit" && e.Value == null)
            {
                var row = dgvLignes.Rows[e.RowIndex].DataBoundItem as Contenir;
                if (row != null) e.Value = row.ProduitBO.Libelle;
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClientInfos_Click(object sender, EventArgs e)
        {

        }
    }
}