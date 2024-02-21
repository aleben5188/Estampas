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
    public class PController : Controller
    {
        private readonly EstampasDatabaseContext _context;

        public PController(EstampasDatabaseContext context)
        {
            _context = context;
        }

        // GET: P
        public async Task<IActionResult> Index()
        {
              return _context.P != null ? 
                          View(await _context.P.ToListAsync()) :
                          Problem("Entity set 'EstampasDatabaseContext.P'  is null.");
        }

        // GET: P/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.P == null)
            {
                return NotFound();
            }

            var p = await _context.P
                .FirstOrDefaultAsync(m => m.PId == id);
            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        // GET: P/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: P/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PId,Nombe")] P p)
        {
            if (ModelState.IsValid)
            {
                _context.Add(p);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        // GET: P/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.P == null)
            {
                return NotFound();
            }

            var p = await _context.P.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // POST: P/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,Nombe")] P p)
        {
            if (id != p.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PExists(p.PId))
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
            return View(p);
        }

        // GET: P/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.P == null)
            {
                return NotFound();
            }

            var p = await _context.P
                .FirstOrDefaultAsync(m => m.PId == id);
            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        // POST: P/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.P == null)
            {
                return Problem("Entity set 'EstampasDatabaseContext.P'  is null.");
            }
            var p = await _context.P.FindAsync(id);
            if (p != null)
            {
                _context.P.Remove(p);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PExists(int id)
        {
          return (_context.P?.Any(e => e.PId == id)).GetValueOrDefault();
        }
    }
}
