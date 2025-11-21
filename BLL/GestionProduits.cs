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
            return ProduitDAO.UpdateProduit(p);
        }

        public static bool ProduitUtilise(int code)
        {
            return ProduitDAO.ProduitEstUtilise(code);
        }

        public static int SupprimerProduit(int code)
        {
            return ProduitDAO.DeleteProduit(code);
        }

        public static int AjouterProduit(ProduitBO produit)
        {
            return ProduitDAO.AddProduit(produit);
        }

        public static bool ProduitExiste(string libelle)
        {
            return ProduitDAO.ProduitExiste(libelle);
        }

    }
}
