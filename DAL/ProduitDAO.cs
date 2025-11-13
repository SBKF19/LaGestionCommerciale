using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BO;

namespace DAL
{
    public class ProduitDAO
    {
        // Récupère un produit par ID
        public static ProduitBO GetProduitById(int id)
        {
            ProduitBO produit = null;

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Produit WHERE id_produit = @id", maConnexion);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader monReader = cmd.ExecuteReader();

                if (monReader.Read())
                {
                    var categorie = new Categorie(
                        Convert.ToInt32(monReader["id_categorie"]),
                        "" // on peut charger le nom plus tard ou via jointure
                    );

                    produit = new ProduitBO(
                        Convert.ToInt32(monReader["id_produit"]),
                        monReader["libelle_produit"].ToString(),
                        categorie,
                        Convert.ToDecimal(monReader["prix_vente_HT_produit"])
                    );
                }

                monReader.Close();
            }

            return produit;
        }

        // Récupère tous les produits
        public static List<ProduitBO> GetProduits()
        {
            List<ProduitBO> lesProduits = new List<ProduitBO>();

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_produit, libelle_produit, id_categorie, prix_vente_HT_produit FROM Produit", maConnexion);
                SqlDataReader monReader = cmd.ExecuteReader();

                while (monReader.Read())
                {
                    var categorie = new Categorie(
                        Convert.ToInt32(monReader["id_categorie"]),
                        ""
                    );

                    var prod = new ProduitBO(
                        Convert.ToInt32(monReader["id_produit"]),
                        monReader["libelle_produit"].ToString(),
                        categorie,
                        Convert.ToDecimal(monReader["prix_vente_HT_produit"])
                    );

                    lesProduits.Add(prod);
                }

                monReader.Close();
            }

            return lesProduits;
        }


        public static int AddProduit(ProduitBO p)
        {
            int nbEnr; // nombre d’enregistrements ajoutés
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Produit (libelle_produit, id_categorie, prix_vente_HT_produit) " +
                "VALUES (@lib, @cat, @prix)", maConnexion);

            // ⚠️ On suppose que p.getCategorie() renvoie un objet Categorie
            cmd.Parameters.AddWithValue("@lib", p.getLibelle());
            cmd.Parameters.AddWithValue("@cat", p.getCategorie().IdCategorie);
            cmd.Parameters.AddWithValue("@prix", p.getPrix());

            nbEnr = cmd.ExecuteNonQuery();

            maConnexion.Close();

            return nbEnr; // Retourne 1 si OK, 0 si rien inséré
        }

        // Met à jour un produit
        public static int UpdateProduit(ProduitBO p)
        {
            int nb = 0;

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Produit SET libelle_produit=@lib, id_categorie=@cat, prix_vente_HT_produit=@prix WHERE id_produit=@id",
                    maConnexion
                );

                cmd.Parameters.AddWithValue("@lib", p.getLibelle());
                cmd.Parameters.AddWithValue("@cat", p.getCategorie().IdCategorie);
                cmd.Parameters.AddWithValue("@prix", p.getPrix());
                cmd.Parameters.AddWithValue("@id", p.getCode());

                nb = cmd.ExecuteNonQuery();
            }

            return nb;
        }

        // Supprime un produit
        public static int DeleteProduit(int code)
        {
            int nb = 0;

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Produit WHERE id_produit=@id", maConnexion);
                cmd.Parameters.AddWithValue("@id", code);

                nb = cmd.ExecuteNonQuery();
            }

            return nb;
        }
    }
}
