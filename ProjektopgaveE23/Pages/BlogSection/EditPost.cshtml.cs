using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.BlogSection    
{
    public class EditPostModel : PageModel
    {

        private IBlogRepository _blogRepository;
        private IUserRepository _userRepository;

        [BindProperty]
        public Blog UpdatedPost { get; set; }

        public User CurrentUser { get; set; }



        public EditPostModel(IBlogRepository blogRepository, IUserRepository userRepository)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
            
        }



        public IActionResult OnGet(int id)
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
                UpdatedPost = _blogRepository.GetBlogPost(id);
                return Page();
            }

        }

        public IActionResult OnPostUpdate(int id) 
        {
            
            if (!ModelState.IsValid)
            {

                UpdatedPost = _blogRepository.GetBlogPost(id);

                return Page();
            }
            _blogRepository.UpdateBlogPost(UpdatedPost);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }

    }
}
