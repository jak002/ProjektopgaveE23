using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Boats
{
    public class AddBoatModel : PageModel
    {
        private IBoatRepository _repo;
        private IWebHostEnvironment webHostEnvironment;
        [BindProperty]
        public Boat NewBoat { get; set; }

        public AddBoatModel(IBoatRepository boatRepository, IWebHostEnvironment webHost)
        {
            _repo = boatRepository;
            this.webHostEnvironment = webHost;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _repo.AddBoat(NewBoat);
            return RedirectToPage("Index");
        }
    }
}
