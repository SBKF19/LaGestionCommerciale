using BLL;
using BO;
using GUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using UtilisateursBLL;

namespace LaGestionCommerciale
{
    public partial class FrmDevis : Form
    {
        public FrmDevis()
        {
            InitializeComponent();

            var chset = ConfigurationManager.ConnectionStrings["gestion_commerciale"];
            if (chset == null)
            {
                MessageBox.Show("Chaîne de connexion introuvable !");
                return;
            }
            GestionClients.SetchaineConnexion(chset);
        }

        private void FrmDevis_Load(object sender, EventArgs e)
        {
            dgvModify.CellValueChanged += dgvModify_CellValueChanged; // Pour recalculer
            dgvModify.CurrentCellDirtyStateChanged += dgvModify_CurrentCellDirtyStateChanged; // Pour valider le clic immédiatement

            dgvModify.AllowUserToAddRows = false;
            dgvModify.AutoGenerateColumns = false;
            dgvModify.Columns.Clear(); // On efface tout ce qui vient du Designer pour recréer proprement

            dgvModify.DataError += dgvModify_DataError;

            // --- 2. CRÉATION DES COLONNES PAR LE CODE ---

            // A. Colonne PRODUIT (ComboBox)
            DataGridViewComboBoxColumn colProd = new DataGridViewComboBoxColumn();
            colProd.HeaderText = "Produit";
            colProd.Name = "ProduitCol";
            colProd.DataSource = GestionProduits.GetProduits();
            colProd.DisplayMember = "Libelle";
            colProd.ValueMember = "Code";
            colProd.Width = 330;
            dgvModify.Columns.Add(colProd);
            

            // B. Colonne CATÉGORIE (Texte Lecture Seule)
            DataGridViewTextBoxColumn colCat = new DataGridViewTextBoxColumn();
            colCat.HeaderText = "Catégorie";
            colCat.Name = "CatCol";
            colCat.ReadOnly = true;
            dgvModify.Columns.Add(colCat);

            // C. Colonne PRIX (Texte Lecture Seule)
            DataGridViewTextBoxColumn colPrix = new DataGridViewTextBoxColumn();
            colPrix.HeaderText = "Prix U. HT";
            colPrix.Name = "PrixCol";
            colPrix.ReadOnly = true;
            dgvModify.Columns.Add(colPrix);

            // D. Colonne QUANTITÉ (ComboBox - Remplie en String pour sécurité)
            DataGridViewComboBoxColumn colQte = new DataGridViewComboBoxColumn();
            colQte.HeaderText = "Qté";
            colQte.Name = "QuantiteCol";
            for (int i = 1; i <= 100; i++) colQte.Items.Add(i.ToString());
            dgvModify.Columns.Add(colQte);

            // E. Colonne REMISE (ComboBox - Remplie en String de 0 à 100)
            DataGridViewComboBoxColumn colRem = new DataGridViewComboBoxColumn();
            colRem.HeaderText = "Rem.%";
            colRem.Name = "RemiseCol";

            // Boucle automatique de 0 à 100 (plus simple que de tout écrire)
            for (int i = 0; i <= 100; i++)
            {
                colRem.Items.Add(i.ToString());
            }
            dgvModify.Columns.Add(colRem);

            // F. Colonne TOTAL (Texte Lecture Seule)
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.HeaderText = "Total HT";
            colTotal.Name = "TotalCol";
            colTotal.ReadOnly = true;
            dgvModify.Columns.Add(colTotal);

            // G. Colonne SUPPRIMER (Bouton)
            DataGridViewButtonColumn colDel = new DataGridViewButtonColumn();
            colDel.HeaderText = "Sup.";
            colDel.Name = "DeleteCol";
            colDel.Text = "X";
            colDel.UseColumnTextForButtonValue = true;
            dgvModify.Columns.Add(colDel);


            // --- 3. CHARGEMENT DES DONNÉES EXTERNES ---
            cmbStatut.DataSource = GestionDevis.GetStatuts();
            cmbStatut.DisplayMember = "Nom_statut";
            cmbStatut.ValueMember = "IdStatut";

            cmbClient.DataSource = GestionClients.GetClients();
            cmbClient.DisplayMember = "NomClient";
            cmbClient.ValueMember = "IdClient";

            // --- 4. CHARGEMENT DE LA LISTE DES DEVIS ---
            ChargerListeDevis();
        }

