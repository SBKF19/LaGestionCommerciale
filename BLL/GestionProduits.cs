using System;
using System.Collections.Generic;
using System.Configuration; 
using BO;
using DAL;

namespace BLL
{
    public class GestionProduits
    {
        private static GestionProduits uneGestionProduits;

        public static GestionProduits GetGestionProduits()
        {
            if (uneGestionProduits == null)
                uneGestionProduits = new GestionProduits();
            return uneGestionProduits;
        }

        public static Categorie GetCategorieById(int id)
        {
            return DAL.CategorieDAO.GetCategorieById(id);
        }

        public static Categorie GetCategorieByNom(string nom)
        {
            return DAL.CategorieDAO.GetCategorieByNom(nom);
        }

        public static List<Categorie> GetCategories()
        {
            return DAL.CategorieDAO.GetCategories();
        }

        public static void SetchaineConnexion(string chaine)
        {
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        public static List<ProduitBO> GetProduits()
        {
            return ProduitDAO.GetProduits();
        }

        public static int ModifierProduit(ProduitBO p)
        {
            if (ProduitDAO.UpdateProduit(p) != -1 && ProduitDAO.UpdateProduit(p) != 69)
            {
                return ProduitDAO.UpdateProduit(p);
            }
            else if (ProduitDAO.UpdateProduit(p) == 69)
            {
                throw new Exception("Veuillez remplir tous les champs");
            }
            else if (ProduitDAO.UpdateProduit(p) == -1)
            {
                throw new Exception("Veuillez saisir un prix supérieur à 0");
            }
            else
            {
                throw new Exception("Une erreur est survenue lors de la modification du produit.");
            }
        }

        public static int SupprimerProduit(int code)
        {
            if (ProduitDAO.ProduitEstUtilise(code) == false) { 
            return ProduitDAO.DeleteProduit(code);
            }
            else             {
                throw new Exception("Le produit est utilisé et ne peut pas être supprimé.");
            }
        }

        public static int AjouterProduit(ProduitBO produit)
        {
            // Validation métier (couche BLL)
            if (string.IsNullOrWhiteSpace(produit.Libelle))
                throw new Exception("Le libellé du produit est obligatoire.");

            if (produit.Prix <= 0)
                throw new Exception("Le prix doit être supérieur à 0.");

            if (produit.Categorie == null)
                throw new Exception("Une catégorie doit être sélectionnée.");

            // Appel à la DAL
            return ProduitDAO.AddProduit(produit);
        }
    }
}
