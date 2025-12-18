using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BO;

namespace DAL
{
    public class ProvenanceDAO
    {
        public static List<Provenance> GetProvenances()
        {
            List<Provenance> resultats = new List<Provenance>();

            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                string req = "SELECT id_provenance, nom_pays, TVA_pays FROM provenance";
                SqlCommand cmd = new SqlCommand(req, cnx);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    resultats.Add(new Provenance(
                        (int)r["id_provenance"],
                        r["nom_pays"].ToString(),
                        Convert.ToSingle(r["TVA_pays"])
                    ));
                }
                r.Close();
            }
            return resultats;
        }
    }
}