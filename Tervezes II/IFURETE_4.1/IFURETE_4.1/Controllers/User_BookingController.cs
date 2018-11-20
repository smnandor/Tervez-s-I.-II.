using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace IFURETE_4.Controllers
{
    public class User_BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}