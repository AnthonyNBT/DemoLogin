using DemoLogin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("Login", "Home");
            }
            
            ViewBag.LoginStatus = id;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (await IsRightUser(user))
                {
                    return RedirectToAction("Index", "Home", new { id = "SUCCESS" });
                }
                return RedirectToAction("Index", "Home", new { id = "FAIL" });
            }
            else
            {
                return View("Login", user);
            }
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        public async Task<bool> IsRightUser(User user)
        {
            await Task.Delay(3000);
            if (user.UserName.Equals("Admin") && user.Password.Equals("123456")) return true;
            return false;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
