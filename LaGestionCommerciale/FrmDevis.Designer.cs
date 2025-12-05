namespace LaGestionCommerciale
{
    partial class FrmDevis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddDevis = new System.Windows.Forms.Button();
            this.dgvDevis = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdresseLivraison = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDevis = new System.Windows.Forms.Panel();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.numTVA = new System.Windows.Forms.TextBox();
            this.txtTTC = new System.Windows.Forms.TextBox();
            this.lblTTC = new System.Windows.Forms.Label();
            this.txtMontantTVA = new System.Windows.Forms.TextBox();
            this.lblMontantTVA = new System.Windows.Forms.Label();
            this.txtHT = new System.Windows.Forms.TextBox();
            this.lblHT = new System.Windows.Forms.Label();
            this.dgvModify = new System.Windows.Forms.DataGridView();
            this.select_produit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categorie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prixUnitaire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteProduit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.lblProduits = new System.Windows.Forms.Label();
            this.numRemiseGlobale = new System.Windows.Forms.NumericUpDown();
            this.lblRemiseGlobale = new System.Windows.Forms.Label();
            this.lblTVA = new System.Windows.Forms.Label();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.txtLivre = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtFacture = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblLivr = new System.Windows.Forms.Label();
            this.lblFact = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbStatut = new System.Windows.Forms.ComboBox();
            this.lblSatut = new System.Windows.Forms.Label();
            this.dtpDevis = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevis)).BeginInit();
            this.pnlDevis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRemiseGlobale)).BeginInit();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddDevis
            // 
            this.btnAddDevis.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddDevis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAddDevis.ForeColor = System.Drawing.Color.White;
            this.btnAddDevis.Location = new System.Drawing.Point(31, 59);
            this.btnAddDevis.Name = "btnAddDevis";
            this.btnAddDevis.Size = new System.Drawing.Size(152, 35);
            this.btnAddDevis.TabIndex = 5;
            this.btnAddDevis.Text = "Ajouter un client";
            this.btnAddDevis.UseVisualStyleBackColor = false;
            // 
            // dgvDevis
            // 
            this.dgvDevis.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDevis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.NomClient,
            this.Date,
            this.AdresseLivraison});
            this.dgvDevis.Location = new System.Drawing.Point(31, 117);
            this.dgvDevis.Name = "dgvDevis";
            this.dgvDevis.RowHeadersVisible = false;
            this.dgvDevis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevis.Size = new System.Drawing.Size(428, 662);
            this.dgvDevis.TabIndex = 6;
            this.dgvDevis.VisibleChanged += new System.EventHandler(this.FrmDevis_Load);
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.Width = 50;
            // 
            // NomClient
            // 
            this.NomClient.HeaderText = "Nom client";
            this.NomClient.Name = "NomClient";
            this.NomClient.Width = 150;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 125;
            // 
            // AdresseLivraison
            // 
            this.AdresseLivraison.HeaderText = "Prix";
            this.AdresseLivraison.Name = "AdresseLivraison";
            // 
            // pnlDevis
            // 
            this.pnlDevis.Controls.Add(this.btnSupprimer);
            this.pnlDevis.Controls.Add(this.btnModifier);
            this.pnlDevis.Controls.Add(this.numTVA);
            this.pnlDevis.Controls.Add(this.txtTTC);
            this.pnlDevis.Controls.Add(this.lblTTC);
            this.pnlDevis.Controls.Add(this.txtMontantTVA);
            this.pnlDevis.Controls.Add(this.lblMontantTVA);
            this.pnlDevis.Controls.Add(this.txtHT);
            this.pnlDevis.Controls.Add(this.lblHT);
            this.pnlDevis.Controls.Add(this.dgvModify);
            this.pnlDevis.Controls.Add(this.btnAjouter);
            this.pnlDevis.Controls.Add(this.lblProduits);
            this.pnlDevis.Controls.Add(this.numRemiseGlobale);
            this.pnlDevis.Controls.Add(this.lblRemiseGlobale);
            this.pnlDevis.Controls.Add(this.lblTVA);
            this.pnlDevis.Controls.Add(this.pnlClient);
            this.pnlDevis.Controls.Add(this.cmbClient);
            this.pnlDevis.Controls.Add(this.lblClient);
            this.pnlDevis.Controls.Add(this.cmbStatut);
            this.pnlDevis.Controls.Add(this.lblSatut);
            this.pnlDevis.Controls.Add(this.dtpDevis);
            this.pnlDevis.Controls.Add(this.lblDate);
            this.pnlDevis.Controls.Add(this.txtCode);
            this.pnlDevis.Controls.Add(this.lblCode);
            this.pnlDevis.Controls.Add(this.lblDetail);
            this.pnlDevis.Location = new System.Drawing.Point(465, 117);
            this.pnlDevis.Name = "pnlDevis";
            this.pnlDevis.Size = new System.Drawing.Size(978, 662);
            this.pnlDevis.TabIndex = 7;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Red;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(455, 256);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(108, 39);
            this.btnSupprimer.TabIndex = 31;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(325, 256);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(111, 40);
            this.btnModifier.TabIndex = 30;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // numTVA
            // 
            this.numTVA.Location = new System.Drawing.Point(25, 272);
            this.numTVA.Name = "numTVA";
            this.numTVA.ReadOnly = true;
            this.numTVA.Size = new System.Drawing.Size(100, 20);
            this.numTVA.TabIndex = 17;
            // 
            // txtTTC
            // 
            this.txtTTC.Location = new System.Drawing.Point(437, 593);
            this.txtTTC.Name = "txtTTC";
            this.txtTTC.ReadOnly = true;
            this.txtTTC.Size = new System.Drawing.Size(172, 20);
            this.txtTTC.TabIndex = 29;
            // 
            // lblTTC
            // 
            this.lblTTC.AutoSize = true;
            this.lblTTC.Location = new System.Drawing.Point(463, 577);
            this.lblTTC.Name = "lblTTC";
            this.lblTTC.Size = new System.Drawing.Size(70, 13);
            this.lblTTC.TabIndex = 28;
            this.lblTTC.Text = "Montant TTC";
            // 
            // txtMontantTVA
            // 
            this.txtMontantTVA.Location = new System.Drawing.Point(223, 593);
            this.txtMontantTVA.Name = "txtMontantTVA";
            this.txtMontantTVA.ReadOnly = true;
            this.txtMontantTVA.Size = new System.Drawing.Size(161, 20);
            this.txtMontantTVA.TabIndex = 27;
            // 
            // lblMontantTVA
            // 
            this.lblMontantTVA.AutoSize = true;
            this.lblMontantTVA.Location = new System.Drawing.Point(247, 577);
            this.lblMontantTVA.Name = "lblMontantTVA";
            this.lblMontantTVA.Size = new System.Drawing.Size(70, 13);
            this.lblMontantTVA.TabIndex = 26;
            this.lblMontantTVA.Text = "Montant TVA";
            // 
            // txtHT
            // 
            this.txtHT.Location = new System.Drawing.Point(25, 593);
            this.txtHT.Name = "txtHT";
            this.txtHT.ReadOnly = true;
            this.txtHT.Size = new System.Drawing.Size(151, 20);
            this.txtHT.TabIndex = 25;
            // 
            // lblHT
            // 
            this.lblHT.AutoSize = true;
            this.lblHT.Location = new System.Drawing.Point(38, 577);
            this.lblHT.Name = "lblHT";
            this.lblHT.Size = new System.Drawing.Size(64, 13);
            this.lblHT.TabIndex = 24;
            this.lblHT.Text = "Montant HT";
            // 
            // dgvModify
            // 
            this.dgvModify.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvModify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModify.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select_produit,
            this.categorie,
            this.prixUnitaire,
            this.quantite,
            this.remise,
            this.TotalHT,
            this.deleteProduit});
            this.dgvModify.Location = new System.Drawing.Point(25, 343);
            this.dgvModify.Name = "dgvModify";
            this.dgvModify.RowHeadersVisible = false;
            this.dgvModify.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModify.Size = new System.Drawing.Size(933, 193);
            this.dgvModify.TabIndex = 23;
            this.dgvModify.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModify_CellContentClick);
            // 
            // select_produit
            // 
            this.select_produit.HeaderText = "Produit";
            this.select_produit.Name = "select_produit";
            this.select_produit.Width = 330;
            // 
            // categorie
            // 
            this.categorie.HeaderText = "Catégorie";
            this.categorie.Name = "categorie";
            // 
            // prixUnitaire
            // 
            this.prixUnitaire.HeaderText = "Prix unitaire HT";
            this.prixUnitaire.Name = "prixUnitaire";
            // 
            // quantite
            // 
            this.quantite.HeaderText = "Qté";
            this.quantite.Name = "quantite";
            // 
            // remise
            // 
            this.remise.HeaderText = "Rem.%";
            this.remise.Name = "remise";
            // 
            // TotalHT
            // 
            this.TotalHT.HeaderText = "Total HT";
            this.TotalHT.Name = "TotalHT";
            // 
            // deleteProduit
            // 
            this.deleteProduit.HeaderText = "supprimer";
            this.deleteProduit.Name = "deleteProduit";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(839, 312);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(119, 23);
            this.btnAjouter.TabIndex = 22;
            this.btnAjouter.Text = "Ajouter un produit";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAddProduit_Click);
            // 
            // lblProduits
            // 
            this.lblProduits.AutoSize = true;
            this.lblProduits.Location = new System.Drawing.Point(22, 317);
            this.lblProduits.Name = "lblProduits";
            this.lblProduits.Size = new System.Drawing.Size(45, 13);
            this.lblProduits.TabIndex = 20;
            this.lblProduits.Text = "Produits";
            // 
            // numRemiseGlobale
            // 
            this.numRemiseGlobale.Location = new System.Drawing.Point(164, 272);
            this.numRemiseGlobale.Name = "numRemiseGlobale";
            this.numRemiseGlobale.Size = new System.Drawing.Size(126, 20);
            this.numRemiseGlobale.TabIndex = 19;
            // 
            // lblRemiseGlobale
            // 
            this.lblRemiseGlobale.AutoSize = true;
            this.lblRemiseGlobale.Location = new System.Drawing.Point(161, 247);
            this.lblRemiseGlobale.Name = "lblRemiseGlobale";
            this.lblRemiseGlobale.Size = new System.Drawing.Size(133, 13);
            this.lblRemiseGlobale.TabIndex = 18;
            this.lblRemiseGlobale.Text = "Taux de remise globale (%)";
            // 
            // lblTVA
            // 
            this.lblTVA.AutoSize = true;
            this.lblTVA.Location = new System.Drawing.Point(22, 247);
            this.lblTVA.Name = "lblTVA";
            this.lblTVA.Size = new System.Drawing.Size(87, 13);
            this.lblTVA.TabIndex = 16;
            this.lblTVA.Text = "Taux de TVA (%)";
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.txtLivre);
            this.pnlClient.Controls.Add(this.txtPhone);
            this.pnlClient.Controls.Add(this.txtMail);
            this.pnlClient.Controls.Add(this.txtFacture);
            this.pnlClient.Controls.Add(this.lblMail);
            this.pnlClient.Controls.Add(this.lblTel);
            this.pnlClient.Controls.Add(this.lblLivr);
            this.pnlClient.Controls.Add(this.lblFact);
            this.pnlClient.Location = new System.Drawing.Point(25, 81);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(933, 154);
            this.pnlClient.TabIndex = 15;
            // 
            // txtLivre
            // 
            this.txtLivre.Location = new System.Drawing.Point(69, 43);
            this.txtLivre.Name = "txtLivre";
            this.txtLivre.ReadOnly = true;
            this.txtLivre.Size = new System.Drawing.Size(828, 20);
            this.txtLivre.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(78, 80);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(819, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(55, 113);
            this.txtMail.Name = "txtMail";
            this.txtMail.ReadOnly = true;
            this.txtMail.Size = new System.Drawing.Size(842, 20);
            this.txtMail.TabIndex = 7;
            // 
            // txtFacture
            // 
            this.txtFacture.Location = new System.Drawing.Point(63, 11);
            this.txtFacture.Name = "txtFacture";
            this.txtFacture.ReadOnly = true;
            this.txtFacture.Size = new System.Drawing.Size(834, 20);
            this.txtFacture.TabIndex = 1;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(8, 116);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(41, 13);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "E-mail :";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(8, 83);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(64, 13);
            this.lblTel.TabIndex = 4;
            this.lblTel.Text = "Telephone :";
            // 
            // lblLivr
            // 
            this.lblLivr.AutoSize = true;
            this.lblLivr.Location = new System.Drawing.Point(8, 50);
            this.lblLivr.Name = "lblLivr";
            this.lblLivr.Size = new System.Drawing.Size(55, 13);
            this.lblLivr.TabIndex = 2;
            this.lblLivr.Text = "Livraison :";
            // 
            // lblFact
            // 
            this.lblFact.AutoSize = true;
            this.lblFact.Location = new System.Drawing.Point(8, 14);
            this.lblFact.Name = "lblFact";
            this.lblFact.Size = new System.Drawing.Size(49, 13);
            this.lblFact.TabIndex = 0;
            this.lblFact.Text = "Facture :";
            // 
            // cmbClient
            // 
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(698, 54);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(260, 21);
            this.cmbClient.TabIndex = 13;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(695, 36);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(33, 13);
            this.lblClient.TabIndex = 12;
            this.lblClient.Text = "Client";
            // 
            // cmbStatut
            // 
            this.cmbStatut.FormattingEnabled = true;
            this.cmbStatut.Location = new System.Drawing.Point(455, 54);
            this.cmbStatut.Name = "cmbStatut";
            this.cmbStatut.Size = new System.Drawing.Size(229, 21);
            this.cmbStatut.TabIndex = 11;
            // 
            // lblSatut
            // 
            this.lblSatut.AutoSize = true;
            this.lblSatut.Location = new System.Drawing.Point(452, 36);
            this.lblSatut.Name = "lblSatut";
            this.lblSatut.Size = new System.Drawing.Size(35, 13);
            this.lblSatut.TabIndex = 10;
            this.lblSatut.Text = "Statut";
            // 
            // dtpDevis
            // 
            this.dtpDevis.Location = new System.Drawing.Point(164, 55);
            this.dtpDevis.Name = "dtpDevis";
            this.dtpDevis.Size = new System.Drawing.Size(272, 20);
            this.dtpDevis.TabIndex = 9;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(161, 36);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(25, 55);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(126, 20);
            this.txtCode.TabIndex = 7;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(22, 36);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "Code";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetail.Location = new System.Drawing.Point(12, 0);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(56, 21);
            this.lblDetail.TabIndex = 1;
            this.lblDetail.Text = "Détail";
            // 
            // FrmDevis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 808);
            this.Controls.Add(this.pnlDevis);
            this.Controls.Add(this.dgvDevis);
            this.Controls.Add(this.btnAddDevis);
            this.Name = "FrmDevis";
            this.Text = "FrmDevis";
            this.Load += new System.EventHandler(this.FrmDevis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevis)).EndInit();
            this.pnlDevis.ResumeLayout(false);
            this.pnlDevis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRemiseGlobale)).EndInit();
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddDevis;
        private System.Windows.Forms.DataGridView dgvDevis;
        private System.Windows.Forms.Panel pnlDevis;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.DateTimePicker dtpDevis;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbStatut;
        private System.Windows.Forms.Label lblSatut;
        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Label lblLivr;
        private System.Windows.Forms.Label lblFact;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtLivre;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtFacture;
        private System.Windows.Forms.Label lblTVA;
        private System.Windows.Forms.NumericUpDown numRemiseGlobale;
        private System.Windows.Forms.Label lblRemiseGlobale;
        private System.Windows.Forms.Label lblProduits;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.DataGridView dgvModify;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdresseLivraison;
        private System.Windows.Forms.DataGridViewTextBoxColumn select_produit;
        private System.Windows.Forms.DataGridViewTextBoxColumn categorie;
        private System.Windows.Forms.DataGridViewTextBoxColumn prixUnitaire;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantite;
        private System.Windows.Forms.DataGridViewTextBoxColumn remise;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteProduit;
        private System.Windows.Forms.Label lblMontantTVA;
        private System.Windows.Forms.TextBox txtHT;
        private System.Windows.Forms.Label lblHT;
        private System.Windows.Forms.TextBox txtTTC;
        private System.Windows.Forms.Label lblTTC;
        private System.Windows.Forms.TextBox txtMontantTVA;
        private System.Windows.Forms.TextBox numTVA;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
    }
}