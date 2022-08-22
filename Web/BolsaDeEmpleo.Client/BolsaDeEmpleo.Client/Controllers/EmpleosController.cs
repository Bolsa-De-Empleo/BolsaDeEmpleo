using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BolsaDeEmpleo.Api.Data;
using BolsaDeEmpleo.Shared;

namespace BolsaDeEmpleo.Client.Controllers
{
    public class EmpleosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empleos
        public async Task<IActionResult> Index()
        {
              return _context.Empleo != null ? 
                          View(await _context.Empleo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Empleo'  is null.");
        }

        // GET: Empleos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleo == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleo == null)
            {
                return NotFound();
            }

            return View(empleo);
        }

        // GET: Empleos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,Categoria,Sueldo,Hornada,Posicion,Empresa,FechaPublicacion")] Empleo empleo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleo);
        }

        // GET: Empleos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleo == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleo.FindAsync(id);
            if (empleo == null)
            {
                return NotFound();
            }
            return View(empleo);
        }

        // POST: Empleos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,Categoria,Sueldo,Hornada,Posicion,Empresa,FechaPublicacion")] Empleo empleo)
        {
            if (id != empleo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleoExists(empleo.Id))
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
            return View(empleo);
        }

        // GET: Empleos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleo == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleo == null)
            {
                return NotFound();
            }

            return View(empleo);
        }

        // POST: Empleos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Empleo'  is null.");
            }
            var empleo = await _context.Empleo.FindAsync(id);
            if (empleo != null)
            {
                _context.Empleo.Remove(empleo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleoExists(int id)
        {
          return (_context.Empleo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
