using Microsoft.AspNetCore.Mvc;

namespace Dextermd.ITDeveloper.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
    }
}
