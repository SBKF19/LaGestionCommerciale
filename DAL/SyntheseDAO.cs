using BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class SyntheseDAO
    {
        private static SyntheseDAO unSyntheseDAO;

        public static SyntheseDAO GetSyntheseDAO()
        {
            if (unSyntheseDAO == null)
                unSyntheseDAO = new SyntheseDAO();
            return unSyntheseDAO;
        }

        public static List<ClientStat> GetStatistiques(DateTime dateDebut, DateTime dateFin)
        {
            List<ClientStat> liste = new List<ClientStat>();
            string req = @"
                SELECT 
                    c.id_client, 
                    c.nom_client,
                    COUNT(d.id_devis) AS NbTotal,
                    SUM(CASE WHEN s.nom_statut = 'accepté' THEN 1 ELSE 0 END) AS NbAcceptes,
                    SUM(CASE WHEN s.nom_statut = 'en attente' THEN 1 ELSE 0 END) AS NbAttente,
                    SUM(CASE WHEN s.nom_statut = 'refusé' THEN 1 ELSE 0 END) AS NbRefuses,
                    SUM(CASE WHEN s.nom_statut = 'accepté' THEN d.montant_HT_devis ELSE 0 END) AS MontantTotal
                FROM 
                    client c
                LEFT JOIN
                    devis d ON c.id_client = d.id_client 
                    AND (@DateDebut IS NULL OR d.date_devis >= @DateDebut) 
                    AND (@DateFin IS NULL OR d.date_devis <= @DateFin)
                LEFT JOIN 
                    statut s ON d.id_statut = s.id_statut
                GROUP BY 
                    c.id_client, c.nom_client";

            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                if (cnx.State == System.Data.ConnectionState.Closed) cnx.Open();

                SqlCommand cmd = new SqlCommand(req, cnx);
                if (dateDebut == DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@DateDebut", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DateDebut", dateDebut);
                }

                // Si la date reçue est la date maximale (31/12/9999), on envoie DBNull à SQL
                if (dateFin == DateTime.MaxValue)
                {
                    cmd.Parameters.AddWithValue("@DateFin", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DateFin", dateFin);
                }

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    liste.Add(new ClientStat
                    {
                        Code = (int)rdr["id_client"],
                        NomClient = rdr["nom_client"].ToString(),
                        NbDevis = rdr["NbTotal"] != DBNull.Value ? (int)rdr["NbTotal"] : 0,
                        NbAcceptes = rdr["NbAcceptes"] != DBNull.Value ? (int)rdr["NbAcceptes"] : 0,
                        NbEnAttente = rdr["NbAttente"] != DBNull.Value ? (int)rdr["NbAttente"] : 0,
                        NbRefuses = rdr["NbRefuses"] != DBNull.Value ? (int)rdr["NbRefuses"] : 0,
                        MontantFactureHT = rdr["MontantTotal"] != DBNull.Value ? Convert.ToDecimal(rdr["MontantTotal"]) : 0
                    });
                }
                rdr.Close();
            }
            return liste;
        }

        // Cette fonction va selectionner la plus petite et la plus grande date dans les devis et les retourner dans des variables
        // en paramètres de sortie | Sert au bouton actualiser pour afficher toute la période des devis
        public static void GetLimitesDatesDevis(out DateTime dateMin, out DateTime dateMax)
        {
            dateMin = DateTime.Now;
            dateMax = DateTime.Now;

            string req = "SELECT MIN(date_devis) as MinDate, MAX(date_devis) as MaxDate FROM devis";

            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                if (cnx.State == System.Data.ConnectionState.Closed) cnx.Open();

                SqlCommand cmd = new SqlCommand(req, cnx);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    // Dates min et max présentes en bdd ? alors on convertis en DateTime
                    if (rdr["MinDate"] != DBNull.Value)
                    {
                        dateMin = (DateTime)rdr["MinDate"];
                    }

                    if (rdr["MaxDate"] != DBNull.Value)
                    {
                        dateMax = (DateTime)rdr["MaxDate"];
                    }
                }
                rdr.Close();
            }
        }
    }
}