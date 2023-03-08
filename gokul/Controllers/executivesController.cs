using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gokul.Data;
using gokul.Models;

namespace gokul.Controllers
{
    public class executivesController : Controller
    {
        private readonly gokulContext _context;

        public executivesController(gokulContext context)
        {
            _context = context;
        }

        // GET: executives
        public async Task<IActionResult> Index()
        {
            var gokulContext = _context.executive.Include(e => e.Order);
            return View(await gokulContext.ToListAsync());
        }

        // GET: executives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.executive == null)
            {
                return NotFound();
            }

            var executive = await _context.executive
                .Include(e => e.Order)
                .FirstOrDefaultAsync(m => m.ExecutiveId == id);
            if (executive == null)
            {
                return NotFound();
            }

            return View(executive);
        }

        // GET: executives/Create
        public IActionResult Create()
        {
            ViewData["OrderTypeId"] = new SelectList(_context.Set<order>(), "OrderTypeId", "OrderTypeId");
            return View();
        }

        // POST: executives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExecutiveId,ExecutiveName,Age,OrderTypeId,PhnNo")] executive executive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(executive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderTypeId"] = new SelectList(_context.Set<order>(), "OrderTypeId", "OrderTypeId", executive.OrderTypeId);
            return View(executive);
        }

        // GET: executives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.executive == null)
            {
                return NotFound();
            }

            var executive = await _context.executive.FindAsync(id);
            if (executive == null)
            {
                return NotFound();
            }
            ViewData["OrderTypeId"] = new SelectList(_context.Set<order>(), "OrderTypeId", "OrderTypeId", executive.OrderTypeId);
            return View(executive);
        }

        // POST: executives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExecutiveId,ExecutiveName,Age,OrderTypeId,PhnNo")] executive executive)
        {
            if (id != executive.ExecutiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(executive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!executiveExists(executive.ExecutiveId))
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
            ViewData["OrderTypeId"] = new SelectList(_context.Set<order>(), "OrderTypeId", "OrderTypeId", executive.OrderTypeId);
            return View(executive);
        }

        // GET: executives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.executive == null)
            {
                return NotFound();
            }

            var executive = await _context.executive
                .Include(e => e.Order)
                .FirstOrDefaultAsync(m => m.ExecutiveId == id);
            if (executive == null)
            {
                return NotFound();
            }

            return View(executive);
        }

        // POST: executives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.executive == null)
            {
                return Problem("Entity set 'gokulContext.executive'  is null.");
            }
            var executive = await _context.executive.FindAsync(id);
            if (executive != null)
            {
                _context.executive.Remove(executive);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool executiveExists(int id)
        {
            return (_context.executive?.Any(e => e.ExecutiveId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> acceptorder()

        {
            return View("acceptorder");
        }
    }
}
