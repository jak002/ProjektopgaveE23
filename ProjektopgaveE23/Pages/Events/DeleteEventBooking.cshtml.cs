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

        [BindProperty]
        public EventBooking BookingToDelete { get; set; }

        [BindProperty]
        public Event Event {  get; set; }

        public DeleteEventBookingModel(IEventBookingRepo eventBookingRepo, IEventRepository eventRepository)
        {
            _eventBookingRepo = eventBookingRepo;
            _eventRepository = eventRepository;

        }


        public void OnGet(int deleteId)
        {
            BookingToDelete = _eventBookingRepo.GetBooking(deleteId);
            Event = _eventRepository.GetEvent(BookingToDelete.EventID);

        }

        public IActionResult OnPostDelete(int idNumber)
        {
            BookingToDelete = _eventBookingRepo.GetBooking(idNumber);
            _eventBookingRepo.DeleteBooking(BookingToDelete);
            return RedirectToPage("Index");

        }

        public IActionResult OnPostCancel() 
        {
            return RedirectToPage("Index");
        }
    }
}
