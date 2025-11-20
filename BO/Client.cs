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
        // Identifiant unique du client dans la base
        public int IdClient { get; set; }

        // Informations de contact
        public string NomClient { get; set; }      // Nom du client
        public string NumFaxClient { get; set; }   // Numéro de fax
        public string MailClient { get; set; }     // Email
        public string NumPhoneClient { get; set; } // Numéro de téléphone

        // Adresse de facturation
        public string CodePostalFacture { get; set; } // Code postal facturation
        public string VilleFacture { get; set; }      // Ville facturation
        public int NumRueFacture { get; set; }        // Numéro de rue facturation
        public string NomRueFacture { get; set; }     // Nom de la rue facturation

        // Adresse de livraison
        public string CodePostalLivraison { get; set; } // Code postal livraison
        public string VilleLivraison { get; set; }      // Ville livraison
        public int NumRueLivraison { get; set; }        // Numéro de rue livraison
        public string NomRueLivraison { get; set; }     // Nom de la rue livraison

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

