using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Users
{
    public class UpdateUserModel : PageModel
    {

        private IUserRepository _urepo;

        [BindProperty]
        public User UsertoUpdate { get; set; }

        public User CurrentUser { get; set; }

        public UpdateUserModel(IUserRepository users)
        {
            _urepo = users;
        }

        public IActionResult OnGet(string username)
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername == null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                CurrentUser = _urepo.GetUser(sessionusername);
                UsertoUpdate = _urepo.GetUser(username);
                return Page();
            }

        }

        public IActionResult OnPost()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _urepo.GetUser(sessionusername);
            _urepo.UpdateUser(UsertoUpdate);
            if (UsertoUpdate.Username != CurrentUser.Username && CurrentUser.Admin)
            {
                return RedirectToPage("Index");
            }
            return RedirectToPage("Info");
        }
    }
}
