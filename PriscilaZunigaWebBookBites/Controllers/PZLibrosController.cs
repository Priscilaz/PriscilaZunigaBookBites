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
    public class PZLibrosController : Controller
    {
        private readonly BookBitesContext _context;

        public PZLibrosController(BookBitesContext context)
        {
            _context = context;
        }

        // GET: PZLibros
        public async Task<IActionResult> Index()
        {
            return View(await _context.PZLibro.ToListAsync());
        }

        // GET: PZLibros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZLibro = await _context.PZLibro
                .FirstOrDefaultAsync(m => m.PZLibroID == id);
            if (pZLibro == null)
            {
                return NotFound();
            }

            return View(pZLibro);
        }

        // GET: PZLibros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PZLibros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PZLibroID,PZTitulo,PZAutor,PZVolumen,PZPrecio,PZNombre")] PZLibro pZLibro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pZLibro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pZLibro);
        }

        // GET: PZLibros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZLibro = await _context.PZLibro.FindAsync(id);
            if (pZLibro == null)
            {
                return NotFound();
            }
            return View(pZLibro);
        }

        // POST: PZLibros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PZLibroID,PZTitulo,PZAutor,PZVolumen,PZPrecio,PZNombre")] PZLibro pZLibro)
        {
            if (id != pZLibro.PZLibroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pZLibro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PZLibroExists(pZLibro.PZLibroID))
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
            return View(pZLibro);
        }

        // GET: PZLibros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pZLibro = await _context.PZLibro
                .FirstOrDefaultAsync(m => m.PZLibroID == id);
            if (pZLibro == null)
            {
                return NotFound();
            }

            return View(pZLibro);
        }

        // POST: PZLibros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pZLibro = await _context.PZLibro.FindAsync(id);
            if (pZLibro != null)
            {
                _context.PZLibro.Remove(pZLibro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PZLibroExists(int id)
        {
            return _context.PZLibro.Any(e => e.PZLibroID == id);
        }
    }
}
