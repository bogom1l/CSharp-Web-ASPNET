namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using TaskBoardApp.Models;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}