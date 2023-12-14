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
        public string Message {  get; set; }
        public string HoursMessage { get; set; }
        public string DateMessage { get; set; }

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
            string sessionusername = HttpContext.Session.GetString("Username");
            if (BoatBooking.NumberOfHours == 0 || BoatBooking.NumberOfHours > 12 || BoatBooking.DateTime < DateTime.Now || BoatBooking.DateTime > DateTime.Now.AddYears(2))
            {
                if(BoatBooking.NumberOfHours == 0 || BoatBooking.NumberOfHours > 12)
                {
                    HoursMessage = "Indtast gyldigt antal timer (mellem 1 og 12)";
                }
                if(BoatBooking.DateTime < DateTime.Now || BoatBooking.DateTime > DateTime.Now.AddYears(2))
                {
                    DateMessage = "Vælg gyldig dato for sejlads (mellem nu og 2 år frem)";
                }
                CurrentUser = _userRepository.GetUser(sessionusername);
                Boat = _boatRepository.GetBoat(id);
                return Page();
            }
            BoatBooking.BoatId = id;
            bool available = _boatBookingRepository.CheckAvailability(BoatBooking.BoatId, BoatBooking.DateTime, BoatBooking.EndDateTime);
            if (sessionusername == null)
            {
                return RedirectToPage("Login");
            }
            else if (!available)
            {
                Message = "Båden er optaget på valgte tidspunkt. Tjek båd booking for tilgængelige tider";
                Boat = _boatRepository.GetBoat(id);
                return Page();
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
