using appPDWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace appPDWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MydbContext mydb;

        public HomeController(MydbContext context)
        {
            mydb = context;
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