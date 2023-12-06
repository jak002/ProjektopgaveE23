using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Interfaces
{
    public interface IBlogRepository    
    {
        
        void AddBlogPost(Blog blogPost);

        List<Blog> GetAllPosts();

        Blog GetBlogPost(int id);

        void UpdateBlogPost(Blog blogPost);

        void DeleteBlogPost(Blog blogPost);
    }
}