        private void dgvModify_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false; // "Ne plante pas"
            e.Cancel = false;         // "Garde la valeur même si tu penses qu'elle est fausse"
        }

        private void ChargerListeDevis()
        {
            List<Devis> lesDevis = GestionDevis.GetDevis();

            // On désactive l'event pour le chargement
            dgvDevis.SelectionChanged -= dgvDevis_SelectionChanged;

            dgvDevis.Rows.Clear();
            dgvDevis.ReadOnly = true;
            dgvDevis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevis.AllowUserToAddRows = false;

            // Dans FrmDevis_Load, remplacez votre boucle foreach par celle-ci :
            foreach (Devis devis in lesDevis)
            {
                // On ajoute la ligne et on récupère son index
                int index = dgvDevis.Rows.Add(
                    devis.IdDevis,
                    devis.Client.NomClient,
                    devis.Date_devis,
                    devis.Montant_HT_devis
                );

                // IMPORTANT : On cache l'objet complet dans la propriété Tag de la ligne
                dgvDevis.Rows[index].Tag = devis;
            }

            // Gestion de la sélection initiale
            if (dgvDevis.Rows.Count > 0)
            {
                dgvDevis.Rows[0].Selected = true;
                RemplirChampsDepuisLigne(0);
            }

            dgvDevis.SelectionChanged += dgvDevis_SelectionChanged;
        }

