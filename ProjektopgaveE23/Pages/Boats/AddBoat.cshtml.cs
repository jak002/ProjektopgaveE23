using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjektopgaveE23.Pages.Boats
{
    public class AddBoatModel : PageModel
    {
        private IBoatRepository _repo;
        private IWebHostEnvironment webHostEnvironment;
        private IUserRepository _userRepository;

        
        [BindProperty]
        public Boat NewBoat { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }
        public User CurrentUser { get; set; }
        public string Message { get; private set; }

        public AddBoatModel(IBoatRepository boatRepository, IWebHostEnvironment webHost, IUserRepository userRepository)
        {
            _repo = boatRepository;
            this.webHostEnvironment = webHost;
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
            if(!ModelState.IsValid)
            {
                Message = "Du skal tilføje et billede";
                return Page();
            }
            if (Photo != null)
            {
                if (NewBoat.BoatImage != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "/images/boatimages", NewBoat.BoatImage);
                    System.IO.File.Delete(filePath);
                }

                NewBoat.BoatImage = ProcessUploadedFile();
            }
            _repo.AddBoat(NewBoat);
            return RedirectToPage("Index");
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/boatimages");
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
