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
    public class PacientStatusController : Controller
    {
        private readonly ITDeveloperDbContext _context;

        public PacientStatusController(ITDeveloperDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
              return View(await _context.PacientStatus.ToListAsync());
        }


        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PacientStatus == null)
            {
                return NotFound();
            }

            var pacientStatus = await _context.PacientStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacientStatus == null)
            {
                return NotFound();
            }

            return View(pacientStatus);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Id")] PacientStatus pacientStatus)
        {
            if (ModelState.IsValid)
            {
                pacientStatus.Id = Guid.NewGuid();
                _context.Add(pacientStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacientStatus);
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PacientStatus == null)
            {
                return NotFound();
            }

            var pacientStatus = await _context.PacientStatus.FindAsync(id);
            if (pacientStatus == null)
            {
                return NotFound();
            }
            return View(pacientStatus);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Description,Id")] PacientStatus pacientStatus)
        {
            if (id != pacientStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacientStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientStatusExists(pacientStatus.Id))
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
            return View(pacientStatus);
        }


        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PacientStatus == null)
            {
                return NotFound();
            }

            var pacientStatus = await _context.PacientStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacientStatus == null)
            {
                return NotFound();
            }

            return View(pacientStatus);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PacientStatus == null)
            {
                return Problem("Entity set 'ITDeveloperDbContext.PacientStatus'  is null.");
            }
            var pacientStatus = await _context.PacientStatus.FindAsync(id);
            if (pacientStatus != null)
            {
                _context.PacientStatus.Remove(pacientStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientStatusExists(Guid id)
        {
          return _context.PacientStatus.Any(e => e.Id == id);
        }
    }
}
