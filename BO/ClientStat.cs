using System;

namespace BO
{
    public class ClientStat
    {
        public int Code { get; set; }
        public string NomClient { get; set; }
        public int NbDevis { get; set; }
        public int NbAcceptes { get; set; }
        public int NbEnAttente { get; set; }
        public int NbRefuses { get; set; }
        public decimal MontantFactureHT { get; set; }

        // Propriétés calculées pour l'affichage (évite la division par zéro)
        public double PctAttente => NbDevis == 0 ? 0.0 : Math.Round((double)NbEnAttente / NbDevis * 100, 1);
        public double PctRefuse => NbDevis == 0 ? 0.0 : Math.Round((double)NbRefuses / NbDevis * 100, 1);
        public double PctAccepte => NbDevis == 0 ? 0.0 : Math.Round((double)NbAcceptes / NbDevis * 100, 1);
    }
}