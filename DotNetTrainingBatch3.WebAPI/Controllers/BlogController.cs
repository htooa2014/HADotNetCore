using DotNetTrainingBatch3.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDBContext _db;

        public BlogController()
        {
            _db = new AppDBContext();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> blogs = _db.Blogs.ToList();

            return Ok(blogs);
        }


        [HttpGet("{id}")]
        public IActionResult GetBlogs(int id)
        {
            BlogModel blog = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (blog == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(blog);
        }

        [HttpPost]
        public IActionResult CreateBlogs(BlogModel model)
        {
            _db.Blogs.Add(model);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlogs(int id, BlogModel model)
        {
            var blog = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (blog == null)
            {
                return NotFound("No Data Found");
            }

            blog.BlogTitle = model.BlogTitle;
            blog.BlogAuthor = model.BlogAuthor;
            blog.BlogContent = model.BlogContent;

            int result = _db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Update fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlogs(int id)
        {
            var blog = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (blog == null)
            {
                return NotFound("No Data Found");
            }


            _db.Remove(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Delete fail";
            return Ok(message);

        }
    }
}
