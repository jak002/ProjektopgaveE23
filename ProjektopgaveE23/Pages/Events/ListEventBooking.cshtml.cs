using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjektopgaveE23.Pages.Events
{
    public class ListEventBookingModel : PageModel
    {

        private IEventBookingRepo _eventBookingRepo;
        private IEventRepository _eventRepository;
        private IUserRepository _userRepository;

        [BindProperty]
        public int EventID { get; set; }

        public Event Event { get; set; }

        public User CurrentUser { get; set; }
        

        public List<EventBooking> EventBookings { get; set; }

        public int EventCount { get; set; }

        public ListEventBookingModel(IEventBookingRepo eventBookingRepo, IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventBookingRepo = eventBookingRepo;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        public IActionResult OnGetAll(int id)
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername != null)
            {
                CurrentUser = _userRepository.GetUser(sessionusername);
            }

            Event = _eventRepository.GetEvent(id);

            EventID = id;

            EventCount = _eventBookingRepo.CalculateAttendees(id);

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

        public ActionResult OnGetPersonal(int id) 
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername != null)
            {
                CurrentUser = _userRepository.GetUser(sessionusername);
            }

            Event = _eventRepository.GetEvent(id);

            EventID = id;

            EventBookings = new List<EventBooking>();
            if (EventID == null)
            {
                return NotFound();
            }
            EventBookings = _eventBookingRepo.GetBookingByUser(CurrentUser.Username, id);
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
