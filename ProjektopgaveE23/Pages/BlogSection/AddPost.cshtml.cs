using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.BlogSection
{
    public class AddPostModel : PageModel
    {

        private IBlogRepository _blogRepository;
        private IUserRepository _userRepository;
        private IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public Blog NewPost {  get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public User CurrentUser { get; set; }

        public AddPostModel(IBlogRepository blogRepository, IUserRepository userRepository, IWebHostEnvironment webHostEnvironment)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
            this._webHostEnvironment = webHostEnvironment;

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
            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _userRepository.GetUser(sessionusername);

            NewPost.Author = CurrentUser.Name;
            
            if (Photo != null)
            {
                if (NewPost.BlogImage != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "/images/blogimages", NewPost.BlogImage);
                    System.IO.File.Delete(filePath);
                }

                NewPost.BlogImage = ProcessUploadedFile();
            }

            _blogRepository.AddBlogPost(NewPost);
            return RedirectToPage("Index");

        }


        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/blogimages");
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
