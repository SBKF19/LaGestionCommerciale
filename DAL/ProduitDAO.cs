using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class ProduitDAO
    {

        // Cette méthode retourne une List contenant les objets Utilisateurs contenus dans la table Identification
        public ProduitBO GetProduitById(int id)
        {
            ProduitBO produit = null;
            // Connexion à la BD
            SqlConnection maConnexion =
            ConnexionBD.GetConnexionBD().GetSqlConnexion();
            // Requête SQL 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "SELECT * FROM dbo.produit WHERE id_produit = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader monReader = cmd.ExecuteReader();

            if (monReader.Read())
            {
                produit = new ProduitBO(
                    (int)monReader["id_produit"],
                    monReader["libelle_produit"].ToString(),
                    (Categorie)monReader["id_categorie"],
                    (decimal)monReader["prix_vente_HT_produit"]
                );
            }

            monReader.Close();
            ConnexionBD.GetConnexionBD().CloseConnexion();

            return produit;
        }

        public static List<ProduitBO> GetProduits()
        {
            List<ProduitBO> lesProduits = new List<ProduitBO>();
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand cmd = new SqlCommand("SELECT id_produit, libelle_produit, id_categorie, prix_vente_HT_produit FROM Produit", maConnexion);
            SqlDataReader monReader = cmd.ExecuteReader();

            while (monReader.Read())
            {
                var prod = new ProduitBO(
                    Convert.ToInt32(monReader["id_produit"]),
                    monReader["libelle_produit"].ToString(),
                    (Categorie)monReader["id_categorie"],
                    Convert.ToDecimal(monReader["prix_vente_HT_produit"])
                );
                lesProduits.Add(prod);
            }

            monReader.Close();
            maConnexion.Close();
            return lesProduits;
        }

        public static int UpdateProduit(ProduitBO p)
        {
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand(
                "UPDATE Produit SET libelle_produit=@lib, id_categorie=@cat, prix_vente_HT_produit=@prix WHERE id_produit=@id", maConnexion);

            cmd.Parameters.AddWithValue("@lib", p.getLibelle());
            cmd.Parameters.AddWithValue("@cat", p.getCategorie());
            cmd.Parameters.AddWithValue("@prix", p.getPrix());
            cmd.Parameters.AddWithValue("@id", p.getCode());

            int nb = cmd.ExecuteNonQuery();
            maConnexion.Close();
            return nb;
        }

        public static int DeleteProduit(int code)
        {
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand("DELETE FROM Produit WHERE id_produit=@id", maConnexion);
            cmd.Parameters.AddWithValue("@id", code);
            int nb = cmd.ExecuteNonQuery();
            maConnexion.Close();
            return nb;
        }
    }
}
