using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjektopgaveE23.Pages.Boats
{
    public class EditBoatModel : PageModel
    {
        private IBoatRepository _repo;
        private IUserRepository _userRepository;
        [BindProperty]
        public Boat BoatToUpdate { get; set; }
        public User CurrentUser { get; set; }
        public EditBoatModel(IBoatRepository boatRepository, IUserRepository userRepository)
        {
            _repo = boatRepository;
            _userRepository = userRepository;
        }
        public IActionResult OnGet(int id)
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
                BoatToUpdate = _repo.GetBoat(id);
                return Page();
            }
        }
        public IActionResult OnPostUpdate()
        {

            _repo.UpdateBoat(BoatToUpdate);
            return RedirectToPage("Index");
        }
        public IActionResult OnpostDelete()
        {
            _repo.DeleteBoat(BoatToUpdate);
            return RedirectToPage("Index");
        }
    }
}
