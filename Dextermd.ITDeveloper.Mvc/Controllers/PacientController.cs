using Dextermd.ITDeveloper.Data.ORM;
using Dextermd.ITDeveloper.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dextermd.ITDeveloper.Mvc.Controllers
{
    [Authorize(Roles = "Administrotor")]
    public class PacientController : Controller
    {
        private readonly ITDeveloperDbContext _context;

        public PacientController(ITDeveloperDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Pacient.Include(x => x.PacientStatus).AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null || _context.Pacient == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.Include(x => x.PacientStatus).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }


        public IActionResult Create()
        {
            ViewBag.PacientStatus = new SelectList(_context.PacientStatus, "Id", "Description");
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
            ViewBag.PacientStatus = new SelectList(_context.PacientStatus, "Id", "Description", pacient.PacientStatusId);
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

            ViewBag.PacientStatus = new SelectList(_context.PacientStatus, "Id", "Description", pacient.PacientStatusId);
            return View(pacient);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, Pacient pacient)
        {
            Debug.WriteLine("Go go go go go   " + pacient.PacientStatus);
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

            ViewBag.PacientStatus = new SelectList(_context.PacientStatus, "Id", "Description", pacient.PacientStatusId);
            return View(pacient);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || _context.Pacient == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.Include(x => x.PacientStatus).AsNoTracking()
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
