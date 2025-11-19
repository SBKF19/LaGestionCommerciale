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


        public int Id_utilisateur { get; set; }
        public string Nom_utilisateur { get; set; }
        public string Mot_de_passe_utilisateur { get; set; }

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
