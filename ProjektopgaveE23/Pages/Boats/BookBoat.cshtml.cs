using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjektopgaveE23.Pages.Boats
{
    public class BookBoatModel : PageModel
    {
        private IBoatRepository _boatRepository;
        private IUserRepository _userRepository;
        private IBoatBookingRepository _boatBookingRepository;


        public SelectList BoatNames { get; set; }
        public SelectList UserNames { get; set; }
        public User CurrentUser { get; set; }

        [BindProperty]
        public Boat Boat { get; set; }
        [BindProperty]
        public BoatBooking BoatBooking { get; set; }
        public BookBoatModel(IBoatRepository boatRepo, IUserRepository userrepo, IBoatBookingRepository bookingRepository)
        {
            _boatRepository = boatRepo;
            _userRepository = userrepo;
            _boatBookingRepository = bookingRepository;
            List<Boat> boats = _boatRepository.GetAllBoats();
            BoatNames = new SelectList(boats, "Id", "Name");
            List<User> users = _userRepository.GetAllUsers().Values.ToList();
            UserNames = new SelectList(users, "Username", "Name");
            

        }
        public IActionResult OnGet(int id)
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _userRepository.GetUser(sessionusername);

            if (sessionusername == null)
            {
                return RedirectToPage("/users/Login");
            }
            else
            {
                //CurrentUser = _userRepository.GetUser(sessionusername);
                Boat = _boatRepository.GetBoat(id);
                return Page();
            }
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            BoatBooking.BoatId = id;
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername == null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                CurrentUser = _userRepository.GetUser(sessionusername);
                BoatBooking.Username = CurrentUser.Username;
                _boatBookingRepository.AddBoatBooking(BoatBooking);
                return RedirectToPage("ListBoatBookings");
            }
        }

    }
}
