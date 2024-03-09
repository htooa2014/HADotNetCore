using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDBContext _db;

        public BlogController()
        {
            _db = new AppDBContext();
        }

        [ActionName("Index")]
        public IActionResult Index()           
        {
            List<BlogModel> blogs = _db.Blogs.ToList();
            return View("Index",blogs);
        }

        [ActionName("Edit")]
        public IActionResult Edit(int id)
        {
           var item = _db.Blogs.FirstOrDefault(x=>x.BlogId==id);
            if (item is null)
                {
                return Redirect("/Blog");
            }
           
           
            return View("Edit",item);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            
            return View("Create");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            _db.SaveChanges();
            return Redirect("/Blog");
        }



        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id,BlogModel blog)
        {
            var item=_db.Blogs.FirstOrDefault(x=>x.BlogId== id);
            if (item is null )
            {
                return Redirect("/Blog");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor=blog.BlogAuthor;
            item.BlogContent= blog.BlogContent; 

            _db.SaveChanges();
            return Redirect("/Blog");
        }


        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }

           _db.Remove(item);
            _db.SaveChanges();


            return Redirect("/Blog");
        }


    }
}
