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
    public class MarriageRegistration : Controller
    {
        private readonly OROMIAVITALEVENTContext _context;

        public MarriageRegistration(OROMIAVITALEVENTContext context)
        {
            _context = context;
        }

        // GET: MarriageRegistration
        public async Task<IActionResult> Index()
        {
            var oROMIAVITALEVENTContext = _context.Marriagetbl.Include(m => m.C);
            return View(await oROMIAVITALEVENTContext.ToListAsync());
        }

        // GET: MarriageRegistration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marriagetbl = await _context.Marriagetbl
                .Include(m => m.C)
                .FirstOrDefaultAsync(m => m.Mnum == id);
            if (marriagetbl == null)
            {
                return NotFound();
            }

            return View(marriagetbl);
        }

        // GET: MarriageRegistration/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname");
            return View();
        }

        // POST: MarriageRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mnum,DateofMarriage,HusbandFullname,Wifefullname,Wittness1,Wittness2,WifeAge,HusbandAge,Region,Zone,IssueDate,Cid")] Marriagetbl marriagetbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marriagetbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", marriagetbl.Cid);
            return View(marriagetbl);
        }

        // GET: MarriageRegistration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marriagetbl = await _context.Marriagetbl.FindAsync(id);
            if (marriagetbl == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", marriagetbl.Cid);
            return View(marriagetbl);
        }

        // POST: MarriageRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mnum,DateofMarriage,HusbandFullname,Wifefullname,Wittness1,Wittness2,WifeAge,HusbandAge,Region,Zone,IssueDate,Cid")] Marriagetbl marriagetbl)
        {
            if (id != marriagetbl.Mnum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marriagetbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarriagetblExists(marriagetbl.Mnum))
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
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", marriagetbl.Cid);
            return View(marriagetbl);
        }

        // GET: MarriageRegistration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marriagetbl = await _context.Marriagetbl
                .Include(m => m.C)
                .FirstOrDefaultAsync(m => m.Mnum == id);
            if (marriagetbl == null)
            {
                return NotFound();
            }

            return View(marriagetbl);
        }

        // POST: MarriageRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marriagetbl = await _context.Marriagetbl.FindAsync(id);
            _context.Marriagetbl.Remove(marriagetbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarriagetblExists(int id)
        {
            return _context.Marriagetbl.Any(e => e.Mnum == id);
        }
    }
}
