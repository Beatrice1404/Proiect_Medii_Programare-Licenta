using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii_Programare.Models
{
    public class Specie
    {
        public int ID { get; set; }
        [Display(Name = "Specie Animal")]
        public string SpecieAnimal { get; set; }
        public ICollection<Rezervare>? Rezervări { get; set; }
    }
}
