using Microsoft.AspNetCore.Mvc;

namespace DemoAppWeb_Session.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
