using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Programare.Models;

namespace Proiect_Medii_Programare.Data
{
    public class Proiect_Medii_ProgramareContext : DbContext
    {
        public Proiect_Medii_ProgramareContext (DbContextOptions<Proiect_Medii_ProgramareContext> options)
            : base(options)
        {
        }
        public DbSet<Proiect_Medii_Programare.Models.Rezervare>? Rezervare { get; set; }
        public DbSet<Proiect_Medii_Programare.Models.Cameră>? Cameră { get; set; }
        public DbSet<Proiect_Medii_Programare.Models.Specie>? Specie { get; set; }
        public DbSet<Proiect_Medii_Programare.Models.Serviciu>? Serviciu { get; set; }
        public DbSet<Proiect_Medii_Programare.Models.Membru>? Membru { get; set; }
        public DbSet<Proiect_Medii_Programare.Models.RezervăriServicii>? RezervăriServicii { get; set; }

    }
}
