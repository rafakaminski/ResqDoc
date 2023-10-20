using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using resqdoc2.Models;

namespace resqdoc2.Controllers
{
    public class CobradesController : Controller
    {
        private readonly Context _context;

        public CobradesController(Context context)
        {
            _context = context;
        }

        // GET: Cobrades
        public async Task<IActionResult> Index()
        {
              return _context.Cobrade != null ? 
                          View(await _context.Cobrade.ToListAsync()) :
                          Problem("Entity set 'Context.Cobrade'  is null.");
        }

        // GET: Cobrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cobrade == null)
            {
                return NotFound();
            }

            var cobrade = await _context.Cobrade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobrade == null)
            {
                return NotFound();
            }

            return View(cobrade);
        }

        // GET: Cobrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cobrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cod,Descricao")] Cobrade cobrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cobrade);
        }

        // GET: Cobrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cobrade == null)
            {
                return NotFound();
            }

            var cobrade = await _context.Cobrade.FindAsync(id);
            if (cobrade == null)
            {
                return NotFound();
            }
            return View(cobrade);
        }

        // POST: Cobrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cod,Descricao")] Cobrade cobrade)
        {
            if (id != cobrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobradeExists(cobrade.Id))
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
            return View(cobrade);
        }

        // GET: Cobrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cobrade == null)
            {
                return NotFound();
            }

            var cobrade = await _context.Cobrade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobrade == null)
            {
                return NotFound();
            }

            return View(cobrade);
        }

        // POST: Cobrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cobrade == null)
            {
                return Problem("Entity set 'Context.Cobrade'  is null.");
            }
            var cobrade = await _context.Cobrade.FindAsync(id);
            if (cobrade != null)
            {
                _context.Cobrade.Remove(cobrade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobradeExists(int id)
        {
          return (_context.Cobrade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
