using Microsoft.AspNetCore.Mvc;

namespace TrainingFPT.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
