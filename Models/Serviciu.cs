using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Medii_Programare.Models
{
    public class Serviciu
    {
        public int ID { get; set; }

        [Display(Name = "Servicii Suplimentare")]
        public string ServiciiSuplimentare { get; set; }
        [Display(Name = "Prețul Serviciului")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal PrețServiciu { get; set; }
        public ICollection<RezervăriServicii>? RezervăriServicii { get; set; }
    }
}
