using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Programare.Data;
using Proiect_Medii_Programare.Models;

namespace Proiect_Medii_Programare.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext _context;

        public IndexModel(Proiect_Medii_Programare.Data.Proiect_Medii_ProgramareContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Serviciu = await _context.Serviciu.ToListAsync();

            if (Serviciu != null)
            {
                // Verificăm dacă lista Serviciu conține elemente
                if (Serviciu.Any())
                {
                    // Executăm cod suplimentar sau logica pentru tratarea datelor din Serviciu

                    // De exemplu, putem itera prin elementele din lista și afișa anumite informații
                    foreach (var serviciu in Serviciu)
                    {
                        // Exemplu de utilizare: Afisăm ID-urile și denumirile serviciilor
                        Console.WriteLine($"ID: {serviciu.ID}, Nume serviciu: {serviciu.ServiciiSuplimentare}");
                    }
                }
                else
                {
                    // Lista este goală, poți trata această situație în consecință
                    Console.WriteLine("Lista de servicii este goală.");
                }
            }
            else
            {
                // Lista Serviciu este null, tratează acest caz dacă este necesar
                Console.WriteLine("Lista de servicii este null.");
            }
        }
    }
}
