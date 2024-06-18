using DemoAppWeb_Session.BLL.Interfaces;
using DemoAppWeb_Session.BLL.Models;
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

            // Enregistrer le membre dans la session (-> Evolution : SessionManager)
            HttpContext.Session.SetInt32("MemberId", member.MemberId);
            HttpContext.Session.SetString("Username", member.Username);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Logout()
        {
            // Efface la session (-> Evolution : SessionManager)
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
