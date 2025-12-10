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

            // Requête SQL optimisée :
            // 1. On filtre les dates DANS le JOIN pour conserver les clients qui n'ont pas de devis (afficher 0 partout).
            // 2. On utilise SUM(CASE...) pour compter les statuts en une seule requête.
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
                    AND d.date_devis >= @DateDebut 
                    AND d.date_devis <= @DateFin
                LEFT JOIN 
                    statut s ON d.id_statut = s.id_statut
                GROUP BY 
                    c.id_client, c.nom_client";

            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                // Sécurité si connexion fermée
                if (cnx.State == System.Data.ConnectionState.Closed) cnx.Open();

                SqlCommand cmd = new SqlCommand(req, cnx);
                cmd.Parameters.AddWithValue("@DateDebut", dateDebut);
                cmd.Parameters.AddWithValue("@DateFin", dateFin);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    liste.Add(new ClientStat
                    {
                        Code = (int)rdr["id_client"],
                        NomClient = rdr["nom_client"].ToString(),
                        // Gestion des valeurs nulles si pas de devis
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
    }
}