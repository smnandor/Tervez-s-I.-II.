using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IFURETE2.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /*
        [HttpPost]
        public ActionResult Report()
        {

            var picked_date = Request.Form["myDate"];
            var Date = DateTime.Parse(picked_date).Date.ToString("yyyyMMdd");


            ViewData["ClickedDate"] = picked_date;



            string query = " SELECT * " +
                           " FROM Booking2 " +
                           " WHERE date = \'" + Date + "\' AND NOT EXISTS ( SELECT * FROM Bookings where Bookings.appointment_id = Booking2.ID) ";


            return View(_context.Booking2.FromSql(query).ToList());
        }

        [HttpPost]
        public ActionResult BookTheAppointment()
        {
            var picked_appointment = Request.Form["myAppointment"];


            var db = _context;
            db.Bookings.Add(new Bookings
            {
                user_id = 1,
                appointment_id = Convert.ToInt32(picked_appointment)
            });
            db.SaveChanges();


            string query = "SELECT * " +
                           "FROM Booking2 " +
                           "WHERE ID = " + picked_appointment;




            return View(_context.Booking2.FromSql(query).ToList());
        }*/

    }
}