using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Service;
using System.Linq;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICategoryService categoryService;

        public HomeController(IProductService productService , UserManager<IdentityUser> userManager , ICategoryService categoryService)
        {
            this.productService = productService;
            this.userManager = userManager;
            this.categoryService = categoryService;
        }
        
        public IActionResult Index()
        {
            TempData["Title"] = "Anasayfa";
            ViewBag.ÜrünSayisi = productService.GetAllProduct().Count();
            ViewBag.KullaniciSayisi = userManager.Users.Count();
            ViewBag.KategoriSayisi = categoryService.GetAllCategories().Count();

  

            return View();
        }
    }
}
