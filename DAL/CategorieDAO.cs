using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
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

        public static Categorie GetCategorieByNom(string nom)
        {
            Categorie cat = null;
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categorie WHERE nom_categorie = @nom", maConnexion);
            cmd.Parameters.AddWithValue("@nom", nom);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cat = new Categorie(
                    Convert.ToInt32(reader["id_categorie"]),
                    reader["nom_categorie"].ToString()
                );
            }
            reader.Close();
            maConnexion.Close();
            return cat;
        }

        public static List<Categorie> GetCategories()
        {
            List<Categorie> lesCategories = new List<Categorie>();

            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categorie", maConnexion);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Categorie cat = new Categorie(
                    Convert.ToInt32(reader["id_categorie"]),
                    reader["nom_categorie"].ToString()
                );
                lesCategories.Add(cat);
            }

            reader.Close();
            maConnexion.Close();

            return lesCategories;
        }
    }
}
