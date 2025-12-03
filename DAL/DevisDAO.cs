using BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DevisDAO
    {
        private static DevisDAO unDevisDAO;

        public static DevisDAO GetDevisDAO()
        {
            if (unDevisDAO == null)
                unDevisDAO = new DevisDAO();
            return unDevisDAO;
        }

        public static List<Devis> GetDevis()
        {
            List<Devis> lesDevis = new List<Devis>();
            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_devis, date_devis, TVA_devis, taux_remise_global_devis, montant_HT_devis, " + 
                    "client.id_client, nom_client, num_fax_client, mail_client, num_phone_client, " + 
                    "code_postal_facture, ville_facture, num_rue_facture, nom_rue_facture, " + 
                    "code_postal_livraison, ville_livraison, num_rue_livraison, nom_rue_livraison, " +  
                    "nom_statut " + 
                    "FROM devis " + 
                    " JOIN client on devis.id_client = client.id_client " + 
                    " JOIN statut on devis.id_statut = statut.id_statut", maConnexion);
                SqlDataReader monReader = cmd.ExecuteReader();

                while (monReader.Read())
                {
                    // Client
                    int id_client = (int)monReader["id_client"];
                    string nom_client = monReader["nom_client"].ToString();
                    string num_fax = monReader["num_fax_client"].ToString();
                    string mail = monReader["mail_client"].ToString();
                    string num_phone = monReader["num_phone_client"].ToString();
                    string code_postal_facture = monReader["code_postal_facture"].ToString();
                    string ville_facture = monReader["ville_facture"].ToString();
                    int num_rue_facture = (int)monReader["num_rue_facture"];
                    string nom_rue_facture = monReader["nom_rue_facture"].ToString();
                    string code_postal_livraison = monReader["code_postal_livraison"].ToString();
                    string ville_livraison = monReader["ville_livraison"].ToString();
                    int num_rue_livraison = (int)monReader["num_rue_livraison"];
                    string nom_rue_livraison = monReader["nom_rue_livraison"].ToString();
                    // Objet Client
                    Client unClient = new Client(id_client, nom_client, num_fax, mail, num_phone, code_postal_facture, ville_facture, num_rue_facture, nom_rue_facture,
                    code_postal_livraison, ville_livraison, num_rue_livraison, nom_rue_livraison);
                    // Statut
                    string nom_statut = monReader["nom_statut"].ToString();
                    // Objet Statut
                    Statut unStatut = new Statut(nom_statut);
                    // Devis
                    int id_devis = (int)monReader["id_devis"];
                    DateTime date_devis = (DateTime)monReader["date_devis"];
                    float tva_devis = (float)monReader["TVA_devis"];
                    float taux_remise_global_devis = (float)monReader["taux_remise_global_devis"];
                    float montant_devis = (float)monReader["montant_devis"];
                    // Objet Devis
                    Devis unDevis = new Devis(id_devis, date_devis, tva_devis, taux_remise_global_devis, montant_devis , unClient, unStatut);
                    lesDevis.Add(unDevis);
                }
                monReader.Close();
            }
            return lesDevis;
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
