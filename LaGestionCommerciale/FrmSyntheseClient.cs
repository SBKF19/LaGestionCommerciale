using BLL;
using BO;
using LaGestionCommerciale;
using System;
using System.Collections.Generic;
using System.Configuration; // Indispensable
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmSyntheseClient : Form
    {
        public FrmSyntheseClient()
        {
            InitializeComponent();
        }

        private void FrmSyntheseClient_Load(object sender, EventArgs e)
        {
            try
            {
                // --- Étape 1 : Connexion ---
                // On récupère l'objet de configuration complet
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["gestion_commerciale"];

                if (cs == null)
                    throw new ConfigurationErrorsException("La chaîne de connexion 'gestion_commerciale' est introuvable dans App.config.");

                // On passe l'objet 'cs' entier à la BLL (Correction de ton erreur)
                GestionSynthese.SetchaineConnexion(cs);

                // Initialisation des dates (Dates de ta maquette)
                dtpDebut.Value = new DateTime(2025, 09, 30);
                dtpFin.Value = new DateTime(2025, 10, 17);

                // --- Étape 2 : Chargement ---
                ChargerDonnees();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur au démarrage : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerDonnees()
        {
            try
            {
                // Appel BLL
                List<ClientStat> lesStats = GestionSynthese.GetSyntheseClients(dtpDebut.Value, dtpFin.Value);

                dgvSynthese.Rows.Clear();

                foreach (var s in lesStats)
                {
                    dgvSynthese.Rows.Add(
                        s.Code,
                        s.NomClient,
                        s.NbDevis,
                        s.NbAcceptes,
                        s.PctAttente.ToString("0.0") + "%", // Format 50.0%
                        s.PctRefuse.ToString("0.0") + "%",
                        s.PctAccepte.ToString("0.0") + "%",
                        s.MontantFactureHT.ToString("N2") + " €" // Format monétaire
                    );
                }
                dgvSynthese.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement : {ex.Message}");
            }
        }

        private void dtpDebut_ValueChanged(object sender, EventArgs e)
        {
            ChargerDonnees();
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            ChargerDonnees();
        }

        // --- Navigation Menu ---
        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmClient().Show();
            this.Hide();
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmProduit().Show();
            this.Hide();
        }

        private void devisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDevis().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}