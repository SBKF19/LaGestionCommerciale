using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    // Classe représentant un client
    public class Client
    {
        private int idClient;

        private string nomClient;
        private string numFaxClient;
        private string mailClient;
        private string numPhoneClient;

        private string codePostalFacture;
        private string villeFacture;
        private int numRueFacture;
        private string nomRueFacture;

        private string codePostalLivraison;
        private string villeLivraison;
        private int numRueLivraison;
        private string nomRueLivraison;

        public int IdClient { get => idClient; set => idClient = value; }
        public string NomClient { get => nomClient; set => nomClient = value; }
        public string NumFaxClient { get => numFaxClient; set => numFaxClient = value; }
        public string MailClient { get => mailClient; set => mailClient = value; }
        public string NumPhoneClient { get => numPhoneClient; set => numPhoneClient = value; }
        public string CodePostalFacture { get => codePostalFacture; set => codePostalFacture = value; }
        public string VilleFacture { get => villeFacture; set => villeFacture = value; }
        public int NumRueFacture { get => numRueFacture; set => numRueFacture = value; }
        public string NomRueFacture { get => nomRueFacture; set => nomRueFacture = value; }
        public string CodePostalLivraison { get => codePostalLivraison; set => codePostalLivraison = value; }
        public string VilleLivraison { get => villeLivraison; set => villeLivraison = value; }
        public int NumRueLivraison { get => numRueLivraison; set => numRueLivraison = value; }
        public string NomRueLivraison { get => nomRueLivraison; set => nomRueLivraison = value; }

        // Constructeur complet avec l'ID du client (pour modification)
        public Client(int idClient, string nomClient, string numFaxClient, string mailClient, string numPhoneClient,
                      string codePostalFacture, string villeFacture, int numRueFacture, string nomRueFacture,
                      string codePostalLivraison, string villeLivraison, int numRueLivraison, string nomRueLivraison)
        {
            this.IdClient = idClient;
            this.NomClient = nomClient;
            this.NumFaxClient = numFaxClient;
            this.MailClient = mailClient;
            this.NumPhoneClient = numPhoneClient;
            this.CodePostalFacture = codePostalFacture;
            this.VilleFacture = villeFacture;
            this.NumRueFacture = numRueFacture;
            this.NomRueFacture = nomRueFacture;
            this.CodePostalLivraison = codePostalLivraison;
            this.VilleLivraison = villeLivraison;
            this.NumRueLivraison = numRueLivraison;
            this.NomRueLivraison = nomRueLivraison;
        }

        // Constructeur sans ID (pour création d'un nouveau client)
        public Client(string nomClient, string numFaxClient, string mailClient, string numPhoneClient,
              string codePostalFacture, string villeFacture, int numRueFacture, string nomRueFacture,
              string codePostalLivraison, string villeLivraison, int numRueLivraison, string nomRueLivraison)
        {
            this.NomClient = nomClient;
            this.NumFaxClient = numFaxClient;
            this.MailClient = mailClient;
            this.NumPhoneClient = numPhoneClient;
            this.CodePostalFacture = codePostalFacture;
            this.VilleFacture = villeFacture;
            this.NumRueFacture = numRueFacture;
            this.NomRueFacture = nomRueFacture;
            this.CodePostalLivraison = codePostalLivraison;
            this.VilleLivraison = villeLivraison;
            this.NumRueLivraison = numRueLivraison;
            this.NomRueLivraison = nomRueLivraison;
        }
    }
}

