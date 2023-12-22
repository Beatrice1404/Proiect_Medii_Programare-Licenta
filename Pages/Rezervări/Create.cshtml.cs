using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Medii_Programare.Data;
using Proiect_Medii_Programare.Models;

namespace Proiect_Medii_Programare.Pages.Rezervări
{

    public class CreateModel : RezervăriServiciiPageModel
    {
        private readonly Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext _context;

        public CreateModel(Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CamerăID"] = new SelectList(_context.Cameră, "ID",
           "TipCameră");
            ViewData["SpecieID"] = new SelectList(_context.Specie, "ID",
           "SpecieAnimal");

            var rez = new Rezervare();
            rez.RezervăriServicii = new List<RezervăriServicii>();
            PopulateAssignedData(_context, rez);
            return Page();
        }
        [BindProperty]
        public Rezervare Rezervare { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedservicii)
        {
            var newRezervare = new Rezervare();
            if (selectedservicii != null)
            {
                newRezervare.RezervăriServicii = new List<RezervăriServicii>();
                foreach (var ser in selectedservicii)
                {
                    var serToAdd = new RezervăriServicii
                    {
                        ServiciuID = int.Parse(ser)
                    };
                    newRezervare.RezervăriServicii.Add(serToAdd);
                }
            }
            Rezervare.RezervăriServicii = newRezervare.RezervăriServicii;
            _context.Rezervare.Add(Rezervare);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}