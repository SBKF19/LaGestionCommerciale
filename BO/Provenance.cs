using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Provenance
    {
        private int idProvenances;
        private string nomPays;
        private float tvaPays;

        public int IdProvenances { get => idProvenances; set => idProvenances = value; }
        public string NomPays { get => nomPays; set => nomPays = value; }
        public float TvaPays { get => tvaPays; set => tvaPays = value; }

        public Provenance(int idProvenances, string nomPays, float tvaPays)
        {
            this.idProvenances = idProvenances;
            this.nomPays = nomPays;
            this.tvaPays = tvaPays;
        }

        public Provenance(string nomPays, float tvaPays)
        {
            this.nomPays = nomPays;
            this.tvaPays = tvaPays;
        }
    }
}