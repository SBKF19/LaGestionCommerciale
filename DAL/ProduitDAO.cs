using System;
using System.Collections.Generic;
using System.Data;
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

                    float prix = 0f;
                    int ordPrix = monReader.GetOrdinal("prix_vente_HT_produit");
                    if (!monReader.IsDBNull(ordPrix))
                    {
                        // Utiliser Convert.ToSingle pour éviter l'erreur d'unboxing si la valeur est un decimal/double
                        prix = Convert.ToSingle(monReader["prix_vente_HT_produit"]);
                    }

                    produit = new ProduitBO(
                        Convert.ToInt32(monReader["id_produit"]),
                        monReader["libelle_produit"].ToString(),
                        categorie,
                        prix
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
                SqlCommand cmd = new SqlCommand("SELECT p.id_produit, p.libelle_produit, p.id_categorie, c.nom_categorie,p.prix_vente_HT_produit " +
                    "FROM produit p INNER JOIN categorie c ON p.id_categorie = c.id_categorie;", maConnexion);
                SqlDataReader monReader = cmd.ExecuteReader();

                while (monReader.Read())
                {
                    var categorie = new Categorie(
                        Convert.ToInt32(monReader["id_categorie"]),
                        monReader["nom_categorie"].ToString()
                    );

                    float prix = 0f;
                    int ordPrix = monReader.GetOrdinal("prix_vente_HT_produit");
                    if (!monReader.IsDBNull(ordPrix))
                    {
                        prix = Convert.ToSingle(monReader["prix_vente_HT_produit"]);
                    }

                        var prod = new ProduitBO(
                        Convert.ToInt32(monReader["id_produit"]),
                        monReader["libelle_produit"].ToString(),
                        categorie,
                        prix
                    );

                    lesProduits.Add(prod);
                }

                monReader.Close();
            }

            return lesProduits;
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

                cmd.Parameters.AddWithValue("@lib", p.Libelle);
                cmd.Parameters.AddWithValue("@cat", p.Categorie.IdCategorie);

                // Préférer un paramètre Decimal si la colonne en base est decimal pour éviter conversions implicites
                var paramPrix = new SqlParameter("@prix", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Value = Convert.ToDecimal(p.Prix)
                };
                cmd.Parameters.Add(paramPrix);

                cmd.Parameters.AddWithValue("@id", p.Code);

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
