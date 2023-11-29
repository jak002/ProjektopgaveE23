using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Events
{
    public class IndexModel : PageModel
    {

        private IEventRepository _repo;

        public List<Event> Events { get; set; }

        public IndexModel(IEventRepository eventRepository)
        {
            _repo = eventRepository;
        }



        public void OnGet()
        {
            Events = _repo.GetAllEvents();
        }
    }
}
