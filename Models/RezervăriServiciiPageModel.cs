using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Medii_Programare.Data;
namespace Proiect_Medii_Programare.Models
{
    public class RezervăriServiciiPageModel:PageModel
 { 
 public List<AssignedData> AssignedDataList;
        public void PopulateAssignedData(Proiect_Medii_ProgramareContext context,Rezervare rezervare)
        {
            var toateserviciile = context.Serviciu;
            var rezervareserviciu = new HashSet<int>(
            rezervare.RezervăriServicii.Select(c => c.ServiciuID)); //
            AssignedDataList = new List<AssignedData>();
            foreach (var ser in toateserviciile)
            {
                AssignedDataList.Add(new AssignedData
                {
                    ServiciuID = ser.ID,
                    Nume = ser.ServiciiSuplimentare,
                    Assigned = rezervareserviciu.Contains(ser.ID)
                });
            }
        }
        public void UpdateRezervariServicii(Proiect_Medii_ProgramareContext context, string[] serviciiselectate, Rezervare rezervareToUpdate)
        {
            if (serviciiselectate == null)
            {
                rezervareToUpdate.RezervăriServicii = new List<RezervăriServicii>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(serviciiselectate);
            var rezervariservicii = new HashSet<int>(rezervareToUpdate.RezervăriServicii.Select(c => c.Serviciu.ID));
            foreach (var ser in context.Serviciu)
            {
                if (selectedCategoriesHS.Contains(ser.ID.ToString()))
                {
                    if (!rezervariservicii.Contains(ser.ID))
                    {
                        rezervareToUpdate.RezervăriServicii.Add(
                            new RezervăriServicii
                            {
                                RezervareID = rezervareToUpdate.ID,
                                ServiciuID = ser.ID
                            });
                    }
                }
                else
                {
                    if (rezervariservicii.Contains(ser.ID))
                    {
                        RezervăriServicii rezervareServiciuToRemove = rezervareToUpdate.RezervăriServicii.SingleOrDefault(i => i.ServiciuID == ser.ID);
                        context.Remove(rezervareServiciuToRemove);
                    }
                }
            }
        }
    }
}

