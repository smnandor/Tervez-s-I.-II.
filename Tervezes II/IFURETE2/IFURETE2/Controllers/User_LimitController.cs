using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IFURETE2.Models;

namespace IFURETE2.Controllers
{
    public class User_LimitController : Controller
    {
        private readonly IFURETE2Context _context;

        public User_LimitController(IFURETE2Context context)
        {
            _context = context;
        }

        // GET: User_Limit
        public async Task<IActionResult> Index()
        {
            return View(await _context.User_Limit.ToListAsync());
        }

        // GET: User_Limit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Limit = await _context.User_Limit
                .SingleOrDefaultAsync(m => m.ID == id);
            if (user_Limit == null)
            {
                return NotFound();
            }

            return View(user_Limit);
        }

        // GET: User_Limit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User_Limit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,limit_id")] User_Limit user_Limit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_Limit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user_Limit);
        }

        // GET: User_Limit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Limit = await _context.User_Limit.SingleOrDefaultAsync(m => m.ID == id);
            if (user_Limit == null)
            {
                return NotFound();
            }
            return View(user_Limit);
        }

        // POST: User_Limit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,user_id,limit_id")] User_Limit user_Limit)
        {
            if (id != user_Limit.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_Limit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_LimitExists(user_Limit.ID))
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
            return View(user_Limit);
        }

        // GET: User_Limit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Limit = await _context.User_Limit
                .SingleOrDefaultAsync(m => m.ID == id);
            if (user_Limit == null)
            {
                return NotFound();
            }

            return View(user_Limit);
        }

        // POST: User_Limit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_Limit = await _context.User_Limit.SingleOrDefaultAsync(m => m.ID == id);
            _context.User_Limit.Remove(user_Limit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_LimitExists(int id)
        {
            return _context.User_Limit.Any(e => e.ID == id);
        }
    }
}
