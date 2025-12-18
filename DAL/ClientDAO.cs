using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BO;

namespace DAL
{
    public class ClientDAO
    {
        private static ClientDAO unClientDAO;

        public static ClientDAO GetClientDAO()
        {
            if (unClientDAO == null)
                unClientDAO = new ClientDAO();
            return unClientDAO;
        }

        private ClientDAO() { }

        // --- 1. LECTURE ---
        public static List<Client> GetClients()
        {
            List<Client> lesClients = new List<Client>();

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                string req = @"SELECT 
                                c.id_client, c.nom_client, c.num_fax_client, c.mail_client, c.num_phone_client, 
                                c.code_postal_facture, c.ville_facture, c.num_rue_facture, c.nom_rue_facture, 
                                c.code_postal_livraison, c.ville_livraison, c.num_rue_livraison, c.nom_rue_livraison,
                                c.id_provenance, 
                                p.nom_pays, p.TVA_pays
                               FROM client c
                               LEFT JOIN provenance p ON c.id_provenance = p.id_provenance";

                SqlCommand cmd = new SqlCommand(req, maConnexion);
                SqlDataReader monReader = cmd.ExecuteReader();

                while (monReader.Read())
                {
                    Provenance prov = null;

                    if (monReader["id_provenance"] != DBNull.Value)
                    {
                        prov = new Provenance(
                            (int)monReader["id_provenance"],
                            monReader["nom_pays"].ToString(),
                            Convert.ToSingle(monReader["TVA_pays"])
                        );
                    }

                    int id = (int)monReader["id_client"];
                    string nom = monReader["nom_client"].ToString();
                    string num_fax = monReader["num_fax_client"].ToString();
                    string mail = monReader["mail_client"].ToString();
                    string num_phone = monReader["num_phone_client"].ToString();
                    string cp_fact = monReader["code_postal_facture"].ToString();
                    string ville_fact = monReader["ville_facture"].ToString();
                    int num_rue_fact = (int)monReader["num_rue_facture"];
                    string nom_rue_fact = monReader["nom_rue_facture"].ToString();
                    string cp_liv = monReader["code_postal_livraison"].ToString();
                    string ville_liv = monReader["ville_livraison"].ToString();
                    int num_rue_liv = (int)monReader["num_rue_livraison"];
                    string nom_rue_liv = monReader["nom_rue_livraison"].ToString();

                    Client unClient = new Client(id, nom, num_fax, mail, num_phone,
                                                 cp_fact, ville_fact, num_rue_fact, nom_rue_fact,
                                                 cp_liv, ville_liv, num_rue_liv, nom_rue_liv,
                                                 prov);

                    lesClients.Add(unClient);
                }

                monReader.Close();
            }

            return lesClients;
        }

        // --- 2. AJOUT  ---
        public static int InsertClient(Client client)
        {
            int nbEnr = 0;

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                string req = @"INSERT INTO client (
                                nom_client, num_fax_client, mail_client, num_phone_client,
                                code_postal_facture, ville_facture, num_rue_facture, nom_rue_facture,
                                code_postal_livraison, ville_livraison, num_rue_livraison, nom_rue_livraison,
                                id_provenance)
                               VALUES(
                                @nom, @fax, @mail, @phone,
                                @cpFact, @villeFact, @numRueFact, @nomRueFact,
                                @cpLiv, @villeLiv, @numRueLiv, @nomRueLiv,
                                @idProv)";

                using (SqlCommand cmd = new SqlCommand(req, maConnexion))
                {
                    cmd.Parameters.AddWithValue("@nom", client.NomClient);
                    cmd.Parameters.AddWithValue("@fax", client.NumFaxClient);
                    cmd.Parameters.AddWithValue("@mail", client.MailClient);
                    cmd.Parameters.AddWithValue("@phone", client.NumPhoneClient);

                    cmd.Parameters.AddWithValue("@cpFact", client.CodePostalFacture);
                    cmd.Parameters.AddWithValue("@villeFact", client.VilleFacture);
                    cmd.Parameters.AddWithValue("@numRueFact", client.NumRueFacture);
                    cmd.Parameters.AddWithValue("@nomRueFact", client.NomRueFacture);

                    cmd.Parameters.AddWithValue("@cpLiv", client.CodePostalLivraison);
                    cmd.Parameters.AddWithValue("@villeLiv", client.VilleLivraison);
                    cmd.Parameters.AddWithValue("@numRueLiv", client.NumRueLivraison);
                    cmd.Parameters.AddWithValue("@nomRueLiv", client.NomRueLivraison);

                    if (client.Provenance != null)
                        cmd.Parameters.AddWithValue("@idProv", client.Provenance.IdProvenances);
                    else
                        cmd.Parameters.AddWithValue("@idProv", DBNull.Value);

                    nbEnr = cmd.ExecuteNonQuery();
                }
            }

            return nbEnr;
        }

        // --- 3. MODIFICATION ---
        public static int ModifierClient(Client client)
        {
            string req = @"UPDATE client SET 
                            nom_client = @Nom,
                            num_fax_client = @Fax,
                            mail_client = @Mail,
                            num_phone_client = @Tel,
                            code_postal_facture = @CPF,
                            ville_facture = @VF,
                            num_rue_facture = @NRF,
                            nom_rue_facture = @NRuF,
                            code_postal_livraison = @CPL,
                            ville_livraison = @VL,
                            num_rue_livraison = @NRL,
                            nom_rue_livraison = @NRuL,
                            id_provenance = @idProv
                           WHERE id_client = @Id";

            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(req, cnx);

                cmd.Parameters.AddWithValue("@Id", client.IdClient);
                cmd.Parameters.AddWithValue("@Nom", client.NomClient);
                cmd.Parameters.AddWithValue("@Fax", client.NumFaxClient);
                cmd.Parameters.AddWithValue("@Mail", client.MailClient);
                cmd.Parameters.AddWithValue("@Tel", client.NumPhoneClient);
                cmd.Parameters.AddWithValue("@CPF", client.CodePostalFacture);
                cmd.Parameters.AddWithValue("@VF", client.VilleFacture);
                cmd.Parameters.AddWithValue("@NRF", client.NumRueFacture);
                cmd.Parameters.AddWithValue("@NRuF", client.NomRueFacture);
                cmd.Parameters.AddWithValue("@CPL", client.CodePostalLivraison);
                cmd.Parameters.AddWithValue("@VL", client.VilleLivraison);
                cmd.Parameters.AddWithValue("@NRL", client.NumRueLivraison);
                cmd.Parameters.AddWithValue("@NRuL", client.NomRueLivraison);

                if (client.Provenance != null)
                    cmd.Parameters.AddWithValue("@idProv", client.Provenance.IdProvenances);
                else
                    cmd.Parameters.AddWithValue("@idProv", DBNull.Value);

                return cmd.ExecuteNonQuery();
            }
        }

        public static bool ClientEstUtilise(int idClient)
        {
            int nbEnr = 0;
            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            using (SqlCommand cmd = maConnexion.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM devis WHERE id_client = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idClient;
                nbEnr = (int)cmd.ExecuteScalar();
            }
            return nbEnr > 0;
        }

        public static int DeleteClient(int idClient)
        {
            int nbEnr = 0;
            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            using (SqlCommand cmd = maConnexion.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM client WHERE id_client = @id";
                cmd.Parameters.AddWithValue("@id", idClient);
                try
                {
                    nbEnr = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erreur SQL lors de la suppression : " + ex.Message, ex);
                }
            }
            return nbEnr;
        }
    }
}