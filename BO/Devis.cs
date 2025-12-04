using System;
using System.Collections.Generic;

namespace BO
{
    public class Devis
    {
        private int idDevis;
        private DateTime date_devis;
        private float tva_devis;
        private float taux_remise_global_devis;
        private float montant_HT_devis;
        private Client client;
        private Statut statut;
        private List<Contenir> lignes;

        public int IdDevis { get => idDevis; set => idDevis = value; }
        public DateTime Date_devis { get => date_devis; set => date_devis = value; }
        public float TVA_devis { get => tva_devis; set => tva_devis = value; }
        public float Taux_remise_global_devis { get => taux_remise_global_devis; set => taux_remise_global_devis = value; }
        public float Montant_HT_devis { get => montant_HT_devis; set => montant_HT_devis = value; }
        public Client Client { get => client; set => client = value; }
        public Statut Statut { get => statut; set => statut = value; }
        public List<Contenir> Lignes { get => lignes; set => lignes = value; }

        public Devis()
        {
            this.Lignes = new List<Contenir>();
            this.Date_devis = DateTime.Now;
        }

        public Devis(int idDevis, DateTime date_devis, float tVA_devis, float taux_remise_global_devis, float montant_HT_devis, Client client, Statut statut)
        {
            this.IdDevis = idDevis;
            this.Date_devis = date_devis;
            this.TVA_devis = tVA_devis;
            this.Taux_remise_global_devis = taux_remise_global_devis;
            this.Montant_HT_devis = montant_HT_devis;
            this.Client = client;
            this.Statut = statut;
            this.Lignes = new List<Contenir>();
        }

        public Devis(DateTime date_devis, float tVA_devis, float taux_remise_global_devis, float montant_HT_devis, Client client, Statut statut)
        {
            this.Date_devis = date_devis;
            this.TVA_devis = tVA_devis;
            this.Taux_remise_global_devis = taux_remise_global_devis;
            this.Montant_HT_devis = montant_HT_devis;
            this.Client = client;
            this.Statut = statut;
            this.Lignes = new List<Contenir>();
        }

        // Méthode de calcul des totaux
        public void RecalculerTotaux()
        {
            float totalHTLignes = 0;
            foreach (var ligne in Lignes)
            {
                totalHTLignes += ligne.MontantHT_AvecRemise;
            }
            float montantRemiseGlobale = totalHTLignes * (this.Taux_remise_global_devis / 100);
            this.Montant_HT_devis = totalHTLignes - montantRemiseGlobale;
        }
    }
}