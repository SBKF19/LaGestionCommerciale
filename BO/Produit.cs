using System;

namespace BO
{
    public class ProduitBO
    {
        private int code;
        private string name;
        private string description;
        private float prix;

        public int Code { get; set; }
        public string Libelle { get; set; }
        public Categorie Categorie { get; set; }
        public float Prix { get; set; }

        public ProduitBO(int code, string libelle, Categorie categorie, float prix)
        {
            Code = code;
            Libelle = libelle;
            Categorie = categorie;
            Prix = prix;
        }

        public ProduitBO(string libelle, Categorie categorie, float prix)
        {
            Libelle = libelle;
            Categorie = categorie;
            Prix = prix;
        }
    }
}
