using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dextermd.ITDeveloper.Data.ORM;
using Dextermd.ITDeveloper.Domain.Models;

namespace Dextermd.ITDeveloper.Mvc.Controllers
{
    public class PacientController : Controller
    {
        private readonly ITDeveloperDbContext _context;

        public PacientController(ITDeveloperDbContext context)
        {
            _context = context;
        }

        // GET: Pacient
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pacient.ToListAsync());
        }

        // GET: Pacient/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Pacient == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // GET: Pacient/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                //pacient.Id = Guid.NewGuid();
                _context.Add(pacient);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");
            }
            return View(pacient);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Pacient == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.FindAsync(id);
            if (pacient == null)
            {
                return NotFound();
            }
            return View(pacient);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Pacient pacient)
        {
            if (id != pacient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientExists(pacient.Id))
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
            return View(pacient);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Pacient == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Pacient == null)
            {
                return Problem("Entity set 'ITDeveloperDbContext.Pacient'  is null.");
            }
            var pacient = await _context.Pacient.FindAsync(id);
            if (pacient != null)
            {
                _context.Pacient.Remove(pacient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientExists(Guid id)
        {
          return _context.Pacient.Any(e => e.Id == id);
        }
    }
}
