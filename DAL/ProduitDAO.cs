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

        public static bool ProduitEstUtilise(int code)
        {
            // Connexion à la BD et commande sécurisée
            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            using (SqlCommand cmd = maConnexion.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM contenir WHERE id_produit = @code";
                cmd.Parameters.Add("@code", SqlDbType.Int).Value = code;

                object result = cmd.ExecuteScalar();
                int nbEnr;
                if (result == null || result == DBNull.Value)
                {
                    nbEnr = 0;
                }
                else
                {
                    nbEnr = Convert.ToInt32(result);
                }

                if (nbEnr > 0)
                    return true;
                else
                    return false;
            }
        }

        public static int AddProduit(ProduitBO produit)
        {
            int nbEnr = 0;

            // Connexion à la base
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            // Requête SQL paramétrée
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Produit (libelle_produit, id_categorie, prix_vente_ht_produit) VALUES (@libelle, @idCat, @prix)",
                maConnexion
            );

            cmd.Parameters.AddWithValue("@libelle", produit.Libelle);
            cmd.Parameters.AddWithValue("@idCat", produit.Categorie.IdCategorie);
            cmd.Parameters.AddWithValue("@prix", produit.Prix);

            // Exécution
            nbEnr = cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            maConnexion.Close();

            return nbEnr;
        }

        // Exemple de méthode existante pour compléter ton DAO
        public static List<ProduitBO> GetProduit()
        {
            List<ProduitBO> listeProduits = new List<ProduitBO>();
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand cmd = new SqlCommand(
                "SELECT p.id_produit, p.libelle_produit, p.prix_vente_ht, c.id_categorie, c.libelle_categorie " +
                "FROM Produit p INNER JOIN Categorie c ON p.id_categorie = c.id_categorie",
                maConnexion
            );

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Categorie cat = new Categorie(
                    Convert.ToInt32(reader["id_categorie"]),
                    reader["libelle_categorie"].ToString()
                );

                ProduitBO produit = new ProduitBO(
                    Convert.ToInt32(reader["id_produit"]),
                    reader["libelle_produit"].ToString(),
                    cat,
                    Convert.ToSingle(reader["prix_vente_ht"])
                );

                listeProduits.Add(produit);
            }

            reader.Close();
            maConnexion.Close();

            return listeProduits;
        }

        // MÉTHODE : Met à jour un produit passé en paramètre
        public static int UpdateProduit(ProduitBO unProduit)
        {
            if (unProduit == null)
                throw new ArgumentNullException(nameof(unProduit), "Le produit à modifier ne peut pas être nul.");

            if (unProduit.Categorie == null)
                throw new ArgumentNullException(nameof(unProduit.Categorie), "La catégorie du produit ne peut pas être nulle.");

            int nbEnr = 0;

            try
            {
                using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = maConnexion;
                        cmd.CommandText = @"
                    UPDATE Produit 
                    SET libelle_produit = @lib, 
                        id_categorie = @cat, 
                        prix_vente_HT_produit = @prix 
                    WHERE id_produit = @id";

                        cmd.Parameters.AddWithValue("@lib", unProduit.Libelle);
                        cmd.Parameters.AddWithValue("@cat", unProduit.Categorie.IdCategorie);
                        cmd.Parameters.AddWithValue("@id", unProduit.Code);

                        // Gestion propre du prix (float)
                        SqlParameter paramPrix = new SqlParameter("@prix", SqlDbType.Float)
                        {
                            Value = unProduit.Prix
                        };
                        cmd.Parameters.Add(paramPrix);

                        nbEnr = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erreur SQL lors de la mise à jour du produit : " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la mise à jour du produit : " + ex.Message);
            }

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
