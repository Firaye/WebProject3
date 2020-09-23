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
    public class BirthRegistration : Controller
    {
        private readonly OROMIAVITALEVENTContext _context;

        public BirthRegistration(OROMIAVITALEVENTContext context)
        {
            _context = context;
        }

        // GET: BirthRegistration
        public async Task<IActionResult> Index()
        {
            var oROMIAVITALEVENTContext = _context.Birthtbl.Include(b => b.C);
            return View(await oROMIAVITALEVENTContext.ToListAsync());
        }

        // GET: BirthRegistration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthtbl = await _context.Birthtbl
                .Include(b => b.C)
                .FirstOrDefaultAsync(m => m.Cnum == id);
            if (birthtbl == null)
            {
                return NotFound();
            }

            return View(birthtbl);
        }

        // GET: BirthRegistration/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname");
            return View();
        }

        // POST: BirthRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cnum,Dob,Mfullname,Region,Woreda,Sex,DateofIssue,Cid")] Birthtbl birthtbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birthtbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", birthtbl.Cid);
            return View(birthtbl);
        }

        // GET: BirthRegistration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthtbl = await _context.Birthtbl.FindAsync(id);
            if (birthtbl == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", birthtbl.Cid);
            return View(birthtbl);
        }

        // POST: BirthRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cnum,Dob,Mfullname,Region,Woreda,Sex,DateofIssue,Cid")] Birthtbl birthtbl)
        {
            if (id != birthtbl.Cnum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(birthtbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BirthtblExists(birthtbl.Cnum))
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
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", birthtbl.Cid);
            return View(birthtbl);
        }

        // GET: BirthRegistration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthtbl = await _context.Birthtbl
                .Include(b => b.C)
                .FirstOrDefaultAsync(m => m.Cnum == id);
            if (birthtbl == null)
            {
                return NotFound();
            }

            return View(birthtbl);
        }

        // POST: BirthRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var birthtbl = await _context.Birthtbl.FindAsync(id);
            _context.Birthtbl.Remove(birthtbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BirthtblExists(int id)
        {
            return _context.Birthtbl.Any(e => e.Cnum == id);
        }
    }
}
