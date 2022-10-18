using Microsoft.AspNetCore.Mvc;
using Project.BLL.Service;
using Project5.Entities.Entity;
using System.Linq;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "Kategori";
            var categories = categoryService.GetAllCategories().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            TempData["Title"] = "Yeni Kategori";
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            categoryService.CreateCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var category = categoryService.GetById(Id);
            categoryService.RemoveCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var category = categoryService.GetById(id);
                
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            
            categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }
    }
}
