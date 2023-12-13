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
        public string UsernameMessage { get; set; }

        public CreateUserModel(IUserRepository users)
        {
            _urepo = users;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
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
                try
                {
                    NewUser.Admin = false;
                    NewUser.CreatedThroughWebsite = true;
                    _urepo.AddUser(NewUser);
                    return RedirectToPage("Index");
                } catch (ArgumentException ex)
                {
                    UsernameMessage = ex.Message;
                    return Page();
                }
            }
        }
    }
}
