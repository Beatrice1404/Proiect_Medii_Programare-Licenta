using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Programare.Data;
using Proiect_Medii_Programare.Models;

namespace Proiect_Medii_Programare.Pages.Rezervări
{
    [Authorize(Roles = "Admin")]

    public class EditModel : RezervăriServiciiPageModel
    {
        private readonly Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext _context;

        public EditModel(Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Rezervare Rezervare { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            Rezervare = await _context.Rezervare
            .Include(b => b.Cameră)
            .Include(b => b.Specie)
            .Include(b => b.RezervăriServicii).ThenInclude(b => b.Serviciu)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Rezervare == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData 
            PopulateAssignedData(_context, Rezervare);

            ViewData["CamerăID"] = new SelectList(_context.Cameră, "ID",
           "TipCameră");
            ViewData["SpecieID"] = new SelectList(_context.Specie, "ID",
           "SpecieAnimal");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedserviciu)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervareToUpdate = await _context.Rezervare
                .Include(i => i.RezervăriServicii)
                .ThenInclude(i => i.Serviciu)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (rezervareToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Rezervare>(rezervareToUpdate))
            {
                UpdateRezervariServicii(_context, selectedserviciu, rezervareToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateRezervariServicii(_context, selectedserviciu, rezervareToUpdate);
            PopulateAssignedData(_context, rezervareToUpdate);
            return Page();
        }

    }
}
