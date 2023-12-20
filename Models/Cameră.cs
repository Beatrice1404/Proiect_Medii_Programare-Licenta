using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Medii_Programare.Models
{
    public class Cameră
    {
        public int ID { get; set; }

        [Display(Name = "Tipul de Cameră")]
        public string TipCameră { get; set; }
        public ICollection<Rezervare>? Rezervări { get; set; }

        [Display(Name = "Prețul pe Noapte")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal PrețPeNoapte { get; set; }
        public string Descriere { get; set; }
    }
}
