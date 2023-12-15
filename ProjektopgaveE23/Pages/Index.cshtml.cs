using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private IBoatBookingRepository _boatBookingRepository;
        public List<BoatBooking> Bookings { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBoatBookingRepository boatbookingrepo)
        {
            _boatBookingRepository = boatbookingrepo;
            _logger = logger;
        }

        public void OnGet()
        {
            Bookings = _boatBookingRepository.GetCurrentBookings();
        }
    }
}