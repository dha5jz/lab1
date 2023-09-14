using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThucHanh1.Models;

namespace ThucHanh1.Controllers
{
    public class HomeController : Controller
    {
        //1hàm Action -> 1 view
        //1 controller -> nhiều action
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
    }
}