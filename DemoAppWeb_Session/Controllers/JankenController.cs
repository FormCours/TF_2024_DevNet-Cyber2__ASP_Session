using Microsoft.AspNetCore.Mvc;

namespace DemoAppWeb_Session.Controllers
{
    public class JankenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
