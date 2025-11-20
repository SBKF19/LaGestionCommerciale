using BO;
using System;
using System.Collections.Generic;
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
    }
}
