using BLL;
using BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["gestion_commerciale"];

                if (cs == null)
                    throw new ConfigurationErrorsException("La chaîne de connexion 'gestion_commerciale' est introuvable dans App.config.");

                GestionSynthese.SetchaineConnexion(cs);

                DateTime min, max;

                GestionSynthese.GetLimitesDates(out min, out max);

                dtpDebut.Value = min;
                dtpFin.Value = max;

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
                List<ClientStat> lesStats;

                // Appel BLL
                if (dtpFin.Value < dtpDebut.Value) 
                {
                    lesStats = new List<ClientStat>();
                } else { 
                    lesStats = GestionSynthese.GetSyntheseClients(dtpDebut.Value, dtpFin.Value);
                }

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
            this.Hide();
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmProduit().Show();
            this.Hide();
        }

        private void devisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime min, max;

                GestionSynthese.GetLimitesDates(out min, out max);

                dtpDebut.Value = min;
                dtpFin.Value = max;

                ChargerDonnees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la réinitialisation : " + ex.Message);
            }
        }

    }
}