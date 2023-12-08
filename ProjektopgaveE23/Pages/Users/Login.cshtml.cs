using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Users
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        private IUserRepository _urepo;
        public LoginModel(IUserRepository users)
        {
            _urepo = users;
        }

        public void OnGet()
        {
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("Username");
        }

        public IActionResult OnPost()
        {
            bool valid = true;
            if (Username == null) 
            {
                valid = false;
                Message = "Husk at skrive brugernavn";
            }
            if (Password == null) 
            {
                if (valid == false)
                {
                    Message = "Indtast brugernavn og password nedenfor";
                }
                else
                {
                    valid = false;
                    Message = "Husk at skrive password";
                }
            }
            if (valid)
            {
                User loginUser = _urepo.VerifyUser(Username, Password);
                if (loginUser != null)
                {

                    HttpContext.Session.SetString("Username", loginUser.Username);
                    return RedirectToPage("Info");
                }
                else
                {
                    Message = "Forkert brugernavn eller password";
                    Username = "";
                    Password = "";
                    return Page();
                }
            } else
            {
                return Page();
            }

        }
    }
}
