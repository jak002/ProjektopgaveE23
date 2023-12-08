using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Pages.BlogSection
{
    public class IndexModel : PageModel
    {
        private IBlogRepository _blogRepository;

        public List<Blog> Posts { get; set; }

        public IndexModel(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }


        public void OnGet()
        {
            Posts = _blogRepository.GetAllPosts();
        }
    }
}
