using DemoAppWeb_Session.BLL.Interfaces;
using DemoAppWeb_Session.BLL.Models;
using DemoAppWeb_Session.Extensions;
using DemoAppWeb_Session.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAppWeb_Session.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMemberService _MemberService;

        public AuthController(IMemberService memberService)
        {
            _MemberService = memberService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(MemberLoginForm loginForm)
        {
            if(!ModelState.IsValid)
            {
                return View(loginForm);
            }

            Member? member = _MemberService.Login(loginForm.Username, loginForm.Password);

            if (member == null)
            {
                ModelState.AddModelError("Login", "Bad credentials !");
                return View(loginForm);
            }

            HttpContext.Session.Start(member.MemberId, member.Username, member.Role);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Stop();

            return RedirectToAction("Index", "Home");
        }
    }
}
