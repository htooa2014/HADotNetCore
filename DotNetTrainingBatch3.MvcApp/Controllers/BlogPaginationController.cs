using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvcApp.Controllers
{
    public class BlogPaginationController : Controller
    {
        public IActionResult Index(int pageNo=1, int pageSize = 10)
        {
            AppDBContext _db=new AppDBContext();
            int rowCount = _db.Blogs.Count();
            int pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
            {
                pageCount++;
            }


            if (pageNo > pageCount)
            {
                return View();
            }

            List<BlogModel> blogs = _db.Blogs
                .OrderBy(x => x.BlogId)
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize).ToList();

            BlogResponseModel model = new BlogResponseModel();
            model.Data = blogs;
            model.PageNumber = pageNo;
            model.PageSize = pageSize;

            model.PageCount = pageCount;

            return View("Index",model);
        }
    }
}
