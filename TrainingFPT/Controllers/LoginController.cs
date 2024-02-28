using TrainingFPT.Models;
using TrainingFPT.Models.Queries;
using Microsoft.AspNetCore.Mvc;

namespace TrainingFPT.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index(LoginViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Handle(LoginViewModel model)
        {
            model = new LoginQuery().CheckUserLogin(model.Username, model.Password);
            if (model.Id != null)
            {
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("sessionUserId")))
                {
                    HttpContext.Session.SetString("sessionUserId", model.Id);
                    HttpContext.Session.SetString("sessionUsername", model.Username);
                    HttpContext.Session.SetString("sessionRoleId", model.RolesId ?? "");

                }

                return RedirectToAction("Index", "Dashboard");
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "login");
        }
    }
}
