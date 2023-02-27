using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalCoreTask.Models;

namespace FinalCoreTask.Controllers
{
    public class Doctors2Controller : Controller
    {
        private readonly Core2Context _context;

        public Doctors2Controller(Core2Context context)
        {
            _context = context;
        }

        // GET: Doctors2
        public async Task<IActionResult> Index()
        {
            var core2Context = _context.Doctors2s.Include(d => d.Clinic);
            return View(await core2Context.ToListAsync());
        }
        public async Task<IActionResult> Index2(int id)
        {
            var core2Context = _context.Doctors2s.Where(x=>x.ClinicId==id).Include(d => d.Clinic);
            return View(await core2Context.ToListAsync());
        }

        // GET: Doctors2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctors2s == null)
            {
                return NotFound();
            }

            var doctors2 = await _context.Doctors2s
                .Include(d => d.Clinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctors2 == null)
            {
                return NotFound();
            }

            return View(doctors2);
        }

        // GET: Doctors2/Create
        public IActionResult Create()
        {
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "Id");
            return View();
        }

        // POST: Doctors2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorName,ClinicId")] Doctors2 doctors2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctors2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "Id", doctors2.ClinicId);
            return View(doctors2);
        }

        // GET: Doctors2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctors2s == null)
            {
                return NotFound();
            }

            var doctors2 = await _context.Doctors2s.FindAsync(id);
            if (doctors2 == null)
            {
                return NotFound();
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "Id", doctors2.ClinicId);
            return View(doctors2);
        }

        // POST: Doctors2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorName,ClinicId")] Doctors2 doctors2)
        {
            if (id != doctors2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctors2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Doctors2Exists(doctors2.Id))
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
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "Id", doctors2.ClinicId);
            return View(doctors2);
        }

        // GET: Doctors2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doctors2s == null)
            {
                return NotFound();
            }

            var doctors2 = await _context.Doctors2s
                .Include(d => d.Clinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctors2 == null)
            {
                return NotFound();
            }

            return View(doctors2);
        }

        // POST: Doctors2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctors2s == null)
            {
                return Problem("Entity set 'Core2Context.Doctors2s'  is null.");
            }
            var doctors2 = await _context.Doctors2s.FindAsync(id);
            if (doctors2 != null)
            {
                _context.Doctors2s.Remove(doctors2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Doctors2Exists(int id)
        {
          return (_context.Doctors2s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
