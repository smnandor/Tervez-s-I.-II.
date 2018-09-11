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
    public class Users_RolesController : Controller
    {
        private readonly IFURETE2Context _context;

        public Users_RolesController(IFURETE2Context context)
        {
            _context = context;
        }

        // GET: Users_Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users_Roles.ToListAsync());
        }

        // GET: Users_Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users_Roles = await _context.Users_Roles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (users_Roles == null)
            {
                return NotFound();
            }

            return View(users_Roles);
        }

        // GET: Users_Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users_Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,user_id,role_id")] Users_Roles users_Roles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users_Roles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(users_Roles);
        }

        // GET: Users_Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users_Roles = await _context.Users_Roles.SingleOrDefaultAsync(m => m.ID == id);
            if (users_Roles == null)
            {
                return NotFound();
            }
            return View(users_Roles);
        }

        // POST: Users_Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,user_id,role_id")] Users_Roles users_Roles)
        {
            if (id != users_Roles.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users_Roles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Users_RolesExists(users_Roles.ID))
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
            return View(users_Roles);
        }

        // GET: Users_Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users_Roles = await _context.Users_Roles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (users_Roles == null)
            {
                return NotFound();
            }

            return View(users_Roles);
        }

        // POST: Users_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users_Roles = await _context.Users_Roles.SingleOrDefaultAsync(m => m.ID == id);
            _context.Users_Roles.Remove(users_Roles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Users_RolesExists(int id)
        {
            return _context.Users_Roles.Any(e => e.ID == id);
        }
    }
}
