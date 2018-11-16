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
    public class RolesController : Controller
    {
        private readonly IFURETE_4Context _context;

        public RolesController(IFURETE_4Context context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Role.ToListAsync());
        }

        public async Task<IActionResult> AdminView()
        {
            return View(await _context.Role.ToListAsync());
        }

        [HttpPost]
        public ActionResult EditRole()
        {
            var db = _context;
            var roleID = Request.Form["roleID"];
            var name_of_role = Request.Form["rolename"];
            var material = Request.Form["0"];
            var sites = Request.Form["1"];
            var users = Request.Form["2"];
            var recipient_ui = Request.Form["3"];
            var supplier_limit = Request.Form["4"];
            var booking_ui = Request.Form["5"];
            var report_ui = Request.Form["6"];
            var EAKER_ui = Request.Form["7"];

            var result = db.Role.SingleOrDefault(item => Convert.ToInt32(item.ID) == Convert.ToInt32(roleID));
            if (result != null)
            {
                result.material = Convert.ToInt32(material);
                result.sites = Convert.ToInt32(sites);
                result.users = Convert.ToInt32(users);
                result.recipient_ui = Convert.ToInt32(recipient_ui);
                result.supplier_limit = Convert.ToInt32(supplier_limit);
                result.booking_ui = Convert.ToInt32(booking_ui);
                result.report_ui = Convert.ToInt32(report_ui);
                result.EAKER_ui = Convert.ToInt32(EAKER_ui);
                db.SaveChanges();
            }

            return View();
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Role
                .SingleOrDefaultAsync(m => m.ID == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name_of_role,material,sites,users,recipient_ui,supplier_limit,booking_ui,report_ui,EAKER_ui")] Role role)
        {
            if (ModelState.IsValid)
            {
                _context.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Role.SingleOrDefaultAsync(m => m.ID == id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name_of_role,material,sites,users,recipient_ui,supplier_limit,booking_ui,report_ui,EAKER_ui")] Role role)
        {
            if (id != role.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(role);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.ID))
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
            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Role
                .SingleOrDefaultAsync(m => m.ID == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var role = await _context.Role.SingleOrDefaultAsync(m => m.ID == id);
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return _context.Role.Any(e => e.ID == id);
        }
    }
}
