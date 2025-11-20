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
using BLL;
using BO;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmClient_Load(object sender, EventArgs e)
        {

        }
    }
}
