using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IFURETE2.Models;

namespace IFURETE2.Models
{
    public class IFURETE2Context : DbContext
    {
        public IFURETE2Context (DbContextOptions<IFURETE2Context> options)
            : base(options)
        {
        }

        public DbSet<IFURETE2.Models.User> User { get; set; }

        public DbSet<IFURETE2.Models.Role> Role { get; set; }

        public DbSet<IFURETE2.Models.Users_Roles> Users_Roles { get; set; }

        public DbSet<IFURETE2.Models.Booking> Booking { get; set; }

        public DbSet<IFURETE2.Models.Booking_Delivery> Booking_Delivery { get; set; }

        public DbSet<IFURETE2.Models.Delivery> Delivery { get; set; }

        public DbSet<IFURETE2.Models.Limit> Limit { get; set; }

        public DbSet<IFURETE2.Models.Materials> Materials { get; set; }

        public DbSet<IFURETE2.Models.Site> Site { get; set; }

        public DbSet<IFURETE2.Models.Site_Material> Site_Material { get; set; }

        public DbSet<IFURETE2.Models.User_Limit> User_Limit { get; set; }
    }
}
