using Microsoft.AspNetCore.Mvc;

namespace TrainingFPT.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
