using Microsoft.AspNetCore.Mvc;

namespace TrainingFPT.Controllers
{
    public class AppController : Controller
    {

        public IActionResult Home()
        {
            return View();
        }

        public string Profile()
        {
            return "Page Profile";
        }

        public IActionResult Index()
        {
            return View();
        }

        public string Course(string name, int? id = -1)
        {
            return $"Courses: {name} {id}";
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
