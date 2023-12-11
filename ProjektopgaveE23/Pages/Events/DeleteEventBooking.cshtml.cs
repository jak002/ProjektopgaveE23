using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Events
{
    public class DeleteEventBookingModel : PageModel
    {
        private IEventBookingRepo _eventBookingRepo;
        private IEventRepository _eventRepository;
        private IUserRepository _userRepository;

        [BindProperty]
        public EventBooking BookingToDelete { get; set; }

        [BindProperty]
        public Event Event {  get; set; }

        public User CurrentUser { get; set; }

        public string Message { get; set; }

        public DeleteEventBookingModel(IEventBookingRepo eventBookingRepo, IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventBookingRepo = eventBookingRepo;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
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


        public void OnGetDel(int deleteId)
            {
            BookingToDelete = _eventBookingRepo.GetBooking(deleteId);
            Event = _eventRepository.GetEvent(BookingToDelete.EventID);

        }

        public IActionResult OnPostDelete(int idNumber)
        {
            BookingToDelete = _eventBookingRepo.GetBooking(idNumber);
            
            //string sessionusername = HttpContext.Session.GetString("Username");
            //CurrentUser = _userRepository.GetUser(sessionusername);
            
            //if (BookingToDelete.Username != CurrentUser.Username && !CurrentUser.Admin)
            //{
            //    Message = "Denne booking kan ikke slettes da den ikke tilhøre dig";
            //    return Page();
            //}
            
            _eventBookingRepo.DeleteBooking(BookingToDelete);
            return RedirectToPage("Index");

        }

        public IActionResult OnPostCancel() 
        {
            return RedirectToPage("Index");
        }
    }
}
