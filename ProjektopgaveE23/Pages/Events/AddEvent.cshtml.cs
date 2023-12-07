using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjektopgaveE23.Pages.Events
{
    public class AddEventModel : PageModel
    {

        private IEventRepository _repo;
        private IUserRepository _userRepository;

        private IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public Event NewEvent { get; set; }

        public User CurrentUser { get; set; }

        public AddEventModel(IEventRepository eventRepository, IWebHostEnvironment webHost, IUserRepository userRepository)
        {
            _repo = eventRepository;
            this._webHostEnvironment = webHost;
            _userRepository = userRepository;
            
        }

        public IActionResult OnGet()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _userRepository.GetUser(sessionusername);

            if (sessionusername == null)
            {
                return RedirectToPage("/users/Login");
            }
            if (!CurrentUser.Admin)
            {
                return RedirectToPage("/RestrictedAdminAccess");
            }
            else
            {
                //CurrentUser = _userRepository.GetUser(sessionusername);
                return Page();
            }

        }

        public IActionResult OnPost()
        {
            if (Photo != null)
            {
                if (NewEvent.Image != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "/images/eventimages", NewEvent.Image);
                    System.IO.File.Delete(filePath);
                }

                NewEvent.Image = ProcessUploadedFile();
            }

            _repo.AddEvent(NewEvent);
            return RedirectToPage("Index");

        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/eventimages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


    }
}
