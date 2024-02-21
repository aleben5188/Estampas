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
    public class PedidoController : Controller
    {
        private readonly EstampasDatabaseContext _context;

        public PedidoController(EstampasDatabaseContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("sesion") != null) { 
            var pedidos = _context.Pedidos.Where(x => x.Email == HttpContext.Session.GetString("sesion"));
                //   var estampasDatabaseContext = _context.ItemsCarrito.Include(i => i.Pedido).Include(i => i.Producto);
                return View(await pedidos.ToListAsync());
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuarios");
            }
            


        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,Email,Fecha,Opinion")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.Items = new Collection<ItemCarrito>();
                pedido.Fecha = DateTime.Now;

                foreach (var item in _context.ItemsCarrito)
                {
                    if (item.Activo == true && item.Email == HttpContext.Session.GetString("sesion"))
                    {
                        pedido.Items.Add(item);
                        item.Activo = false;
                    }
                }
                pedido.Email = HttpContext.Session.GetString("sesion");
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction("Finalizar", "Home");
            }
            return View("~/Views/Home/Finalizar.cshtml");
        }

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

   
 

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            if (pedido.Opinion != null)
            {
                string comentario = pedido.Opinion;
                ViewData["Comentario"] = comentario;
                return View("Opinion");
            }
            return View(pedido);

        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,Email,Fecha,Opinion")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(pedido);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PedidoExists(pedido.PedidoId))
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
                return View(pedido);
            

        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'EstampasDatabaseContext.Pedidos'  is null.");
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return (_context.Pedidos?.Any(e => e.PedidoId == id)).GetValueOrDefault();
        }
    }
}
