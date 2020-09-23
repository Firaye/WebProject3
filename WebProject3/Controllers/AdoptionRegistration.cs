using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProject3.Models;

namespace WebProject3.Controllers
{
    public class AdoptionRegistration : Controller
    {
        private readonly OROMIAVITALEVENTContext _context;

        public AdoptionRegistration(OROMIAVITALEVENTContext context)
        {
            _context = context;
        }

        // GET: AdoptionRegistration
        public async Task<IActionResult> Index()
        {
            var oROMIAVITALEVENTContext = _context.Adoptiontbl.Include(a => a.C);
            return View(await oROMIAVITALEVENTContext.ToListAsync());
        }

        // GET: AdoptionRegistration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptiontbl = await _context.Adoptiontbl
                .Include(a => a.C)
                .FirstOrDefaultAsync(m => m.AdoptId == id);
            if (adoptiontbl == null)
            {
                return NotFound();
            }

            return View(adoptiontbl);
        }

        // GET: AdoptionRegistration/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname");
            return View();
        }

        // POST: AdoptionRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdoptId,ChildFullName,AdoptFullName,CitizenshipofAdopter,Ageofchild,AdopterphoneNumber,ReasonforAdoption,Sexofchild,IssueDate,Cid")] Adoptiontbl adoptiontbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptiontbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", adoptiontbl.Cid);
            return View(adoptiontbl);
        }

        // GET: AdoptionRegistration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptiontbl = await _context.Adoptiontbl.FindAsync(id);
            if (adoptiontbl == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", adoptiontbl.Cid);
            return View(adoptiontbl);
        }

        // POST: AdoptionRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdoptId,ChildFullName,AdoptFullName,CitizenshipofAdopter,Ageofchild,AdopterphoneNumber,ReasonforAdoption,Sexofchild,IssueDate,Cid")] Adoptiontbl adoptiontbl)
        {
            if (id != adoptiontbl.AdoptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptiontbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptiontblExists(adoptiontbl.AdoptId))
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
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", adoptiontbl.Cid);
            return View(adoptiontbl);
        }

        // GET: AdoptionRegistration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptiontbl = await _context.Adoptiontbl
                .Include(a => a.C)
                .FirstOrDefaultAsync(m => m.AdoptId == id);
            if (adoptiontbl == null)
            {
                return NotFound();
            }

            return View(adoptiontbl);
        }

        // POST: AdoptionRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptiontbl = await _context.Adoptiontbl.FindAsync(id);
            _context.Adoptiontbl.Remove(adoptiontbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptiontblExists(int id)
        {
            return _context.Adoptiontbl.Any(e => e.AdoptId == id);
        }
    }
}
