using Microsoft.AspNetCore.Mvc;
using Project.BLL.Service;
using Project5.Entities.Entity;
using System.Linq;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService , ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var products = productService.GetAllProduct().ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = categoryService.GetAllCategories().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.ID.ToString()
            });
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            productService.CreateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete (int Id)
        {
            var product = productService.GetById(Id);
            productService.RemoveProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
            var product = productService.GetById(Id);
            ViewBag.Categories = categoryService.GetAllCategories()
              .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
              {
                  Text = x.CategoryName,
                  Value = x.ID.ToString()
              });
            return View(product);
        }
        [HttpPost]
        public IActionResult Update (Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("Index");
        }

    }
}
