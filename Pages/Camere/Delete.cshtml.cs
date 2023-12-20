using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Programare.Data;
using Proiect_Medii_Programare.Models;

namespace Proiect_Medii_Programare.Pages.Camere
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext _context;

        public DeleteModel(Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cameră == null)
            {
                return NotFound();
            }
            var cameră = await _context.Cameră.FindAsync(id);

            if (cameră != null)
            {
                Cameră = cameră;
                _context.Cameră.Remove(Cameră);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
