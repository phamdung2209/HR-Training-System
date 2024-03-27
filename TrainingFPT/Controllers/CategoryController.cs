using Microsoft.AspNetCore.Mvc;
using TrainingFPT.DataDBContext;
using TrainingFPT.Models.Queries;
using TrainingFPT.Models;
using TrainingFPT.Helper;

namespace TrainingFPT.Controllers
{
    public class CategoryController : Controller
    {

        public IActionResult Index(string search, string filterStatus)
        {
            CategoryModel categories = new CategoryModel();
            categories.CategoryDetailsList = new List<CategoryDetail>();
            var category = new CategoryQuery().GetCategories(search, filterStatus);
            foreach (var item in category)
            {
                categories.CategoryDetailsList.Add(item);

                //new CategoryDetail
                //{
                //    Id = item.Id,
                //    Name = item.Name,
                //    Description = item.Description,
                //    PosterName = item.PosterName,
                //    ParentId = item.ParentId,
                //    Status = item.Status,
                //    Created_at = item.Created_at,
                //    Updated_at = item.Updated_at,
                //    Deleted_at = item.Deleted_at
                //}
            }

            ViewData["search"] = search;
            ViewData["filterStatus"] = filterStatus;
            return View(categories);
        }

        public IActionResult Add()
        {
            CategoryDetail category = new CategoryDetail();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDetail category, IFormFile poster)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string uniquePoster = UploadFileHelper.UploadFile(poster);
                    //var categoryDetail = new Category()
                    //{
                    //    Name = category.Name,
                    //    Description = category.Description,
                    //    Poster = uniquePoster,
                    //    ParentId = category.ParentId,
                    //    Status = category.Status,
                    //    CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    //    UpdatedAt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),

                    //};

                    //_dbContext.Categories.Add(categoryDetail);
                    //await _dbContext.SaveChangesAsync();
                    int id = new CategoryQuery().AddCategory(category.Name!, category.Description!, uniquePoster, category.Status!);
                    Console.WriteLine("id: " + id);
                    if (id > 0)
                    {
                        TempData["saveStatus"] = true;
                    }
                    else
                    {
                        TempData["saveStatus"] = false;
                    }


                }
                catch (Exception e)
                {
                    TempData["saveStatus"] = false;
                    Console.WriteLine(e.Message);
                }
                return RedirectToAction("Index");

            }

            return View(category);
        }

        public IActionResult Edit(int id)
        {
            CategoryDetail category = new CategoryQuery().GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(CategoryDetail category, IFormFile poster)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryDetail = new CategoryQuery().GetCategoryById(category.Id);
                    string uniquePoster = categoryDetail.PosterName!;
                    if (category.Poster != null)
                    {
                        uniquePoster = UploadFileHelper.UploadFile(poster);
                        category.PosterName = uniquePoster;
                    }

                    bool result = new CategoryQuery().UpdateCategoryById(category);

                    if (result)
                    {
                        TempData["updateStatus"] = true;
                    }
                    else
                    {
                        TempData["updateStatus"] = false;
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["updateStatus"] = false;
                    Console.WriteLine("Error in Update (CategoryController): ", e.Message);
                    return Ok(e.Message);
                }
            }

            return View(category);
        }

        public IActionResult Delete(int id = -1)
        {
            bool result = new CategoryQuery().DeleteCategory(id);
            if (result)
            {
                TempData["deleteStatus"] = true;
            }
            else
            {
                TempData["deleteStatus"] = false;
            }
            return RedirectToAction("Index");
        }
    }
}
