using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estampas.Contexto;
using Estampas.Models;
using System.Collections.ObjectModel;

namespace Estampas.Controllers
{
    public class CarritoController : Controller
    {
        private readonly EstampasDatabaseContext _context;

        public CarritoController(EstampasDatabaseContext context)
        {
            _context = context;
        }
         public IActionResult Finalizar()
         {
             return View("~/Views/Pedido/Create.cshtml");
         }



        public IActionResult AgregarAlCarrito(int productoId, int cantidad)
        {
            var itemCarrito = _context.ItemsCarrito.FirstOrDefault(c => c.ProductoId == productoId);

            if (itemCarrito == null)
            {
                itemCarrito = new ItemCarrito
                {
                    ProductoId = productoId,
                    Cantidad = cantidad
                };
                _context.ItemsCarrito.Add(itemCarrito);
            }
            else
            {
                itemCarrito.Cantidad += cantidad;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }







    }
}
