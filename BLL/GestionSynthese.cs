using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration; // Nécessaire pour ConnectionStringSettings

namespace BLL
{
    public class GestionSynthese
    {
        private static GestionSynthese uneGestionSynthese;

        // Pattern Singleton
        public static GestionSynthese GetGestionSynthese()
        {
            if (uneGestionSynthese == null)
                uneGestionSynthese = new GestionSynthese();
            return uneGestionSynthese;
        }

        // CORRECTION CS1503 : Cette méthode attend bien l'objet Settings complet
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        public static List<ClientStat> GetSyntheseClients(DateTime debut, DateTime fin)
        {
            return SyntheseDAO.GetStatistiques(debut, fin);
        }
        public static void GetLimitesDates(out DateTime debut, out DateTime fin)
        {
            SyntheseDAO.GetLimitesDatesDevis(out debut, out fin);
        }
    }
}