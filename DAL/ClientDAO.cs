using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Récupère tous les utilisateurs de la table "utilisateur"
        public static List<Client> GetClients()
        {
            List<Client> lesClients = new List<Client>();

            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT id_client, nom_client, num_fax_client, mail_client, num_phone_client, code_postal_facture, " +
                    "ville_facture, num_rue_facture, nom_rue_facture, code_postal_livraison, ville_livraison, num_rue_livraison, " +
                    "nom_rue_livraison FROM client", maConnexion);
                SqlDataReader monReader = cmd.ExecuteReader();

                while (monReader.Read())
                {
                    int id = (int)monReader["id_client"];
                    string nom = monReader["nom_client"].ToString();
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


                    Client unClient = new Client(id, nom, num_fax, mail, num_phone, code_postal_facture, ville_facture, num_rue_facture, nom_rue_facture, code_postal_livraison, ville_livraison, num_rue_livraison, nom_rue_livraison);
                    lesClients.Add(unClient);
                }

                monReader.Close();
            }

            return lesClients;
        }

        public static int InsertClient(Client client)
        {
            int nbEnr;

            // Connexion à la base
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            SqlCommand cmd = new SqlCommand(@"INSERT INTO client (nom_client, num_fax_client, mail_client, num_phone_client,
            code_postal_facture, ville_facture, num_rue_facture, nom_rue_facture,
            code_postal_livraison, ville_livraison, num_rue_livraison, nom_rue_livraison)
            VALUES(@nom, @fax, @mail, @phone,@cpFact, @villeFact, @numRueFact, @nomRueFact,@cpLiv, @villeLiv, @numRueLiv, 
            @nomRueLiv)",maConnexion);

            // Paramètres
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

            nbEnr = cmd.ExecuteNonQuery();
            return nbEnr;
        }
        public static int ModifierClient(Client client)
        {
            string req = @"UPDATE Client
                   SET NomClient = @Nom,
                       NumFaxClient = @Fax,
                       MailClient = @Mail,
                       NumPhoneClient = @Tel,
                       CodePostalFacture = @CPF,
                       VilleFacture = @VF,
                       NumRueFacture = @NRF,
                       NomRueFacture = @NRuF,
                       CodePostalLivraison = @CPL,
                       VilleLivraison = @VL,
                       NumRueLivraison = @NRL,
                       NomRueLivraison = @NRuL
                   WHERE IdClient = @Id";

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

                return cmd.ExecuteNonQuery();
            }
        }

        public static int SupprimerClient(int idClient)
        {
            string req = @"DELETE FROM Client WHERE IdClient = @Id";

            using (SqlConnection cnx = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            {
                SqlCommand cmd = new SqlCommand(req, cnx);
                cmd.Parameters.AddWithValue("@Id", idClient);

                return cmd.ExecuteNonQuery();
            }
        }

        // Vérifie si un client est lié à un devis (ou autre table) : retourne true si utilisé
        public static bool ClientEstUtilise(int idClient)
        {
            int nbEnr = 0;
            using (SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion())
            using (SqlCommand cmd = maConnexion.CreateCommand())
            {
                // Remplacez "devis" par le nom exact de la table qui référence client (ex : "devis", "commande", ...)
                cmd.CommandText = "SELECT COUNT(*) FROM devis WHERE id_client = @id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idClient;

                nbEnr = (int)cmd.ExecuteScalar();
            }

            return nbEnr > 0;
        }

        // Supprime un client par id
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
                    // Si contrainte FK en base, on peut remonter une exception plus parlante
                    throw new Exception("Erreur SQL lors de la suppression : " + ex.Message, ex);
                }
            }

            return nbEnr;
        }
    }
}
