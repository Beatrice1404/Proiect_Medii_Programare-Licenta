using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Programare.Data;
using Proiect_Medii_Programare.Models;

namespace Proiect_Medii_Programare.Pages.Camere
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext _context;

        public DetailsModel(Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext context)
        {
            _context = context;
        }

      public Cameră Cameră { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cameră == null)
            {
                return NotFound();
            }

            var cameră = await _context.Cameră.FirstOrDefaultAsync(m => m.ID == id);
            if (cameră == null)
            {
                return NotFound();
            }
            else 
            {
                Cameră = cameră;
            }
            return Page();
        }
    }
}
