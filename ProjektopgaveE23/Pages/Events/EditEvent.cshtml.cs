using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Events
{
    public class EditEventModel : PageModel
    {

        private IEventRepository _repo;

        [BindProperty]
        public Event UpdatedEvent { get; set; }

        public EditEventModel(IEventRepository eventRepository)
        {
            _repo = eventRepository;
        }


        public void OnGet(int id)
        {
            UpdatedEvent=_repo.GetEvent(id);
        }

        public IActionResult OnPostUpdate() 
        {
            _repo.UpdateEvent(UpdatedEvent);
            return RedirectToPage("index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("index");
        }

    }
}
