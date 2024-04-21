using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.ChatApp.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
