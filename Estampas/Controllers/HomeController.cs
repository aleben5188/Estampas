using Microsoft.AspNetCore.Mvc;
using Estampas.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Estampas.Contexto;

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
           /* if (HttpContext.Session.GetString("A") == null)
            {
                HttpContext.Session.SetString("A", "hola");
            }*/

            return RedirectToAction("Index2", "Producto");
            // return RedirectToAction("Index2", "Producto");
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


