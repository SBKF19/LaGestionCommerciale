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


            // --- 3. CHARGEMENT DES COMBO BOX STATUT ET CLIENT ---
            cmbStatut.DataSource = GestionDevis.GetStatuts();
            cmbStatut.DisplayMember = "Nom_statut";
            cmbStatut.ValueMember = "IdStatut";

            cmbClient.DataSource = GestionClients.GetClients();
            cmbClient.DisplayMember = "NomClient";
            cmbClient.ValueMember = "IdClient";

            // --- 4. CHARGEMENT DE LA LISTE DES DEVIS ---
            ChargerListeDevis();
            numRemiseGlobale.ValueChanged += GlobalRates_ValueChanged;
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
                // --- REMPLISSAGE DU TABLEAU DEVIS ---
                txtCode.Text = devis.IdDevis.ToString();
                dtpDevis.Value = devis.Date_devis;

                if (devis.Client != null) cmbClient.SelectedValue = devis.Client.IdClient;
                if (devis.Statut != null) cmbStatut.SelectedValue = devis.Statut.IdStatut;

                // --- REMPLISSAGE DES DÉTAILS ---
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

                    CalculerTotauxGlobaux();
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

            CalculerTotauxGlobaux();
        }

        // 1. Cette méthode force la validation dès qu'on clique sur la liste déroulante
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

            CalculerTotauxGlobaux();
        }

        private void CalculerTotauxGlobaux()
        {
            decimal totalLignesHT = 0;

            // 1. On additionne le montant HT de chaque ligne
            foreach (DataGridViewRow row in dgvModify.Rows)
            {
                if (row.Cells["TotalCol"].Value != null)
                {
                    decimal valLigne = 0;
                    // On convertit le texte "100,00" en chiffre
                    decimal.TryParse(row.Cells["TotalCol"].Value.ToString(), out valLigne);
                    totalLignesHT += valLigne;
                }
            }

            // 2. Gestion de la Remise GLOBALE (NumericUpDown)
            // On garde .Value car c'est surement encore un NumericUpDown
            decimal tauxRemiseGlobal = numRemiseGlobale.Value;
            decimal montantRemiseGlobal = totalLignesHT * (tauxRemiseGlobal / 100);
            decimal totalHTNet = totalLignesHT - montantRemiseGlobal;

            // 3. Gestion de la TVA (TextBox - FIX)
            decimal tauxTVA = 0;
            // On essaie de convertir le texte en chiffre. Si le texte est vide ou invalide, ça restera 0.
            decimal.TryParse(numTVA.Text, out tauxTVA);

            decimal montantTVA = totalHTNet * (tauxTVA / 100);

            // 4. Calcul TTC
            decimal totalTTC = totalHTNet + montantTVA;

            // 5. Affichage dans les TextBox du bas
            // Remplacez les noms ci-dessous par les noms réels de vos TextBox
            txtHT.Text = totalHTNet.ToString("F2");
            txtMontantTVA.Text = montantTVA.ToString("F2");
            txtTTC.Text = totalTTC.ToString("F2");
        }

        private void GlobalRates_ValueChanged(object sender, EventArgs e)
        {
            CalculerTotauxGlobaux();
        }

        private void pnlDevis_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dgvModify_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false; // "Ne plante pas"
            e.Cancel = false;         // "Garde la valeur même si tu penses qu'elle est fausse"
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            // --- 1. VALIDATIONS PRÉLIMINAIRES ---

            // A. Vérifier qu'un devis est sélectionné
            if (dgvDevis.CurrentRow == null || dgvDevis.CurrentRow.Tag == null)
            {
                MessageBox.Show("Veuillez sélectionner un devis à modifier.");
                return;
            }

            // B. Vérifier Client et Statut
            if (cmbClient.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.");
                return;
            }
            if (cmbStatut.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un statut.");
                return;
            }

            // C. Vérifier qu'il y a au moins une ligne de produit
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

            // D. Vérifier les Quantités et les Doublons
            List<int> produitsVerif = new List<int>();

            foreach (DataGridViewRow row in dgvModify.Rows)
            {
                if (row.Cells["ProduitCol"].Value == null) continue;

                int idProd = (int)row.Cells["ProduitCol"].Value;

                // 1. Check Doublon
                if (produitsVerif.Contains(idProd))
                {
                    MessageBox.Show($"Le produit (ID: {idProd}) est présent plusieurs fois. Veuillez regrouper les lignes.");
                    return;
                }
                produitsVerif.Add(idProd);

                // 2. Check Quantité
                int qteVerif = 0;
                if (row.Cells["QuantiteCol"].Value != null)
                    int.TryParse(row.Cells["QuantiteCol"].Value.ToString(), out qteVerif);

                if (qteVerif <= 0)
                {
                    MessageBox.Show($"La quantité pour le produit (ID: {idProd}) doit être supérieure à 0.");
                    return;
                }
            }

            // --- FIN DES VALIDATIONS, DÉBUT DU TRAITEMENT ---

            Devis devisOriginal = (Devis)dgvDevis.CurrentRow.Tag;
            int idDevis = devisOriginal.IdDevis;

            // 2. Mise à jour de l'entête du devis
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

            // Attention : Assurez-vous d'avoir le constructeur vide dans BO.Client ou utilisez le constructeur complet
            Client c = new Client();
            c.IdClient = (int)cmbClient.SelectedValue;
            devisModif.Client = c;

            Statut s = new Statut((int)cmbStatut.SelectedValue, cmbStatut.Text);
            devisModif.Statut = s;

            // Mise à jour SQL de l'entête
            GestionDevis.ModifierDevis(devisModif);

            // 3. Gestion des lignes (Ajout / Modif / Suppression)
            List<Contenir> lignesBD = GestionDevis.GetLignesDuDevis(idDevis);
            List<int> produitsTraites = new List<int>();

            foreach (DataGridViewRow row in dgvModify.Rows)
            {
                if (row.Cells["ProduitCol"].Value == null) continue;

                int idProduit = (int)row.Cells["ProduitCol"].Value;
                int qte = int.Parse(row.Cells["QuantiteCol"].Value.ToString());
                float remise = float.Parse(row.Cells["RemiseCol"].Value.ToString());

                ProduitBO p = new ProduitBO(idProduit, "", null, 0);
                Contenir ligne = new Contenir(p, devisModif, qte, remise);

                if (lignesBD.Any(x => x.ProduitBO.Code == idProduit))
                {
                    // Le produit existait déjà -> UPDATE
                    GestionDevis.ModifierLigneContenir(ligne);
                }
                else
                {
                    // Le produit est nouveau -> INSERT
                    GestionDevis.AjouterLigneContenir(ligne);
                }

                produitsTraites.Add(idProduit);
            }

            // 4. Suppression des lignes qui ne sont plus dans la grille
            foreach (Contenir ligneOld in lignesBD)
            {
                if (!produitsTraites.Contains(ligneOld.ProduitBO.Code))
                {
                    GestionDevis.SupprimerLigneContenir(ligneOld.ProduitBO.Code, idDevis);
                }
            }

            // 5. Rafraichissement
            ChargerListeDevis();

            // Resélectionner la ligne modifiée
            foreach (DataGridViewRow row in dgvDevis.Rows)
            {
                if (((Devis)row.Tag).IdDevis == idDevis)
                {
                    row.Selected = true;
                    dgvDevis.CurrentCell = row.Cells[0];
                    break;
                }
            }

            MessageBox.Show("Devis modifié avec succès !");
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvDevis.CurrentRow == null || dgvDevis.CurrentRow.Tag == null)
            {
                MessageBox.Show("Veuillez sélectionner un devis à supprimer.");
                return;
            }

            Devis devisASupprimer = (Devis)dgvDevis.CurrentRow.Tag;

            DialogResult reponse = MessageBox.Show(
                $"Voulez-vous vraiment supprimer le devis N° {devisASupprimer.IdDevis} ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (reponse == DialogResult.Yes)
            {
                List<Contenir> lignes = GestionDevis.GetLignesDuDevis(devisASupprimer.IdDevis);
                foreach (var ligne in lignes)
                {
                    GestionDevis.SupprimerLigneContenir(ligne.ProduitBO.Code, devisASupprimer.IdDevis);
                }

                GestionDevis.SupprimerDevis(devisASupprimer.IdDevis);

                ChargerListeDevis();

                // Vider les champs si plus aucun devis
                if (dgvDevis.Rows.Count == 0)
                {
                    dgvModify.Rows.Clear();
                    txtCode.Clear();
                    txtHT.Clear();
                    txtTTC.Clear();
                }
            }
        }
    }
}