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

namespace Proiect_Medii_Programare.Pages.Rezervări
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext _context;

        public DeleteModel(Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext context)
        {
            _context = context;
        }

        public Rezervare Rezervare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rezervare = await _context.Rezervare
                .Include(r => r.Cameră)
                .Include(r => r.Specie)
                .Include(r => r.RezervăriServicii)
                    .ThenInclude(rs => rs.Serviciu)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Rezervare == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervareToDelete = await _context.Rezervare
                .FirstOrDefaultAsync(r => r.ID == id);

            if (rezervareToDelete == null)
            {
                return NotFound();
            }

            // Șterge toate rezervările de servicii asociate acestei rezervări
            var rezervariServicii = await _context.RezervăriServicii
                .Where(rs => rs.RezervareID == id)
                .ToListAsync();

            _context.RezervăriServicii.RemoveRange(rezervariServicii);

            // Șterge rezervarea
            _context.Rezervare.Remove(rezervareToDelete);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
