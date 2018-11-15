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
    public class Site_MaterialController : Controller
    {
        private readonly IFURETE2Context _context;

        public Site_MaterialController(IFURETE2Context context)
        {
            _context = context;
        }

        // GET: Site_Material
        public async Task<IActionResult> Index()
        {
            return View(await _context.Site_Material.ToListAsync());
        }

        // GET: Site_Material/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site_Material = await _context.Site_Material
                .SingleOrDefaultAsync(m => m.ID == id);
            if (site_Material == null)
            {
                return NotFound();
            }

            return View(site_Material);
        }

        // GET: Site_Material/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Site_Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,site_id,material_id")] Site_Material site_Material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site_Material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(site_Material);
        }

        // GET: Site_Material/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site_Material = await _context.Site_Material.SingleOrDefaultAsync(m => m.ID == id);
            if (site_Material == null)
            {
                return NotFound();
            }
            return View(site_Material);
        }

        // POST: Site_Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,site_id,material_id")] Site_Material site_Material)
        {
            if (id != site_Material.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site_Material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Site_MaterialExists(site_Material.ID))
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
            return View(site_Material);
        }

        // GET: Site_Material/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site_Material = await _context.Site_Material
                .SingleOrDefaultAsync(m => m.ID == id);
            if (site_Material == null)
            {
                return NotFound();
            }

            return View(site_Material);
        }

        // POST: Site_Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site_Material = await _context.Site_Material.SingleOrDefaultAsync(m => m.ID == id);
            _context.Site_Material.Remove(site_Material);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Site_MaterialExists(int id)
        {
            return _context.Site_Material.Any(e => e.ID == id);
        }
    }
}
