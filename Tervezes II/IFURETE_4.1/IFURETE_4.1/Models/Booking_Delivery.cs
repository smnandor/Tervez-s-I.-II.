using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFURETE4.Models
{
    public class Booking_Delivery
    {
        public int ID { get; set; }
        public int booking_id { get; set; }
        public int delivery_id { get; set; }
    }
}
