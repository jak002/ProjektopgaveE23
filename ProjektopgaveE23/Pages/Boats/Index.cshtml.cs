using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private IBoatRepository _repo;
        public List<Boat> Boats { get; set; }
        
        public IndexModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }
        public void OnGet()
        {
            
                Boats = _repo.GetAllBoats();
            
        }
    }
}
