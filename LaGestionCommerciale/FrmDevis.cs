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
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilisateursBLL;

namespace LaGestionCommerciale
{
    public partial class FrmDevis : Form
    {
        //private Devis devisCourant;

        public FrmDevis()
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

        private void FrmDevis_Load(object sender, EventArgs e)
        {
            cmbStatut.DataSource = GestionDevis.GetStatuts();
            cmbStatut.DisplayMember = "nom_statut";
            cmbStatut.ValueMember = "id_statut";

            // charger la liste des devis
            List<Devis> lesDevis = GestionDevis.GetDevis();
            dgvDevis.ReadOnly = true;
            dgvDevis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevis.AllowUserToAddRows = false;

            dgvDevis.Rows.Clear();
            foreach (Devis devis in lesDevis)
            {
                dgvDevis.Rows.Add(
                    devis.IdDevis,
                    devis.Client.NomClient,
                    devis.Date_devis,
                    devis.Montant_HT_devis
                );
            }

            // Sélectionne la première ligne
            if (dgvDevis.Rows.Count > 0) { 
                dgvDevis.Rows[0].Selected = true;

            // Réactive l'événement
            dgvDevis.SelectionChanged += dgvDevis_SelectionChanged;

            // Remplit les champs pour la première ligne
            RemplirChampsDepuisLigne(0);
            }
        }

        // Événement déclenché lors de la sélection d'une ligne dans le DataGridView
        private void dgvDevis_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevis.CurrentRow != null)
            {
                RemplirChampsDepuisLigne(dgvDevis.CurrentRow.Index);
            }
        }

        private void RemplirChampsDepuisLigne(int index)
        {
            // Rows[index] permet d'accéder à la ligne cliquée
            DataGridViewRow row = dgvDevis.Rows[index];

            txtCode.Text = row.Cells["Code"].Value?.ToString();
            dtpDevis.Text = row.Cells["Date"].Value?.ToString();

        }

        private void btnAddDevis_Click(object sender, EventArgs e)
        {

        }

        private void pnlDevis_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDevis_Load_1(object sender, EventArgs e)
        {

        }

        //private void btnModifier_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Récupération des champs
        //        string statut = cmbStatut.Text.Trim();
        //        var clientSelectionne = cmbClient.SelectedItem;
        //        var produitSelectionne = cmbProduit.SelectedItem;

        //        if (clientSelectionne == null || produitSelectionne == null)
        //            throw new Exception("Veuillez sélectionner un client et un produit.");

        //        int quantite = (int)numQuantite.Value;
        //        float remiseProduit = (float)numRemiseProduit.Value;
        //        float remiseGlobale = (float)numRemiseGlobale.Value;

        //        if (quantite <= 0)
        //            throw new Exception("La quantité doit être > 0.");

        //        // Vérifier qu'une ligne est sélectionnée
        //        if (dgvDevis.SelectedRows.Count == 0)
        //            throw new Exception("Veuillez sélectionner une ligne.");

        //        // Récupération des clés (idDevis + idProduit)
        //        int idProduit = ((ProduitBO)produitSelectionne).Code;
        //        int idDevis = devisCourant.IdDevis;  // garde ton Devis actuel dans une variable globale

        //        // Reconstruction de la ligne
        //        Contenir ligne = new Contenir(
        //            (ProduitBO)produitSelectionne,
        //            devisCourant,
        //            quantite,
        //            remiseProduit
        //        );

        //        // Mise à jour ligne CONTENIR
        //        int nb = GestionDevis.ModifierLigneContenir(ligne);
        //        if (nb == 0)
        //            throw new Exception("La modification de la ligne a échoué.");


        //        // Mise à jour du DEVIS (remise globale, statut, date…)
        //        devisCourant.Date_devis = dtpDevis.Value;
        //        devisCourant.Taux_remise_global_devis = remiseGlobale;

        //        GestionDevis.ModifierDevis(devisCourant);

        //        Devis devis = new Devis(
        //            dtpDevis.Value,            // DateTime
        //            tVA_devis,                  // float (ex : 20f)
        //            (float)remiseGlobale,      // float
        //            montantHT,                 // float (calcule ou récupère)
        //            (Client)clientSelectionne, // Client
        //            (Statut)cmbStatut.SelectedItem // Statut
        //        );

        //        // Mise à jour DataGridView
        //        var row = dgvDevis.SelectedRows[0];

        //        row.Cells["Produit"].Value = ((ProduitBO)produitSelectionne).Libelle;
        //        row.Cells["Quantite"].Value = quantite;
        //        row.Cells["RemiseProduit"].Value = remiseProduit;

        //        // Recalcul totals
        //        CalculerTotaux();

        //        MessageBox.Show("Devis modifié avec succès.", "OK",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
