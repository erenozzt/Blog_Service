using BlogService.Business;
using BlogService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BlogService.Controllers
{
    [Authorize]
    [Route("v1/")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _repository;
        public ILogger<BlogController> _logger;
        public BlogController(ILogger<BlogController> logger) => _logger = logger;

        public BlogController(IBlogRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("AddBlog")]
        public ActionResult AddBlog(Blog item)
        {
            _repository.InsertBlog(item.Author, item.Description, item.Title, item.CreatedDate.ToString());
            return Ok(item);
        }
         
        [HttpGet]
        [Route("GetBlogs")]
        public ActionResult<List<Blog>> GetBlogs()
        {
            var allBlogs = _repository.GetAllBlogs();
            if (allBlogs.Count>0)
                _logger.LogInformation("All Blogs bring here.");
            return Ok(allBlogs);
        } 

        [HttpGet]
        [Route("GetBlog/{Id}")]
        public ActionResult<Blog> GetBlog(int Id)
        {
            var blog = _repository.GetBlogById(Id);
            if (blog == null)
                _logger.LogCritical("Critical Level");
            return Ok(blog);
        }

        [HttpPost]
        [Route("Delete/{Id}")]
        public ActionResult DeleteBlogById(int Id)
        {
            _repository.DeleteBlogById(Id);
            return Ok();
        }
    }
}