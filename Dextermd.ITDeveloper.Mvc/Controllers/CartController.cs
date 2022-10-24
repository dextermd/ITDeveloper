using Dextermd.ITDeveloper.Domain.Entities;
using Dextermd.ITDeveloper.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dextermd.ITDeveloper.Mvc.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>();
            for(int i = 0; i < 11; i++)
            {
                var n = i < 10 ? "0" + i : i + "";
                products.Add(new Product
                {
                    Name = "Prod-" + n,
                    Stock = 3,
                    ExpirationDate = DateTime.Now,
                    Price = 1.13M * i

                });
            }

            var model = new CartViewModel
            {
                Products = products,
                //TotalCartPrice = products.Sum(p=>p.Price),
                TotalCartPrice = 13.27M,
                // Message = "Спысибо за покупку!"
                Message = "Ах!"
            };

            //return View(model);
            return RedirectToAction("Checkout", model);
        }

        public IActionResult Checkout(CartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState.ErrorCount > 0)
                {
                    ViewData["semerro"] = "OPS!";
                    ModelState.AddModelError( errorMessage: "Модель недействительна", key: "error");
                }
            }
            else
            {
                ViewData["semerro"] = "MODEL OK!";
            }
            return View(model);
        }
    }
}
