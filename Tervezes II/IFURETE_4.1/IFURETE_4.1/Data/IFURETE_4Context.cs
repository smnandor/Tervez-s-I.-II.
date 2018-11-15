using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IFURETE4.Models;

namespace IFURETE_4.Models
{
    public class IFURETE_4Context : DbContext
    {
        public IFURETE_4Context (DbContextOptions<IFURETE_4Context> options)
            : base(options)
        {
        }

        public DbSet<IFURETE4.Models.Booking> Booking { get; set; }

        public DbSet<IFURETE4.Models.Booking_Delivery> Booking_Delivery { get; set; }

        public DbSet<IFURETE4.Models.Delivery> Delivery { get; set; }

        public DbSet<IFURETE4.Models.Limit> Limit { get; set; }

        public DbSet<IFURETE4.Models.Material> Material { get; set; }

        public DbSet<IFURETE4.Models.Role> Role { get; set; }

        public DbSet<IFURETE4.Models.Site> Site { get; set; }

        public DbSet<IFURETE4.Models.Site_Material> Site_Material { get; set; }

        public DbSet<IFURETE4.Models.User> User { get; set; }

        public DbSet<IFURETE4.Models.User_Limit> User_Limit { get; set; }

        public DbSet<IFURETE4.Models.Users_Roles> Users_Roles { get; set; }
    }
}
