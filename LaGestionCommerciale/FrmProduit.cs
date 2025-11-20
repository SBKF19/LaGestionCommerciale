using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using BLL;
using BO;
using System.Configuration;
using System.Globalization;


namespace GUI
{
    public partial class FrmProduit : Form
    {
        public FrmProduit()
        {
            InitializeComponent();
        }

        private void Produit_Load(object sender, EventArgs e)
        {
            try
            {
                //Étape 1 : établir la connexion à la base via la BLL
                var cs = ConfigurationManager.ConnectionStrings["gestion_commerciale"];
                if (cs == null)
                    throw new ConfigurationErrorsException("Connection string 'gestion_commerciale' introuvable dans le fichier de configuration.");
                string chaine = cs.ConnectionString;
                GestionProduits.SetchaineConnexion(chaine);

                cmbCategorie.DataSource = GestionProduits.GetCategories();
                cmbCategorie.DisplayMember = "NomCategorie";
                cmbCategorie.ValueMember = "IdCategorie"; 


                //Étape 2 : récupérer la liste des produits depuis la BLL
                List<ProduitBO> lesProduits = GestionProduits.GetProduits();

                //Étape 3 : afficher dans le DataGridView
                dataGridView1.Rows.Clear();

                foreach (var p in lesProduits)
                {
                    dataGridView1.Rows.Add(p.Code, p.Libelle, p.Categorie.NomCategorie, $"{p.Prix} €");
                }

                // Sélection automatique de la première ligne
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[0].Selected = true;
                    dataGridView1_SelectionChanged(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            LaGestionCommerciale.FrmAjoutDeProduit frm = new LaGestionCommerciale.FrmAjoutDeProduit();
            frm.Show();
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                txtCode.Text = row.Cells["Code"].Value?.ToString() ?? string.Empty;
                txtLibelle.Text = row.Cells["Libellé"].Value?.ToString() ?? string.Empty;
                var nomCat = row.Cells["Catégorie"].Value?.ToString();

                var categorie = cmbCategorie.Items
                    .Cast<Categorie>()
                    .FirstOrDefault(c => c.NomCategorie == nomCat);

                cmbCategorie.SelectedItem = categorie;


                var prixVal = row.Cells["Prix"].Value?.ToString() ?? string.Empty;
                if (prixVal.EndsWith(" €"))
                    prixVal = prixVal.Substring(0, prixVal.Length - 2).Trim();
                txtPrix.Text = prixVal;
            }
            else
            {
                txtCode.Text = "";
                txtLibelle.Text = "";
                cmbCategorie.SelectedIndex = -1;
                txtPrix.Text = "";
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                MessageBox.Show("Le libellé est requis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            float prix;
            var cultureFr = new CultureInfo("fr-FR"); // accepte les virgules comme séparateurs décimaux
            string prixTxt = txtPrix.Text.Replace('.', ',');

            if (!float.TryParse(prixTxt, NumberStyles.Float, cultureFr, out prix) || prix <= 0)
            {
                MessageBox.Show(
                    "Prix invalide. Utilisez un format numérique (ex : 14,99) et supérieur à 0€.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            try
            {
                Categorie macat = GestionProduits.GetCategorieByNom(cmbCategorie.Text);

                ProduitBO monprod = new ProduitBO(
                    int.Parse(txtCode.Text),
                    txtLibelle.Text,
                    macat,
                    prix
                );

                int nbLines = GestionProduits.ModifierProduit(monprod);
                if ((nbLines == 0))
                {
                    throw new Exception("Le produit n'existe pas");
                }
                var row = dataGridView1.SelectedRows[0];
                row.Cells["Libellé"].Value = txtLibelle.Text;
                row.Cells["Catégorie"].Value = cmbCategorie.Text;
                row.Cells["Prix"].Value = $"{prix} €";

                MessageBox.Show($"Produit modifié : {txtLibelle.Text} ({cmbCategorie.Text}) | {prix} €", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Impossible de modifier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Aucun produit sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Confirmer la suppression du produit '{txtLibelle.Text}' ?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int codeProduit = int.Parse(txtCode.Text);

                    if (GestionProduits.ProduitUtilise(codeProduit) == true)
                    {
                        throw new Exception("Impossible de supprimer ce produit car il est utilisé dans un devis client.");
                    }

                    int nbLines = GestionProduits.SupprimerProduit(codeProduit);
                    if (nbLines > 0) {
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                        txtCode.Text = "";
                        txtLibelle.Text = "";
                        cmbCategorie.SelectedIndex = -1;
                        txtPrix.Text = "";

                        MessageBox.Show("Produit supprimé avec succès.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception("Le produit n'existe pas");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Impossible de supprimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addProduct_Click(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1_SelectionChanged(sender, e);
            }
        }
    }
}
