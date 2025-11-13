using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BO; 

namespace DAL
{
    // Classe de gestion des accès à la table Produit
    public class ProduitDAO
    {
        // Instance unique de ProduitDAO
        private static ProduitDAO unProduitDAO;

        // Accesseur en lecture - renvoie une instance unique
        public static ProduitDAO GetProduitDAO()
        {
            if (unProduitDAO == null)
            {
                unProduitDAO = new ProduitDAO();
            }
            return unProduitDAO;
        }

        // Constructeur privé (empêche l’instanciation directe)
        private ProduitDAO() { }

        // MÉTHODE : Récupère un produit par son identifiant
        public static ProduitBO GetProduitById(int id)
        {
            int idProduit;
            string libelle;
            int idCategorie;
            float prix = 0f;
            ProduitBO unProduit = null;

            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            // Commande SQL
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "SELECT * FROM Produit WHERE id_produit = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader monReader = cmd.ExecuteReader();

            // Lecture du résultat
            if (monReader.Read())
            {
                idProduit = Convert.ToInt32(monReader["id_produit"]);
                libelle = monReader["libelle_produit"].ToString();
                idCategorie = Convert.ToInt32(monReader["id_categorie"]);

                if (monReader["prix_vente_HT_produit"] != DBNull.Value)
                {
                    prix = Convert.ToSingle(monReader["prix_vente_HT_produit"]);
                }

                // Création de l’objet Categorie
                Categorie uneCategorie = new Categorie(idCategorie, "");

                // Création du produit
                unProduit = new ProduitBO(idProduit, libelle, uneCategorie, prix);
            }

            // Fermeture du reader et de la connexion
            monReader.Close();
            maConnexion.Close();

            return unProduit;
        }

        // MÉTHODE : Récupère la liste de tous les produits
        public static List<ProduitBO> GetProduits()
        {
            int idProduit;
            string libelle;
            int idCategorie;
            string nomCategorie;
            float prix = 0f;

            ProduitBO unProduit;
            List<ProduitBO> lesProduits = new List<ProduitBO>();

            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            // Commande SQL
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "SELECT p.id_produit, p.libelle_produit, p.id_categorie, c.nom_categorie, p.prix_vente_HT_produit " +
                              "FROM Produit p INNER JOIN Categorie c ON p.id_categorie = c.id_categorie;";

            SqlDataReader monReader = cmd.ExecuteReader();

            // Remplissage de la liste
            while (monReader.Read())
            {
                idProduit = Convert.ToInt32(monReader["id_produit"]);
                libelle = monReader["libelle_produit"].ToString();
                idCategorie = Convert.ToInt32(monReader["id_categorie"]);
                nomCategorie = monReader["nom_categorie"].ToString();

                if (monReader["prix_vente_HT_produit"] != DBNull.Value)
                {
                    prix = Convert.ToSingle(monReader["prix_vente_HT_produit"]);
                }

                Categorie uneCategorie = new Categorie(idCategorie, nomCategorie);
                unProduit = new ProduitBO(idProduit, libelle, uneCategorie, prix);

                lesProduits.Add(unProduit);
            }

            // Fermeture du reader et de la connexion
            monReader.Close();
            maConnexion.Close();

            return lesProduits;
        }

        // MÉTHODE : Met à jour un produit passé en paramètre
        public static int UpdateProduit(ProduitBO unProduit)
        {
            int nbEnr;

            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            // Commande SQL paramétrée
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "UPDATE Produit " +
                              "SET libelle_produit = @lib, id_categorie = @cat, prix_vente_HT_produit = @prix " +
                              "WHERE id_produit = @id";

            cmd.Parameters.AddWithValue("@lib", unProduit.Libelle);
            cmd.Parameters.AddWithValue("@cat", unProduit.Categorie.IdCategorie);

            // Gestion du type SQL Decimal pour la colonne prix
            SqlParameter paramPrix = new SqlParameter("@prix", SqlDbType.Float)
            {
                Precision = 18,
                Scale = 2,
                Value = (unProduit.Prix)
            };
            cmd.Parameters.Add(paramPrix);

            cmd.Parameters.AddWithValue("@id", unProduit.Code);

            // Exécution
            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();

            return nbEnr;
        }

        // MÉTHODE : Supprime un produit par son identifiant
        public static int DeleteProduit(int id)
        {
            int nbEnr;

            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            // Commande SQL paramétrée
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "DELETE FROM Produit WHERE id_produit = @id";
            cmd.Parameters.AddWithValue("@id", id);

            // Exécution
            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();

            return nbEnr;
        }
    }
}
