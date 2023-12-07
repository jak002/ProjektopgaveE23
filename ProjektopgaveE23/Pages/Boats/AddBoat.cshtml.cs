using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.Boats
{
    public class AddBoatModel : PageModel
    {
        private IBoatRepository _repo;
        private IWebHostEnvironment webHostEnvironment;
        [BindProperty]
        public Boat NewBoat { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public AddBoatModel(IBoatRepository boatRepository, IWebHostEnvironment webHost)
        {
            _repo = boatRepository;
            this.webHostEnvironment = webHost;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
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
