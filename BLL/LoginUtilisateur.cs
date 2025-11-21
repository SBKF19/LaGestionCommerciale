using System;
using System.Collections.Generic;
using System.Configuration;
using BO;
using DAL;

namespace UtilisateursBLL
{
    public class LoginUtilisateur
    {
        private static LoginUtilisateur uneGestionUtilisateurs;

        // Accesseur en lecture 
        public static LoginUtilisateur GetGestionUtilisateurs()
        {
            if (uneGestionUtilisateurs == null)
                uneGestionUtilisateurs = new LoginUtilisateur();

            return uneGestionUtilisateurs;
        }

        // Définit la chaîne de connexion à la base de données
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Récupère tous les utilisateurs (si besoin)
        public static List<Utilisateur> GetUtilisateurs()
        {
            return UtilisateurDAO.GetUtilisateurs();
        }

        // Méthode de vérification du login
        public static bool VerifierConnexion(string nomUser, string motDePasse)
        {
            return UtilisateurDAO.VerifierConnexion(nomUser, motDePasse);
        }
    }
}
