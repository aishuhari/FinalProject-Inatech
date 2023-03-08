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
    public class customerController : Controller
    {
        private readonly gokulContext _context;

        public customerController(gokulContext context)
        {
            _context = context;
        }

        // GET: customer
        public async Task<IActionResult> Index()
        {
            var gokulContext = _context.customer.Include(c => c.Order);
            return View(await gokulContext.ToListAsync());
        }

        // GET: customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.customer == null)
            {
                return NotFound();
            }

            var customer = await _context.customer
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: customer/Create
        public IActionResult Create()
        {
            ViewData["OrderTypeId"] = new SelectList(_context.Set<order>(), "OrderTypeId", "OrderTypeId");
            return View();
        }

        // POST: customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Name,Age,FromAddress,ToAddress,City,Weight,OrderTypeId")] customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderTypeId"] = new SelectList(_context.Set<order>(), "OrderTypeId", "OrderTypeId", customer.OrderTypeId);
            return View(customer);
        }

        // GET: customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.customer == null)
            {
                return NotFound();
            }

            var customer = await _context.customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["OrderTypeId"] = new SelectList(_context.Set<order>(), "OrderTypeId", "OrderTypeId", customer.OrderTypeId);
            return View(customer);
        }

        // POST: customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Name,Age,FromAddress,ToAddress,City,Weight,OrderTypeId")] customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!customerExists(customer.CustomerId))
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
            ViewData["OrderTypeId"] = new SelectList(_context.Set<order>(), "OrderTypeId", "OrderTypeId", customer.OrderTypeId);
            return View(customer);
        }

        // GET: customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.customer == null)
            {
                return NotFound();
            }

            var customer = await _context.customer
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.customer == null)
            {
                return Problem("Entity set 'gokulContext.customer'  is null.");
            }
            var customer = await _context.customer.FindAsync(id);
            if (customer != null)
            {
                _context.customer.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool customerExists(int id)
        {
          return (_context.customer?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> detail1()

        {
            return View("Details");
        }
    
}
}
