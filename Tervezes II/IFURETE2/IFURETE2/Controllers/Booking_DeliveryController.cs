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
    public class Booking_DeliveryController : Controller
    {
        private readonly IFURETE2Context _context;

        public Booking_DeliveryController(IFURETE2Context context)
        {
            _context = context;
        }

        // GET: Booking_Delivery
        public async Task<IActionResult> Index()
        {
            return View(await _context.Booking_Delivery.ToListAsync());
        }

        // GET: Booking_Delivery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking_Delivery = await _context.Booking_Delivery
                .SingleOrDefaultAsync(m => m.ID == id);
            if (booking_Delivery == null)
            {
                return NotFound();
            }

            return View(booking_Delivery);
        }

        // GET: Booking_Delivery/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking_Delivery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,booking_id,delivery_id")] Booking_Delivery booking_Delivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking_Delivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking_Delivery);
        }

        // GET: Booking_Delivery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking_Delivery = await _context.Booking_Delivery.SingleOrDefaultAsync(m => m.ID == id);
            if (booking_Delivery == null)
            {
                return NotFound();
            }
            return View(booking_Delivery);
        }

        // POST: Booking_Delivery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,booking_id,delivery_id")] Booking_Delivery booking_Delivery)
        {
            if (id != booking_Delivery.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking_Delivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Booking_DeliveryExists(booking_Delivery.ID))
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
            return View(booking_Delivery);
        }

        // GET: Booking_Delivery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking_Delivery = await _context.Booking_Delivery
                .SingleOrDefaultAsync(m => m.ID == id);
            if (booking_Delivery == null)
            {
                return NotFound();
            }

            return View(booking_Delivery);
        }

        // POST: Booking_Delivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking_Delivery = await _context.Booking_Delivery.SingleOrDefaultAsync(m => m.ID == id);
            _context.Booking_Delivery.Remove(booking_Delivery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Booking_DeliveryExists(int id)
        {
            return _context.Booking_Delivery.Any(e => e.ID == id);
        }
    }
}
