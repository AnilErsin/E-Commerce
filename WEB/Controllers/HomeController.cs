using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.BLL.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models;
using WEB.Models.ViewModel;
using WEB.Utils;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IProductService productService;

        public HomeController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager,IProductService productService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.productService = productService;
        }
        public IActionResult Index()
        {

            var product = productService.GetAllProduct().ToList();
            return View(product);
        }

        public IActionResult AddToCart(int id)
        {
            Cart cartSession;

            if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") == null)
            {
                cartSession = new Cart();
            }
            else
            {
                cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            }

            //Cart cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") == null ? new Cart() : SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");

            var newProduct = productService.GetById(id);




            CartItem cartItem = new CartItem()
            {
                Id = newProduct.ID,
                ProductName = newProduct.ProductName,
                UnitPrice = newProduct.UnitPrice

            };


            cartSession.AddItem(cartItem);

            SessionHelper.SetProductJson(HttpContext.Session, "sepet", cartSession);







            return RedirectToAction("Index");
        }

        public IActionResult MyCart()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
                {
                    Cart c = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
                    return View(c.MyCart);
                }
                else
                {
                    return RedirectToAction("Index");
                }


            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Register(RegisterVM registerUser)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser()
                {
                    UserName=registerUser.Username,
                    Email=registerUser.Email
               
                };
               

                var result = await userManager.CreateAsync(newUser,registerUser.Password);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index");
                    
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }


            return View(registerUser);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(loginUser.Username);

                if (user != null)
                {
                    var result =await signInManager.PasswordSignInAsync(user, loginUser.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }

                }
                
            }
            return View();
        }

        public async Task <IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
