using Dextermd.ITDeveloper.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dextermd.ITDeveloper.Mvc.Controllers
{

    [Route("dashboard")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("home")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about-us")]
        public IActionResult About(Guid id, string patients, string categoria)
        {
            return View();
        }
        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}