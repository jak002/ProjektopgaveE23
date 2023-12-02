using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Events
{
    public class BookEventModel : PageModel
    {
        private IEventBookingRepo _bookingRepo;
        private IEventRepository _eventRepo;
        private IUserRepository _userRepo;

        public SelectList Usernames { get; set; } 

        public SelectList AtendeesNumber { get; set; }

        [BindProperty]
        public EventBooking EventBooking { get; set; }

        [BindProperty]
        public Event Event { get; set; }

        public BookEventModel(IEventBookingRepo eventBookingRepo,IEventRepository eventRepository, 
            IUserRepository userRepository)
        {
            _bookingRepo = eventBookingRepo;
            _eventRepo = eventRepository;
            _userRepo = userRepository;

            Dictionary<string,User> users = _userRepo.GetAllUsers();
            Usernames = new SelectList((IEnumerable<KeyValuePair<string, User>>)users);

            AtendeesNumber = new SelectList(numbers);

        }



        public void OnGet(int id)
        {
            Event = _eventRepo.GetEvent(id);
            
        }

        public IActionResult OnPostBooking() 
        {
            _bookingRepo.Addbooking(EventBooking);
            return RedirectToPage("ListEventBooking");
        
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }

        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        
    }
}

