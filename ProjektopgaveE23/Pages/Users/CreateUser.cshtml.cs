using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Users
{
    public class CreateUserModel : PageModel
    {
        private IUserRepository _urepo;

        [BindProperty]
        public User NewUser { get; set; }

        public CreateUserModel(IUserRepository users)
        {
            _urepo = users;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            NewUser.Admin = false;
            _urepo.AddUser(NewUser);
            return RedirectToPage("Index");
        }
    }
}
