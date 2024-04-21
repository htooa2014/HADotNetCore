using DotNetTrainingBatch3.LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace DotNetTrainingBatch3.LoginApp.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDBContext _db;

        public UserController()
        {
            _db = new AppDBContext();
        }

        [ActionName("Create")]
        public IActionResult Index()
        {
            UserModel userModel = new UserModel();
            return View("Index", userModel);
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {

            //check user name already exists
            var check_user=_db.users.SingleOrDefault(x=>x.UserName==user.UserName);
            if(check_user != null)
            {
                return Redirect("/User/Create");
            }


            string ulID = Ulid.NewUlid().ToString();
            //save user Data
            user.UserId = ulID;
            _db.users.Add(user);
            _db.SaveChanges();

           


            return Redirect("/Login");
        }

    }


}
