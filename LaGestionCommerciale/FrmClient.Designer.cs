namespace LaGestionCommerciale
{
    partial class FrmClient
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
            this.btnAddClient = new System.Windows.Forms.Button();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtVilleLivraison = new System.Windows.Forms.TextBox();
            this.lblVilleLivraison = new System.Windows.Forms.Label();
            this.txtCodePostalLivraison = new System.Windows.Forms.TextBox();
            this.lblCodePostalLivraison = new System.Windows.Forms.Label();
            this.txtRueLivraison = new System.Windows.Forms.TextBox();
            this.lblRueLivraison = new System.Windows.Forms.Label();
            this.txtNumeroRueLivraison = new System.Windows.Forms.TextBox();
            this.lblNumeroRueLivraison = new System.Windows.Forms.Label();
            this.lblAdresseDeLivraison = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblVilleFacturation = new System.Windows.Forms.Label();
            this.txtVilleFacturation = new System.Windows.Forms.TextBox();
            this.txtCodePostalFacturation = new System.Windows.Forms.TextBox();
            this.lblCodePostalFacturation = new System.Windows.Forms.Label();
            this.txtRueFacturation = new System.Windows.Forms.TextBox();
            this.lblRueFacturation = new System.Windows.Forms.Label();
            this.txtNumeroRueFacturation = new System.Windows.Forms.TextBox();
            this.lblNumeroRueFacturation = new System.Windows.Forms.Label();
            this.lblAdresseDeFacturation = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdresseFacturation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdresseLivraison = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Téléphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumRueFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RueFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VilleFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodePostalFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumRueLiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RueLiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VilleLiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodePostalLiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Location = new System.Drawing.Point(25, 26);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(152, 35);
            this.btnAddClient.TabIndex = 1;
            this.btnAddClient.Text = "Ajouter un client";
            this.btnAddClient.UseVisualStyleBackColor = false;
            // 
            // dgvClient
            // 
            this.dgvClient.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.NomClient,
            this.AdresseFacturation,
            this.AdresseLivraison,
            this.Téléphone,
            this.Fax,
            this.Email,
            this.NumRueFact,
            this.RueFact,
            this.VilleFact,
            this.CodePostalFact,
            this.NumRueLiv,
            this.RueLiv,
            this.VilleLiv,
            this.CodePostalLiv});
            this.dgvClient.Location = new System.Drawing.Point(25, 82);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.RowHeadersVisible = false;
            this.dgvClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClient.Size = new System.Drawing.Size(932, 581);
            this.dgvClient.TabIndex = 0;
            this.dgvClient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClient_SelectionChanged);
            // 
            // pnlDetail
            // 
            this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetail.Controls.Add(this.btnSupprimer);
            this.pnlDetail.Controls.Add(this.btnModifier);
            this.pnlDetail.Controls.Add(this.txtEmail);
            this.pnlDetail.Controls.Add(this.lblEmail);
            this.pnlDetail.Controls.Add(this.txtFax);
            this.pnlDetail.Controls.Add(this.lblFax);
            this.pnlDetail.Controls.Add(this.txtTelephone);
            this.pnlDetail.Controls.Add(this.lblTelephone);
            this.pnlDetail.Controls.Add(this.panel3);
            this.pnlDetail.Controls.Add(this.txtVilleLivraison);
            this.pnlDetail.Controls.Add(this.lblVilleLivraison);
            this.pnlDetail.Controls.Add(this.txtCodePostalLivraison);
            this.pnlDetail.Controls.Add(this.lblCodePostalLivraison);
            this.pnlDetail.Controls.Add(this.txtRueLivraison);
            this.pnlDetail.Controls.Add(this.lblRueLivraison);
            this.pnlDetail.Controls.Add(this.txtNumeroRueLivraison);
            this.pnlDetail.Controls.Add(this.lblNumeroRueLivraison);
            this.pnlDetail.Controls.Add(this.lblAdresseDeLivraison);
            this.pnlDetail.Controls.Add(this.panel2);
            this.pnlDetail.Controls.Add(this.lblVilleFacturation);
            this.pnlDetail.Controls.Add(this.txtVilleFacturation);
            this.pnlDetail.Controls.Add(this.txtCodePostalFacturation);
            this.pnlDetail.Controls.Add(this.lblCodePostalFacturation);
            this.pnlDetail.Controls.Add(this.txtRueFacturation);
            this.pnlDetail.Controls.Add(this.lblRueFacturation);
            this.pnlDetail.Controls.Add(this.txtNumeroRueFacturation);
            this.pnlDetail.Controls.Add(this.lblNumeroRueFacturation);
            this.pnlDetail.Controls.Add(this.lblAdresseDeFacturation);
            this.pnlDetail.Controls.Add(this.panel1);
            this.pnlDetail.Controls.Add(this.txtNom);
            this.pnlDetail.Controls.Add(this.lblNom);
            this.pnlDetail.Controls.Add(this.lblDetail);
            this.pnlDetail.Location = new System.Drawing.Point(1003, 82);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(380, 680);
            this.pnlDetail.TabIndex = 2;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Red;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(224, 598);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(113, 41);
            this.btnSupprimer.TabIndex = 31;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.LimeGreen;
            this.btnModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(44, 598);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(116, 41);
            this.btnModifier.TabIndex = 30;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(18, 548);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(346, 20);
            this.txtEmail.TabIndex = 29;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 532);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "Email";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(184, 493);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(181, 20);
            this.txtFax.TabIndex = 27;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(181, 477);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(24, 13);
            this.lblFax.TabIndex = 26;
            this.lblFax.Text = "Fax";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(17, 493);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(158, 20);
            this.txtTelephone.TabIndex = 25;
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(15, 477);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(58, 13);
            this.lblTelephone.TabIndex = 24;
            this.lblTelephone.Text = "Téléphone";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(18, 460);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 1);
            this.panel3.TabIndex = 23;
            // 
            // txtVilleLivraison
            // 
            this.txtVilleLivraison.Location = new System.Drawing.Point(119, 418);
            this.txtVilleLivraison.Name = "txtVilleLivraison";
            this.txtVilleLivraison.Size = new System.Drawing.Size(245, 20);
            this.txtVilleLivraison.TabIndex = 22;
            // 
            // lblVilleLivraison
            // 
            this.lblVilleLivraison.AutoSize = true;
            this.lblVilleLivraison.Location = new System.Drawing.Point(118, 402);
            this.lblVilleLivraison.Name = "lblVilleLivraison";
            this.lblVilleLivraison.Size = new System.Drawing.Size(26, 13);
            this.lblVilleLivraison.TabIndex = 21;
            this.lblVilleLivraison.Text = "Ville";
            // 
            // txtCodePostalLivraison
            // 
            this.txtCodePostalLivraison.Location = new System.Drawing.Point(17, 418);
            this.txtCodePostalLivraison.Name = "txtCodePostalLivraison";
            this.txtCodePostalLivraison.Size = new System.Drawing.Size(96, 20);
            this.txtCodePostalLivraison.TabIndex = 20;
            // 
            // lblCodePostalLivraison
            // 
            this.lblCodePostalLivraison.AutoSize = true;
            this.lblCodePostalLivraison.Location = new System.Drawing.Point(14, 402);
            this.lblCodePostalLivraison.Name = "lblCodePostalLivraison";
            this.lblCodePostalLivraison.Size = new System.Drawing.Size(64, 13);
            this.lblCodePostalLivraison.TabIndex = 19;
            this.lblCodePostalLivraison.Text = "Code Postal";
            // 
            // txtRueLivraison
            // 
            this.txtRueLivraison.Location = new System.Drawing.Point(121, 361);
            this.txtRueLivraison.Name = "txtRueLivraison";
            this.txtRueLivraison.Size = new System.Drawing.Size(244, 20);
            this.txtRueLivraison.TabIndex = 18;
            // 
            // lblRueLivraison
            // 
            this.lblRueLivraison.AutoSize = true;
            this.lblRueLivraison.Location = new System.Drawing.Point(118, 345);
            this.lblRueLivraison.Name = "lblRueLivraison";
            this.lblRueLivraison.Size = new System.Drawing.Size(27, 13);
            this.lblRueLivraison.TabIndex = 17;
            this.lblRueLivraison.Text = "Rue";
            // 
            // txtNumeroRueLivraison
            // 
            this.txtNumeroRueLivraison.Location = new System.Drawing.Point(15, 361);
            this.txtNumeroRueLivraison.Name = "txtNumeroRueLivraison";
            this.txtNumeroRueLivraison.Size = new System.Drawing.Size(98, 20);
            this.txtNumeroRueLivraison.TabIndex = 16;
            // 
            // lblNumeroRueLivraison
            // 
            this.lblNumeroRueLivraison.AutoSize = true;
            this.lblNumeroRueLivraison.Location = new System.Drawing.Point(14, 345);
            this.lblNumeroRueLivraison.Name = "lblNumeroRueLivraison";
            this.lblNumeroRueLivraison.Size = new System.Drawing.Size(77, 13);
            this.lblNumeroRueLivraison.TabIndex = 15;
            this.lblNumeroRueLivraison.Text = "Numéro de rue";
            // 
            // lblAdresseDeLivraison
            // 
            this.lblAdresseDeLivraison.AutoSize = true;
            this.lblAdresseDeLivraison.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAdresseDeLivraison.Location = new System.Drawing.Point(13, 308);
            this.lblAdresseDeLivraison.Name = "lblAdresseDeLivraison";
            this.lblAdresseDeLivraison.Size = new System.Drawing.Size(162, 21);
            this.lblAdresseDeLivraison.TabIndex = 14;
            this.lblAdresseDeLivraison.Text = "Adresse de livraison";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(16, 287);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 1);
            this.panel2.TabIndex = 13;
            // 
            // lblVilleFacturation
            // 
            this.lblVilleFacturation.AutoSize = true;
            this.lblVilleFacturation.Location = new System.Drawing.Point(118, 225);
            this.lblVilleFacturation.Name = "lblVilleFacturation";
            this.lblVilleFacturation.Size = new System.Drawing.Size(26, 13);
            this.lblVilleFacturation.TabIndex = 11;
            this.lblVilleFacturation.Text = "Ville";
            // 
            // txtVilleFacturation
            // 
            this.txtVilleFacturation.Location = new System.Drawing.Point(121, 241);
            this.txtVilleFacturation.Name = "txtVilleFacturation";
            this.txtVilleFacturation.Size = new System.Drawing.Size(244, 20);
            this.txtVilleFacturation.TabIndex = 12;
            // 
            // txtCodePostalFacturation
            // 
            this.txtCodePostalFacturation.Location = new System.Drawing.Point(15, 241);
            this.txtCodePostalFacturation.Name = "txtCodePostalFacturation";
            this.txtCodePostalFacturation.Size = new System.Drawing.Size(100, 20);
            this.txtCodePostalFacturation.TabIndex = 10;
            // 
            // lblCodePostalFacturation
            // 
            this.lblCodePostalFacturation.AutoSize = true;
            this.lblCodePostalFacturation.Location = new System.Drawing.Point(13, 225);
            this.lblCodePostalFacturation.Name = "lblCodePostalFacturation";
            this.lblCodePostalFacturation.Size = new System.Drawing.Size(63, 13);
            this.lblCodePostalFacturation.TabIndex = 9;
            this.lblCodePostalFacturation.Text = "Code postal";
            // 
            // txtRueFacturation
            // 
            this.txtRueFacturation.Location = new System.Drawing.Point(121, 182);
            this.txtRueFacturation.Name = "txtRueFacturation";
            this.txtRueFacturation.Size = new System.Drawing.Size(244, 20);
            this.txtRueFacturation.TabIndex = 8;
            // 
            // lblRueFacturation
            // 
            this.lblRueFacturation.AutoSize = true;
            this.lblRueFacturation.Location = new System.Drawing.Point(118, 166);
            this.lblRueFacturation.Name = "lblRueFacturation";
            this.lblRueFacturation.Size = new System.Drawing.Size(27, 13);
            this.lblRueFacturation.TabIndex = 7;
            this.lblRueFacturation.Text = "Rue";
            // 
            // txtNumeroRueFacturation
            // 
            this.txtNumeroRueFacturation.Location = new System.Drawing.Point(15, 182);
            this.txtNumeroRueFacturation.Name = "txtNumeroRueFacturation";
            this.txtNumeroRueFacturation.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroRueFacturation.TabIndex = 6;
            // 
            // lblNumeroRueFacturation
            // 
            this.lblNumeroRueFacturation.AutoSize = true;
            this.lblNumeroRueFacturation.Location = new System.Drawing.Point(13, 166);
            this.lblNumeroRueFacturation.Name = "lblNumeroRueFacturation";
            this.lblNumeroRueFacturation.Size = new System.Drawing.Size(77, 13);
            this.lblNumeroRueFacturation.TabIndex = 5;
            this.lblNumeroRueFacturation.Text = "Numéro de rue";
            // 
            // lblAdresseDeFacturation
            // 
            this.lblAdresseDeFacturation.AutoSize = true;
            this.lblAdresseDeFacturation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAdresseDeFacturation.Location = new System.Drawing.Point(12, 128);
            this.lblAdresseDeFacturation.Name = "lblAdresseDeFacturation";
            this.lblAdresseDeFacturation.Size = new System.Drawing.Size(181, 21);
            this.lblAdresseDeFacturation.TabIndex = 4;
            this.lblAdresseDeFacturation.Text = "Adresse de facturation";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(15, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 1);
            this.panel1.TabIndex = 3;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(15, 67);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(350, 20);
            this.txtNom.TabIndex = 2;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(12, 51);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 1;
            this.lblNom.Text = "Nom";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetail.Location = new System.Drawing.Point(11, 13);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(56, 21);
            this.lblDetail.TabIndex = 0;
            this.lblDetail.Text = "Détail";
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
            // AdresseFacturation
            // 
            this.AdresseFacturation.HeaderText = "Adresse fact.";
            this.AdresseFacturation.Name = "AdresseFacturation";
            this.AdresseFacturation.Width = 175;
            // 
            // AdresseLivraison
            // 
            this.AdresseLivraison.HeaderText = "Adresse livr.";
            this.AdresseLivraison.Name = "AdresseLivraison";
            this.AdresseLivraison.Width = 175;
            // 
            // Téléphone
            // 
            this.Téléphone.HeaderText = "tél.";
            this.Téléphone.Name = "Téléphone";
            // 
            // Fax
            // 
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 175;
            // 
            // NumRueFact
            // 
            this.NumRueFact.HeaderText = "Numéro de rue de facturation";
            this.NumRueFact.Name = "NumRueFact";
            this.NumRueFact.Visible = false;
            // 
            // RueFact
            // 
            this.RueFact.HeaderText = "Nom de la rue de facturation";
            this.RueFact.Name = "RueFact";
            this.RueFact.Visible = false;
            // 
            // VilleFact
            // 
            this.VilleFact.HeaderText = "Ville de facturation";
            this.VilleFact.Name = "VilleFact";
            this.VilleFact.Visible = false;
            // 
            // CodePostalFact
            // 
            this.CodePostalFact.HeaderText = "Code postal de facturation";
            this.CodePostalFact.Name = "CodePostalFact";
            this.CodePostalFact.Visible = false;
            // 
            // NumRueLiv
            // 
            this.NumRueLiv.HeaderText = "Numéro de rue de livraison";
            this.NumRueLiv.Name = "NumRueLiv";
            this.NumRueLiv.Visible = false;
            // 
            // RueLiv
            // 
            this.RueLiv.HeaderText = "Nom de la rue de livraison";
            this.RueLiv.Name = "RueLiv";
            this.RueLiv.Visible = false;
            // 
            // VilleLiv
            // 
            this.VilleLiv.HeaderText = "Ville de livraison";
            this.VilleLiv.Name = "VilleLiv";
            this.VilleLiv.Visible = false;
            // 
            // CodePostalLiv
            // 
            this.CodePostalLiv.HeaderText = "Code postal de livraison";
            this.CodePostalLiv.Name = "CodePostalLiv";
            this.CodePostalLiv.Visible = false;
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 826);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.dgvClient);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmClient";
            this.Text = "FrmClient";
            this.Load += new System.EventHandler(this.FrmClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAdresseDeFacturation;
        private System.Windows.Forms.TextBox txtNumeroRueFacturation;
        private System.Windows.Forms.Label lblNumeroRueFacturation;
        private System.Windows.Forms.Label lblRueFacturation;
        private System.Windows.Forms.Label lblVilleFacturation;
        private System.Windows.Forms.TextBox txtVilleFacturation;
        private System.Windows.Forms.TextBox txtCodePostalFacturation;
        private System.Windows.Forms.Label lblCodePostalFacturation;
        private System.Windows.Forms.TextBox txtRueFacturation;
        private System.Windows.Forms.Label lblCodePostalLivraison;
        private System.Windows.Forms.TextBox txtRueLivraison;
        private System.Windows.Forms.Label lblRueLivraison;
        private System.Windows.Forms.TextBox txtNumeroRueLivraison;
        private System.Windows.Forms.Label lblNumeroRueLivraison;
        private System.Windows.Forms.Label lblAdresseDeLivraison;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtVilleLivraison;
        private System.Windows.Forms.Label lblVilleLivraison;
        private System.Windows.Forms.TextBox txtCodePostalLivraison;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdresseFacturation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdresseLivraison;
        private System.Windows.Forms.DataGridViewTextBoxColumn Téléphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumRueFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn RueFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn VilleFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodePostalFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumRueLiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn RueLiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn VilleLiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodePostalLiv;
    }
}