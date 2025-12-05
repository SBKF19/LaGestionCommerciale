using BLL;
using BO;
using GUI;
using System;
using System.Collections.Generic;
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
        public object ContenirDAO { get; private set; }

        public FrmDevis()
        {
            InitializeComponent();
        }

        // Méthode exécutée au chargement du formulaire pour initialiser les composants et configurer les colonnes du DataGridView.
        // Méthode exécutée au chargement du formulaire pour initialiser les composants et configurer les colonnes du DataGridView.
        private void FrmDevis_Load(object sender, EventArgs e)
        {
            var chset = ConfigurationManager.ConnectionStrings["gestion_commerciale"];
            if (chset == null)
            {
                MessageBox.Show("Chaîne de connexion introuvable !");
                return;
            }
            GestionDevis.SetchaineConnexion(chset);

            dgvModify.CellValueChanged += dgvModify_CellValueChanged;
            dgvModify.CurrentCellDirtyStateChanged += dgvModify_CurrentCellDirtyStateChanged;

            dgvModify.AllowUserToAddRows = false;
            dgvModify.AutoGenerateColumns = false;
            dgvModify.Columns.Clear();

            dgvModify.DataError += dgvModify_DataError;

            DataGridViewComboBoxColumn colProd = new DataGridViewComboBoxColumn();
            colProd.HeaderText = "Produit";
            colProd.Name = "ProduitCol";
            colProd.DataSource = GestionProduits.GetProduits();
            colProd.DisplayMember = "Libelle";
            colProd.ValueMember = "Code";
            colProd.Width = 230;
            dgvModify.Columns.Add(colProd);

            DataGridViewTextBoxColumn colCat = new DataGridViewTextBoxColumn();
            colCat.HeaderText = "Catégorie";
            colCat.Name = "CatCol";
            colCat.ReadOnly = true;
            dgvModify.Columns.Add(colCat);

            DataGridViewTextBoxColumn colPrix = new DataGridViewTextBoxColumn();
            colPrix.HeaderText = "Prix U. HT";
            colPrix.Name = "PrixCol";
            colPrix.ReadOnly = true;
            dgvModify.Columns.Add(colPrix);

            DataGridViewComboBoxColumn colQte = new DataGridViewComboBoxColumn();
            colQte.HeaderText = "Qté";
            colQte.Name = "QuantiteCol";
            for (int i = 1; i <= 999; i++) colQte.Items.Add(i.ToString());
            dgvModify.Columns.Add(colQte);

            DataGridViewComboBoxColumn colRem = new DataGridViewComboBoxColumn();
            colRem.HeaderText = "Rem.%";
            colRem.Name = "RemiseCol";
            for (int i = 0; i <= 100; i++) colRem.Items.Add(i.ToString());
            dgvModify.Columns.Add(colRem);

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.HeaderText = "Total HT";
            colTotal.Name = "TotalCol";
            colTotal.ReadOnly = true;
            dgvModify.Columns.Add(colTotal);

            // --- CORRECTION ICI ---
            DataGridViewTextBoxColumn colMontantRem = new DataGridViewTextBoxColumn();
            colMontantRem.HeaderText = "Montant Rem";
            colMontantRem.Name = "MontantRemCol"; // J'ai donné un nom précis
            colMontantRem.ReadOnly = true;
            dgvModify.Columns.Add(colMontantRem);
            // ----------------------

            DataGridViewButtonColumn colDel = new DataGridViewButtonColumn();
            colDel.HeaderText = "Sup.";
            colDel.Name = "DeleteCol";
            colDel.Text = "X";
            colDel.UseColumnTextForButtonValue = true;
            dgvModify.Columns.Add(colDel);

            cmbStatut.DataSource = GestionDevis.GetStatuts();
            cmbStatut.DisplayMember = "Nom_statut";
            cmbStatut.ValueMember = "IdStatut";

            cmbClient.DataSource = GestionClients.GetClients();
            cmbClient.DisplayMember = "NomClient";
            cmbClient.ValueMember = "IdClient";

            ChargerListeDevis();
            numRemiseGlobale.ValueChanged += GlobalRates_ValueChanged;
        }

        // Récupère la liste des devis depuis la base de données et remplit la grille de sélection des devis.
        private void ChargerListeDevis(int idSelection = -1)
        {
            List<Devis> lesDevis = GestionDevis.GetDevis();

            // On désactive l'event pour éviter de déclencher SelectionChanged pendant la construction
            dgvDevis.SelectionChanged -= dgvDevis_SelectionChanged;

            dgvDevis.Rows.Clear();
            dgvDevis.ReadOnly = true;
            dgvDevis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevis.AllowUserToAddRows = false;

            int indexRowSelection = 0; // Par défaut, on sélectionnera la première ligne (0)

            foreach (Devis devis in lesDevis)
            {
                // On ajoute la ligne et on récupère son index
                int index = dgvDevis.Rows.Add(
                    devis.IdDevis,
                    devis.Client.NomClient,
                    devis.Date_devis,
                    devis.Montant_HT_devis
                );

                // On cache l'objet complet dans le Tag
                dgvDevis.Rows[index].Tag = devis;

                // SI l'ID du devis en cours correspond à celui qu'on veut sélectionner
                if (idSelection != -1 && devis.IdDevis == idSelection)
                {
                    indexRowSelection = index;
                }
            }

            // On réactive l'event
            dgvDevis.SelectionChanged += dgvDevis_SelectionChanged;

            // Gestion de la sélection finale
            if (dgvDevis.Rows.Count > 0)
            {
                dgvDevis.ClearSelection();

                // On sélectionne la ligne trouvée (ou la 0 par défaut)
                dgvDevis.Rows[indexRowSelection].Selected = true;

                // On place la cellule active dessus
                dgvDevis.CurrentCell = dgvDevis.Rows[indexRowSelection].Cells[0];

                // IMPORTANT : On scroll visuellement jusqu'à cette ligne pour qu'elle soit visible
                dgvDevis.FirstDisplayedScrollingRowIndex = indexRowSelection;

                // On force le remplissage des champs de droite
                RemplirChampsDepuisLigne(indexRowSelection);
            }
        }

        // Gère l'événement de changement de sélection dans la liste des devis pour afficher les détails du devis sélectionné.
        private void dgvDevis_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevis.CurrentRow != null)
            {
                RemplirChampsDepuisLigne(dgvDevis.CurrentRow.Index);
            }
        }

        // Remplit les champs de détails et la grille de modification avec les informations du devis situé à l'index spécifié.
        // Remplit les champs de détails et la grille de modification avec les informations du devis situé à l'index spécifié.
        private void RemplirChampsDepuisLigne(int index)
        {
            DataGridViewRow row = dgvDevis.Rows[index];

            if (row.Tag is Devis devis)
            {
                // ... (Début du code inchangé : txtCode, dtpDevis, Client, etc.) ...
                txtCode.Text = devis.IdDevis.ToString();
                dtpDevis.Value = devis.Date_devis;
                if (devis.Client != null) cmbClient.SelectedValue = devis.Client.IdClient;
                if (devis.Statut != null) cmbStatut.SelectedValue = devis.Statut.IdStatut;

                if (devis.Client != null)
                {
                    txtPhone.Text = devis.Client.NumPhoneClient;
                    txtMail.Text = devis.Client.MailClient;
                    txtFacture.Text = $"{devis.Client.NumRueFacture} {devis.Client.NomRueFacture}, {devis.Client.CodePostalFacture} {devis.Client.VilleFacture}";
                    txtLivre.Text = $"{devis.Client.NumRueLivraison} {devis.Client.NomRueLivraison}, {devis.Client.CodePostalLivraison} {devis.Client.VilleLivraison}";
                }

                try
                {
                    numTVA.Text = devis.TVA_devis.ToString();
                    numRemiseGlobale.Value = (decimal)devis.Taux_remise_global_devis;
                }
                catch { numTVA.Text = "0"; numRemiseGlobale.Value = 0; }
                // ... (Fin partie entête) ...

                dgvModify.Rows.Clear();
                List<Contenir> lesLignes = GestionDevis.GetLignesDuDevis(devis.IdDevis);

                dgvModify.CellValueChanged -= dgvModify_CellValueChanged;

                foreach (Contenir ligne in lesLignes)
                {
                    int i = dgvModify.Rows.Add();
                    DataGridViewRow r = dgvModify.Rows[i];

                    r.Cells["ProduitCol"].Value = ligne.ProduitBO.Code;

                    if (ligne.ProduitBO.Categorie != null)
                        r.Cells["CatCol"].Value = ligne.ProduitBO.Categorie.NomCategorie;
                    r.Cells["PrixCol"].Value = ligne.ProduitBO.Prix;

                    string qteStr = ligne.Quantite_commandee.ToString();
                    DataGridViewComboBoxCell cellQte = (DataGridViewComboBoxCell)r.Cells["QuantiteCol"];
                    if (!cellQte.Items.Contains(qteStr)) cellQte.Items.Add(qteStr);
                    cellQte.Value = qteStr;

                    string remStr = ((int)ligne.Remise_par_ligne).ToString();
                    DataGridViewComboBoxCell cellRem = (DataGridViewComboBoxCell)r.Cells["RemiseCol"];
                    if (!cellRem.Items.Contains(remStr)) cellRem.Items.Add(remStr);
                    cellRem.Value = remStr;

                    // --- NOUVEAUX CALCULS ---
                    decimal prixTotalBrut = (decimal)ligne.ProduitBO.Prix * ligne.Quantite_commandee;
                    decimal montantRemise = prixTotalBrut * ((decimal)ligne.Remise_par_ligne / 100); // Cast decimal important

                    r.Cells["MontantRemCol"].Value = montantRemise.ToString("F2");
                    // La colonne TotalCol affiche le BRUT (sans remise)
                    r.Cells["TotalCol"].Value = prixTotalBrut.ToString("F2");
                    // ------------------------

                    dgvModify.CellValueChanged += dgvModify_CellValueChanged;
                    CalculerTotauxGlobaux();
                }
            }
        }

        // Ajoute une nouvelle ligne dans la grille de modification pour permettre l'ajout d'un produit au devis.
        private void btnAddProduit_Click(object sender, EventArgs e)
        {
            dgvModify.AllowUserToAddRows = true;
            int rowIndex = dgvModify.Rows.Add();
            DataGridViewRow newRow = dgvModify.Rows[rowIndex];

            newRow.Cells["QuantiteCol"].Value = "1";
            newRow.Cells["RemiseCol"].Value = "0";

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

        // Gère les suppressions de lignes produits si le bouton de suppression est cliqué.
        private void dgvModify_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvModify.Columns[e.ColumnIndex].Name == "DeleteCol")
            {
                dgvModify.Rows.RemoveAt(e.RowIndex);
            }

            CalculerTotauxGlobaux();
        }

        // Force la validation immédiate des modifications dans la grille pour déclencher les événements de changement de valeur.
        private void dgvModify_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvModify.IsCurrentCellDirty)
            {
                dgvModify.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Détecte les modifications de valeurs dans les cellules (Quantité, Remise, Produit) et lance le recalcul de la ligne.
        private void dgvModify_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvModify.Columns[e.ColumnIndex].Name;

            // --- CORRECTION : Mise à jour des infos produit si on change le produit ---
            if (colName == "ProduitCol")
            {
                DataGridViewRow row = dgvModify.Rows[e.RowIndex];

                // On récupère l'ID du produit sélectionné
                if (row.Cells["ProduitCol"].Value != null)
                {
                    int idProduit;
                    if (int.TryParse(row.Cells["ProduitCol"].Value.ToString(), out idProduit))
                    {
                        // On récupère la liste source depuis la colonne pour éviter de rappeler la BDD
                        var colProd = (DataGridViewComboBoxColumn)dgvModify.Columns["ProduitCol"];
                        List<ProduitBO> lesProduits = (List<ProduitBO>)colProd.DataSource;

                        // On cherche le produit correspondant
                        ProduitBO leProduit = lesProduits.Find(p => p.Code == idProduit);

                        if (leProduit != null)
                        {
                            // On met à jour les cellules Prix et Catégorie
                            row.Cells["PrixCol"].Value = leProduit.Prix;

                            if (leProduit.Categorie != null)
                                row.Cells["CatCol"].Value = leProduit.Categorie.NomCategorie;
                            else
                                row.Cells["CatCol"].Value = "";
                        }
                    }
                }
            }
            // --------------------------------------------------------------------------

            if (colName == "QuantiteCol" || colName == "RemiseCol" || colName == "ProduitCol")
            {
                CalculerTotalLigne(e.RowIndex);
            }
        }

        // Calcule le montant total HT d'une ligne spécifique en fonction du prix, de la quantité et de la remise unitaire.
        private void CalculerTotalLigne(int rowIndex)
        {
            DataGridViewRow row = dgvModify.Rows[rowIndex];

            decimal prix = 0;
            if (row.Cells["PrixCol"].Value != null)
                decimal.TryParse(row.Cells["PrixCol"].Value.ToString(), out prix);

            int qte = 0;
            if (row.Cells["QuantiteCol"].Value != null)
                int.TryParse(row.Cells["QuantiteCol"].Value.ToString(), out qte);

            decimal remisePourcentage = 0;
            if (row.Cells["RemiseCol"].Value != null)
                decimal.TryParse(row.Cells["RemiseCol"].Value.ToString(), out remisePourcentage);

            // Calcul du Total Brut (Prix * Qté) SANS la remise
            decimal totalBrut = prix * qte;

            // Calcul du montant de la remise
            decimal montantRemise = totalBrut * (remisePourcentage / 100);

            // Affichage : TotalCol contient maintenant le Brut
            row.Cells["MontantRemCol"].Value = montantRemise.ToString("F2");
            row.Cells["TotalCol"].Value = totalBrut.ToString("F2");

            CalculerTotauxGlobaux();
        }

        // Calcule les totaux globaux du devis (Total HT, TVA, TTC) en incluant la remise globale.
        // Calcule les totaux globaux : Brut, Net Commercial, TVA et TTC
        private void CalculerTotauxGlobaux()
        {
            decimal totalBrutGlobal = 0;      // Somme des (Prix * Qté) sans remises
            decimal totalRemiseLignes = 0;    // Somme des remises par ligne

            foreach (DataGridViewRow row in dgvModify.Rows)
            {
                // 1. Récupération du Total Brut (Colonne TotalCol contient maintenant le brut)
                if (row.Cells["TotalCol"].Value != null)
                {
                    decimal valLigne = 0;
                    decimal.TryParse(row.Cells["TotalCol"].Value.ToString(), out valLigne);
                    totalBrutGlobal += valLigne;
                }

                // 2. Récupération du Montant Remise Ligne
                if (row.Cells["MontantRemCol"].Value != null)
                {
                    decimal valRem = 0;
                    decimal.TryParse(row.Cells["MontantRemCol"].Value.ToString(), out valRem);
                    totalRemiseLignes += valRem;
                }
            }

            // --- CALCULS ---

            // A. Calculs des remises
            decimal tauxRemiseGlobal = numRemiseGlobale.Value;

            // Le total après avoir enlevé les remises ligne par ligne
            decimal totalApresRemiseLignes = totalBrutGlobal - totalRemiseLignes;

            // Calcul de la remise globale sur le montant restant
            decimal montantRemiseGlobal = totalApresRemiseLignes * (tauxRemiseGlobal / 100);

            // Total HT Net (Le montant final HT que le client doit payer)
            decimal totalHTNetFinancier = totalApresRemiseLignes - montantRemiseGlobal;

            // B. Calcul TVA (Sur le BRUT GLOBAL comme demandé précédemment)
            decimal tauxTVA = 0;
            decimal.TryParse(numTVA.Text, out tauxTVA);

            decimal montantTVA = totalBrutGlobal * (tauxTVA / 100);

            // C. Calcul TTC
            decimal totalTTC = totalHTNetFinancier + montantTVA;

            // --- AFFICHAGE ---

            // 1. Le Total HT sans aucune remise (Brut) -> C'est ici votre nouveau champ
            txtNonRemHt.Text = totalBrutGlobal.ToString("F2");

            // 2. Le Total HT Net (remises déduites)
            txtHT.Text = totalHTNetFinancier.ToString("F2");

            // 3. La TVA
            txtMontantTVA.Text = montantTVA.ToString("F2");

            // 4. Le TTC
            txtTTC.Text = totalTTC.ToString("F2");
        }

        // Recalcule les totaux globaux lorsque la remise globale ou le taux de TVA est modifié.
        private void GlobalRates_ValueChanged(object sender, EventArgs e)
        {
            CalculerTotauxGlobaux();
        }

        // Gère les erreurs de données dans le DataGridView pour éviter les plantages lors de problèmes d'affichage ou de saisie.
        private void dgvModify_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = false;
        }



        //----------------------------------------------------------Partie Modification et suppression-----------------------------------------------------

        private void btnModifier_Click(object sender, EventArgs e)
        {
            // Vérifie qu'un devis est sélectionné dans la liste
            if (dgvDevis.CurrentRow == null || dgvDevis.CurrentRow.Tag == null)
            {
                MessageBox.Show("Veuillez sélectionner un devis à modifier.");
                return;
            }

            // Vérifie qu'un client a été choisi
            if (cmbClient.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.");
                return;
            }

            // Vérifie qu'un statut a été choisi
            if (cmbStatut.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un statut.");
                return;
            }

            // Vérifie qu'au moins un produit est présent dans la grille
            bool aDesProduits = false;
            foreach (DataGridViewRow row in dgvModify.Rows)
            {
                if (row.Cells["ProduitCol"].Value != null)
                {
                    aDesProduits = true;
                    break;
                }
            }

            if (!aDesProduits)
            {
                MessageBox.Show("Le devis doit contenir au moins un produit.");
                return;
            }

            // Vérifie qu'il n'y a pas de doublons et que les quantités sont valides
            List<int> produitsVerif = new List<int>();

            foreach (DataGridViewRow row in dgvModify.Rows)
            {
                if (row.Cells["ProduitCol"].Value == null) continue;

                int idProd = (int)row.Cells["ProduitCol"].Value;

                // Vérification d'un doublon de produit
                if (produitsVerif.Contains(idProd))
                {
                    MessageBox.Show($"Le produit (ID: {idProd}) est présent plusieurs fois. Veuillez regrouper les lignes.");
                    return;
                }
                produitsVerif.Add(idProd);

                // Vérification de la quantité
                int qteVerif = 0;
                if (row.Cells["QuantiteCol"].Value != null)
                    int.TryParse(row.Cells["QuantiteCol"].Value.ToString(), out qteVerif);

                if (qteVerif <= 0)
                {
                    MessageBox.Show($"La quantité pour le produit (ID: {idProd}) doit être supérieure à 0.");
                    return;
                }
            }

            // Récupération du devis sélectionné
            Devis devisOriginal = (Devis)dgvDevis.CurrentRow.Tag;
            int idDevis = devisOriginal.IdDevis;

            // Création d'un objet Devis avec les valeurs modifiées
            Devis devisModif = new Devis();
            devisModif.IdDevis = idDevis;
            devisModif.Date_devis = dtpDevis.Value;

            float tva = 0;
            float.TryParse(numTVA.Text, out tva);
            devisModif.TVA_devis = tva;

            devisModif.Taux_remise_global_devis = (float)numRemiseGlobale.Value;

            float montantHT = 0;
            float.TryParse(txtHT.Text, out montantHT);
            devisModif.Montant_HT_devis = montantHT;

            // Association du client choisi
            Client c = new Client();
            c.IdClient = (int)cmbClient.SelectedValue;
            devisModif.Client = c;

            // Association du statut choisi
            Statut s = new Statut((int)cmbStatut.SelectedValue, cmbStatut.Text);
            devisModif.Statut = s;

            // Mise à jour de l'entête du devis dans la base de données
            GestionDevis.ModifierDevis(devisModif);

            // Récupération des lignes actuelles du devis dans la base
            List<Contenir> lignesBD = GestionDevis.GetLignesDuDevis(idDevis);
            List<int> produitsTraites = new List<int>();

            // Parcourt les lignes affichées dans la grille de modification
            foreach (DataGridViewRow row in dgvModify.Rows)
            {
                if (row.Cells["ProduitCol"].Value == null) continue;

                int idProduit = (int)row.Cells["ProduitCol"].Value;
                int qte = int.Parse(row.Cells["QuantiteCol"].Value.ToString());
                float remise = float.Parse(row.Cells["RemiseCol"].Value.ToString());

                // Création de l'objet Contenir associé à la ligne
                ProduitBO p = new ProduitBO(idProduit, "", null, 0);
                Contenir ligne = new Contenir(p, devisModif, qte, remise);

                // Si le produit existait déjà → mise à jour
                if (lignesBD.Any(x => x.ProduitBO.Code == idProduit))
                {
                    GestionDevis.ModifierLigneContenir(ligne);
                }
                else
                {
                    // Sinon → ajout d'une nouvelle ligne
                    GestionDevis.AjouterLigneContenir(ligne);
                }

                produitsTraites.Add(idProduit);
            }

            // Suppression des lignes qui ont été retirées dans la grille
            foreach (Contenir ligneOld in lignesBD)
            {
                if (!produitsTraites.Contains(ligneOld.ProduitBO.Code))
                {
                    GestionDevis.SupprimerLigneContenir(ligneOld.ProduitBO.Code, idDevis);
                }
            }

            // Recharge la liste et resélectionne automatiquement le devis modifié
            ChargerListeDevis(idDevis);

            MessageBox.Show("Devis modifié avec succès !");
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // Vérifie qu'un devis est sélectionné
            if (dgvDevis.CurrentRow == null || dgvDevis.CurrentRow.Tag == null)
            {
                MessageBox.Show("Veuillez sélectionner un devis à supprimer.");
                return;
            }

            // Récupère le devis sélectionné
            Devis devisASupprimer = (Devis)dgvDevis.CurrentRow.Tag;

            // Message de confirmation
            DialogResult reponse = MessageBox.Show(
                $"Voulez-vous vraiment supprimer le devis N° {devisASupprimer.IdDevis} ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (reponse == DialogResult.Yes)
            {
                // Supprime d'abord les lignes associées au devis
                List<Contenir> lignes = GestionDevis.GetLignesDuDevis(devisASupprimer.IdDevis);
                foreach (var ligne in lignes)
                {
                    GestionDevis.SupprimerLigneContenir(ligne.ProduitBO.Code, devisASupprimer.IdDevis);
                }

                // Supprime ensuite le devis lui-même
                GestionDevis.SupprimerDevis(devisASupprimer.IdDevis);

                // Recharge la liste des devis
                ChargerListeDevis();

                // Si la liste est vide, on efface les champs
                if (dgvDevis.Rows.Count == 0)
                {
                    dgvModify.Rows.Clear();
                    txtCode.Clear();
                    txtHT.Clear();
                    txtTTC.Clear();
                }
            }
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmClient().Show();
            this.Hide();
        }

        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmProduit().Show();
            this.Hide();
        }

        private void devisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}