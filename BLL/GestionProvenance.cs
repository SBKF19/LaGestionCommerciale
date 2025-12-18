using System.Collections.Generic;
using BO;
using DAL;

namespace BLL
{
    public class GestionProvenances
    {
        public static List<Provenance> GetProvenances()
        {
            return ProvenanceDAO.GetProvenances();
        }
    }
}