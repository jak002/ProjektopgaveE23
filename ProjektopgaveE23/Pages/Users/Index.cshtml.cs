using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Users
{
    public class IndexModel : PageModel
    {
        private IUserRepository _urepo;

        public User CurrentUser { get; set; }
        public List<User> Users { get; private set; }

        public IndexModel(IUserRepository users)
        {
            _urepo = users;
            CurrentUser = null;
        }

        public IActionResult OnGet()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername != null)
            {
                if (_urepo.GetUser(sessionusername).Admin)
                {
                    CurrentUser = _urepo.GetUser(sessionusername);
                    Users = _urepo.GetAllUsers().Values.ToList();
                    return Page();
                }
                else
                {
                    return RedirectToPage("/RestrictedAdminAccess");
                }
            }
            else
            {
                return RedirectToPage("Login");
            }

        }
    }
}
