using Microsoft.AspNetCore.Mvc;

namespace TrainingFPT.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("sessionUserId")))
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
