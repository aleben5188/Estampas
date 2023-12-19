using Microsoft.AspNetCore.Mvc;
using Estampas.Models;
using System.Diagnostics;

namespace Estampas.Controllers
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
            return RedirectToAction("Index2", "Producto");
        }

        public IActionResult Finalizar()
        {
            return View();
        }

        public IActionResult Index2()
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


