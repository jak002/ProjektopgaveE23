using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using System.Diagnostics.CodeAnalysis;

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

        [BindProperty]
        public User CurrentUser {  get; set; } 

        public List<EventBooking> Found {  get; set; }

        public string Message { get; set; }

        public string Message2 { get; set; }

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

        public IActionResult OnGet()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername == null)
            {
                return RedirectToPage("/Users/Login");
            }
            else
            {

                return RedirectToPage("Index");
            }
        }



        public IActionResult OnGetBook(int id)
        {
            Event = _eventRepo.GetEvent(id);
            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _userRepo.GetUser(sessionusername);
            Found = _bookingRepo.GetBookingByUserAndEvent(CurrentUser.Username, id);
            if (sessionusername == null)
            {
                return RedirectToPage("/Users/Login");
            }
            else if (Found.Count!=0)
            {
                Message = "Du har allerede en booking, så du kan ikke lave flere";
                return Page();
            }
            else
            {
                CurrentUser = _userRepo.GetUser(sessionusername);
                return Page();
            }

        }

        public IActionResult OnPostBooking(int id) 
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            

            if (EventBooking.AttendeesPerBooking==0)
            {
                CurrentUser = _userRepo.GetUser(sessionusername);            
                Found = _bookingRepo.GetBookingByUserAndEvent(CurrentUser.Username, id);
                Event = _eventRepo.GetEvent(id);
                Message2 = "Du skal vælge antal deltager";

                return Page();
            }


            EventBooking.EventID = id;
            
            if (sessionusername == null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                CurrentUser = _userRepo.GetUser(sessionusername);
                EventBooking.Username = CurrentUser.Username;
                _bookingRepo.Addbooking(EventBooking);
                return RedirectToPage("Index");
            }

                

        
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }

        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        
    }
}

