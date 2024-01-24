using Microsoft.AspNetCore.Mvc;

namespace TrainingFPT.Controllers
{
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
