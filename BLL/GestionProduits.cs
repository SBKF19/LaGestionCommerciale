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

        public static int SupprimerProduit(int code)
        {
            if (ProduitDAO.ProduitEstUtilise(code) == false) { 
            return ProduitDAO.DeleteProduit(code);
            }
            else             {
                throw new Exception("Le produit est utilisé et ne peut pas être supprimé.");
            }
        }
    }
}
