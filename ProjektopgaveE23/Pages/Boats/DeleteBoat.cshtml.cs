using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjektopgaveE23.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private IBoatRepository _repo;
        private IUserRepository _userRepository;

        public Boat DeleteBoat { get; set; }
        public User CurrentUser { get; set; }
        public DeleteBoatModel(IBoatRepository repo, IUserRepository userRepository)
        {
            _repo = repo;
            _userRepository = userRepository;
        }
        public IActionResult OnGet(int deleteId)
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _userRepository.GetUser(sessionusername);

            if (sessionusername == null)
            {
                return RedirectToPage("/users/Login");
            }
            if (!CurrentUser.Admin)
            {
                return RedirectToPage("/RestrictedAdminAccess");
            }
            else
            {
                //CurrentUser = _userRepository.GetUser(sessionusername);
                DeleteBoat = _repo.GetBoat(deleteId);
                return Page();
            }
        }
        public IActionResult OnPostDelete(int number)
        {
            DeleteBoat = _repo.GetBoat(number);
            _repo.DeleteBoat(DeleteBoat);
            return RedirectToPage("Index");
        }
    }
}