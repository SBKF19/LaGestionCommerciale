using BLL;
using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            GestionDevis.SetchaineConnexion(chset);
        }

        private void FrmDevis_Load(object sender, EventArgs e)
        {
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
