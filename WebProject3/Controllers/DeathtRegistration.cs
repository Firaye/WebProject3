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
    public class DeathtRegistration : Controller
    {
        private readonly OROMIAVITALEVENTContext _context;

        public DeathtRegistration(OROMIAVITALEVENTContext context)
        {
            _context = context;
        }

        // GET: DeathtRegistration
        public async Task<IActionResult> Index()
        {
            var oROMIAVITALEVENTContext = _context.Deathtbl.Include(d => d.C);
            return View(await oROMIAVITALEVENTContext.ToListAsync());
        }

        // GET: DeathtRegistration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deathtbl = await _context.Deathtbl
                .Include(d => d.C)
                .FirstOrDefaultAsync(m => m.DrefNum == id);
            if (deathtbl == null)
            {
                return NotFound();
            }

            return View(deathtbl);
        }

        // GET: DeathtRegistration/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname");
            return View();
        }

        // POST: DeathtRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrefNum,DateofDeath,CaseofDeath,Region,Zone,Woreda,Wittness,Reltionofwittness,Age,Sex,IssueDate,Cid")] Deathtbl deathtbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deathtbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", deathtbl.Cid);
            return View(deathtbl);
        }

        // GET: DeathtRegistration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deathtbl = await _context.Deathtbl.FindAsync(id);
            if (deathtbl == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", deathtbl.Cid);
            return View(deathtbl);
        }

        // POST: DeathtRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrefNum,DateofDeath,CaseofDeath,Region,Zone,Woreda,Wittness,Reltionofwittness,Age,Sex,IssueDate,Cid")] Deathtbl deathtbl)
        {
            if (id != deathtbl.DrefNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deathtbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeathtblExists(deathtbl.DrefNum))
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
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", deathtbl.Cid);
            return View(deathtbl);
        }

        // GET: DeathtRegistration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deathtbl = await _context.Deathtbl
                .Include(d => d.C)
                .FirstOrDefaultAsync(m => m.DrefNum == id);
            if (deathtbl == null)
            {
                return NotFound();
            }

            return View(deathtbl);
        }

        // POST: DeathtRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deathtbl = await _context.Deathtbl.FindAsync(id);
            _context.Deathtbl.Remove(deathtbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeathtblExists(int id)
        {
            return _context.Deathtbl.Any(e => e.DrefNum == id);
        }
    }
}
