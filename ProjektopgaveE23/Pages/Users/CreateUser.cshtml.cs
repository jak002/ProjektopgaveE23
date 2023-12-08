using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Helpers;

namespace ProjektopgaveE23.Pages.Users
{
    public class CreateUserModel : PageModel
    {
        private IUserRepository _urepo;

        [BindProperty]
        public User NewUser { get; set; }
        public string EmailMessage { get; set; }
        public string PhoneMessage { get; set; }

        public CreateUserModel(IUserRepository users)
        {
            _urepo = users;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            bool valid = true;
            if (!InputValidator.ValidateEmail(NewUser.Email))
            {
                EmailMessage = "E-mail skal formateres korrekt";
                valid = false;
            }
            if (!InputValidator.ValidatePhone(NewUser.PhoneNumber))
            {
                PhoneMessage = "Telefonnummer må kun indeholde tal, +, og mellemrum";
                valid = false;
            }

            if (!valid)
            {
                return Page();
            }
            else
            {
                NewUser.Admin = false;
                _urepo.AddUser(NewUser);
                return RedirectToPage("Index");
            }
        }
    }
}
