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
                // Vérification du libellé
                string libelle = txtLibelle.Text?.Trim();
                if (string.IsNullOrWhiteSpace(libelle))
                {
                    throw new Exception("Veuillez saisir un libellé.");
                }

                // Vérification prix
                string prixText = txtPrixDeVenteHT.Text?.Trim();
                if (string.IsNullOrWhiteSpace(prixText))
                {
                    throw new Exception("Veuillez saisir un prix.");
                }

                // Accepter à la fois "." et "," pour les décimales
                prixText = prixText.Replace('.', ',');

                if (!float.TryParse(prixText, out float prix))
                {
                    throw new Exception("Le prix saisi n'est pas valide. Exemple : 12,34");
                }

                if (prix <= 0)
                {
                    throw new Exception("Le prix doit être supérieur à 0.");
                }

                // Vérification catégorie sélectionnée
                if (cmbCategorie.SelectedItem == null)
                {
                    throw new Exception("Veuillez sélectionner une catégorie.");
                }

                Categorie categorie = (Categorie)cmbCategorie.SelectedItem;

                // Création du ProduitBO 
                ProduitBO produit = new ProduitBO(0, libelle, categorie, prix);

                // Appel à la BLL
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