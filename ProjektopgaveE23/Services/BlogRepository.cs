using ProjektopgaveE23.Helpers;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Services
{
    public class BlogRepository : IBlogRepository
    {

        private string Filepath = @"Data\jsonBlog.json";

        public void AddBlogPost(Blog blogPost)
        {
            List<int> blogId = new List<int>();
            List<Blog> blogposts = GetAllPosts();
            foreach (var post in blogposts) 
            {
                blogId.Add(post.Id);
            }
            if (blogId.Count != 0) 
            {
                int start = blogId.Max();
                blogPost.Id = start + 1;
            }
            else
            {
                blogPost.Id = 1;
            }
            blogposts.Add(blogPost);
            JsonFileWriter<Blog>.WriteToJson(blogposts, Filepath);
        }

        public void DeleteBlogPost(Blog blogPost)
        {
            List<Blog> posts = GetAllPosts();
            posts.Remove(blogPost);
            JsonFileWriter<Blog>.WriteToJson(posts, Filepath);
        }

        public List<Blog> GetAllPosts()
        {
            return JsonFileReader<Blog>.ReadJson(Filepath);
        }

        public Blog GetBlogPost(int id)
        {
            foreach(var posts in GetAllPosts()) 
            {
                if (posts.Id == id)
                {
                    return posts;
                }
            }
            return new Blog();
        }

        public void UpdateBlogPost(Blog updatedPost)
        {
            if (updatedPost != null)
            {
                List<Blog> posts = GetAllPosts();
                foreach (var post in posts) 
                { 
                    post.Id = updatedPost.Id;
                    post.Title = updatedPost.Title;
                    post.Text = updatedPost.Text;
                    //post.Date = updatedPost.Date; man burde ikke kunne ændre en dato
                    //måske image

                    break;
                
                }
                JsonFileWriter<Blog>.WriteToJson(posts,Filepath);
            }
        }



    }
}
