using LibProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("HomePage")]
        public IActionResult HomePage()
        {
            return View();
        }
        [Route("HomePageLogined")]
        public IActionResult HomePageLogined()
        {
            return View();
        }
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

    }
}