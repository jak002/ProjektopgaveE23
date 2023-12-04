using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Users
{
    public class InfoModel : PageModel
    {

        public User CurrentUser { get; set; }

        private IUserRepository _urepo;

        public InfoModel(IUserRepository users)
        {
            _urepo = users;
        }
        public IActionResult OnGet()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername == null)
            {
                return RedirectToPage("Login");
            } else
            {
                CurrentUser = _urepo.GetUser(sessionusername);
                return Page();
            }
        }
    }
}
