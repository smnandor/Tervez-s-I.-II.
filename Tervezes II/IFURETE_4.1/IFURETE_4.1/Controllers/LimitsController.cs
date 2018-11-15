using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IFURETE4.Models;
using IFURETE_4.Models;

namespace IFURETE_4.Controllers
{
    public class LimitsController : Controller
    {
        private readonly IFURETE_4Context _context;

        public LimitsController(IFURETE_4Context context)
        {
            _context = context;
        }

        // GET: Limits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Limit.ToListAsync());
        }

        // GET: Limits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var limit = await _context.Limit
                .SingleOrDefaultAsync(m => m.ID == id);
            if (limit == null)
            {
                return NotFound();
            }

            return View(limit);
        }

        // GET: Limits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Limits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name_of_company,material,limit")] Limit limit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(limit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(limit);
        }

        // GET: Limits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var limit = await _context.Limit.SingleOrDefaultAsync(m => m.ID == id);
            if (limit == null)
            {
                return NotFound();
            }
            return View(limit);
        }

        // POST: Limits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name_of_company,material,limit")] Limit limit)
        {
            if (id != limit.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(limit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LimitExists(limit.ID))
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
            return View(limit);
        }

        // GET: Limits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var limit = await _context.Limit
                .SingleOrDefaultAsync(m => m.ID == id);
            if (limit == null)
            {
                return NotFound();
            }

            return View(limit);
        }

        // POST: Limits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var limit = await _context.Limit.SingleOrDefaultAsync(m => m.ID == id);
            _context.Limit.Remove(limit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LimitExists(int id)
        {
            return _context.Limit.Any(e => e.ID == id);
        }
    }
}
