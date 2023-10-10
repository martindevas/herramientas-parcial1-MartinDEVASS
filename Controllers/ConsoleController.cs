using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parcial1.Models;
using parcial1.ViewModels;

namespace parcial1.Controllers
{
    public class ConsoleController : Controller
    {
        private readonly EquiposFutbolContext _context;

        public ConsoleController(EquiposFutbolContext context)
        {
            _context = context;
        }

        // GET: Console
        public async Task<IActionResult> Index()
        {
              return _context.EquipoConsole != null ? 
                          View(await _context.EquipoConsole.ToListAsync()) :
                          Problem("Entity set 'EquiposFutbolContext.EquipoConsole'  is null.");
        }

        // GET: Console/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EquipoConsole == null)
            {
                return NotFound();
            }

            var equipoConsole = await _context.EquipoConsole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipoConsole == null)
            {
                return NotFound();
            }

            return View(equipoConsole);
        }

        // GET: Console/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Console/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Anio,Pais")] ConsoleVM equipoConsoleInput)
        {
            if (ModelState.IsValid)
            {
                var console = new EquipoConsole
                {
                    Nombre = equipoConsoleInput.Nombre,
                    Anio = equipoConsoleInput.Anio,
                    Pais = equipoConsoleInput.Pais
                };
                _context.Add(console);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipoConsoleInput);
        }

        // GET: Console/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipoConsole == null)
            {
                return NotFound();
            }

            var equipoConsole = await _context.EquipoConsole.FindAsync(id);
            if (equipoConsole == null)
            {
                return NotFound();
            }
            return View(equipoConsole);
        }

        // POST: Console/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Anio,Pais")] EquipoConsole equipoConsole)
        {
            if (id != equipoConsole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoConsole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoConsoleExists(equipoConsole.Id))
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
            return View(equipoConsole);
        }

        // GET: Console/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipoConsole == null)
            {
                return NotFound();
            }

            var equipoConsole = await _context.EquipoConsole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipoConsole == null)
            {
                return NotFound();
            }

            return View(equipoConsole);
        }

        // POST: Console/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipoConsole == null)
            {
                return Problem("Entity set 'EquiposFutbolContext.EquipoConsole'  is null.");
            }
            var equipoConsole = await _context.EquipoConsole.FindAsync(id);
            if (equipoConsole != null)
            {
                _context.EquipoConsole.Remove(equipoConsole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoConsoleExists(int id)
        {
          return (_context.EquipoConsole?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
