namespace LaGestionCommerciale
{
    partial class FrmAjoutDeProduit
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
            this.lblAjoutDeProduit = new System.Windows.Forms.Label();
            this.lblLibelle = new System.Windows.Forms.Label();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.lblPrixDeVenteHT = new System.Windows.Forms.Label();
            this.txtPrixDeVenteHT = new System.Windows.Forms.TextBox();
            this.btnAjoutDeProduit = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAjoutDeProduit
            // 
            this.lblAjoutDeProduit.AutoSize = true;
            this.lblAjoutDeProduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblAjoutDeProduit.Location = new System.Drawing.Point(285, 29);
            this.lblAjoutDeProduit.Name = "lblAjoutDeProduit";
            this.lblAjoutDeProduit.Size = new System.Drawing.Size(203, 31);
            this.lblAjoutDeProduit.TabIndex = 0;
            this.lblAjoutDeProduit.Text = "Ajout de produit";
            this.lblAjoutDeProduit.Click += new System.EventHandler(this.lblAjoutDeProduit_Click);
            // 
            // lblLibelle
            // 
            this.lblLibelle.AutoSize = true;
            this.lblLibelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblLibelle.Location = new System.Drawing.Point(180, 107);
            this.lblLibelle.Name = "lblLibelle";
            this.lblLibelle.Size = new System.Drawing.Size(44, 15);
            this.lblLibelle.TabIndex = 1;
            this.lblLibelle.Text = "Libellé";
            this.lblLibelle.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtLibelle
            // 
            this.txtLibelle.Location = new System.Drawing.Point(183, 125);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(422, 20);
            this.txtLibelle.TabIndex = 2;
            this.txtLibelle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblCategorie
            // 
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCategorie.Location = new System.Drawing.Point(180, 178);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(60, 15);
            this.lblCategorie.TabIndex = 3;
            this.lblCategorie.Text = "Catégorie";
            this.lblCategorie.Click += new System.EventHandler(this.lblCategorie_Click);
            // 
            // cmbCategorie
            // 
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Location = new System.Drawing.Point(183, 196);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(422, 21);
            this.cmbCategorie.TabIndex = 4;
            // 
            // lblPrixDeVenteHT
            // 
            this.lblPrixDeVenteHT.AutoSize = true;
            this.lblPrixDeVenteHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblPrixDeVenteHT.Location = new System.Drawing.Point(180, 256);
            this.lblPrixDeVenteHT.Name = "lblPrixDeVenteHT";
            this.lblPrixDeVenteHT.Size = new System.Drawing.Size(130, 15);
            this.lblPrixDeVenteHT.TabIndex = 5;
            this.lblPrixDeVenteHT.Text = "Prix de vente hors taxe";
            // 
            // txtPrixDeVenteHT
            // 
            this.txtPrixDeVenteHT.Location = new System.Drawing.Point(183, 274);
            this.txtPrixDeVenteHT.Name = "txtPrixDeVenteHT";
            this.txtPrixDeVenteHT.Size = new System.Drawing.Size(422, 20);
            this.txtPrixDeVenteHT.TabIndex = 6;
            // 
            // btnAjoutDeProduit
            // 
            this.btnAjoutDeProduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAjoutDeProduit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAjoutDeProduit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAjoutDeProduit.Location = new System.Drawing.Point(183, 326);
            this.btnAjoutDeProduit.Name = "btnAjoutDeProduit";
            this.btnAjoutDeProduit.Size = new System.Drawing.Size(422, 34);
            this.btnAjoutDeProduit.TabIndex = 7;
            this.btnAjoutDeProduit.Text = "Ajouter le produit";
            this.btnAjoutDeProduit.UseVisualStyleBackColor = true;
            this.btnAjoutDeProduit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRetour.Location = new System.Drawing.Point(183, 388);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(422, 33);
            this.btnRetour.TabIndex = 8;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            // 
            // btnAjouterLeProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnAjoutDeProduit);
            this.Controls.Add(this.txtPrixDeVenteHT);
            this.Controls.Add(this.lblPrixDeVenteHT);
            this.Controls.Add(this.cmbCategorie);
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.txtLibelle);
            this.Controls.Add(this.lblLibelle);
            this.Controls.Add(this.lblAjoutDeProduit);
            this.Name = "btnAjouterLeProduit";
            this.Text = "FrmAjoutDeProduit";
            this.Load += new System.EventHandler(this.FrmAjoutDeProduit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAjoutDeProduit;
        private System.Windows.Forms.Label lblLibelle;
        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.ComboBox cmbCategorie;
        private System.Windows.Forms.Label lblPrixDeVenteHT;
        private System.Windows.Forms.TextBox txtPrixDeVenteHT;
        private System.Windows.Forms.Button btnAjoutDeProduit;
        private System.Windows.Forms.Button btnRetour;
    }
}