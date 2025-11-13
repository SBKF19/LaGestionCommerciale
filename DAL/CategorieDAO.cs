using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO; // Référence la couche BO
using System.Data.SqlClient;

namespace DAL
{
    public class CategorieDAO
    {
        public static Categorie GetCategorieById(int id)
        {
            Categorie cat = null;
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categorie WHERE id_categorie = @id", maConnexion);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cat = new Categorie(
                    Convert.ToInt32(reader["id_categorie"]),
                    reader["libelle_categorie"].ToString()
                );
            }

            reader.Close();
            maConnexion.Close();

            return cat;
        }
    }
}
