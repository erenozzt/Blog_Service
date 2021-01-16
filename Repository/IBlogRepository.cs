using BlogService.Models;
using System.Collections.Generic;

namespace BlogService.Business
{
    public interface IBlogRepository
    {
        List<Blog> GetAllBlogs();
        Blog GetBlogById(int BlogId);
        void InsertBlog(string Author, string Description, string Title, string CreatedDate);
        void DeleteBlogById(int BlogId);
    }
}