using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Events
{
    public class ListEventBookingModel : PageModel
    {

        private IEventBookingRepo _eventBookingRepo;
        private IEventRepository _eventRepository;

        [BindProperty]
        public int EventID { get; set; }

        public Event Event { get; set; }
        

        public List<EventBooking> EventBookings { get; set; }

        public ListEventBookingModel(IEventBookingRepo eventBookingRepo, IEventRepository eventRepository)
        {
            _eventBookingRepo = eventBookingRepo;
            _eventRepository = eventRepository;
        }

        public IActionResult OnGet(int id)
        {
            Event = _eventRepository.GetEvent(id);

            EventID = id;
            EventBookings = new List<EventBooking>();
            if (EventID == null) 
            { 
                return NotFound();
            }
            EventBookings = _eventBookingRepo.GetAllbookingsByEvent(id);
            {
                if (EventBookings == null) 
                {
                    return NotFound();
                }
            }
            return Page();

        }
    }
}
