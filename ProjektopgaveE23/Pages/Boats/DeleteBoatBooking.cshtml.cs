using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Boats
{
    public class DeleteBoatBookingModel : PageModel
    {
        private IBoatBookingRepository _boatBookingRepo;
        private IBoatRepository _boatRepository;
        private IUserRepository _userRepository;

        [BindProperty]
        public BoatBooking BookingToDelete { get; set; }

        [BindProperty]
        public Boat Boat { get; set; }

        public User CurrentUser { get; set; }

        public string Message { get; set; }

        public DeleteBoatBookingModel(IBoatBookingRepository boatBookingRepo, IBoatRepository boatRepository, IUserRepository userRepository)
        {
            _boatBookingRepo = boatBookingRepo;
            _boatRepository = boatRepository;
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
            BookingToDelete = _boatBookingRepo.GetBoatBookingById(deleteId);
            Boat = _boatRepository.GetBoat(BookingToDelete.BoatId);

        }

        public IActionResult OnPostDelete(int idNumber)
        {
            BookingToDelete = _boatBookingRepo.GetBoatBookingById(idNumber);

            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _userRepository.GetUser(sessionusername);

            if (BookingToDelete.Username != CurrentUser.Username && !CurrentUser.Admin)
            {
                Message = "Denne booking kan ikke slettes da den ikke tilhøre dig";
                return Page();
            }

            _boatBookingRepo.DeleteBoatBooking(BookingToDelete);
            return RedirectToPage("ListBoatBookings");

        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("ListBoatBookings");
        }
    }
}
