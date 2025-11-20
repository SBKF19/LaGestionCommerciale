using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Utilisateur
    {
        private int id_utilisateur;
        private string nom_utilisateur;
        private string mot_de_passe_utilisateur;

        public int Id_utilisateur { get => id_utilisateur; set => id_utilisateur = value; }
        public string Nom_utilisateur { get => nom_utilisateur; set => nom_utilisateur = value; }
        public string Mot_de_passe_utilisateur { get => mot_de_passe_utilisateur; set => mot_de_passe_utilisateur = value; }

        public Utilisateur(int id_utilisateur, string nom_utilisateur, string mot_de_passe_utilisateur)
        {
            this.Id_utilisateur = id_utilisateur;
            this.Nom_utilisateur = nom_utilisateur;
            this.Mot_de_passe_utilisateur = mot_de_passe_utilisateur;
        }
        public Utilisateur(string nom_utilisateur, string mot_de_passe_utilisateur)
        {
            this.Nom_utilisateur = nom_utilisateur;
            this.Mot_de_passe_utilisateur = mot_de_passe_utilisateur;
        }
    }
}
