using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estampas.Contexto;
using Estampas.Models;
using Estampas.Migrations;
using System.Drawing;
using Humanizer.DateTimeHumanizeStrategy;
using System.Web;

namespace Estampas.Controllers
{
    public class ProductoController : Controller
    {
        private readonly EstampasDatabaseContext _context;

        public ProductoController(EstampasDatabaseContext context)
        {
            _context = context;
        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
              return _context.Productos != null ? 
                          View(await _context.Productos.ToListAsync()) :
                          Problem("Entity set 'EstampasDatabaseContext.Productos'  is null.");
        }

        public async Task<IActionResult> Index2()
        {
            return _context.Productos != null ?
                        View(await _context.Productos.ToListAsync()) :
                        Problem("Entity set 'EstampasDatabaseContext.Productos'  is null.");
        }

        public IActionResult Index3()
        {
            /* if (HttpContext.Session.GetString("A") == null)
             {
                 HttpContext.Session.SetString("A", "hola");
             }*/

            return View();

        }
     /*       public async Task<IActionResult> Filtrar(string parametro)
        {
            if (parametro == "Taza")
            {
                var productos = _context.Productos.Where(x => x.Tipo == Categoria.Taza);
                return View(await productos.ToListAsync());
            }
            else
            {
                var productos = _context.Productos.Where(x => x.Tipo == Categoria.Remera);
                return View(await productos.ToListAsync());
            }
           

        }*/

        /*public async Task<IActionResult> Index2(Usuario usuario)
        {
            var ped = _context.Pedidos.FirstOrDefault(p => p.UsuarioId == usuario.UsuarioId && p.Finalizado == false && p.PedidoId != 0);
            if (ped != null)
            {
                ViewData["PedidoId"] = ped.PedidoId;
                ViewData["UsuarioId"] = usuario.UsuarioId;
                return _context.Productos != null ?
                        View(await _context.Productos.ToListAsync()) :
                        Problem("Entity set 'EstampasDatabaseContext.Productos' is null.");
            }
            else
            {
                ped = new Models.Pedido()
                {
                    UsuarioId = usuario.UsuarioId,
                    Finalizado = false,
                };          
            _context.Pedidos.Add(ped);
            _context.SaveChanges();
            };
            ViewData["PedidoId"] = ped.PedidoId;
            ViewData["UsuarioId"] = usuario.UsuarioId;
            return _context.Productos != null ?
                        View(await _context.Productos.ToListAsync()) :
                        Problem("Entity set 'EstampasDatabaseContext.Productos' is null.");
        }*/


        /* public async Task<IActionResult> Comprar(int id)
         {
             var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == id);
             var item = new Models.ItemCarrito()
             {
                 ProductoId = id,
                 Descripcion = producto.Descripcion,
                 ImagePath = producto.ImagePath,
                 Precio = producto.Precio,
                 Activo = true,
                 Cantidad = 1,
             };
             _context.ItemsCarrito.Add(item);
             _context.SaveChanges();
             return RedirectToAction("CompraRealizada", "ItemCarrito", item);
         }*/

        public async Task<IActionResult> Comprar(int id)
        {

            if (HttpContext.Session.GetString("sesion") == null)
            {
                return RedirectToAction("InicioSesion", "Usuarios");
            }
            else
            {
                var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == id);
                var item = _context.ItemsCarrito.FirstOrDefault(i => i.ProductoId == id && i.Activo == true && i.Email == HttpContext.Session.GetString("sesion"));
                if (item == null)
                {
                    item = new Models.ItemCarrito()
                    {
                        ProductoId = id,
                        Descripcion = producto.Descripcion,
                        ImagePath = producto.ImagePath,
                        Precio = producto.Precio,
                        Activo = true,
                        Cantidad = 1,
                        Email = HttpContext.Session.GetString("sesion")
                    };
                    _context.ItemsCarrito.Add(item);
                    _context.SaveChanges();
                }
                else
                {
                    double PrecioUnitario = item.Precio / item.Cantidad;
                    item.Cantidad += 1;
                    item.Precio = PrecioUnitario * item.Cantidad;
                    _context.SaveChanges();
                }
                return RedirectToAction("CompraRealizada", "ItemCarrito", item);
            }
        }

        public async Task<IActionResult> Comprar2(int id)
        {
            return RedirectToAction("InicioSesion", "Home");
        }


        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,Nombre,Descripcion,ImagePath,Precio,Licencia,Tipo")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,Nombre,Descripcion,ImagePath,Precio")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'EstampasDatabaseContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.ProductoId == id)).GetValueOrDefault();
        }
    }
}
