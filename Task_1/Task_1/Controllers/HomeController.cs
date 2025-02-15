using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (LoginController.IsLogged != false)
            {
                if (LoginController.IsAdmin != false)
                {
                    ViewBag.IsAdmin = true;
                }
                return View();
            }
            return RedirectToAction("Verify", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
