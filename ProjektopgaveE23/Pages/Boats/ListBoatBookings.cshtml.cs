using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjektopgaveE23.Pages.Boats
{
    public class ListBoatBookingsModel : PageModel
    {
        private IBoatBookingRepository boatBookingRepository;
        private IUserRepository _userRepository;

        public List<BoatBooking> Bookings { get; set; }
        public User CurrentUser { get; set; }
        public ListBoatBookingsModel(IBoatBookingRepository boatBookingRepo, IUserRepository userRepository)
        {
            boatBookingRepository = boatBookingRepo;
            Bookings = boatBookingRepository.GetAllBoatBookings();
            _userRepository = userRepository;
        }
        public IActionResult OnGet()
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
                Bookings = boatBookingRepository.GetAllBoatBookings();
                return Page();
            }
        }
    }
}
