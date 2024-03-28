using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingFPT.Helper;
using TrainingFPT.Models;
using TrainingFPT.Models.Queries;

namespace TrainingFPT.Controllers
{
    public class CourseController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CourseModel course = new CourseModel();
            course.CourseDetailsList = new List<CourseDetail>();
            var dataCourse = new CourseQuery().GetCourses();
            foreach (var item in dataCourse)
            {
                course.CourseDetailsList.Add(new CourseDetail
                {
                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    Name = item.Name,
                    Description = item.Description,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Status = item.Status,
                    ImageUrlString = item.ImageUrlString,
                    CategoryName = item.CategoryName
                });
            }
            //var category = new CategoryQuery().GetCategories(null, null);
            //ViewBag.Categories = category;
            return View(course);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CourseDetail course = new CourseDetail();
            List<SelectListItem> itemCategories = new List<SelectListItem>();
            var dataCategory = new CategoryQuery().GetCategories(null, null);
            foreach (var item in dataCategory)
            {
                itemCategories.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }

            ViewBag.Categories = itemCategories;
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CourseDetail course, IFormFile ImageUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string imageUrl = UploadFileHelper.UploadFile(ImageUrl);
                    int IdCourse = new CourseQuery().AddCourse(course.Name, course.CategoryId, course.Description, imageUrl, course.StartDate, course.EndDate, course.Status);
                    
                    if (IdCourse > 0)
                    {
                        TempData["saveStatus"] = true;
                    }
                    else
                    {
                        TempData["saveStatus"] = false;
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }
            List<SelectListItem> itemCategories = new List<SelectListItem>();
            var dataCategory = new CategoryQuery().GetCategories(null, null);
            foreach (var item in dataCategory)
            {
                itemCategories.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }

            ViewBag.Categories = itemCategories;

            return View(course);
        }

        [HttpPost]
        public JsonResult Delete(int id = -1)
        {
            bool deleteCourse = new CourseQuery().DeleteCourseById(id);
            if (deleteCourse)
            {
                return Json("ok");
            }

            return Json("Error");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            CourseDetail course = new CourseQuery().GetCourseById(Id);
            List<SelectListItem> itemCategories = new List<SelectListItem>();
            var dataCategory = new CategoryQuery().GetCategories(null, null);
            foreach (var item in dataCategory)
            {
                itemCategories.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }

            ViewBag.Categories = itemCategories;
            return View(course);
        }

        [HttpGet]
        public IActionResult Edit1(int Id)
        {
            CourseDetail course = new CourseQuery().GetCourseById(Id);
            List<SelectListItem> itemCategories = new List<SelectListItem>();
            var dataCategory = new CategoryQuery().GetCategories(null, null);
            foreach (var item in dataCategory)
            {
                itemCategories.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }

            ViewBag.Categories = itemCategories;
            return View(course);
        }
    }
}
