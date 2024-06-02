using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PZ.Data;
using PriscilaZunigaWebBookBites.Models;

namespace PriscilaZunigaWebBookBites.Controllers
{
    public class PZCopiasController : Controller
    {
        private readonly BookBitesContext _context;

        public PZCopiasController(BookBitesContext context)
        {
            _context = context;
        }

        // GET: PZCopias
        public async Task<IActionResult> Index()
        {
            var bookBitesContext = _context.PZCopia.Include(p => p.PZLibro);
            return View(await bookBitesContext.ToListAsync());
        }

        // GET: PZCopias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZCopia = await _context.PZCopia
                .Include(p => p.PZLibro)
                .FirstOrDefaultAsync(m => m.PZCopiaID == id);
            if (pZCopia == null)
            {
                return NotFound();
            }

            return View(pZCopia);
        }

        // GET: PZCopias/Create
        public IActionResult Create()
        {
            ViewData["PZLibroID"] = new SelectList(_context.PZLibro, "PZLibroID", "PZAutor");
            return View();
        }

        // POST: PZCopias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PZCopiaID,PZCantidad,PZColor,PZFormato,PZFechaCopia,PZLibroID")] PZCopia pZCopia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pZCopia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PZLibroID"] = new SelectList(_context.PZLibro, "PZLibroID", "PZAutor", pZCopia.PZLibroID);
            return View(pZCopia);
        }

        // GET: PZCopias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZCopia = await _context.PZCopia.FindAsync(id);
            if (pZCopia == null)
            {
                return NotFound();
            }
            ViewData["PZLibroID"] = new SelectList(_context.PZLibro, "PZLibroID", "PZAutor", pZCopia.PZLibroID);
            return View(pZCopia);
        }

        // POST: PZCopias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PZCopiaID,PZCantidad,PZColor,PZFormato,PZFechaCopia,PZLibroID")] PZCopia pZCopia)
        {
            if (id != pZCopia.PZCopiaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pZCopia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PZCopiaExists(pZCopia.PZCopiaID))
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
            ViewData["PZLibroID"] = new SelectList(_context.PZLibro, "PZLibroID", "PZAutor", pZCopia.PZLibroID);
            return View(pZCopia);
        }

        // GET: PZCopias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZCopia = await _context.PZCopia
                .Include(p => p.PZLibro)
                .FirstOrDefaultAsync(m => m.PZCopiaID == id);
            if (pZCopia == null)
            {
                return NotFound();
            }

            return View(pZCopia);
        }

        // POST: PZCopias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pZCopia = await _context.PZCopia.FindAsync(id);
            if (pZCopia != null)
            {
                _context.PZCopia.Remove(pZCopia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PZCopiaExists(int id)
        {
            return _context.PZCopia.Any(e => e.PZCopiaID == id);
        }
    }
}
