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
            this.lblTitre = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listeDesClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerLesClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesProduitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerLesProduitsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnProduitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesDevisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerLesDevisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnDevisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synthèseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Location = new System.Drawing.Point(33, 78);
            this.btnAddClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(203, 43);
            this.btnAddClient.TabIndex = 1;
            this.btnAddClient.Text = "Ajouter un client";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
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
            this.dgvClient.Location = new System.Drawing.Point(33, 142);
            this.dgvClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.RowHeadersVisible = false;
            this.dgvClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClient.Size = new System.Drawing.Size(1243, 818);
            this.dgvClient.TabIndex = 0;
            this.dgvClient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClient_SelectionChanged);
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
            this.pnlDetail.Location = new System.Drawing.Point(1336, 142);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(506, 818);
            this.pnlDetail.TabIndex = 2;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Red;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(299, 736);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(151, 50);
            this.btnSupprimer.TabIndex = 31;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.LimeGreen;
            this.btnModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(59, 736);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(155, 50);
            this.btnModifier.TabIndex = 30;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(24, 674);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(460, 22);
            this.txtEmail.TabIndex = 29;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 655);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "Email";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(245, 607);
            this.txtFax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(240, 22);
            this.txtFax.TabIndex = 27;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(241, 587);
            this.lblFax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(29, 16);
            this.lblFax.TabIndex = 26;
            this.lblFax.Text = "Fax";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(23, 607);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(209, 22);
            this.txtTelephone.TabIndex = 25;
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(20, 587);
            this.lblTelephone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(73, 16);
            this.lblTelephone.TabIndex = 24;
            this.lblTelephone.Text = "Téléphone";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(24, 566);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 1);
            this.panel3.TabIndex = 23;
            // 
            // txtVilleLivraison
            // 
            this.txtVilleLivraison.Location = new System.Drawing.Point(159, 514);
            this.txtVilleLivraison.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVilleLivraison.Name = "txtVilleLivraison";
            this.txtVilleLivraison.Size = new System.Drawing.Size(325, 22);
            this.txtVilleLivraison.TabIndex = 22;
            // 
            // lblVilleLivraison
            // 
            this.lblVilleLivraison.AutoSize = true;
            this.lblVilleLivraison.Location = new System.Drawing.Point(157, 495);
            this.lblVilleLivraison.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVilleLivraison.Name = "lblVilleLivraison";
            this.lblVilleLivraison.Size = new System.Drawing.Size(33, 16);
            this.lblVilleLivraison.TabIndex = 21;
            this.lblVilleLivraison.Text = "Ville";
            // 
            // txtCodePostalLivraison
            // 
            this.txtCodePostalLivraison.Location = new System.Drawing.Point(23, 514);
            this.txtCodePostalLivraison.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodePostalLivraison.Name = "txtCodePostalLivraison";
            this.txtCodePostalLivraison.Size = new System.Drawing.Size(127, 22);
            this.txtCodePostalLivraison.TabIndex = 20;
            // 
            // lblCodePostalLivraison
            // 
            this.lblCodePostalLivraison.AutoSize = true;
            this.lblCodePostalLivraison.Location = new System.Drawing.Point(19, 495);
            this.lblCodePostalLivraison.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodePostalLivraison.Name = "lblCodePostalLivraison";
            this.lblCodePostalLivraison.Size = new System.Drawing.Size(81, 16);
            this.lblCodePostalLivraison.TabIndex = 19;
            this.lblCodePostalLivraison.Text = "Code Postal";
            // 
            // txtRueLivraison
            // 
            this.txtRueLivraison.Location = new System.Drawing.Point(161, 444);
            this.txtRueLivraison.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRueLivraison.Name = "txtRueLivraison";
            this.txtRueLivraison.Size = new System.Drawing.Size(324, 22);
            this.txtRueLivraison.TabIndex = 18;
            // 
            // lblRueLivraison
            // 
            this.lblRueLivraison.AutoSize = true;
            this.lblRueLivraison.Location = new System.Drawing.Point(157, 425);
            this.lblRueLivraison.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRueLivraison.Name = "lblRueLivraison";
            this.lblRueLivraison.Size = new System.Drawing.Size(32, 16);
            this.lblRueLivraison.TabIndex = 17;
            this.lblRueLivraison.Text = "Rue";
            // 
            // txtNumeroRueLivraison
            // 
            this.txtNumeroRueLivraison.Location = new System.Drawing.Point(20, 444);
            this.txtNumeroRueLivraison.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumeroRueLivraison.Name = "txtNumeroRueLivraison";
            this.txtNumeroRueLivraison.Size = new System.Drawing.Size(129, 22);
            this.txtNumeroRueLivraison.TabIndex = 16;
            // 
            // lblNumeroRueLivraison
            // 
            this.lblNumeroRueLivraison.AutoSize = true;
            this.lblNumeroRueLivraison.Location = new System.Drawing.Point(19, 425);
            this.lblNumeroRueLivraison.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroRueLivraison.Name = "lblNumeroRueLivraison";
            this.lblNumeroRueLivraison.Size = new System.Drawing.Size(96, 16);
            this.lblNumeroRueLivraison.TabIndex = 15;
            this.lblNumeroRueLivraison.Text = "Numéro de rue";
            // 
            // lblAdresseDeLivraison
            // 
            this.lblAdresseDeLivraison.AutoSize = true;
            this.lblAdresseDeLivraison.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAdresseDeLivraison.Location = new System.Drawing.Point(17, 379);
            this.lblAdresseDeLivraison.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdresseDeLivraison.Name = "lblAdresseDeLivraison";
            this.lblAdresseDeLivraison.Size = new System.Drawing.Size(162, 21);
            this.lblAdresseDeLivraison.TabIndex = 14;
            this.lblAdresseDeLivraison.Text = "Adresse de livraison";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(21, 353);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 1);
            this.panel2.TabIndex = 13;
            // 
            // lblVilleFacturation
            // 
            this.lblVilleFacturation.AutoSize = true;
            this.lblVilleFacturation.Location = new System.Drawing.Point(157, 277);
            this.lblVilleFacturation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVilleFacturation.Name = "lblVilleFacturation";
            this.lblVilleFacturation.Size = new System.Drawing.Size(33, 16);
            this.lblVilleFacturation.TabIndex = 11;
            this.lblVilleFacturation.Text = "Ville";
            // 
            // txtVilleFacturation
            // 
            this.txtVilleFacturation.Location = new System.Drawing.Point(161, 297);
            this.txtVilleFacturation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVilleFacturation.Name = "txtVilleFacturation";
            this.txtVilleFacturation.Size = new System.Drawing.Size(324, 22);
            this.txtVilleFacturation.TabIndex = 12;
            // 
            // txtCodePostalFacturation
            // 
            this.txtCodePostalFacturation.Location = new System.Drawing.Point(20, 297);
            this.txtCodePostalFacturation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodePostalFacturation.Name = "txtCodePostalFacturation";
            this.txtCodePostalFacturation.Size = new System.Drawing.Size(132, 22);
            this.txtCodePostalFacturation.TabIndex = 10;
            // 
            // lblCodePostalFacturation
            // 
            this.lblCodePostalFacturation.AutoSize = true;
            this.lblCodePostalFacturation.Location = new System.Drawing.Point(17, 277);
            this.lblCodePostalFacturation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodePostalFacturation.Name = "lblCodePostalFacturation";
            this.lblCodePostalFacturation.Size = new System.Drawing.Size(80, 16);
            this.lblCodePostalFacturation.TabIndex = 9;
            this.lblCodePostalFacturation.Text = "Code postal";
            // 
            // txtRueFacturation
            // 
            this.txtRueFacturation.Location = new System.Drawing.Point(161, 224);
            this.txtRueFacturation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRueFacturation.Name = "txtRueFacturation";
            this.txtRueFacturation.Size = new System.Drawing.Size(324, 22);
            this.txtRueFacturation.TabIndex = 8;
            // 
            // lblRueFacturation
            // 
            this.lblRueFacturation.AutoSize = true;
            this.lblRueFacturation.Location = new System.Drawing.Point(157, 204);
            this.lblRueFacturation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRueFacturation.Name = "lblRueFacturation";
            this.lblRueFacturation.Size = new System.Drawing.Size(32, 16);
            this.lblRueFacturation.TabIndex = 7;
            this.lblRueFacturation.Text = "Rue";
            // 
            // txtNumeroRueFacturation
            // 
            this.txtNumeroRueFacturation.Location = new System.Drawing.Point(20, 224);
            this.txtNumeroRueFacturation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumeroRueFacturation.Name = "txtNumeroRueFacturation";
            this.txtNumeroRueFacturation.Size = new System.Drawing.Size(132, 22);
            this.txtNumeroRueFacturation.TabIndex = 6;
            // 
            // lblNumeroRueFacturation
            // 
            this.lblNumeroRueFacturation.AutoSize = true;
            this.lblNumeroRueFacturation.Location = new System.Drawing.Point(17, 204);
            this.lblNumeroRueFacturation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroRueFacturation.Name = "lblNumeroRueFacturation";
            this.lblNumeroRueFacturation.Size = new System.Drawing.Size(96, 16);
            this.lblNumeroRueFacturation.TabIndex = 5;
            this.lblNumeroRueFacturation.Text = "Numéro de rue";
            // 
            // lblAdresseDeFacturation
            // 
            this.lblAdresseDeFacturation.AutoSize = true;
            this.lblAdresseDeFacturation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAdresseDeFacturation.Location = new System.Drawing.Point(16, 158);
            this.lblAdresseDeFacturation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdresseDeFacturation.Name = "lblAdresseDeFacturation";
            this.lblAdresseDeFacturation.Size = new System.Drawing.Size(181, 21);
            this.lblAdresseDeFacturation.TabIndex = 4;
            this.lblAdresseDeFacturation.Text = "Adresse de facturation";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(20, 137);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 1);
            this.panel1.TabIndex = 3;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(20, 82);
            this.txtNom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(465, 22);
            this.txtNom.TabIndex = 2;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(16, 63);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(36, 16);
            this.lblNom.TabIndex = 1;
            this.lblNom.Text = "Nom";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetail.Location = new System.Drawing.Point(15, 16);
            this.lblDetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(56, 21);
            this.lblDetail.TabIndex = 0;
            this.lblDetail.Text = "Détail";
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblTitre.Location = new System.Drawing.Point(780, 78);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(185, 29);
            this.lblTitre.TabIndex = 3;
            this.lblTitre.Text = "Liste des clients";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesClientsToolStripMenuItem,
            this.listeDesProduitsToolStripMenuItem,
            this.listeDesDevisToolStripMenuItem,
            this.synthèseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1924, 27);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // listeDesClientsToolStripMenuItem
            // 
            this.listeDesClientsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listeDesClientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gérerLesClientsToolStripMenuItem,
            this.ajouterUnClientToolStripMenuItem});
            this.listeDesClientsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listeDesClientsToolStripMenuItem.Name = "listeDesClientsToolStripMenuItem";
            this.listeDesClientsToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.listeDesClientsToolStripMenuItem.Text = "Clients";
            // 
            // gérerLesClientsToolStripMenuItem
            // 
            this.gérerLesClientsToolStripMenuItem.Name = "gérerLesClientsToolStripMenuItem";
            this.gérerLesClientsToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.gérerLesClientsToolStripMenuItem.Text = "Gérer les clients";
            // 
            // ajouterUnClientToolStripMenuItem
            // 
            this.ajouterUnClientToolStripMenuItem.Name = "ajouterUnClientToolStripMenuItem";
            this.ajouterUnClientToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.ajouterUnClientToolStripMenuItem.Text = "Ajouter un client";
            this.ajouterUnClientToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnClientToolStripMenuItem_Click);
            // 
            // listeDesProduitsToolStripMenuItem
            // 
            this.listeDesProduitsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listeDesProduitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gérerLesProduitsToolStripMenuItem1,
            this.ajouterUnProduitToolStripMenuItem1});
            this.listeDesProduitsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listeDesProduitsToolStripMenuItem.Name = "listeDesProduitsToolStripMenuItem";
            this.listeDesProduitsToolStripMenuItem.Size = new System.Drawing.Size(72, 23);
            this.listeDesProduitsToolStripMenuItem.Text = "Produits";
            // 
            // gérerLesProduitsToolStripMenuItem1
            // 
            this.gérerLesProduitsToolStripMenuItem1.Name = "gérerLesProduitsToolStripMenuItem1";
            this.gérerLesProduitsToolStripMenuItem1.Size = new System.Drawing.Size(192, 24);
            this.gérerLesProduitsToolStripMenuItem1.Text = "Gérer les produits";
            this.gérerLesProduitsToolStripMenuItem1.Click += new System.EventHandler(this.gérerLesProduitsToolStripMenuItem1_Click);
            // 
            // ajouterUnProduitToolStripMenuItem1
            // 
            this.ajouterUnProduitToolStripMenuItem1.Name = "ajouterUnProduitToolStripMenuItem1";
            this.ajouterUnProduitToolStripMenuItem1.Size = new System.Drawing.Size(192, 24);
            this.ajouterUnProduitToolStripMenuItem1.Text = "Ajouter un produit";
            this.ajouterUnProduitToolStripMenuItem1.Click += new System.EventHandler(this.ajouterUnProduitToolStripMenuItem1_Click);
            // 
            // listeDesDevisToolStripMenuItem
            // 
            this.listeDesDevisToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listeDesDevisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gérerLesDevisToolStripMenuItem,
            this.ajouterUnDevisToolStripMenuItem});
            this.listeDesDevisToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listeDesDevisToolStripMenuItem.Name = "listeDesDevisToolStripMenuItem";
            this.listeDesDevisToolStripMenuItem.Size = new System.Drawing.Size(54, 23);
            this.listeDesDevisToolStripMenuItem.Text = "Devis";
            // 
            // gérerLesDevisToolStripMenuItem
            // 
            this.gérerLesDevisToolStripMenuItem.Name = "gérerLesDevisToolStripMenuItem";
            this.gérerLesDevisToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.gérerLesDevisToolStripMenuItem.Text = "Gérer les devis";
            // 
            // ajouterUnDevisToolStripMenuItem
            // 
            this.ajouterUnDevisToolStripMenuItem.Name = "ajouterUnDevisToolStripMenuItem";
            this.ajouterUnDevisToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.ajouterUnDevisToolStripMenuItem.Text = "Ajouter un devis";
            // 
            // synthèseToolStripMenuItem
            // 
            this.synthèseToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.synthèseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.synthèseToolStripMenuItem.Name = "synthèseToolStripMenuItem";
            this.synthèseToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.synthèseToolStripMenuItem.Text = "Synthèse";
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1924, 1017);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.dgvClient);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmClient";
            this.Text = "FrmClient";
            this.Load += new System.EventHandler(this.FrmClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listeDesClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerLesClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesProduitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerLesProduitsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnProduitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listeDesDevisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem synthèseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerLesDevisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnDevisToolStripMenuItem;
    }
}