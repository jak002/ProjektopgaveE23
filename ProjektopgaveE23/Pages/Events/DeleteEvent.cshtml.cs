using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Events
{
    public class DeleteEventModel : PageModel
    {
        private IEventRepository _repo;

        public Event DeleteEvent { get; set; }

        public DeleteEventModel(IEventRepository eventRepository)
        {
           _repo = eventRepository;
        }

        public IActionResult OnGet(int deleteId)
        {
            DeleteEvent = _repo.GetEvent(deleteId);
            return Page();

        }

        public IActionResult OnPostDelete(int idNumber)
        {
            DeleteEvent = _repo.GetEvent(idNumber);
            _repo.DeleteEvent(DeleteEvent);
            return RedirectToPage("index");
        }

        public IActionResult OnPostCancel() 
        {
            return RedirectToPage("index");
        }

    }
}
