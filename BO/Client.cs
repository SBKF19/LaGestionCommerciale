using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Client
    {
        public int IdClient { get; set; }
        public string NomClient { get; set; }
        public string NumFaxClient { get; set; }
        public string MailClient { get; set; }
        public string NumPhoneClient { get; set; }

        public string CodePostalFacture { get; set; }
        public string VilleFacture { get; set; }
        public int NumRueFacture { get; set; }
        public string NomRueFacture { get; set; }

        public string CodePostalLivraison { get; set; }
        public string VilleLivraison { get; set; }
        public int NumRueLivraison { get; set; }
        public string NomRueLivraison { get; set; }

        public Client() { }

        public Client(int idClient, string nomClient, string numFaxClient, string mailClient, string numPhoneClient,
                      string codePostalFacture, string villeFacture, int numRueFacture, string nomRueFacture,
                      string codePostalLivraison, string villeLivraison, int numRueLivraison, string nomRueLivraison)
        {
            IdClient = idClient;
            NomClient = nomClient;
            NumFaxClient = numFaxClient;
            MailClient = mailClient;
            NumPhoneClient = numPhoneClient;
            CodePostalFacture = codePostalFacture;
            VilleFacture = villeFacture;
            NumRueFacture = numRueFacture;
            NomRueFacture = nomRueFacture;
            CodePostalLivraison = codePostalLivraison;
            VilleLivraison = villeLivraison;
            NumRueLivraison = numRueLivraison;
            NomRueLivraison = nomRueLivraison;
        }
    }
}
