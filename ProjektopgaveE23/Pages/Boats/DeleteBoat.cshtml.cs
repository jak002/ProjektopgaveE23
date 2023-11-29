using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private IBoatRepository _repo;

        public Boat DeleteBoat { get; set; }
        public DeleteBoatModel(IBoatRepository repo)
        {
            _repo = repo;
        }
        public IActionResult OnGet(int deleteId)
        {
            DeleteBoat = _repo.GetBoat(deleteId);
            return Page();
        }
        public IActionResult OnPostDelete(int number)
        {
            DeleteBoat = _repo.GetBoat(number);
            _repo.DeleteBoat(DeleteBoat);
            return RedirectToPage("Index");
        }
    }
}