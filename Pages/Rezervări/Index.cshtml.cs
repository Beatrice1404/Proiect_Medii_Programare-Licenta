using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Programare.Data;
using Proiect_Medii_Programare.Models;

namespace Proiect_Medii_Programare.Pages.Rezervări
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext _context;

        public IndexModel(Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext context)
        {
            _context = context;
        }

        public IList<Rezervare> Rezervare { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        public string AnimalSort { get; set; }
        public string DateSort { get; set; }
        public int RezervareID { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString)
        {
            CurrentSort = sortOrder;
            AnimalSort = String.IsNullOrEmpty(sortOrder) ? "animal_desc" : "";
            DateSort = sortOrder == "ajunge" ? "ajunge_desc" : "ajunge";

            if (searchString != null)
            {
                CurrentFilter = searchString;
            }
            else
            {
                searchString = CurrentFilter;
            }

            IQueryable<Rezervare> rezervareQuery = _context.Rezervare
                .Include(b => b.Cameră)
                .Include(b => b.Specie)
                .Include(b => b.RezervăriServicii)
                .ThenInclude(b => b.Serviciu)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                rezervareQuery = rezervareQuery.Where(s =>
                    s.Animal.Contains(searchString) || s.Stăpân.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "animal_desc":
                    rezervareQuery = rezervareQuery.OrderByDescending(s => s.Animal);
                    break;
                case "ajunge":
                    rezervareQuery = rezervareQuery.OrderBy(s => s.Ajunge);
                    break;
                case "ajunge_desc":
                    rezervareQuery = rezervareQuery.OrderByDescending(s => s.Ajunge);
                    break;
                default:
                    rezervareQuery = rezervareQuery.OrderBy(s => s.Animal);
                    break;
            }

            Rezervare = await rezervareQuery.ToListAsync();
        }
    }
}
