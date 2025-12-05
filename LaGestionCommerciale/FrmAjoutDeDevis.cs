using BLL;
using BO;
using System;
using System.ComponentModel;
using System.Configuration;
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

            // 1. Initialisation Connexion
            var chset = ConfigurationManager.ConnectionStrings["gestion_commerciale"];
            if (chset != null) GestionDevis.SetchaineConnexion(chset);
            else MessageBox.Show("Erreur critique : Chaîne de connexion introuvable !");

            // 2. Initialisation Objets
            devisCourant = new Devis();
            lignesBinding = new BindingList<Contenir>(devisCourant.Lignes);

            // 3. Configuration Affichage
            ConfiguerGrille();
            ChargerListes();

            // 4. Valeurs par défaut
            dtpDate.Value = DateTime.Now;
            nudTauxTVA.Value = 20;
        }

        private void ChargerListes()
        {
            try
            {
                // Clients
                cbClient.DataSource = GestionClients.GetClients();
                cbClient.DisplayMember = "NomClient";
                cbClient.ValueMember = "IdClient";
                cbClient.SelectedIndex = -1;

                // Statuts
                cbStatut.DataSource = GestionDevis.GetStatuts();
                cbStatut.DisplayMember = "Nom_statut";
                cbStatut.ValueMember = "IdStatut";
                if (cbStatut.Items.Count > 0) cbStatut.SelectedIndex = 0;

                // Produits
                cbProduit.DataSource = GestionProduits.GetProduits();
                cbProduit.DisplayMember = "Libelle";
                cbProduit.ValueMember = "Code";

                // Petite astuce pour afficher "Libelle (Code)" dans la liste déroulante
                cbProduit.Format += (s, e) => {
                    if (e.ListItem is ProduitBO p) e.Value = $"{p.Libelle} (Ref: {p.Code})";
                };

                cbProduit.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Erreur listes : " + ex.Message); }
        }

        private void ConfiguerGrille()
        {
            dgvLignes.AutoGenerateColumns = false;
            dgvLignes.DataSource = lignesBinding;
            dgvLignes.Columns.Clear();

            // NOTE : J'ai ajouté la propriété 'Name' pour identifier les colonnes dans CellFormatting

            // 1. Produit (Lecture seule)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProduit", // Important pour l'affichage
                HeaderText = "Produit",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 2. Code (Lecture seule)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCode", // Important pour l'affichage
                HeaderText = "Code",
                ReadOnly = true,
                Width = 60
            });

            // 3. Catégorie (Lecture seule)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategorie",
                HeaderText = "Catég.",
                ReadOnly = true,
                Width = 80
            });

            // 4. Prix Unitaire (Lecture seule)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "PU HT",
                DataPropertyName = "PrixUnitaire", // Propriété directe de 'Contenir', ça marche tout seul
                ReadOnly = true,
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            // 5. Quantité (Editable - Fond Jaune)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Qté",
                DataPropertyName = "Quantite_commandee",
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightYellow, Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. Remise (Editable - Fond Jaune)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Rem.%",
                DataPropertyName = "Remise_par_ligne",
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightYellow, Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 7. Total HT (Calculé)
            dgvLignes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total HT",
                DataPropertyName = "MontantHT_AvecRemise",
                ReadOnly = true,
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Font = new Font("Segoe UI", 9, FontStyle.Bold) }
            });
        }

        // C'EST ICI QUE LA MAGIE DE L'AFFICHAGE OPÈRE
        private void dgvLignes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // On récupère l'objet de la ligne en cours
            var ligne = dgvLignes.Rows[e.RowIndex].DataBoundItem as Contenir;
            if (ligne == null || ligne.ProduitBO == null) return;

            // Affichage du Libellé Produit
            if (dgvLignes.Columns[e.ColumnIndex].Name == "colProduit")
            {
                e.Value = ligne.ProduitBO.Libelle;
            }
            // Affichage du Code
            else if (dgvLignes.Columns[e.ColumnIndex].Name == "colCode")
            {
                e.Value = ligne.ProduitBO.Code;
            }
            // Affichage de la Catégorie
            else if (dgvLignes.Columns[e.ColumnIndex].Name == "colCategorie")
            {
                e.Value = ligne.ProduitBO.Categorie.NomCategorie;
            }
        }

        private void btnAjouterLigne_Click(object sender, EventArgs e)
        {
            if (cbProduit.SelectedItem is ProduitBO p)
            {
                // Vérif doublon
                foreach (var l in lignesBinding)
                {
                    if (l.ProduitBO.Code == p.Code)
                    {
                        MessageBox.Show("Produit déjà présent.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                lignesBinding.Add(new Contenir(p, devisCourant, 1, 0));
                RecalculerTotaux();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un produit.");
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

        private void dgvLignes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Validation instantanée de la saisie utilisateur
            var ligne = lignesBinding[e.RowIndex];
            if (ligne.Quantite_commandee <= 0) ligne.Quantite_commandee = 1;
            if (ligne.Remise_par_ligne < 0) ligne.Remise_par_ligne = 0;

            dgvLignes.Refresh();
            RecalculerTotaux();
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClient.SelectedItem is Client c)
                lblClientInfos.Text = $"Fact: {c.NumRueFacture} {c.NomRueFacture}, {c.CodePostalFacture} {c.VilleFacture}\nLivr: {c.NumRueLivraison} {c.NomRueLivraison}, {c.CodePostalLivraison} {c.VilleLivraison}\nTél: {c.NumPhoneClient} | Email: {c.MailClient}";
        }

        private void nudTauxTVA_ValueChanged(object sender, EventArgs e) { RecalculerTotaux(); }

        // BOUTON VALIDER AVEC LES VALIDATIONS DEMANDÉES
        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validation des champs obligatoires
                if (cbClient.SelectedItem == null)
                    throw new Exception("Veuillez sélectionner un client.");

                if (cbStatut.SelectedItem == null)
                    throw new Exception("Veuillez sélectionner un statut.");

                // 2. Validation du contenu
                if (lignesBinding.Count == 0)
                    throw new Exception("Le devis est vide. Veuillez ajouter au moins un produit.");

                // 3. Validation des taux
                if (nudTauxTVA.Value < 0)
                    throw new Exception("Le taux de TVA ne peut pas être négatif.");

                if (nudTauxRemiseGlobale.Value < 0 || nudTauxRemiseGlobale.Value > 100)
                    throw new Exception("Le taux de remise global doit être compris entre 0 et 100.");

                // 4. Validation détaillée des lignes (quantités, stocks...)
                foreach (var ligne in lignesBinding)
                {
                    if (ligne.Quantite_commandee <= 0)
                        throw new Exception($"La quantité pour le produit '{ligne.ProduitBO.Libelle}' doit être supérieure à 0.");

                    if (ligne.Remise_par_ligne < 0 || ligne.Remise_par_ligne > 100)
                        throw new Exception($"La remise ligne pour '{ligne.ProduitBO.Libelle}' est invalide.");
                }

                // Si tout est OK, on enregistre
                devisCourant.Client = (Client)cbClient.SelectedItem;
                devisCourant.Statut = (Statut)cbStatut.SelectedItem;
                devisCourant.Date_devis = dtpDate.Value;

                int newId = GestionDevis.AjouterDevis(devisCourant);
                MessageBox.Show($"Devis n°{newId} créé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new FrmDevis().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Affichage propre de l'erreur
                MessageBox.Show(ex.Message, "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            new FrmDevis().Show();
            this.Close();
        }

        private void FrmAjoutDeDevis_Load(object sender, EventArgs e)
        {

        }
    }
}