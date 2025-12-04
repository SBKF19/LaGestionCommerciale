using System;

namespace BO
{
    public class Contenir
    {
        private ProduitBO produitBO;
        private Devis devis;
        private int quantite_commandee;
        private float remise_par_ligne;

        public ProduitBO ProduitBO { get => produitBO; set => produitBO = value; }
        public Devis Devis { get => devis; set => devis = value; }
        public int Quantite_commandee { get => quantite_commandee; set => quantite_commandee = value; }
        public float Remise_par_ligne { get => remise_par_ligne; set => remise_par_ligne = value; }

        public Contenir(ProduitBO produitBO, Devis devis, int quantite_commandee, float remise_par_ligne)
        {
            this.ProduitBO = produitBO;
            this.Devis = devis;
            this.Quantite_commandee = quantite_commandee;
            this.Remise_par_ligne = remise_par_ligne;
        }

        // --- CORRECTION : Utilisation de .Prix (tel que défini dans ProduitBO) ---
        public float PrixUnitaire => ProduitBO.Prix;

        public float MontantHT_SansRemise => PrixUnitaire * Quantite_commandee;

        public float MontantRemise => MontantHT_SansRemise * (Remise_par_ligne / 100);

        public float MontantHT_AvecRemise => MontantHT_SansRemise - MontantRemise;
    }
}