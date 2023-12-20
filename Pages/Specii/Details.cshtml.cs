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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext _context;

        public DetailsModel(Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext context)
        {
            _context = context;
        }

      public Specie Specie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specie == null)
            {
                return NotFound();
            }

            var specie = await _context.Specie.FirstOrDefaultAsync(m => m.ID == id);
            if (specie == null)
            {
                return NotFound();
            }
            else 
            {
                Specie = specie;
            }
            return Page();
        }
    }
}
