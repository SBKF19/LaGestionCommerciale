namespace LaGestionCommerciale
{
    partial class FrmAjoutDeDevis
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleRows = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatut = new System.Windows.Forms.Label();
            this.cbStatut = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lblClientInfos = new System.Windows.Forms.Label();
            this.lblTauxTVA = new System.Windows.Forms.Label();
            this.nudTauxTVA = new System.Windows.Forms.NumericUpDown();
            this.lblTauxRemise = new System.Windows.Forms.Label();
            this.nudTauxRemiseGlobale = new System.Windows.Forms.NumericUpDown();
            this.lblProduits = new System.Windows.Forms.Label();
            this.cbProduit = new System.Windows.Forms.ComboBox();
            this.btnAjouterLigne = new System.Windows.Forms.Button();
            this.dgvLignes = new System.Windows.Forms.DataGridView();
            this.lblMontantHT = new System.Windows.Forms.Label();
            this.lblValHT = new System.Windows.Forms.Label();
            this.lblMontantTVA = new System.Windows.Forms.Label();
            this.lblValTVA = new System.Windows.Forms.Label();
            this.lblMontantTTC = new System.Windows.Forms.Label();
            this.lblValTTC = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.nudTauxTVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTauxRemiseGlobale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).BeginInit();
            this.SuspendLayout();

            // 
            // CONFIGURATION GLOBALE
            // 
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250))))); // Gris très clair moderne
            this.ClientSize = new System.Drawing.Size(820, 650);
            this.Text = "Détail Devis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // =========================================================================
            // LIGNE 1 : EN-TETE
            // =========================================================================

            // Code
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(20, 20);
            this.lblCode.Name = "lblCode";
            this.lblCode.Text = "Code";
            this.lblCode.ForeColor = System.Drawing.Color.DimGray;

            this.txtCode.Enabled = false;
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239))))); // Gris input disabled
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(23, 40);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 23);
            this.txtCode.Text = "Auto";

            // Date
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(140, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Text = "Date";
            this.lblDate.ForeColor = System.Drawing.Color.DimGray;

            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(143, 40);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(120, 23);

            // Statut
            this.lblStatut.AutoSize = true;
            this.lblStatut.Location = new System.Drawing.Point(280, 20);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Text = "Statut";
            this.lblStatut.ForeColor = System.Drawing.Color.DimGray;

            this.cbStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatut.FormattingEnabled = true;
            this.cbStatut.Location = new System.Drawing.Point(283, 40);
            this.cbStatut.Name = "cbStatut";
            this.cbStatut.Size = new System.Drawing.Size(150, 23);
            this.cbStatut.BackColor = System.Drawing.Color.White;

            // Client
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(450, 20);
            this.lblClient.Name = "lblClient";
            this.lblClient.Text = "Client";
            this.lblClient.ForeColor = System.Drawing.Color.DimGray;

            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(453, 40);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(340, 23);
            this.cbClient.BackColor = System.Drawing.Color.White;
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);

            // =========================================================================
            // ZONE INFO CLIENT (Bleu)
            // =========================================================================
            this.lblClientInfos.BackColor = System.Drawing.Color.AliceBlue; // Le fameux bleu clair
            this.lblClientInfos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; // Bordure fine
            this.lblClientInfos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.lblClientInfos.Location = new System.Drawing.Point(23, 80);
            this.lblClientInfos.Name = "lblClientInfos";
            this.lblClientInfos.Padding = new System.Windows.Forms.Padding(10);
            this.lblClientInfos.Size = new System.Drawing.Size(770, 70); // Plus haut pour contenir le texte
            this.lblClientInfos.Text = "Sélectionnez un client...";
            this.lblClientInfos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // =========================================================================
            // TAUX
            // =========================================================================
            this.lblTauxTVA.AutoSize = true;
            this.lblTauxTVA.Location = new System.Drawing.Point(20, 165);
            this.lblTauxTVA.Name = "lblTauxTVA";
            this.lblTauxTVA.Text = "Taux TVA (%)";
            this.lblTauxTVA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.nudTauxTVA.DecimalPlaces = 2;
            this.nudTauxTVA.Location = new System.Drawing.Point(23, 185);
            this.nudTauxTVA.Name = "nudTauxTVA";
            this.nudTauxTVA.Size = new System.Drawing.Size(380, 23);
            this.nudTauxTVA.Value = new decimal(new int[] { 20, 0, 0, 0 });
            this.nudTauxTVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudTauxTVA.ValueChanged += new System.EventHandler(this.nudTauxTVA_ValueChanged);

            // Taux Remise
            this.lblTauxRemise.AutoSize = true;
            this.lblTauxRemise.Location = new System.Drawing.Point(410, 165);
            this.lblTauxRemise.Name = "lblTauxRemise";
            this.lblTauxRemise.Text = "Taux remise globale (%)";
            this.lblTauxRemise.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.nudTauxRemiseGlobale.DecimalPlaces = 2;
            this.nudTauxRemiseGlobale.Location = new System.Drawing.Point(413, 185);
            this.nudTauxRemiseGlobale.Name = "nudTauxRemiseGlobale";
            this.nudTauxRemiseGlobale.Size = new System.Drawing.Size(380, 23);
            this.nudTauxRemiseGlobale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudTauxRemiseGlobale.ValueChanged += new System.EventHandler(this.nudTauxTVA_ValueChanged);

            // =========================================================================
            // ZONE PRODUITS
            // =========================================================================
            this.lblProduits.AutoSize = true;
            this.lblProduits.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProduits.Location = new System.Drawing.Point(20, 230);
            this.lblProduits.Name = "lblProduits";
            this.lblProduits.Text = "Produits";

            this.cbProduit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduit.FormattingEnabled = true;
            this.cbProduit.Location = new System.Drawing.Point(90, 228);
            this.cbProduit.Name = "cbProduit";
            this.cbProduit.Size = new System.Drawing.Size(610, 23);
            this.cbProduit.BackColor = System.Drawing.Color.White;

            this.btnAjouterLigne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20))))); // Noir/Bleu nuit
            this.btnAjouterLigne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouterLigne.FlatAppearance.BorderSize = 0;
            this.btnAjouterLigne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouterLigne.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAjouterLigne.ForeColor = System.Drawing.Color.White;
            this.btnAjouterLigne.Location = new System.Drawing.Point(710, 227);
            this.btnAjouterLigne.Name = "btnAjouterLigne";
            this.btnAjouterLigne.Size = new System.Drawing.Size(83, 26);
            this.btnAjouterLigne.Text = "+ Ajouter";
            this.btnAjouterLigne.UseVisualStyleBackColor = false;
            this.btnAjouterLigne.Click += new System.EventHandler(this.btnAjouterLigne_Click);

            // =========================================================================
            // DATAGRIDVIEW STYLE
            // =========================================================================
            this.dgvLignes.AllowUserToAddRows = false;
            this.dgvLignes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLignes.BackgroundColor = System.Drawing.Color.White; // Fond blanc
            this.dgvLignes.BorderStyle = System.Windows.Forms.BorderStyle.None; // Pas de bordure externe
            this.dgvLignes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLignes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            // Style Entête (Gris clair)
            dataGridViewCellStyleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyleHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            dataGridViewCellStyleHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyleHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyleHeader.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyleHeader.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyleHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLignes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyleHeader;
            this.dgvLignes.ColumnHeadersHeight = 35;
            this.dgvLignes.EnableHeadersVisualStyles = false; // Force le style personnalisé

            // Style Lignes
            dataGridViewCellStyleRows.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyleRows.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyleRows.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyleRows.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyleRows.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(243)))), ((int)(((byte)(255))))); // Bleu très clair sélection
            dataGridViewCellStyleRows.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyleRows.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLignes.DefaultCellStyle = dataGridViewCellStyleRows;

            this.dgvLignes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLignes.Location = new System.Drawing.Point(23, 270);
            this.dgvLignes.Name = "dgvLignes";
            this.dgvLignes.RowHeadersVisible = false;
            this.dgvLignes.RowTemplate.Height = 30;
            this.dgvLignes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLignes.Size = new System.Drawing.Size(770, 200);
            this.dgvLignes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLignes_CellEndEdit);
            this.dgvLignes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLignes_CellFormatting);

            // =========================================================================
            // TOTAUX
            // =========================================================================
            // HT
            this.lblMontantHT.AutoSize = true;
            this.lblMontantHT.Location = new System.Drawing.Point(20, 490);
            this.lblMontantHT.Name = "lblMontantHT";
            this.lblMontantHT.Text = "Montant HT";
            this.lblMontantHT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.lblValHT.BackColor = System.Drawing.Color.White; // Fond blanc pour faire "boite"
            this.lblValHT.BorderStyle = System.Windows.Forms.BorderStyle.None; // Ou FixedSingle si tu veux un contour
            this.lblValHT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblValHT.Location = new System.Drawing.Point(23, 510);
            this.lblValHT.Name = "lblValHT";
            this.lblValHT.Size = new System.Drawing.Size(250, 35);
            this.lblValHT.Text = "0,00 €";
            this.lblValHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; // Centrage vertical

            // TVA
            this.lblMontantTVA.AutoSize = true;
            this.lblMontantTVA.Location = new System.Drawing.Point(280, 490);
            this.lblMontantTVA.Name = "lblMontantTVA";
            this.lblMontantTVA.Text = "Montant TVA";
            this.lblMontantTVA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.lblValTVA.BackColor = System.Drawing.Color.White;
            this.lblValTVA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblValTVA.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblValTVA.Location = new System.Drawing.Point(283, 510);
            this.lblValTVA.Name = "lblValTVA";
            this.lblValTVA.Size = new System.Drawing.Size(250, 35);
            this.lblValTVA.Text = "0,00 €";
            this.lblValTVA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // TTC
            this.lblMontantTTC.AutoSize = true;
            this.lblMontantTTC.Location = new System.Drawing.Point(540, 490);
            this.lblMontantTTC.Name = "lblMontantTTC";
            this.lblMontantTTC.Text = "Montant TTC";
            this.lblMontantTTC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.lblValTTC.BackColor = System.Drawing.Color.White;
            this.lblValTTC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblValTTC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValTTC.Location = new System.Drawing.Point(543, 510);
            this.lblValTTC.Name = "lblValTTC";
            this.lblValTTC.Size = new System.Drawing.Size(250, 35);
            this.lblValTTC.Text = "0,00 €";
            this.lblValTTC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // =========================================================================
            // BOUTONS ACTION
            // =========================================================================
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))); // Vert Bootstrap
            this.btnValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValider.FlatAppearance.BorderSize = 0;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.Location = new System.Drawing.Point(23, 580);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(120, 40);
            this.btnValider.Text = "Ajouter";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);

            // Bouton Retour
            this.btnRetour.BackColor = System.Drawing.Color.White;
            this.btnRetour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetour.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnRetour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRetour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRetour.Location = new System.Drawing.Point(673, 580);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(120, 40);
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);

            // Ajout des contrôles
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblStatut);
            this.Controls.Add(this.cbStatut);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.lblClientInfos);
            this.Controls.Add(this.lblTauxTVA);
            this.Controls.Add(this.nudTauxTVA);
            this.Controls.Add(this.lblTauxRemise);
            this.Controls.Add(this.nudTauxRemiseGlobale);
            this.Controls.Add(this.lblProduits);
            this.Controls.Add(this.cbProduit);
            this.Controls.Add(this.btnAjouterLigne);
            this.Controls.Add(this.dgvLignes);
            this.Controls.Add(this.lblMontantHT);
            this.Controls.Add(this.lblValHT);
            this.Controls.Add(this.lblMontantTVA);
            this.Controls.Add(this.lblValTVA);
            this.Controls.Add(this.lblMontantTTC);
            this.Controls.Add(this.lblValTTC);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnRetour);

            ((System.ComponentModel.ISupportInitialize)(this.nudTauxTVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTauxRemiseGlobale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Déclaration des variables
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.ComboBox cbStatut;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lblClientInfos;
        private System.Windows.Forms.Label lblTauxTVA;
        private System.Windows.Forms.NumericUpDown nudTauxTVA;
        private System.Windows.Forms.Label lblTauxRemise;
        private System.Windows.Forms.NumericUpDown nudTauxRemiseGlobale;
        private System.Windows.Forms.Label lblProduits;
        private System.Windows.Forms.ComboBox cbProduit;
        private System.Windows.Forms.Button btnAjouterLigne;
        private System.Windows.Forms.DataGridView dgvLignes;
        private System.Windows.Forms.Label lblMontantHT;
        private System.Windows.Forms.Label lblValHT;
        private System.Windows.Forms.Label lblMontantTVA;
        private System.Windows.Forms.Label lblValTVA;
        private System.Windows.Forms.Label lblMontantTTC;
        private System.Windows.Forms.Label lblValTTC;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnRetour;
    }
}