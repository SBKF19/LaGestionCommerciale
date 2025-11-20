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
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        public static int AjouterClient(Client client)
        {
            return DAL.ClientDAO.InsertClient(client);
        }

        public static List<Client> GetClients()
        {
            return ClientDAO.GetClients();
        }

        public static int ModifierClient(Client client)
        {
            return ClientDAO.ModifierClient(client);
        }

        public static bool ClientEstUtilise(int idClient)
        {
            return ClientDAO.ClientEstUtilise(idClient);
        }

        public static int DeleteClient(int idClient)
        {
            return ClientDAO.DeleteClient(idClient);
        }


    }
}
