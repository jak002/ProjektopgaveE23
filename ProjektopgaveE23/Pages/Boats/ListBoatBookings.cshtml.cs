using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Boats
{
    public class ListBoatBookingsModel : PageModel
    {
        private IBoatBookingRepository boatBookingRepository;

        public List<BoatBooking> Bookings { get; set; }
        public ListBoatBookingsModel(IBoatBookingRepository boatBookingRepo)
        {
            boatBookingRepository = boatBookingRepo;
            Bookings = boatBookingRepository.GetAllBoatBookings();
        }
        public void OnGet()
        {
            EventBookings = _eventBookingRepo.GetAllBookings();
        }
    }
}
