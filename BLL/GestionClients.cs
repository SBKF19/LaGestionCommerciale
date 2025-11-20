using BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class GestionClients
    {
        private static GestionClients uneGestionClients;
      
        public static GestionClients GetGestionClients()
        {
            if (uneGestionClients == null)
                uneGestionClients = new GestionClients();
            return uneGestionClients;
        }

        public static int AjouterClient(Client client)
        {
            return DAL.ClientDAO.InsertClient(client);
        }
            // Définit la chaîne de connexion à la base de données
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        public static List<Client> GetClients()
        {
            return ClientDAO.GetClients();
        }
    }
}
