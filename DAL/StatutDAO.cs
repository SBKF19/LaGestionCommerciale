using BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StatutDAO
    {
        private static StatutDAO unStatutDAO;

        public static StatutDAO GetStatutDAO()
        {
            if (unStatutDAO == null)
            {
                unStatutDAO = new StatutDAO();
            }
            return unStatutDAO;
        }

        public static int ModifierStatut(Statut statut)
        {
            string req = @"UPDATE STATUT SET 
                    nom_statut = @nomStatut
                    WHERE id_statut = @id";


            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", statut.IdStatut);
                    cmd.Parameters.AddWithValue("@nomStatut", statut.Nom_statut);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int SupprimerStatut(int id_statut)
        {
            int nbEnr = 0;

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            using (SqlCommand cmd = maConnexion.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM statut WHERE id_statut = @id";
                cmd.Parameters.AddWithValue("@id", id_statut);

                try
                {
                    nbEnr = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Si contrainte FK en base, on peut remonter une exception plus parlante
                    throw new Exception("Erreur SQL lors de la suppression : " + ex.Message, ex);
                }
            }

            return nbEnr;
        }
    }
}