        private void dgvDevis_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevis.CurrentRow != null)
            {
                RemplirChampsDepuisLigne(dgvDevis.CurrentRow.Index);
            }
        }

        private void RemplirChampsDepuisLigne(int index)
        {
            DataGridViewRow row = dgvDevis.Rows[index];

            if (row.Tag is Devis devis)
            {
                // Infos Générales
                txtCode.Text = devis.IdDevis.ToString();
                dtpDevis.Value = devis.Date_devis;

                if (devis.Client != null) cmbClient.SelectedValue = devis.Client.IdClient;
                if (devis.Statut != null) cmbStatut.SelectedValue = devis.Statut.IdStatut;

                // Infos Client
                if (devis.Client != null)
                {
                    txtPhone.Text = devis.Client.NumPhoneClient;
                    txtMail.Text = devis.Client.MailClient;
                    txtFacture.Text = $"{devis.Client.NumRueFacture} {devis.Client.NomRueFacture}, {devis.Client.CodePostalFacture} {devis.Client.VilleFacture}";
                    txtLivre.Text = $"{devis.Client.NumRueLivraison} {devis.Client.NomRueLivraison}, {devis.Client.CodePostalLivraison} {devis.Client.VilleLivraison}";
                }

                try
                {
                    numTVA.Value = (decimal)devis.TVA_devis;
                    numRemiseGlobale.Value = (decimal)devis.Taux_remise_global_devis;
                }
                catch { numTVA.Value = 0; numRemiseGlobale.Value = 0; }

                // --- REMPLISSAGE DU TABLEAU PRODUITS ---
                dgvModify.Rows.Clear();
                List<Contenir> lesLignes = GestionDevis.GetLignesDuDevis(devis.IdDevis);

                dgvModify.CellValueChanged -= dgvModify_CellValueChanged;
                foreach (Contenir ligne in lesLignes)
                {
                    int i = dgvModify.Rows.Add();
                    DataGridViewRow r = dgvModify.Rows[i];

                    // 1. Produit
                    r.Cells["ProduitCol"].Value = ligne.ProduitBO.Code;

                    // 2. Infos ReadOnly
                    if (ligne.ProduitBO.Categorie != null)
                        r.Cells["CatCol"].Value = ligne.ProduitBO.Categorie.NomCategorie;
                    r.Cells["PrixCol"].Value = ligne.ProduitBO.Prix;

                    // 3. QUANTITÉ (Sécurisée avec String)
                    string qteStr = ligne.Quantite_commandee.ToString();
                    DataGridViewComboBoxCell cellQte = (DataGridViewComboBoxCell)r.Cells["QuantiteCol"];
                    // Si la quantité (ex: 150) n'est pas dans la liste (1-100), on l'ajoute pour ne pas planter
                    if (!cellQte.Items.Contains(qteStr)) cellQte.Items.Add(qteStr);
                    cellQte.Value = qteStr;

                    // 4. REMISE (Sécurisée avec String)
                    string remStr = ((int)ligne.Remise_par_ligne).ToString();
                    DataGridViewComboBoxCell cellRem = (DataGridViewComboBoxCell)r.Cells["RemiseCol"];
                    // Si la remise n'est pas dans la liste standard, on l'ajoute
                    if (!cellRem.Items.Contains(remStr)) cellRem.Items.Add(remStr);
                    cellRem.Value = remStr;

                    // 5. Total
                    r.Cells["TotalCol"].Value = (ligne.ProduitBO.Prix * ligne.Quantite_commandee).ToString("F2");
                    dgvModify.CellValueChanged += dgvModify_CellValueChanged;
                }
            }
        }

        private void btnAddProduit_Click(object sender, EventArgs e)
        {
            dgvModify.AllowUserToAddRows = true;
            int rowIndex = dgvModify.Rows.Add();
            DataGridViewRow newRow = dgvModify.Rows[rowIndex];

            // --- VALEURS PAR DÉFAUT (En String pour éviter les erreurs ComboBox) ---
            newRow.Cells["QuantiteCol"].Value = "1";
            newRow.Cells["RemiseCol"].Value = "0";

            // Sélectionner le premier produit par défaut pour éviter une cellule vide
            var colProduit = (DataGridViewComboBoxColumn)dgvModify.Columns["ProduitCol"];
            if (colProduit.DataSource is List<ProduitBO> liste && liste.Count > 0)
            {
                newRow.Cells["ProduitCol"].Value = liste[0].Code;
                newRow.Cells["PrixCol"].Value = liste[0].Prix;
                if (liste[0].Categorie != null)
                    newRow.Cells["CatCol"].Value = liste[0].Categorie.NomCategorie;
            }

            dgvModify.CurrentCell = newRow.Cells["ProduitCol"];
            dgvModify.BeginEdit(true);
            dgvModify.AllowUserToAddRows = false;
        }

        private void dgvModify_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gestion du bouton Supprimer "X"
            if (e.RowIndex >= 0 && dgvModify.Columns[e.ColumnIndex].Name == "DeleteCol")
            {
                dgvModify.Rows.RemoveAt(e.RowIndex);
            }
        }

        // 1. Cette méthode force la validation dès qu'on clique sur la liste déroulante
        // (Sinon il faut cliquer ailleurs pour que le total change)
        private void dgvModify_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvModify.IsCurrentCellDirty)
            {
                dgvModify.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // 2. C'est ici que le calcul se fait en temps réel
        private void dgvModify_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // On ignore si c'est l'entête ou si la ligne est vide
            if (e.RowIndex < 0) return;

            string colName = dgvModify.Columns[e.ColumnIndex].Name;

            // On ne recalcule que si on touche à la Quantité, la Remise ou le Produit
            if (colName == "QuantiteCol" || colName == "RemiseCol" || colName == "ProduitCol")
            {
                CalculerTotalLigne(e.RowIndex);
            }
        }

        // 3. La logique mathématique isolée pour être propre
        private void CalculerTotalLigne(int rowIndex)
        {
            DataGridViewRow row = dgvModify.Rows[rowIndex];

            // --- A. Récupération des valeurs (Sécurisée) ---

            // Prix
            decimal prix = 0;
            if (row.Cells["PrixCol"].Value != null)
                decimal.TryParse(row.Cells["PrixCol"].Value.ToString(), out prix);

            // Quantité
            int qte = 0;
            if (row.Cells["QuantiteCol"].Value != null)
                int.TryParse(row.Cells["QuantiteCol"].Value.ToString(), out qte);

            // Remise (Si vous voulez l'inclure dans le calcul)
            decimal remise = 0;
            if (row.Cells["RemiseCol"].Value != null)
                decimal.TryParse(row.Cells["RemiseCol"].Value.ToString(), out remise);

            // --- B. Le Calcul ---

            // Formule simple (celle que vous avez montrée) :
            // decimal total = prix * qte; 

            // OU Formule avec Remise (Prix * Qté) - Remise% :
            decimal totalSansRemise = prix * qte;
            decimal montantRemise = totalSansRemise * (remise / 100);
            decimal total = totalSansRemise - montantRemise;

            // --- C. Affichage ---
            row.Cells["TotalCol"].Value = total.ToString("F2");
        }

        private void btnAddDevis_Click(object sender, EventArgs e)
        {
            // Logique d'ajout de devis ici
        }

        private void pnlDevis_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}