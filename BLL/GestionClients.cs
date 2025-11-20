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
    // Classe de gestion des clients (Business Logic Layer)
    public class GestionClients
    {
        // Instance unique pour le pattern Singleton
        private static GestionClients uneGestionClients;

        /// <summary>
        /// Retourne l'instance unique de GestionClients (Singleton)
        /// </summary>
        public static GestionClients GetGestionClients()
        {
            if (uneGestionClients == null)
                uneGestionClients = new GestionClients(); // création si inexistant
            return uneGestionClients;
        }

        /// <summary>
        /// Définit la chaîne de connexion pour la base de données
        /// </summary>
        /// <param name="chset">Paramètres de connexion</param>
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        /// <summary>
        /// Ajoute un nouveau client dans la base de données
        /// </summary>
        /// <param name="client">Objet Client à ajouter</param>
        /// <returns>Nombre de lignes affectées</returns>
        public static int AjouterClient(Client client)
        {
            return DAL.ClientDAO.InsertClient(client);
        }

        /// <summary>
        /// Récupère tous les clients depuis la base
        /// </summary>
        /// <returns>Liste des clients</returns>
        public static List<Client> GetClients()
        {
            return ClientDAO.GetClients();
        }

        /// <summary>
        /// Modifie un client existant dans la base
        /// </summary>
        /// <param name="client">Client avec les nouvelles valeurs</param>
        /// <returns>Nombre de lignes affectées</returns>
        public static int ModifierClient(Client client)
        {
            return ClientDAO.ModifierClient(client);
        }

        /// <summary>
        /// Vérifie si un client est utilisé dans un devis
        /// </summary>
        /// <param name="idClient">ID du client</param>
        /// <returns>true si le client est utilisé, false sinon</returns>
        public static bool ClientEstUtilise(int idClient)
        {
            return ClientDAO.ClientEstUtilise(idClient);
        }

        /// <summary>
        /// Supprime un client de la base
        /// </summary>
        /// <param name="idClient">ID du client à supprimer</param>
        /// <returns>Nombre de lignes affectées</returns>
        public static int DeleteClient(int idClient)
        {
            return ClientDAO.DeleteClient(idClient);
        }
    }
}

