using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Events
{
    public class IndexModel : PageModel
    {

        private IEventRepository _repo;
        private IUserRepository _userRepository;

        public List<Event> Events { get; set; }

        public User CurrentUser { get; set; }

        public IndexModel(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _repo = eventRepository;
            _userRepository = userRepository;
        }



        public void OnGet()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername != null)
            {
                CurrentUser = _userRepository.GetUser(sessionusername);
            }
            Events = _repo.GetAllEvents();
        }





    }
}
