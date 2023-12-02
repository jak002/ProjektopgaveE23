using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Events
{
    public class ListEventBookingModel : PageModel
    {

        private IEventBookingRepo _eventBookingRepo;

        public List<EventBooking> EventBookings { get; set; }

        public ListEventBookingModel(IEventBookingRepo eventBookingRepo)
        {
            _eventBookingRepo = eventBookingRepo;
        }

        public void OnGet()
        {
            EventBookings = _eventBookingRepo.GetAllBookings();
        }
    }
}
