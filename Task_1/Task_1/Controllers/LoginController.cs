using Microsoft.AspNetCore.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class LoginController : Controller
    {
        public static bool IsLogged { get; set; } = false;
        public static bool IsAdmin { get; set; } = false;
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            List<User> users = new List<User>();
            users.Add(new User { Id = 1, IsAdmin = true, Password = "admin", Username = "admin" });
            users.Add(new User { Id = 2, IsAdmin = false, Password = "1234", Username = "foo" });

            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                IsAdmin = user.IsAdmin;
                IsLogged = true;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.WrongLogin = true;
            return View("Verify");
        }
        public IActionResult Verify()
        {
            return View();
        }
    }
}
