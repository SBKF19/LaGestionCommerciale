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

namespace LaGestionCommerciale
{
    public partial class FrmClient : Form
    {
        public FrmClient()
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

        private void FrmClient_Load(object sender, EventArgs e)
        {
            // Récupérer la liste des produits depuis la BLL
            List<Client> lesClients = GestionClients.GetClients();

            // Active le retour à la ligne
            dgvClient.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // Autoriser les lignes à s’ajuster en hauteur
            dgvClient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Afficher les données dans le DataGridView
            dgvClient.Rows.Clear();

            foreach (var c in lesClients)
            {
                dgvClient.Rows.Add(c.IdClient, c.NomClient, c.NumRueFacture + " " + c.NomRueFacture + ", " + c.VilleFacture + " " + c.CodePostalFacture, c.NumRueLivraison 
                    + " " + c.NomRueLivraison + ", " + c.VilleLivraison + " " + c.CodePostalLivraison, c.NumPhoneClient, c.NumFaxClient, c.MailClient);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
