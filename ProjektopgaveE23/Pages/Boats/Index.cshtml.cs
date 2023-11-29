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
        //[BindProperty(SupportsGet = true)]
        //public string FilterCriteria { get; set; }
        public IndexModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }
        public void OnGet()
        {
            //if (!string.IsNullOrEmpty(FilterCriteria))
            //{
            //    Boats = _repo.FilterBoats(FilterCriteria);
            //}
            //else
            //{
                Boats = _repo.GetAllBoats();
            //}
        }
    }
}
