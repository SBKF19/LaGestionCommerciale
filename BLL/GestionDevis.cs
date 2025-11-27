using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionDevis
    {
        private static GestionDevis uneGestionDevis;

        public static GestionDevis GetGestionDevis()
        {
            if (uneGestionDevis == null)
                uneGestionDevis = new GestionDevis(); 
            return uneGestionDevis;
        }

        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        public static int ModifierDevis(Devis idDevis)
        {
            return DevisDAO.ModifierDevis(idDevis);
        }

        public static int SupprimerDevis(int idDevis)
        {
            return DevisDAO.SupprimerDevis(idDevis);
        }
    }
}
