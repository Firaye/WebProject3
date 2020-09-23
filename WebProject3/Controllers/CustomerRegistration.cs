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
    public class CustomerRegistration : Controller
    {
        private readonly OROMIAVITALEVENTContext _context;

        public CustomerRegistration(OROMIAVITALEVENTContext context)
        {
            _context = context;
        }

        // GET: CustomerRegistration
        public async Task<IActionResult> Index()
        {
            return View(await _context.Custometbl.ToListAsync());
        }

        // GET: CustomerRegistration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custometbl = await _context.Custometbl
                .FirstOrDefaultAsync(m => m.Cid == id);
            if (custometbl == null)
            {
                return NotFound();
            }

            return View(custometbl);
        }

        // GET: CustomerRegistration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cid,Fname,Lname,Country")] Custometbl custometbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custometbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(custometbl);
        }

        // GET: CustomerRegistration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custometbl = await _context.Custometbl.FindAsync(id);
            if (custometbl == null)
            {
                return NotFound();
            }
            return View(custometbl);
        }

        // POST: CustomerRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cid,Fname,Lname,Country")] Custometbl custometbl)
        {
            if (id != custometbl.Cid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custometbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustometblExists(custometbl.Cid))
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
            return View(custometbl);
        }

        // GET: CustomerRegistration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custometbl = await _context.Custometbl
                .FirstOrDefaultAsync(m => m.Cid == id);
            if (custometbl == null)
            {
                return NotFound();
            }

            return View(custometbl);
        }

        // POST: CustomerRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var custometbl = await _context.Custometbl.FindAsync(id);
            _context.Custometbl.Remove(custometbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustometblExists(int id)
        {
            return _context.Custometbl.Any(e => e.Cid == id);
        }
    }
}
