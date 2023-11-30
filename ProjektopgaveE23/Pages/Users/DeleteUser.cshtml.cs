using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Interfaces;

namespace ProjektopgaveE23.Pages.Users
{
    public class DeleteUserModel : PageModel
    {
        private IUserRepository _urepo;
        public User UserToDelete;

        public DeleteUserModel(IUserRepository users)
        {
            _urepo = users;
        }

        public IActionResult OnGet(string username)
        {
            UserToDelete = _urepo.GetUser(username);
            return Page();
        }

        public IActionResult OnPostDelete(string username)
        {
            UserToDelete = _urepo.GetUser(username);
            _urepo.DeleteUser(username);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
