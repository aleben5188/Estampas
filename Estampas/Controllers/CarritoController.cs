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
    public class CarritoController : Controller
    {
        private readonly EstampasDatabaseContext _context;

        public CarritoController(EstampasDatabaseContext context)
        {
            _context = context;
        }

        // GET: Carrito
        public async Task<IActionResult> Index()
        {
              return _context.Carritos != null ? 
                          View(await _context.Carritos.ToListAsync()) :
                          Problem("Entity set 'EstampasDatabaseContext.Carritos'  is null.");
        }

        // GET: Carrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .FirstOrDefaultAsync(m => m.CarritoId == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carrito/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarritoId")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrito);
        }

        // GET: Carrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            return View(carrito);
        }

        // POST: Carrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarritoId")] Carrito carrito)
        {
            if (id != carrito.CarritoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.CarritoId))
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
            return View(carrito);
        }

        // GET: Carrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .FirstOrDefaultAsync(m => m.CarritoId == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carritos == null)
            {
                return Problem("Entity set 'EstampasDatabaseContext.Carritos'  is null.");
            }
            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito != null)
            {
                _context.Carritos.Remove(carrito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(int id)
        {
          return (_context.Carritos?.Any(e => e.CarritoId == id)).GetValueOrDefault();
        }
    }
}
