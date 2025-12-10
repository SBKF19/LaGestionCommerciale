namespace GUI
{
    partial class FrmSyntheseClient
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.devisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syntheseClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFiltres = new System.Windows.Forms.Panel();
            this.lblFin = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.lblDebut = new System.Windows.Forms.Label();
            this.dtpDebut = new System.Windows.Forms.DateTimePicker();
            this.dgvSynthese = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNbDevis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNbAcceptes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPctAttente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPctRefuse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPctAccepte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelFiltres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynthese)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devisToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.produitsToolStripMenuItem,
            this.syntheseClientsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // devisToolStripMenuItem
            // 
            this.devisToolStripMenuItem.Name = "devisToolStripMenuItem";
            this.devisToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.devisToolStripMenuItem.Text = "Devis";
            this.devisToolStripMenuItem.Click += new System.EventHandler(this.devisToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.clientsToolStripMenuItem.Text = "Clients";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // syntheseClientsToolStripMenuItem
            // 
            this.syntheseClientsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.syntheseClientsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.syntheseClientsToolStripMenuItem.Name = "syntheseClientsToolStripMenuItem";
            this.syntheseClientsToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.syntheseClientsToolStripMenuItem.Text = "Synthèse clients";
            // 
            // produitsToolStripMenuItem
            // 
            this.produitsToolStripMenuItem.Name = "produitsToolStripMenuItem";
            this.produitsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.produitsToolStripMenuItem.Text = "Produits";
            this.produitsToolStripMenuItem.Click += new System.EventHandler(this.produitsToolStripMenuItem_Click);
            // 
            // panelFiltres
            // 
            this.panelFiltres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.panelFiltres.Controls.Add(this.txtReset);
            this.panelFiltres.Controls.Add(this.lblFin);
            this.panelFiltres.Controls.Add(this.dtpFin);
            this.panelFiltres.Controls.Add(this.lblDebut);
            this.panelFiltres.Controls.Add(this.dtpDebut);
            this.panelFiltres.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltres.Location = new System.Drawing.Point(0, 24);
            this.panelFiltres.Name = "panelFiltres";
            this.panelFiltres.Size = new System.Drawing.Size(1100, 70);
            this.panelFiltres.TabIndex = 1;
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFin.Location = new System.Drawing.Point(180, 15);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(48, 15);
            this.lblFin.TabIndex = 3;
            this.lblFin.Text = "Date fin";
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(180, 31);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(120, 20);
            this.dtpFin.TabIndex = 2;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtpFin_ValueChanged);
            // 
            // lblDebut
            // 
            this.lblDebut.AutoSize = true;
            this.lblDebut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDebut.Location = new System.Drawing.Point(20, 15);
            this.lblDebut.Name = "lblDebut";
            this.lblDebut.Size = new System.Drawing.Size(65, 15);
            this.lblDebut.TabIndex = 1;
            this.lblDebut.Text = "Date début";
            // 
            // dtpDebut
            // 
            this.dtpDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDebut.Location = new System.Drawing.Point(20, 31);
            this.dtpDebut.Name = "dtpDebut";
            this.dtpDebut.Size = new System.Drawing.Size(120, 20);
            this.dtpDebut.TabIndex = 0;
            this.dtpDebut.ValueChanged += new System.EventHandler(this.dtpDebut_ValueChanged);
            // 
            // dgvSynthese
            // 
            this.dgvSynthese.AllowUserToAddRows = false;
            this.dgvSynthese.AllowUserToDeleteRows = false;
            this.dgvSynthese.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSynthese.BackgroundColor = System.Drawing.Color.White;
            this.dgvSynthese.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSynthese.ColumnHeadersHeight = 40;
            this.dgvSynthese.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colNom,
            this.colNbDevis,
            this.colNbAcceptes,
            this.colPctAttente,
            this.colPctRefuse,
            this.colPctAccepte,
            this.colMontant});
            this.dgvSynthese.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSynthese.Location = new System.Drawing.Point(0, 94);
            this.dgvSynthese.Name = "dgvSynthese";
            this.dgvSynthese.ReadOnly = true;
            this.dgvSynthese.RowHeadersVisible = false;
            this.dgvSynthese.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSynthese.Size = new System.Drawing.Size(1100, 506);
            this.dgvSynthese.TabIndex = 2;
            // 
            // colCode
            // 
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colNom
            // 
            this.colNom.HeaderText = "Nom client";
            this.colNom.Name = "colNom";
            this.colNom.ReadOnly = true;
            // 
            // colNbDevis
            // 
            this.colNbDevis.HeaderText = "Nb devis";
            this.colNbDevis.Name = "colNbDevis";
            this.colNbDevis.ReadOnly = true;
            // 
            // colNbAcceptes
            // 
            this.colNbAcceptes.HeaderText = "Nb acceptés";
            this.colNbAcceptes.Name = "colNbAcceptes";
            this.colNbAcceptes.ReadOnly = true;
            // 
            // colPctAttente
            // 
            this.colPctAttente.HeaderText = "% En attente";
            this.colPctAttente.Name = "colPctAttente";
            this.colPctAttente.ReadOnly = true;
            // 
            // colPctRefuse
            // 
            this.colPctRefuse.HeaderText = "% Refusé";
            this.colPctRefuse.Name = "colPctRefuse";
            this.colPctRefuse.ReadOnly = true;
            // 
            // colPctAccepte
            // 
            this.colPctAccepte.HeaderText = "% Accepté";
            this.colPctAccepte.Name = "colPctAccepte";
            this.colPctAccepte.ReadOnly = true;
            // 
            // colMontant
            // 
            this.colMontant.HeaderText = "Montant facturé HT";
            this.colMontant.Name = "colMontant";
            this.colMontant.ReadOnly = true;
            // 
            // txtReset
            // 
            this.txtReset.Location = new System.Drawing.Point(367, 27);
            this.txtReset.Name = "txtReset";
            this.txtReset.Size = new System.Drawing.Size(75, 23);
            this.txtReset.TabIndex = 4;
            this.txtReset.Text = "Réinitialiser";
            this.txtReset.UseVisualStyleBackColor = true;
            this.txtReset.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmSyntheseClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.dgvSynthese);
            this.Controls.Add(this.panelFiltres);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmSyntheseClient";
            this.Text = "Gestion Commerciale - Synthèse clients";
            this.Load += new System.EventHandler(this.FrmSyntheseClient_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelFiltres.ResumeLayout(false);
            this.panelFiltres.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynthese)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem devisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syntheseClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produitsToolStripMenuItem;
        private System.Windows.Forms.Panel panelFiltres;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label lblDebut;
        private System.Windows.Forms.DateTimePicker dtpDebut;
        private System.Windows.Forms.DataGridView dgvSynthese;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNbDevis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNbAcceptes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPctAttente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPctRefuse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPctAccepte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontant;
        private System.Windows.Forms.Button txtReset;
    }
}