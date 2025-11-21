using BLL;
using BO;
using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaGestionCommerciale
{
    public partial class FrmAjoutDeProduit : Form
    {
        public FrmAjoutDeProduit()
        {
            InitializeComponent();
        }

        private void FrmAjoutDeProduit_Load(object sender, EventArgs e)
        {
            try
            {
                // Récupération des catégories depuis la BLL
                List<Categorie> lesCategories = GestionProduits.GetCategories();

                // Récupérer toutes les catégories 
                cmbCategorie.DataSource = lesCategories;
                cmbCategorie.DisplayMember = "NomCategorie"; 
                cmbCategorie.ValueMember = "IdCategorie";
                cmbCategorie.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des catégories : " + ex.Message);
            }
        }

        private void btnAjoutDeProduit_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupération des valeurs
                string libelle = txtLibelle.Text?.Trim();
                string prixText = txtPrixDeVenteHT.Text?.Trim();
                var categorie = cmbCategorie.SelectedItem;

                // Vérification des champs vides
                if (string.IsNullOrWhiteSpace(libelle) ||
                    string.IsNullOrWhiteSpace(prixText) ||
                    categorie == null)
                {
                    MessageBox.Show("Veuillez remplir les champs vides.",
                                    "Champs manquants",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Vérification si le produit existe déjà
                if (GestionProduits.ProduitExiste(libelle))
                {
                    MessageBox.Show("Un produit portant ce libellé existe déjà.",
                                    "Doublon",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Vérification et conversion du prix
                prixText = prixText.Replace('.', ',');
                if (!float.TryParse(prixText, out float prix) || prix <= 0)
                {
                    MessageBox.Show("Le prix saisi n'est pas valide (ex : 12,34).",
                                    "Prix invalide",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Cast catégorie
                Categorie cat = (Categorie)categorie;

                // Création du produit
                ProduitBO produit = new ProduitBO(0, libelle, cat, prix);

                // Enregistrement
                int resultat = GestionProduits.AjouterProduit(produit);

                if (resultat > 0)
                {
                    MessageBox.Show("Produit ajouté avec succès !");
                    ViderChamps();
                }
                else
                {
                    MessageBox.Show("Aucun produit ajouté.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            // Ouvre le formulaire FrmProduits
            FrmProduit Produit = new FrmProduit();
            Produit.Show();

            // Ferme le formulaire actuel
            this.Close();
        }

        private void ViderChamps()
        {
            txtLibelle.Clear();
            txtPrixDeVenteHT.Clear();
            cmbCategorie.SelectedIndex = -1;
            txtLibelle.Focus(); 
        }
    }
}