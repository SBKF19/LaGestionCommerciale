using BO;
using System;
using System.Collections.Generic;
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
    }
}
