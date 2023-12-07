using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjektopgaveE23.Pages.Events
{
    public class EditEventModel : PageModel
    {

        private IEventRepository _repo;
        private IUserRepository _userRepository;

        public User CurrentUser { get; set; }

        [BindProperty]
        public Event UpdatedEvent { get; set; }

        public EditEventModel(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _repo = eventRepository;
            _userRepository = userRepository;
        }


        public IActionResult OnGet(int id)
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _userRepository.GetUser(sessionusername);

            if (sessionusername == null)
            {
                return RedirectToPage("/users/Login");
            }
            if (!CurrentUser.Admin)
            {
                return RedirectToPage("/RestrictedAdminAccess");
            }
            else
            {
                //CurrentUser = _userRepository.GetUser(sessionusername);
                UpdatedEvent =_repo.GetEvent(id);
                return Page();
            }
            
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
