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
    public class UsersController : Controller
    {
        private readonly IFURETE_4Context _context;

        public UsersController(IFURETE_4Context context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync() );
        }
        public async Task<IActionResult> DefaultView()
        {
            return View(await _context.User.ToListAsync());
        }
        
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Confirmation()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            var db = _context;
            var result = db.User.SingleOrDefault(item => item.username == username);
            if (result != null)
            {
                if (result.password == password)
                {
                    result.is_logged_in = true;
                    db.SaveChanges();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditUser()
        {
            
            var db = _context;
            var userID = Request.Form["userID"];
            var name = Request.Form["name"];
            var email = Request.Form["email"];
            var phonenumber = Request.Form["phonenumber"];            

            var result = db.User.SingleOrDefault(item => Convert.ToInt32(item.ID) == Convert.ToInt32(userID));
            if (result != null)
            {
                result.name = name;
                result.e_mail = email;
                result.phone_number = phonenumber;
                db.SaveChanges();
            }

            return View();           
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,password,username,phone_number,e_mail,is_confirmed,is_logged_in")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,password,username,phone_number,e_mail,is_confirmed,is_logged_in")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.SingleOrDefaultAsync(m => m.ID == id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.ID == id);
        }
    }
}
