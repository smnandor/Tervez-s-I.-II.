using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IFURETE_4.Controllers;
using IFURETE_4._1.Controllers;
using IFURETE_4.Models;
using IFURETE4.Models;
using IFURETE_4.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;



namespace IFURETE_4.Controllers
{
    public class AdminController: Controller
    {

        private readonly IFURETE_4Context _context;
        public AdminController(IFURETE_4Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Users()
        {
            string query = " SELECT * " +
                           " FROM User";

            return View(_context.User.FromSql(query).ToList()); 
        }

        public IActionResult Sites()
        {
            return View();
        }

        public IActionResult Materials()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

    }
}
