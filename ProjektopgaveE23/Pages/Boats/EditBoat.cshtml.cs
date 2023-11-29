using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Boats
{
    public class EditBoatModel : PageModel
    {
        private IBoatRepository _repo;
        [BindProperty]
        public Boat BoatToUpdate { get; set; }
        public EditBoatModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }
        public void OnGet(int id)
        {
            BoatToUpdate = _repo.GetBoat(id);
        }
        public IActionResult OnPostUpdate()
        {

            _repo.UpdateBoat(BoatToUpdate);
            return RedirectToPage("Index");
        }
        public IActionResult OnpostDelete()
        {
            _repo.DeleteBoat(BoatToUpdate);
            return RedirectToPage("Index");
        }
    }
}
