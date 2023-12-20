namespace Proiect_Medii_Programare.Models
{
    public class RezervăriServicii
    {
        public int ID { get; set; }
        public int RezervareID { get; set; }
        public Rezervare Rezervare { get; set; }
        public int ServiciuID { get; set; }
        public Serviciu Serviciu { get; set; }
    }
}
