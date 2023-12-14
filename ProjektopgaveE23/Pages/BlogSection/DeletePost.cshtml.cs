using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.BlogSection
{
    public class DeletePostModel : PageModel
    {

        private IBlogRepository _blogRepository;
        private IUserRepository _userRepository;

        public Blog DeletePost {  get; set; }

        public User CurrentUser { get; set; }

        public DeletePostModel(IBlogRepository blogRepository, IUserRepository userRepository)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }

        public IActionResult OnGet(int deleteId)
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
                DeletePost = _blogRepository.GetBlogPost(deleteId);
                return Page();
            }
        }

        public IActionResult OnPostDelete(int postId)
        {
            DeletePost = _blogRepository.GetBlogPost(postId);
            _blogRepository.DeleteBlogPost(DeletePost);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel() 
        {
            return RedirectToPage("Index");
        }


    }
}
