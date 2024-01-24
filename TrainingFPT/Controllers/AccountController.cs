using Microsoft.AspNetCore.Mvc;

namespace TrainingFPT.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
