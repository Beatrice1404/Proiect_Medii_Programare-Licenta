using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_Medii_Programare.Models
{
    public class Rezervare
    {
        public int ID { get; set; }
       
        [Display(Name = "Nume animal")]
        public string Animal { get; set; }

        [Display(Name = "Nume stăpân")]
        public string Stăpân { get; set; }

        [DataType(DataType.Date)]
        public DateTime Ajunge { get; set; }

        [DataType(DataType.Date)]
        public DateTime Pleacă { get; set; }
        public int NrNopți
        {
            get
            {
                // Calculate the difference in days between Ajunge and Pleacă dates
                TimeSpan duration = Pleacă - Ajunge;
                return (int)duration.TotalDays;
            }
        }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Total
        {
            get
            {
                if (NrNopți == 0 && Cameră != null)
                {
                    // If there are 0 nights, charge the price per night of the room
                    return Cameră.PrețPeNoapte;
                }
                else if (Cameră != null)
                {
                    // Calculate total cost by multiplying number of nights with price per night
                    return NrNopți * Cameră.PrețPeNoapte;
                }
                return 0; // Or handle this according to your application's logic if Cameră is null
            }
        }
        public string? Comentarii { get; set; }
        public int? CamerăID { get; set; }
        public Cameră? Cameră { get; set; }
        public int? SpecieID { get; set; }
        
        public Specie? Specie { get; set; }
        public ICollection<RezervăriServicii>? RezervăriServicii { get; set; }

    }
}