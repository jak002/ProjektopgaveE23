using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjektopgaveE23.Pages.Events
{
    public class DeleteEventModel : PageModel
    {
        private IEventRepository _repo;
        private IUserRepository _userRepository;

        public Event DeleteEvent { get; set; }

        public User CurrentUser { get; set; }

        public DeleteEventModel(IEventRepository eventRepository, IUserRepository userRepository)
        {
           _repo = eventRepository;
           _userRepository = userRepository;
        }



        public IActionResult OnGet(int deleteId)
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
                DeleteEvent = _repo.GetEvent(deleteId);
                return Page();
            }
            //DeleteEvent = _repo.GetEvent(deleteId);
            //return Page(); 

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
