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
    public class SitesController : Controller
    {
        private readonly IFURETE_4Context _context;

        public SitesController(IFURETE_4Context context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Site.ToListAsync());
        }

        public async Task<IActionResult> AdminView()
        {
            return View(await _context.Site.ToListAsync());
        }

        [HttpPost]
        public ActionResult EditSite()
        {
            
            var db = _context;
            var siteID = Request.Form["siteID"];
            var sitename = Request.Form["sitename"];
            var siteaddress = Request.Form["siteaddress"];
            var contactName = Request.Form["contactName"];
            var emailAddress = Request.Form["emailAddress"];
            var phoneNumber = Request.Form["phoneNumber"];
            var openFrom = Request.Form["openFrom"];
            var openTo = Request.Form["openTo"];
            var numberOfTrucks = Request.Form["numberOfTrucks"];

            var result = db.Site.SingleOrDefault(item => Convert.ToInt32(item.ID) == Convert.ToInt32(siteID));
            if (result != null)
            {
                result.Name = sitename;
                result.Address = siteaddress;
                result.NameOfContact = contactName;
                result.EmailAddressOfContact = emailAddress;
                result.PhonenumberOfContact = phoneNumber;
                result.OpenFrom = openFrom;
                result.OpenTo = openTo;
                result.NumberOfTrucks = numberOfTrucks;
                db.SaveChanges();
            }

            return View();
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .SingleOrDefaultAsync(m => m.ID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,NameOfContact,EmailAddressOfContact,PhonenumberOfContact,OpenFrom,OpenTo,NumberOfTrucks")] Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site.SingleOrDefaultAsync(m => m.ID == id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,NameOfContact,EmailAddressOfContact,PhonenumberOfContact,OpenFrom,OpenTo,NumberOfTrucks")] Site site)
        {
            if (id != site.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.ID))
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
            return View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .SingleOrDefaultAsync(m => m.ID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.Site.SingleOrDefaultAsync(m => m.ID == id);
            _context.Site.Remove(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
            return _context.Site.Any(e => e.ID == id);
        }
    }
}
