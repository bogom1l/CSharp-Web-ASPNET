namespace MVCIntroDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MVCIntroDemo.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "hello World az sum gotin";
            //ViewData["People"] = new[] { "Pesho", "Gosho", "Bogi" };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About() // /Home/About
        {
            ViewBag.Message = "This is an ASPNET Core MVP App.";

            return View();
        }

        public IActionResult Numbers() // /Home/Numbers
        {
            return View();
        }

        [HttpGet]
        public IActionResult NumbersToN() // /Home/NumbersToN
        {
            ViewData["Count"] = -1;
            return View();
        }

        [HttpPost]
        public IActionResult NumbersToN(int count = -1) // /Home/NumbersToN
        {
            ViewData["Count"] = count;
            
            return this.View();
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}