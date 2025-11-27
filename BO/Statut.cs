using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Statut
    {
        private int id_statut;
        private string nom_statut;

        public int Id_statut { get => id_statut; set => id_statut = value; }
        public string Nom_statut { get => nom_statut; set => nom_statut = value; }

        public Statut(int id_statut, string nom_statut)
        {
            this.Id_statut = id_statut;
            this.Nom_statut = nom_statut;
        }

        public Statut(string nom_statut)
        {
            this.Nom_statut = nom_statut;
        }
    }
}
