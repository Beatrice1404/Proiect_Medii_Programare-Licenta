namespace Proiect_Medii_Programare.Models
{
    public class RezervareData
    {
        public IEnumerable<Rezervare> Rezervări { get; set; }
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<RezervăriServicii> RezervareServiciu { get; set; }
    }
}
