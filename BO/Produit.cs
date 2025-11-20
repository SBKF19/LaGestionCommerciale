using System;

namespace BO
{
    public class ProduitBO
    {
        private int code;
        private string libelle;
        private Categorie categorie;
        private float prix;

        public int Code { get => code; set => code = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public Categorie Categorie { get => categorie; set => categorie = value; }
        public float Prix { get => prix; set => prix = value; }

        public ProduitBO(int code, string libelle, Categorie categorie, float prix)
        {
            this.code = code;
            this.libelle = libelle;
            this.categorie = categorie;
            this.prix = prix;
        }

        public ProduitBO(string libelle, Categorie categorie, float prix)
        {
            this.libelle = libelle;
            this.categorie = categorie;
            this.prix = prix;
        }
    }
}
