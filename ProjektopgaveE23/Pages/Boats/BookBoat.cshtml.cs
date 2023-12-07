using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Boats
{
    public class BookBoatModel : PageModel
    {
        private IBoatRepository _boatRepository;
        private IUserRepository _userRepository;
        private IBoatBookingRepository _boatBookingRepository;


        public SelectList BoatNames { get; set; }
        public SelectList UserNames { get; set; }

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
        public void OnGet(int id)
        {
            Boat = _boatRepository.GetBoat(id);
        }

        public IActionResult OnPost(int id)
        {
            BoatBooking.BoatId = id;
            _boatBookingRepository.AddBoatBooking(BoatBooking);
            return RedirectToPage("ListBoatBookings");
        }

    }
}
