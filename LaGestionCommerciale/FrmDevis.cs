using BLL;
using BO;
using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilisateursBLL;

namespace LaGestionCommerciale
{
    public partial class FrmDevis : Form
    {
        public FrmDevis()
        {
            InitializeComponent();

            // Initialisation de la connexion à la BD
            var chset = ConfigurationManager.ConnectionStrings["gestion_commerciale"];

            if (chset == null)
            {
                MessageBox.Show("Chaîne de connexion 'gestion_commerciale' introuvable dans App.config !");
                return;
            }

            GestionClients.SetchaineConnexion(chset);
        }

        private void FrmDevis_Load(object sender, EventArgs e)
        {
            cmbStatut.DataSource = GestionDevis.GetStatuts();
            cmbStatut.DisplayMember = "Nom_statut";
            cmbStatut.ValueMember = "IdStatut";

            cmbClient.DataSource = GestionClients.GetClients();
            cmbClient.DisplayMember = "NomClient";
            cmbClient.ValueMember = "IdClient";

            // charger la liste des devis
            List<Devis> lesDevis = GestionDevis.GetDevis();
            dgvDevis.ReadOnly = true;
            dgvDevis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevis.AllowUserToAddRows = false;

            dgvDevis.Rows.Clear();
            foreach (Devis devis in lesDevis)
            {
                dgvDevis.Rows.Add(
                    devis.IdDevis,
                    devis.Client.NomClient,
                    devis.Date_devis,
                    devis.Montant_HT_devis
                );
            }

            // Sélectionne la première ligne
            if (dgvDevis.Rows.Count > 0) { 
                dgvDevis.Rows[0].Selected = true;

            // Réactive l'événement
            dgvDevis.SelectionChanged += dgvDevis_SelectionChanged;

            // Remplit les champs pour la première ligne
            RemplirChampsDepuisLigne(0);
            }
        }

        // Événement déclenché lors de la sélection d'une ligne dans le DataGridView
        private void dgvDevis_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevis.CurrentRow != null)
            {
                RemplirChampsDepuisLigne(dgvDevis.CurrentRow.Index);
            }
        }

        private void RemplirChampsDepuisLigne(int index)
        {
            // Rows[index] permet d'accéder à la ligne cliquée
            DataGridViewRow row = dgvDevis.Rows[index];

            txtCode.Text = row.Cells["Code"].Value?.ToString();
            dtpDevis.Text = row.Cells["Date"].Value?.ToString();

        }

        private void btnAddDevis_Click(object sender, EventArgs e)
        {

        }

        private void pnlDevis_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDevis_Load_1(object sender, EventArgs e)
        {

        }
    }
}
