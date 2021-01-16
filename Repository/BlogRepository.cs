using Dapper;
using BlogService.Models;
using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace BlogService.Business
{
    public class BlogRepository : IBlogRepository

    {
        private readonly List<Blog> _blogs;
        IDbConnection connection = new SqlConnection("Server=erenozzt\\SQLEXPRESS;Database=BlogDb;Integrated Security=True");
        public BlogRepository()
        {
            _blogs = new List<Blog>();
        } 
        public List<Blog> GetAllBlogs()
        {  
            var allBlogs = connection.Query<Blog>("sp_getAllBlogs", CommandType.StoredProcedure).ToList(); 
            return allBlogs;
        } 
        public Blog GetBlogById(int BlogId)
        {
            return connection.Query<Blog>("sp_getBlogById", new { BlogId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        } 
        public void InsertBlog(string Author, string Description, string Title, string CreatedDate)
        {
            DynamicParameters paramsValue = new DynamicParameters();

            paramsValue.Add("@Author", Author);
            paramsValue.Add("@Description", Description);
            paramsValue.Add("@Title", Title);
            paramsValue.Add("@CreatedDate", CreatedDate);

            connection.Execute("sp_insertBlogItem", paramsValue, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBlogById(int BlogId)
        {
            DynamicParameters paramsValue = new DynamicParameters();

            paramsValue.Add("@BlogId", BlogId); 

            connection.Execute("sp_deleteBlogByBlogId", paramsValue, commandType: CommandType.StoredProcedure);
        }
    }
}