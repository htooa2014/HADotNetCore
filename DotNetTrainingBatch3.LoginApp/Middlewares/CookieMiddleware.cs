using DotNetTrainingBatch3.LoginApp.Models;

namespace DotNetTrainingBatch3.LoginApp.Middlewares
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppDBContext _db;


        public CookieMiddleware(RequestDelegate next)
        {
            _next = next;
            _db = new AppDBContext();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string url = context.Request.Path.ToString().ToLower();
            if (url == "/login" || url == "/login/index" || url == "/user/create")
            {
                goto result;
            }


            string userName = context.Request.Cookies["UserName"]!;
            string password = context.Request.Cookies["Password"]!;
            string sessionExpired = context.Request.Cookies["SessionExpired"]!;

            if (userName == null && password == null && sessionExpired==null)
            {
                context.Response.Redirect("/Login");
                goto result;
            }


            var _user = _db.users.SingleOrDefault(x => x.UserName == userName  && x.Password == password);
            if (_user == null)
            {
                context.Response.Redirect("/Login");
                goto result;
            }

            //if user exists

            //Save in Login table
            string sessionID = Ulid.NewUlid().ToString();
            //save user Data
            LoginModel login = new LoginModel()
            {
                LoginID = 0,
                UserID = _user.UserId,
                SessionID = sessionID,
                SessionExpired = Convert.ToDateTime(sessionExpired)
            };


            _db.logins.Add(login);
            _db.SaveChanges();

        //if (string.IsNullOrEmpty(userName))
        //{
        //    context.Response.Redirect("/Login");
        //}

        result:
            await _next(context);
        }
    }
}
