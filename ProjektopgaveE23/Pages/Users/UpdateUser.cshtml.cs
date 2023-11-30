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

        public UpdateUserModel(IUserRepository users)
        {
            _urepo = users;
        }

        public void OnGet(string username)
        {
            UsertoUpdate = _urepo.GetUser(username);
        }

        public IActionResult OnPost()
        {
            _urepo.UpdateUser(UsertoUpdate);
            return RedirectToPage("Index");
        }
    }
}
