using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvcApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly AppDBContext _db;

        public BlogAjaxController()
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
           int result= _db.SaveChanges();
            //return Redirect("/Blog");
            //must return JSON
            string message= result>0 ? "Saving Successful.":"Saving Failed.";
            BlogMessageResponseModel model = new BlogMessageResponseModel()
            {
                IsSuccess = result > 0,
                Message = message
            };
            return Json(model);
        }



        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id,BlogModel blog)
        {
            BlogMessageResponseModel model = new BlogMessageResponseModel();

            var item=_db.Blogs.FirstOrDefault(x=>x.BlogId== id);
            if (item is null)
            {
                //  return Redirect("/Blog");
                model = new BlogMessageResponseModel()
                {
                    IsSuccess = false,
                    Message = "No Data Found"
                };
            
            
                     return Json(model);
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor=blog.BlogAuthor;
            item.BlogContent= blog.BlogContent; 

            int result=_db.SaveChanges();
            //  return Redirect("/Blog");
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            model = new BlogMessageResponseModel()
            {
                IsSuccess = result > 0,
                Message = message
             };
        
            
            return Json(model);
        }

        [HttpPost] // Add
        [ActionName("Delete")]
        public IActionResult Delete(BlogModel blog) //Delete(int id)
        {
            BlogMessageResponseModel model = new BlogMessageResponseModel();

            // var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == blog.BlogId);
            if (item is null)
            {
                //  return Redirect("/Blog");
                model = new BlogMessageResponseModel()
                {
                    IsSuccess = false,
                    Message = "No Data Found"
                };


                return Json(model);
            }

           _db.Remove(item);
            int result=_db.SaveChanges();
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            model = new BlogMessageResponseModel()
            {
                IsSuccess = result>0,
                Message = message
            };


            return Json(model);
            //  return Redirect("/Blog");
        }


    }
}
