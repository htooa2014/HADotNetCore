using DotNetTrainingBatch3.LoginApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.LoginApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDBContext _db;

        public LoginController()
        {
            _db = new AppDBContext();
        }

        [ActionName("Index")]
        public IActionResult Login()
        {
            UserModel user = new UserModel();
            return View(user);
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel user)
        {
            string ulID = Ulid.NewUlid().ToString();




         
               
                //Create Cookie Session
                CookieOptions option=new CookieOptions();
                option.Expires = DateTime.Now.AddSeconds(10);
                Response.Cookies.Append("UserName", user.UserName, option);
                Response.Cookies.Append("Password", user.Password, option);
                Response.Cookies.Append("SessionExpired", option.Expires.ToString(), option);



                return Redirect("/Home");
            

            //using (DB_Entities db = new DB_Entities())
            //{
            //    var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
            //    if (obj != null)
            //    {
            //        Session["UserID"] = obj.UserId.ToString();
            //        Session["UserName"] = obj.UserName.ToString();
            //        return RedirectToAction("UserDashBoard");
            //    }
            //}

            return Redirect("/Home");
        }
    }
}
