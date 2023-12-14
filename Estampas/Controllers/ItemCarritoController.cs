using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estampas.Contexto;
using Estampas.Models;

namespace Estampas.Controllers
{
    public class ItemCarritoController : Controller
    {
        private readonly EstampasDatabaseContext _context;

        public ItemCarritoController(EstampasDatabaseContext context)
        {
            _context = context;
        }

        // GET: ItemCarrito
        public async Task<IActionResult> Index()
        {
            var estampasDatabaseContext = _context.ItemsCarrito.Include(i => i.Carrito).Include(i => i.Producto);
            return View(await estampasDatabaseContext.ToListAsync());
        }

        // GET: ItemCarrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemsCarrito == null)
            {
                return NotFound();
            }

            var itemCarrito = await _context.ItemsCarrito
                .Include(i => i.Carrito)
                .Include(i => i.Producto)
                .FirstOrDefaultAsync(m => m.ItemCarritoId == id);
            if (itemCarrito == null)
            {
                return NotFound();
            }

            return View(itemCarrito);
        }

        // GET: ItemCarrito/Create
        public IActionResult Create()
        {
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "CarritoId", "CarritoId");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId");
            return View();
        }

        // POST: ItemCarrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemCarritoId,Cantidad,PrecioTotal,CarritoId,ProductoId")] ItemCarrito itemCarrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemCarrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "CarritoId", "CarritoId", itemCarrito.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", itemCarrito.ProductoId);
            return View(itemCarrito);
        }

        // GET: ItemCarrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemsCarrito == null)
            {
                return NotFound();
            }

            var itemCarrito = await _context.ItemsCarrito.FindAsync(id);
            if (itemCarrito == null)
            {
                return NotFound();
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "CarritoId", "CarritoId", itemCarrito.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", itemCarrito.ProductoId);
            return View(itemCarrito);
        }

        // POST: ItemCarrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemCarritoId,Cantidad,PrecioTotal,CarritoId,ProductoId")] ItemCarrito itemCarrito)
        {
            if (id != itemCarrito.ItemCarritoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemCarrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCarritoExists(itemCarrito.ItemCarritoId))
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
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "CarritoId", "CarritoId", itemCarrito.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", itemCarrito.ProductoId);
            return View(itemCarrito);
        }

        // GET: ItemCarrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemsCarrito == null)
            {
                return NotFound();
            }

            var itemCarrito = await _context.ItemsCarrito
                .Include(i => i.Carrito)
                .Include(i => i.Producto)
                .FirstOrDefaultAsync(m => m.ItemCarritoId == id);
            if (itemCarrito == null)
            {
                return NotFound();
            }

            return View(itemCarrito);
        }

        // POST: ItemCarrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemsCarrito == null)
            {
                return Problem("Entity set 'EstampasDatabaseContext.ItemsCarrito'  is null.");
            }
            var itemCarrito = await _context.ItemsCarrito.FindAsync(id);
            if (itemCarrito != null)
            {
                _context.ItemsCarrito.Remove(itemCarrito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCarritoExists(int id)
        {
          return (_context.ItemsCarrito?.Any(e => e.ItemCarritoId == id)).GetValueOrDefault();
        }
    }
}
