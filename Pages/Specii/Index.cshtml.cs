using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Programare.Data;
using Proiect_Medii_Programare.Models;

namespace Proiect_Medii_Programare.Pages.Specii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext _context;

        public IndexModel(Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext context)
        {
            _context = context;
        }

        public IList<Specie> Specie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Specie != null)
            {
                Specie = await _context.Specie.ToListAsync();
            }
        }
    }
}
