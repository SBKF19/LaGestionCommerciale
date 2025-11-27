using BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DevisDAO
    {
        private static DevisDAO unDevisDAO;

        public static DevisDAO GetDevisDAO()
        {
            if (unDevisDAO == null)
            {
                unDevisDAO = new DevisDAO();
            }
            return unDevisDAO;
        }

        public static int ModifierDevis(Devis devis)
        {
            string req = @"UPDATE DEVIS SET 
                    date_devis = @dateDevis,
                    TVA_devis = @tvaDevis,
                    taux_remise_global_devis = @tauxRemiseGlobalDevis,
                    montant_HT_devis = @montantHorsTaxeDevis,
                    id_client = @client,
                    id_statut = @statut,
                    WHERE id_devis = @id";


            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@dateDevis", devis.Date_devis);
                    cmd.Parameters.AddWithValue("@tvaDevis", devis.TVA_devis);
                    cmd.Parameters.AddWithValue("@tauxRemiseGlobalDevis", devis.Taux_remise_global_devis);
                    cmd.Parameters.AddWithValue("@montantHorsTaxeDevis", devis.Montant_HT_devis);
                    cmd.Parameters.AddWithValue("@client", devis.Client.IdClient);
                    cmd.Parameters.AddWithValue("@statut", devis.Statut.IdStatut);
                    
                    return cmd.ExecuteNonQuery(); 
                }
            }
        }

        public static int SupprimerDevis(int idDevis)
        {
            int nbEnr = 0;

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            using (SqlCommand cmd = maConnexion.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM devis WHERE id_devis = @id";
                cmd.Parameters.AddWithValue("@id", idDevis);

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
