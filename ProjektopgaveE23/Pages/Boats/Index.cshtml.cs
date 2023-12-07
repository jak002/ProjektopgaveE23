using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private IBoatRepository _repo;
        private IUserRepository _userRepository;
        public List<Boat> Boats { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public User CurrentUser { get; set; }
        public IndexModel(IBoatRepository boatRepository, IUserRepository userRepository)
        {
            _repo = boatRepository;
            _userRepository = userRepository;
        }
        public void OnGet()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername != null)
            {
                CurrentUser = _userRepository.GetUser(sessionusername);
            }
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = _repo.FilterBoats(FilterCriteria);
            }
            else
            {
                Boats = _repo.GetAllBoats();
            }
            
        }
    }
}
