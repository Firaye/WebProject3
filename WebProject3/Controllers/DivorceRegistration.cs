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
    public class DivorceRegistration : Controller
    {
        private readonly OROMIAVITALEVENTContext _context;

        public DivorceRegistration(OROMIAVITALEVENTContext context)
        {
            _context = context;
        }

        // GET: DivorceRegistration
        public async Task<IActionResult> Index()
        {
            var oROMIAVITALEVENTContext = _context.Divorcetbl.Include(d => d.C);
            return View(await oROMIAVITALEVENTContext.ToListAsync());
        }

        // GET: DivorceRegistration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divorcetbl = await _context.Divorcetbl
                .Include(d => d.C)
                .FirstOrDefaultAsync(m => m.Did == id);
            if (divorcetbl == null)
            {
                return NotFound();
            }

            return View(divorcetbl);
        }

        // GET: DivorceRegistration/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname");
            return View();
        }

        // POST: DivorceRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Did,DateofDivorce,DcirtificateNumber,HusbandFullName,WifeFullName,WifeAge,RequesterofDinvorce,IssueDate,Cid")] Divorcetbl divorcetbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(divorcetbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", divorcetbl.Cid);
            return View(divorcetbl);
        }

        // GET: DivorceRegistration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divorcetbl = await _context.Divorcetbl.FindAsync(id);
            if (divorcetbl == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", divorcetbl.Cid);
            return View(divorcetbl);
        }

        // POST: DivorceRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Did,DateofDivorce,DcirtificateNumber,HusbandFullName,WifeFullName,WifeAge,RequesterofDinvorce,IssueDate,Cid")] Divorcetbl divorcetbl)
        {
            if (id != divorcetbl.Did)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divorcetbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivorcetblExists(divorcetbl.Did))
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
            ViewData["Cid"] = new SelectList(_context.Custometbl, "Cid", "Fname", divorcetbl.Cid);
            return View(divorcetbl);
        }

        // GET: DivorceRegistration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divorcetbl = await _context.Divorcetbl
                .Include(d => d.C)
                .FirstOrDefaultAsync(m => m.Did == id);
            if (divorcetbl == null)
            {
                return NotFound();
            }

            return View(divorcetbl);
        }

        // POST: DivorceRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var divorcetbl = await _context.Divorcetbl.FindAsync(id);
            _context.Divorcetbl.Remove(divorcetbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivorcetblExists(int id)
        {
            return _context.Divorcetbl.Any(e => e.Did == id);
        }
    }
}
