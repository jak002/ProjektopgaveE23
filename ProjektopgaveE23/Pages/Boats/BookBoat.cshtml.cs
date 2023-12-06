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

        //private List<string> _facilities;
        //public List<string> Facilities { get { return _facilities; } }

        [BindProperty]
        public List<string> AreChecked { get; set; }

        public List<string> PriceModel { get; }

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
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //BoatBooking.Facilities = AreChecked;
            _boatBookingRepository.AddBoatBooking(BoatBooking);
            return RedirectToPage("ListBoatBookings");
        }

    }
}
