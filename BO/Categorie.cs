using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Categorie
    {
        private int idCategorie;
        private string nomCategorie;

        public int IdCategorie { get => idCategorie; set => idCategorie = value; }
        public string NomCategorie { get => nomCategorie; set => nomCategorie = value; }

        public Categorie(int idCategorie, string nomCategorie)
        {
            this.IdCategorie = idCategorie;
            this.NomCategorie = nomCategorie;
        }

        public Categorie(string nomCategorie)
        {
            this.NomCategorie = nomCategorie;
        }
    }
}
