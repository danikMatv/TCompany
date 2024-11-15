using BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _userService.login(username, password);

            if (user != null)
            {
                // Створення сесії чи кукі для авторизованого користувача
                HttpContext.Session.SetString("UserId", user.id.ToString());

                // Перенаправлення до панелі керування товарами
                return RedirectToAction("Index", "Goods");
            }

            // Повідомлення про невірні дані
            ViewBag.ErrorMessage = "Невірний логін або пароль";
            return View();
        }
    }

}
