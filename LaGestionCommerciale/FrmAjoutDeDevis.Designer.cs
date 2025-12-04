namespace LaGestionCommerciale // ou LaGestionCommerciale selon ton namespace
{
    partial class FrmAjoutDeDevis
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbStatut = new System.Windows.Forms.ComboBox();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lblClientInfos = new System.Windows.Forms.Label();
            this.nudTauxTVA = new System.Windows.Forms.NumericUpDown();
            this.nudTauxRemiseGlobale = new System.Windows.Forms.NumericUpDown();
            this.cbProduit = new System.Windows.Forms.ComboBox();
            this.btnAjouterLigne = new System.Windows.Forms.Button();
            this.dgvLignes = new System.Windows.Forms.DataGridView();
            this.lblTotalHT = new System.Windows.Forms.Label();
            this.lblMontantTVA = new System.Windows.Forms.Label();
            this.lblTotalTTC = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelStatut = new System.Windows.Forms.Label();
            this.labelClient = new System.Windows.Forms.Label();
            this.labelTVA = new System.Windows.Forms.Label();
            this.labelRemise = new System.Windows.Forms.Label();
            this.labelProduits = new System.Windows.Forms.Label();
            this.labelTotalHT = new System.Windows.Forms.Label();
            this.labelMontantTVA = new System.Windows.Forms.Label();
            this.labelTTC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudTauxTVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTauxRemiseGlobale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Arial", 20F);
            this.lblTitre.Location = new System.Drawing.Point(20, 20);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(197, 32);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Nouveau Devis";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(280, 45);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(120, 20);
            this.dtpDate.TabIndex = 2;
            // 
            // cbStatut
            // 
            this.cbStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatut.Location = new System.Drawing.Point(420, 45);
            this.cbStatut.Name = "cbStatut";
            this.cbStatut.Size = new System.Drawing.Size(120, 21);
            this.cbStatut.TabIndex = 4;
            // 
            // cbClient
            // 
            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.Location = new System.Drawing.Point(560, 45);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(200, 21);
            this.cbClient.TabIndex = 6;
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            // 
            // lblClientInfos
            // 
            this.lblClientInfos.BackColor = System.Drawing.Color.AliceBlue;
            this.lblClientInfos.Location = new System.Drawing.Point(25, 80);
            this.lblClientInfos.Name = "lblClientInfos";
            this.lblClientInfos.Padding = new System.Windows.Forms.Padding(5);
            this.lblClientInfos.Size = new System.Drawing.Size(735, 60);
            this.lblClientInfos.TabIndex = 7;
            this.lblClientInfos.Text = "Infos client...";
            this.lblClientInfos.Click += new System.EventHandler(this.lblClientInfos_Click);
            // 
            // nudTauxTVA
            // 
            this.nudTauxTVA.DecimalPlaces = 2;
            this.nudTauxTVA.Location = new System.Drawing.Point(25, 170);
            this.nudTauxTVA.Name = "nudTauxTVA";
            this.nudTauxTVA.Size = new System.Drawing.Size(120, 20);
            this.nudTauxTVA.TabIndex = 9;
            this.nudTauxTVA.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudTauxTVA.ValueChanged += new System.EventHandler(this.nudTauxTVA_ValueChanged);
            // 
            // nudTauxRemiseGlobale
            // 
            this.nudTauxRemiseGlobale.DecimalPlaces = 2;
            this.nudTauxRemiseGlobale.Location = new System.Drawing.Point(420, 170);
            this.nudTauxRemiseGlobale.Name = "nudTauxRemiseGlobale";
            this.nudTauxRemiseGlobale.Size = new System.Drawing.Size(120, 20);
            this.nudTauxRemiseGlobale.TabIndex = 11;
            this.nudTauxRemiseGlobale.ValueChanged += new System.EventHandler(this.nudTauxTVA_ValueChanged);
            // 
            // cbProduit
            // 
            this.cbProduit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduit.Location = new System.Drawing.Point(100, 210);
            this.cbProduit.Name = "cbProduit";
            this.cbProduit.Size = new System.Drawing.Size(550, 21);
            this.cbProduit.TabIndex = 13;
            // 
            // btnAjouterLigne
            // 
            this.btnAjouterLigne.BackColor = System.Drawing.Color.Black;
            this.btnAjouterLigne.ForeColor = System.Drawing.Color.White;
            this.btnAjouterLigne.Location = new System.Drawing.Point(660, 208);
            this.btnAjouterLigne.Name = "btnAjouterLigne";
            this.btnAjouterLigne.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterLigne.TabIndex = 14;
            this.btnAjouterLigne.Text = "+ Ajouter";
            this.btnAjouterLigne.UseVisualStyleBackColor = false;
            this.btnAjouterLigne.Click += new System.EventHandler(this.btnAjouterLigne_Click);
            // 
            // dgvLignes
            // 
            this.dgvLignes.AllowUserToAddRows = false;
            this.dgvLignes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLignes.Location = new System.Drawing.Point(25, 240);
            this.dgvLignes.Name = "dgvLignes";
            this.dgvLignes.Size = new System.Drawing.Size(735, 200);
            this.dgvLignes.TabIndex = 15;
            this.dgvLignes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLignes_CellEndEdit);
            this.dgvLignes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLignes_CellFormatting);
            // 
            // lblTotalHT
            // 
            this.lblTotalHT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalHT.Location = new System.Drawing.Point(25, 470);
            this.lblTotalHT.Name = "lblTotalHT";
            this.lblTotalHT.Size = new System.Drawing.Size(100, 23);
            this.lblTotalHT.TabIndex = 17;
            this.lblTotalHT.Text = "0.00 €";
            // 
            // lblMontantTVA
            // 
            this.lblMontantTVA.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblMontantTVA.Location = new System.Drawing.Point(300, 470);
            this.lblMontantTVA.Name = "lblMontantTVA";
            this.lblMontantTVA.Size = new System.Drawing.Size(100, 23);
            this.lblMontantTVA.TabIndex = 19;
            this.lblMontantTVA.Text = "0.00 €";
            // 
            // lblTotalTTC
            // 
            this.lblTotalTTC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalTTC.Location = new System.Drawing.Point(600, 470);
            this.lblTotalTTC.Name = "lblTotalTTC";
            this.lblTotalTTC.Size = new System.Drawing.Size(100, 23);
            this.lblTotalTTC.TabIndex = 21;
            this.lblTotalTTC.Text = "0.00 €";
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.ForestGreen;
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.Location = new System.Drawing.Point(25, 520);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(150, 40);
            this.btnValider.TabIndex = 22;
            this.btnValider.Text = "Valider le Devis";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(610, 520);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(150, 40);
            this.btnRetour.TabIndex = 23;
            this.btnRetour.Text = "Retour";
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // labelDate
            // 
            this.labelDate.Location = new System.Drawing.Point(280, 25);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(100, 23);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Date";
            // 
            // labelStatut
            // 
            this.labelStatut.Location = new System.Drawing.Point(420, 25);
            this.labelStatut.Name = "labelStatut";
            this.labelStatut.Size = new System.Drawing.Size(100, 23);
            this.labelStatut.TabIndex = 3;
            this.labelStatut.Text = "Statut";
            // 
            // labelClient
            // 
            this.labelClient.Location = new System.Drawing.Point(560, 25);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(100, 23);
            this.labelClient.TabIndex = 5;
            this.labelClient.Text = "Client";
            // 
            // labelTVA
            // 
            this.labelTVA.Location = new System.Drawing.Point(25, 150);
            this.labelTVA.Name = "labelTVA";
            this.labelTVA.Size = new System.Drawing.Size(100, 23);
            this.labelTVA.TabIndex = 8;
            this.labelTVA.Text = "Taux TVA (%)";
            // 
            // labelRemise
            // 
            this.labelRemise.Location = new System.Drawing.Point(420, 150);
            this.labelRemise.Name = "labelRemise";
            this.labelRemise.Size = new System.Drawing.Size(100, 23);
            this.labelRemise.TabIndex = 10;
            this.labelRemise.Text = "Remise Globale (%)";
            // 
            // labelProduits
            // 
            this.labelProduits.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelProduits.Location = new System.Drawing.Point(25, 210);
            this.labelProduits.Name = "labelProduits";
            this.labelProduits.Size = new System.Drawing.Size(100, 23);
            this.labelProduits.TabIndex = 12;
            this.labelProduits.Text = "Produits";
            // 
            // labelTotalHT
            // 
            this.labelTotalHT.Location = new System.Drawing.Point(25, 450);
            this.labelTotalHT.Name = "labelTotalHT";
            this.labelTotalHT.Size = new System.Drawing.Size(100, 23);
            this.labelTotalHT.TabIndex = 16;
            this.labelTotalHT.Text = "Total HT";
            // 
            // labelMontantTVA
            // 
            this.labelMontantTVA.Location = new System.Drawing.Point(300, 450);
            this.labelMontantTVA.Name = "labelMontantTVA";
            this.labelMontantTVA.Size = new System.Drawing.Size(100, 23);
            this.labelMontantTVA.TabIndex = 18;
            this.labelMontantTVA.Text = "Montant TVA";
            // 
            // labelTTC
            // 
            this.labelTTC.Location = new System.Drawing.Point(600, 450);
            this.labelTTC.Name = "labelTTC";
            this.labelTTC.Size = new System.Drawing.Size(100, 23);
            this.labelTTC.TabIndex = 20;
            this.labelTTC.Text = "Total TTC";
            // 
            // FrmAjoutDeDevis
            // 
            this.ClientSize = new System.Drawing.Size(922, 600);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.labelStatut);
            this.Controls.Add(this.cbStatut);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.lblClientInfos);
            this.Controls.Add(this.labelTVA);
            this.Controls.Add(this.nudTauxTVA);
            this.Controls.Add(this.labelRemise);
            this.Controls.Add(this.nudTauxRemiseGlobale);
            this.Controls.Add(this.labelProduits);
            this.Controls.Add(this.cbProduit);
            this.Controls.Add(this.btnAjouterLigne);
            this.Controls.Add(this.dgvLignes);
            this.Controls.Add(this.labelTotalHT);
            this.Controls.Add(this.lblTotalHT);
            this.Controls.Add(this.labelMontantTVA);
            this.Controls.Add(this.lblMontantTVA);
            this.Controls.Add(this.labelTTC);
            this.Controls.Add(this.lblTotalTTC);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnRetour);
            this.Name = "FrmAjoutDeDevis";
            ((System.ComponentModel.ISupportInitialize)(this.nudTauxTVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTauxRemiseGlobale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre, lblClientInfos, lblTotalHT, lblMontantTVA, lblTotalTTC;
        private System.Windows.Forms.Label labelDate, labelStatut, labelClient, labelTVA, labelRemise, labelProduits, labelTotalHT, labelMontantTVA, labelTTC;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cbStatut, cbClient, cbProduit;
        private System.Windows.Forms.NumericUpDown nudTauxTVA, nudTauxRemiseGlobale;
        private System.Windows.Forms.Button btnAjouterLigne, btnValider, btnRetour;
        private System.Windows.Forms.DataGridView dgvLignes;
    }
}