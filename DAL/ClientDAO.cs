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
