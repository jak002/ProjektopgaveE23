using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Users
{
    public class IndexModel : PageModel
    {
        private IUserRepository _urepo;

        public List<User> Users { get; private set; }

        public IndexModel(IUserRepository users)
        {
            _urepo = users;
        }

        public void OnGet()
        {
            Users = _urepo.GetAllUsers().Values.ToList();
        }
    }
}
