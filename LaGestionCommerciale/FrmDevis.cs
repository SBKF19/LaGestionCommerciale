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
    public partial class FrmDevis : Form
    {
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
            dgvModify.AllowUserToAddRows = false;
            dgvModify.Columns.Clear();

            // 1. Nettoyage
            dgvModify.AllowUserToAddRows = false;
            dgvModify.Columns.Clear();

            // --- Colonne PRODUIT (ComboBox) ---
            DataGridViewComboBoxColumn dgvCmbProduit = new DataGridViewComboBoxColumn();
            dgvCmbProduit.HeaderText = "Produit";
            dgvCmbProduit.Name = "ProduitCol";
            dgvCmbProduit.DataPropertyName = "Produit";
            dgvCmbProduit.DataSource = GestionProduits.GetProduits();
            dgvCmbProduit.DisplayMember = "Libelle";
            dgvCmbProduit.ValueMember = "Code";
            dgvModify.Columns.Add(dgvCmbProduit);

            // --- Colonne CATÉGORIE (Readonly) ---
            DataGridViewTextBoxColumn dgvTxtCat = new DataGridViewTextBoxColumn();
            dgvTxtCat.HeaderText = "Catégorie";
            dgvTxtCat.Name = "CatCol";
            dgvTxtCat.ReadOnly = true;
            dgvModify.Columns.Add(dgvTxtCat);

            // --- Colonne PRIX U. HT (Readonly) ---
            DataGridViewTextBoxColumn dgvTxtPrix = new DataGridViewTextBoxColumn();
            dgvTxtPrix.HeaderText = "Prix U. HT";
            dgvTxtPrix.Name = "PrixCol";
            dgvTxtPrix.ReadOnly = true;
            dgvModify.Columns.Add(dgvTxtPrix);

            // --- Colonne QUANTITÉ (COMBOBOX) ---
            DataGridViewComboBoxColumn dgvCmbQuantite = new DataGridViewComboBoxColumn();
            dgvCmbQuantite.HeaderText = "Qté";
            dgvCmbQuantite.Name = "QuantiteCol";
            // On remplit la combobox avec des chiffres de 1 à 100
            for (int i = 1; i <= 100; i++) dgvCmbQuantite.Items.Add(i);
            dgvModify.Columns.Add(dgvCmbQuantite);

            // --- Colonne REMISE % (COMBOBOX) ---
            DataGridViewComboBoxColumn dgvCmbRemise = new DataGridViewComboBoxColumn();
            dgvCmbRemise.HeaderText = "Rem.%";
            dgvCmbRemise.Name = "RemiseCol";
            // On remplit avec des valeurs fixes (0, 5, 10, 20...)
            dgvCmbRemise.Items.AddRange(0, 5, 10, 15, 20, 25, 30, 40, 50);
            dgvModify.Columns.Add(dgvCmbRemise);

            // --- Colonne TOTAL HT (Readonly) ---
            DataGridViewTextBoxColumn dgvTxtTotal = new DataGridViewTextBoxColumn();
            dgvTxtTotal.HeaderText = "Total HT";
            dgvTxtTotal.Name = "TotalCol";
            dgvTxtTotal.ReadOnly = true;
            dgvModify.Columns.Add(dgvTxtTotal);

            // --- Colonne SUPPRIMER ---
            DataGridViewButtonColumn dgvBtnDel = new DataGridViewButtonColumn();
            dgvBtnDel.HeaderText = "Sup.";
            dgvBtnDel.Name = "DeleteCol";
            dgvBtnDel.Text = "X";
            dgvBtnDel.UseColumnTextForButtonValue = true;
            dgvModify.Columns.Add(dgvBtnDel);

            // chargement combobox Statuts
            cmbStatut.DataSource = GestionDevis.GetStatuts();
            cmbStatut.DisplayMember = "Nom_statut";
            cmbStatut.ValueMember = "IdStatut";

            // chargement combobox utilisateurs
            cmbClient.DataSource = GestionClients.GetClients();
            cmbClient.DisplayMember = "NomClient";
            cmbClient.ValueMember = "IdClient";
            // chargement

            // charger la liste des devis
            List<Devis> lesDevis = GestionDevis.GetDevis();
            dgvDevis.ReadOnly = true;
            dgvDevis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevis.AllowUserToAddRows = false;
            dgvDevis.Rows.Clear();

            foreach (Devis devis in lesDevis)
            {
                // On ajoute la ligne et on récupère son index
                int index = dgvDevis.Rows.Add(
                    devis.IdDevis,
                    devis.Client.NomClient,
                    devis.Date_devis,
                    devis.Montant_HT_devis
                );
                dgvDevis.Rows[index].Tag = devis;
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

            // On récupère l'objet Devis complet stocké dans le Tag
            if (row.Tag is Devis devisSelectionne)
            {
                // --- 1. Champs existants ---
                txtCode.Text = devisSelectionne.IdDevis.ToString();
                dtpDevis.Value = devisSelectionne.Date_devis;

                // Sélection des ComboBox
                if (devisSelectionne.Client != null)
                    cmbClient.SelectedValue = devisSelectionne.Client.IdClient;

                if (devisSelectionne.Statut != null)
                    cmbStatut.SelectedValue = devisSelectionne.Statut.IdStatut;

                // --- 2. Infos Client (Téléphone & Mail) ---
                // Vérifiez le nom de vos TextBox dans le Design (ici j'utilise txtPhone et txtMail)
                if (devisSelectionne.Client != null)
                {
                    txtPhone.Text = devisSelectionne.Client.NumPhoneClient;
                    txtMail.Text = devisSelectionne.Client.MailClient;

                    // --- 3. Adresses (Concaténation) ---
                    // On combine : N° + Rue + CP + Ville pour faire une belle phrase

                    // Adresse de Facturation
                    txtFacture.Text = string.Format("{0} {1}, {2} {3}",
                        devisSelectionne.Client.NumRueFacture,
                        devisSelectionne.Client.NomRueFacture,
                        devisSelectionne.Client.CodePostalFacture,
                        devisSelectionne.Client.VilleFacture).Trim();

                    // Adresse de Livraison
                    txtLivre.Text = string.Format("{0} {1}, {2} {3}",
                        devisSelectionne.Client.NumRueLivraison,
                        devisSelectionne.Client.NomRueLivraison,
                        devisSelectionne.Client.CodePostalLivraison,
                        devisSelectionne.Client.VilleLivraison).Trim();
                }

                // --- 4. Taux (NumericUpDown) ---
                // Les NumericUpDown demandent des types 'decimal'. Votre objet a surement des 'float' ou 'double'.
                // Il faut donc convertir (caster).

                try
                {
                    numTVA.Value = (decimal)devisSelectionne.TVA_devis;
                    numRemiseGlobale.Value = (decimal)devisSelectionne.Taux_remise_global_devis;
                }
                catch
                {
                    // Sécurité au cas où la valeur dépasse le max du NumericUpDown
                    numTVA.Value = 0;
                    numRemiseGlobale.Value = 0;
                }

                // --- PARTIE 2 : REMPLISSAGE DU TABLEAU PRODUITS ---

                // 1. Vider le tableau
                dgvModify.Rows.Clear();

                // 2. Récupérer les lignes depuis la base
                // Note : On utilise l'ID du devis sélectionné
                List<Contenir> lesLignes = GestionDevis.GetLignesDuDevis(devisSelectionne.IdDevis);

                // 3. Remplir la grille
                foreach (Contenir ligne in lesLignes)
                {
                    int i = dgvModify.Rows.Add(); // Ajoute une ligne vide
                    DataGridViewRow r = dgvModify.Rows[i];

                    // A. Produit (ComboBox) : On sélectionne via l'ID (Code)
                    r.Cells["ProduitCol"].Value = ligne.ProduitBO.Code;

                    // B. Infos Lecture Seule (Catégorie & Prix)
                    if (ligne.ProduitBO.Categorie != null)
                        r.Cells["CatCol"].Value = ligne.ProduitBO.Categorie.NomCategorie; // Assure-toi que NomCategorie existe dans ta classe Categorie

                    r.Cells["PrixCol"].Value = ligne.ProduitBO.Prix;

                    // C. Quantité (ComboBox)
                    // Sécurité : Si la quantité de la BDD n'est pas dans la liste (1-100), on l'ajoute temporairement pour éviter le crash
                    DataGridViewComboBoxCell cellQte = (DataGridViewComboBoxCell)r.Cells["QuantiteCol"];
                    if (!cellQte.Items.Contains(ligne.Quantite_commandee))
                    {
                        cellQte.Items.Add(ligne.Quantite_commandee);
                    }
                    cellQte.Value = ligne.Quantite_commandee;

                    // D. Remise (ComboBox)
                    // Sécurité : Idem pour la remise. Tes remises en BDD sont des float (ex: 5.0), 
                    // ta combo attend peut-être des int (5). On convertit.
                    int remiseInt = (int)ligne.Remise_par_ligne;
                    DataGridViewComboBoxCell cellRem = (DataGridViewComboBoxCell)r.Cells["RemiseCol"];
                    if (!cellRem.Items.Contains(remiseInt))
                    {
                        cellRem.Items.Add(remiseInt);
                    }
                    cellRem.Value = remiseInt;

                    // E. Total HT (Calculé via ta propriété calculée dans Contenir)
                    r.Cells["TotalCol"].Value = ligne.MontantHT_AvecRemise.ToString("F2");
                }
            }
        }

        // Assumons que le bouton d'ajout de produit s'appelle btnAddProduit
        private void btnAddProduit_Click(object sender, EventArgs e)
        {
            // On permet l'ajout temporairement pour insérer une nouvelle ligne
            dgvModify.AllowUserToAddRows = true;

            // Ajout d'une nouvelle ligne vide
            // La méthode Add() renvoie l'index de la nouvelle ligne
            int rowIndex = dgvModify.Rows.Add();

            // Sélectionner la nouvelle ligne pour que l'utilisateur puisse la modifier immédiatement
            dgvModify.CurrentCell = dgvModify.Rows[rowIndex].Cells["ProduitCol"];

            // Mettre le DataGridView en mode édition sur la nouvelle cellule
            dgvModify.BeginEdit(true);

            // On désactive l'ajout pour éviter d'ajouter des lignes inutiles
            dgvModify.AllowUserToAddRows = false;
        }

        private void dgvModify_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // On vérifie que le clic n'est pas sur l'entête (-1) et qu'il est sur la colonne "DeleteCol"
            if (e.RowIndex >= 0 && dgvModify.Columns[e.ColumnIndex].Name == "DeleteCol")
            {  
                    dgvModify.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnAddDevis_Click(object sender, EventArgs e)
        {

        }

        private void pnlDevis_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
