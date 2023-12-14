using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.BlogSection
{
    public class IndexModel : PageModel
    {
        private IBlogRepository _blogRepository;
        private IUserRepository _userRepository;

        public List<Blog> Posts { get; set; }

        public User CurrentUser { get; set; }

        public IndexModel(IBlogRepository blogRepository, IUserRepository userRepository)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }


        public void OnGet()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername != null)
            {
                CurrentUser = _userRepository.GetUser(sessionusername);
            }
            Posts = _blogRepository.GetAllPosts();
        }
    }
}
